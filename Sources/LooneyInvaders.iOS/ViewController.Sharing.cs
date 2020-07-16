using System;
using Foundation;
using UIKit;
using LooneyInvaders.Services.App42;

namespace LooneyInvaders.iOS
{
    public partial class ViewController : UIViewController, IApp42ServiceInitialization
    {
        public void ShareOnSocialNetworkHandler(string network, System.IO.Stream stream)
        {
            if (stream == null)
            {
                Console.WriteLine("stream is null");

                return;
            }

            var ms = (System.IO.MemoryStream)stream;

            var data = NSData.FromArray(ms.ToArray());
            var img = UIImage.LoadFromData(data);

            Console.WriteLine($"IMAGE width: {img.Size.Width} height: {img.Size.Height}");

            BeginInvokeOnMainThread(() => { ShareOnSocialNetworkIos(network, img); });
        }

        public void ShareOnSocialNetworkIos(string network, UIImage img)
        {
            var activityVc = new UIActivityViewController(new NSObject[] { img }, null);
            /*
            if (network == "facebook")
            {
                activityVC.ExcludedActivityTypes = new NSString[]
                    {
                        UIActivityType.AddToReadingList,
                        UIActivityType.AirDrop,
                        UIActivityType.AssignToContact,
                        UIActivityType.CopyToPasteboard,
                        UIActivityType.Mail,
                        UIActivityType.Message,
                        UIActivityType.OpenInIBooks,                
                        UIActivityType.PostToFlickr,
                        UIActivityType.PostToTencentWeibo,
                        UIActivityType.PostToTwitter,
                        UIActivityType.PostToVimeo,
                        UIActivityType.PostToWeibo,
                        UIActivityType.Print,
                        UIActivityType.SaveToCameraRoll
                    };
            }
            else if(network == "twitter")
            {
                activityVC.ExcludedActivityTypes = new NSString[]
                    {
                        UIActivityType.AddToReadingList,
                        UIActivityType.AirDrop,
                        UIActivityType.AssignToContact,
                        UIActivityType.CopyToPasteboard,
                        UIActivityType.Mail,
                        UIActivityType.Message,
                        UIActivityType.OpenInIBooks,
                        UIActivityType.PostToFacebook,
                        UIActivityType.PostToFlickr,
                        UIActivityType.PostToTencentWeibo,                
                        UIActivityType.PostToVimeo,
                        UIActivityType.PostToWeibo,
                        UIActivityType.Print,
                        UIActivityType.SaveToCameraRoll
                    };
            }
            */
            if (activityVc.PopoverPresentationController != null)
            {
                activityVc.PopoverPresentationController.SourceView = View;
            }
            PresentViewController(activityVc, true, null);
        }
    }
}
