using System.Threading.Tasks;
using Facebook.CoreKit;
using Facebook.LoginKit;
using Foundation;
using UIKit;
using LooneyInvaders.Model;
using LooneyInvaders.Model.Facebook;
using LooneyInvaders.Services;
using LooneyInvaders.iOS.Extensions;

namespace LooneyInvaders.iOS.Services
{
    public class FacebookService : IFacebookService
    {
        static readonly NSString FanCountNSString = new NSString("fan_count");

        readonly LoginManager _loginManager = new LoginManager();
        // it's required to pass FB review to use pages_read_engagement
        readonly string[] _permissions = { @"public_profile"/*, @"pages_read_engagement"*/ };

        public LoginState LoginState { get; set; }

        private LoginResult _loginResult;
        private TaskCompletionSource<LoginResult> _loginCompletionSource;
        private TaskCompletionSource<int> _likesCompletionSource;

        public event System.EventHandler OnResult;

        public FacebookService()
        {
            _loginManager.DefaultAudience = DefaultAudience.Everyone;
            _loginManager.AuthType = LoginAuthType.Reauthorize;
        }

        public Task<LoginResult> Login()
        {
            var current = this.GetCurrentViewController();
            //_loginManager.ReauthorizeDataAccess(current, new LoginManagerLoginResultBlockHandler(LoginManagerLoginHandler));
            _loginCompletionSource = new TaskCompletionSource<LoginResult>();
            _loginManager.LogIn(_permissions, current, LoginManagerLoginHandler);

            return _loginCompletionSource.Task;
        }

        public void Logout()
        {
            _loginManager.LogOut();

            OnResult = null;
        }

        public Task<int> CountPageLikes(string pageId)
        {
            var likesRequest = new GraphRequest(pageId, new NSDictionary("fields", FanCountNSString.ToString()));
            likesRequest.Start(GetLikesRequestHandler);
            _likesCompletionSource = new TaskCompletionSource<int>();

            return _likesCompletionSource.Task;
        }

        public void OpenPage(string pageUrl) => UIApplication.SharedApplication.OpenUrl(new NSUrl(pageUrl));

        private void LoginManagerLoginHandler(LoginManagerLoginResult result, NSError error)
        {
            if (result != null && result.IsCancelled)
            {
                _loginCompletionSource.TrySetResult(new LoginResult { LoginState = LoginState.Canceled });
                OnResult?.Invoke(this, System.EventArgs.Empty);
            }
            else if (error != null)
            {
                _loginCompletionSource.TrySetResult(new LoginResult { LoginState = LoginState.Failed, ErrorString = error.LocalizedDescription });
                OnResult?.Invoke(this, System.EventArgs.Empty);
            }
            else
            {
                _loginResult = new LoginResult
                {
                    Token = result.Token.TokenString,
                    UserId = result.Token.UserId,
                    LoginState = LoginState.Success
                };
                LoginState = LoginState.Success;

                _loginCompletionSource.TrySetResult(_loginResult);
            }
        }
        
        private void GetLikesRequestHandler(GraphRequestConnection connection, NSObject result, NSError error)
        {
            if (error != null)
            {
                _loginCompletionSource.TrySetResult(new LoginResult { LoginState = LoginState.Failed, ErrorString = error.LocalizedDescription });
                _likesCompletionSource.TrySetResult(-1);
            }
            else
            {
                var likes = result.ValueForKey(FanCountNSString);
                if (int.TryParse(likes.Description, out var likesCount))
                {
                    _likesCompletionSource.TrySetResult(likesCount);
                }
                else _likesCompletionSource.TrySetResult(-1);
            }
            OnResult?.Invoke(this, System.EventArgs.Empty);
        }
    }
}