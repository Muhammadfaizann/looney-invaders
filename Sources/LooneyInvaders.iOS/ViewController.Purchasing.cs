using System;
using System.Threading.Tasks;
using CC.Mobile.Purchases;
using UIKit;
using LooneyInvaders.Model;
using LooneyInvaders.Services.App42;

namespace LooneyInvaders.iOS
{
    public partial class ViewController : UIViewController, IApp42ServiceInitialization
    {
        private async Task MakePurchase(IProduct product)
        {
            try
            {
                var purchase = await _svc.Purchase(product);
                if (purchase.Status == TransactionStatus.Purchased)
                {
                    //new UIAlertView("Success", $"Just Purchased {product}", null, "OK").Show();
                    if (product.ProductId == "credits_1_mil") Player.Instance.Credits += 1000000;
                    else if (product.ProductId == "credits_300_k") Player.Instance.Credits += 300000;
                    else if (product.ProductId == "credits_100_k") Player.Instance.Credits += 100000;
                    else if (product.ProductId == "ads_off") Settings.Instance.Advertisements = false;

                    PurchaseManager.FireOnPurchaseFinished();
                }
                else
                {
                    Console.WriteLine("Failed Purchase: Cannot Purchase " + product.ProductId);
                    PurchaseManager.FireOnPurchaseFinished();
                }
            }
            catch (PurchaseError)
            {
                Console.WriteLine("Error with {product}:{ex.Message}");
                PurchaseManager.FireOnPurchaseFinished();
            }
        }

        private async Task<bool> PurchaseProduct(string productId)
        {
            await MakePurchase(new Product(productId)).ConfigureAwait(false);

            return true;
        }
    }
}
