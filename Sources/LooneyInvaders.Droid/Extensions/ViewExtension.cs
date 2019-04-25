using Android.Views;

namespace LooneyInvaders.Droid.Extensions
{
    public static class ViewExtension
    {
        public static void ChangeVisibility(this View view, ViewStates toState)
        {
            if (view != null)
            {
                view.Visibility = toState;
            }
        }
    }
}
