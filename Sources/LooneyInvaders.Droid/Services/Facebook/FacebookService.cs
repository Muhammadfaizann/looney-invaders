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
        static readonly string LikesCountString = "fan_count";

        private readonly ICallbackManager _callbackManager = CallbackManagerFactory.Create();
        // it's required to pass FB review to use pages_read_engagement
        private readonly string[] _permissions = { "public_profile", "pages_read_engagement"/*, "email" */};
        private readonly Activity _activity;

        private LoginResult _loginResult;
        private TaskCompletionSource<LoginResult> _loginCompletionSource;

        public event EventHandler OnResult;

        public LoginState LoginState { get; set; }

        private FacebookService() { }

        public FacebookService(Activity activity) : this()
        {
            _activity = activity;

            LoginManager.Instance.SetDefaultAudience(DefaultAudience.Everyone)
                                 .SetLoginBehavior(LoginBehavior.WebOnly)
                                 .RegisterCallback(_callbackManager, this);
        }

        public Task<LoginResult> Login()
        {
            _loginCompletionSource = new TaskCompletionSource<LoginResult>();

            LoginManager.Instance.ReauthorizeDataAccess(_activity);
            //ToDo: Pavel - find out what's the difference, which one do we need?
            //LoginManager.Instance.LogInWithPublishPermissions(_activity, _permissions);
            LoginManager.Instance.LogInWithReadPermissions(_activity, _permissions);

            return _loginCompletionSource.Task;
        }

        public void Logout()
        {
            LoginManager.Instance.LogOut();

            OnResult = null;
        }

        public Task<int> CountPageLikes(string pageId) => Task.Run(async () =>
        {
            int likes = -1;
            var likesRequest = $"{pageId}?{LikesCountString}";
            var response = await Task.Run(() => GraphRequest.ExecuteAndWait(new GraphRequest(AccessToken.CurrentAccessToken, likesRequest)));
            if (response != null && response.JSONObject is JSONObject jSON)
            {
                likes = jSON.GetInt(LikesCountString);
            }
            OnResult?.Invoke(this, EventArgs.Empty);

            return likes;
        });

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

        public void OnCompleted(JSONObject data, GraphResponse response) => OnCompleted(response);

        public void OnCompleted(GraphResponse response)
        {
            if (response?.JSONObject == null)
            {
                _loginCompletionSource?.TrySetResult(new LoginResult { LoginState = LoginState.Canceled });
            }
            else
            {
                _loginResult = new LoginResult
                {
                    FirstName = Profile.CurrentProfile?.FirstName ?? "Maxoiduss",
                    LastName = Profile.CurrentProfile?.LastName ?? "Wisemahnn",
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
            OnResult?.Invoke(this, EventArgs.Empty);
        }

        public void OnError(FacebookException exception)
        {
            _loginCompletionSource?.TrySetResult(new LoginResult
            {
                LoginState = LoginState.Failed,
                ErrorString = exception?.Message
            });
            OnResult?.Invoke(this, EventArgs.Empty);
        }

        public async void OnSuccess(Java.Lang.Object result)
        {
            var facebookLoginResult = result.JavaCast<Xamarin.Facebook.Login.LoginResult>();

            if (facebookLoginResult == null) return;

            var parameters = new Bundle();
            parameters.PutString("fields", "id,email,picture.type(large)");

            var request = GraphRequest.NewMeRequest(facebookLoginResult.AccessToken, this);
            request.Parameters = parameters;

            await request.ExecuteAsync().GetAsync();
        }
    }
}