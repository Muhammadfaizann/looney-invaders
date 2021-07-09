using UIKit;

namespace LooneyInvaders.iOS.Extensions
{
    public static class CommonExtension
    {
        public static UIViewController GetCurrentViewController(this object _)
        {
            var viewController = UIApplication.SharedApplication.KeyWindow.RootViewController;

            while (viewController.PresentedViewController != null)
            {
                viewController = viewController.PresentedViewController;
            }

            if (!viewController.IsViewLoaded || viewController.View.Window == null)
            {
                viewController = viewController.ParentViewController;
            }

            return viewController;
        }
    }
}
