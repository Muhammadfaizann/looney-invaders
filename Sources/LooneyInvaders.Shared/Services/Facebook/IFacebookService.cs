using System.Threading.Tasks;
using LooneyInvaders.Model.Facebook;

namespace LooneyInvaders.Droid.Services
{
    public interface IFacebookService
    {
        LoginState LoginState { get; set; }
        Task<LoginResult> Login();
        Task<int> CountPageLikes(string pageId);
        void OpenPage(string pageUrl);
    }
}