using System.IO;
using CocosSharp;

#if (__IOS__)
    using UIKit;
    using Foundation;
#endif
#if (__ANDROID__)

#endif

namespace LooneyInvaders.Model
{
    public static class SocialNetworkShareManager
    {

        public delegate void SocialNetworkShare(string network, Stream stream);
        public static SocialNetworkShare ShareOnSocialNetwork;

        public static void ShareLayer(string network, CCLayer layer)
        {
            var rt = new CCRenderTexture(layer.VisibleBoundsWorldspace.Size, layer.VisibleBoundsWorldspace.Size, CCSurfaceFormat.Color, CCDepthFormat.Depth24Stencil8);
            rt.BeginWithClear(CCColor4B.Transparent);
            layer.Visit();
            rt.End();
            rt.Sprite.Position = layer.VisibleBoundsWorldspace.Center;

            var shareCommand = new CCCustomCommand(() =>
            {
                using (var ms = new MemoryStream())
                {
                    rt.Texture.SaveAsPng(ms, (int)layer.VisibleBoundsWorldspace.Size.Width, (int)layer.VisibleBoundsWorldspace.Size.Height);
                    ShareImage(network, ms);
                }
            });
            layer.Renderer.AddCommand(shareCommand);
        }

        public static void ShareImage(string network, Stream stream)
        {
            ShareOnSocialNetwork?.Invoke(network, stream);
        }


        /*
        
        **** iOS sharing ****

                var img = NSData.FromStream(stream);
                UIActivityViewController activityVC = new UIActivityViewController(new NSObject[] { img }, null);
                if (activityVC.PopoverPresentationController != null)
                    activityVC.PopoverPresentationController.SourceView = UIApplication.SharedApplication.KeyWindow.RootViewController.PresentingViewController.View;
                UIApplication.SharedApplication.KeyWindow.RootViewController.PresentViewController(activityVC, true, null);
        
        */

    }
}