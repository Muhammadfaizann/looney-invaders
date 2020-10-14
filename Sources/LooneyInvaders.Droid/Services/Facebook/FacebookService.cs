using System;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Org.Json;
using Xamarin.Facebook;
using Xamarin.Facebook.Login;
using LooneyInvaders.Model;
using LooneyInvaders.Services;
using LoginResult = LooneyInvaders.Model.Facebook.LoginResult;

namespace LooneyInvaders.Droid.Services.Facebook
{
    public class FacebookService : Java.Lang.Object, IFacebookService, IFacebookCallback, GraphRequest.IGraphJSONObjectCallback
    {
        static readonly string FanCountString = "fan_count";

        private readonly ICallbackManager _callbackManager = CallbackManagerFactory.Create();
        //ToDo: Pavel - find out what the trick, which permission do we need to pass?
        private readonly string[] _permissions = { /*"publish_actions",*/ "public_profile"/*, "email" */};
        private readonly Activity _activity;

        private LoginResult _loginResult;
        private TaskCompletionSource<LoginResult> _loginCompletionSource;

        public LoginState LoginState { get; set; }

        private FacebookService() { }

        public FacebookService(Activity activity) : this()
        {
            _activity = activity;

            LoginManager.Instance.SetDefaultAudience(DefaultAudience.Everyone);
            LoginManager.Instance.SetLoginBehavior(LoginBehavior.WebOnly);
            LoginManager.Instance.RegisterCallback(_callbackManager, this);
        }

        public Task<LoginResult> Login()
        {
            _loginCompletionSource = new TaskCompletionSource<LoginResult>();
            LoginManager.Instance.LogOut();
            LoginManager.Instance.ReauthorizeDataAccess(_activity);
            //ToDo: Pavel - find out what's the difference, which one do we need?
            //LoginManager.Instance.LogInWithPublishPermissions(_activity, _permissions);
            LoginManager.Instance.LogInWithReadPermissions(_activity, _permissions);

            return _loginCompletionSource.Task;
        }

        public void Logout() => LoginManager.Instance.LogOut();

        public Task<int> CountPageLikes(string pageId)
        {
            var likes = Task.Run(() =>
            {
                int likes = 0;
                var likesRequest = $"{pageId}/{FanCountString}";
                var response = GraphRequest.ExecuteAndWait(new GraphRequest(AccessToken.CurrentAccessToken, likesRequest));
                if (response != null && response.JSONObject is JSONObject jSON)
                {
                    likes = jSON.GetInt(FanCountString);
                }

                return likes;
            });
            
            return likes;
        }

        public void OpenPage(string pageUrl)
        {
            var uri = Android.Net.Uri.Parse(pageUrl);
            var intent = new Intent(Intent.ActionView, uri);
            intent.SetFlags(ActivityFlags.NewTask);

            Application.Context.StartActivity(intent);
        }

        public void OnActivityResult(int requestCode, int resultCode, Intent data)
        {
            _callbackManager?.OnActivityResult(requestCode, resultCode, data);
        }

        public void OnCompleted(JSONObject data, GraphResponse response)
        {
            OnCompleted(response);
        }

        public void OnCompleted(GraphResponse response)
        {
            if (response?.JSONObject == null)
            {
                _loginCompletionSource?.TrySetResult(new LoginResult { LoginState = LoginState.Canceled });
            }
            else
            {
                _loginResult = new LoginResult
                {   //ToDo: place here Looney Invders admin's test user name instead of strings
                    FirstName = Profile.CurrentProfile?.FirstName ?? "ImSexy",
                    LastName = Profile.CurrentProfile?.LastName ?? "AndIKnowIt",
                    Token = AccessToken.CurrentAccessToken.Token,
                    UserId = AccessToken.CurrentAccessToken.UserId,
                    LoginState = LoginState.Success
                };

                _loginCompletionSource?.TrySetResult(_loginResult);
            }
        }

        public void OnCancel()
        {
            _loginCompletionSource?.TrySetResult(new LoginResult {LoginState = LoginState.Canceled});
        }

        public void OnError(FacebookException exception)
        {
            _loginCompletionSource?.TrySetResult(new LoginResult
            {
                LoginState = LoginState.Failed,
                ErrorString = exception?.Message
            });
        }

        public void OnSuccess(Java.Lang.Object result)
        {
            var facebookLoginResult = result.JavaCast<Xamarin.Facebook.Login.LoginResult>();
            if (facebookLoginResult == null)
            { return; }

            var parameters = new Bundle();
            parameters.PutString("fields", "id,email,picture.type(large)");

            var request = GraphRequest.NewMeRequest(facebookLoginResult.AccessToken, this);
            request.Parameters = parameters;
            request.ExecuteAsync();
        }
    }
}