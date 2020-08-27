using System.Threading.Tasks;
using Facebook.CoreKit;
using Facebook.LoginKit;
using Foundation;
using LooneyInvaders.Model;
using LooneyInvaders.Model.Facebook;
using LooneyInvaders.Services;
using UIKit;

namespace LooneyInvaders.iOS.Services
{
    public class FacebookService : IFacebookService
    {
        static readonly NSString FanCountNSString = new NSString("fan_count");

        readonly LoginManager _loginManager = new LoginManager();
        readonly string[] _permissions = { @"public_profile", @"pages_manage_engagement" };

        public LoginState LoginState { get; set; }

        private LoginResult _loginResult;
        private TaskCompletionSource<LoginResult> _loginCompletionSource;
        private TaskCompletionSource<int> _likesCompletionSource;

        public Task<LoginResult> Login()
        {
            _loginCompletionSource = new TaskCompletionSource<LoginResult>();
            _loginManager.LogIn(_permissions, GetCurrentViewController(), LoginManagerLoginHandler);

            return _loginCompletionSource.Task;
        }

        public void Logout()
        {
            _loginManager.LogOut();
        }

        public Task<int> CountPageLikes(string pageId)
        {
            var likesRequest = new GraphRequest(pageId, new NSDictionary("fields", FanCountNSString.ToString()));
            likesRequest.Start(GetLikesRequestHandler);
            _likesCompletionSource = new TaskCompletionSource<int>();

            return _likesCompletionSource.Task;
        }

        public void OpenPage(string pageUrl)
        {
            UIApplication.SharedApplication.OpenUrl(new NSUrl(pageUrl));
        }

        private void LoginManagerLoginHandler(LoginManagerLoginResult result, NSError error)
        {
            if (result.IsCancelled)
            {
                _loginCompletionSource.TrySetResult(new LoginResult { LoginState = LoginState.Canceled });
            }
            else if (error != null)
            {
                _loginCompletionSource.TrySetResult(new LoginResult { LoginState = LoginState.Failed, ErrorString = error.LocalizedDescription });
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
            }
            else
            {
                var likes = result.ValueForKey(FanCountNSString);
                if (int.TryParse(likes.Description, out var likeCount))
                {
                    _likesCompletionSource.TrySetResult(likeCount);
                }
            }
        }
        
        private static UIViewController GetCurrentViewController()
        {
            var viewController = UIApplication.SharedApplication.KeyWindow.RootViewController;
            while (viewController.PresentedViewController != null)
            {
                viewController = viewController.PresentedViewController;
            }

            return viewController;
        }
    }
}