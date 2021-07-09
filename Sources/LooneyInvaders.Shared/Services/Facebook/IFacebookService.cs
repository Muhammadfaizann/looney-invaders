using System.Threading.Tasks;
using LooneyInvaders.Model;
using LooneyInvaders.Model.Facebook;

namespace LooneyInvaders.Services
{
    public interface IFacebookService
    {
        event System.EventHandler OnResult;
        LoginState LoginState { get; set; }
        Task<LoginResult> Login();
        void Logout();
        Task<int> CountPageLikes(string pageId);
        void OpenPage(string pageUrl);
    #if __ANDROID__ //makes sence on Android only
        void OnActivityResult(int requestCode, int resultCode, Android.Content.Intent data);
    #endif
    }
}