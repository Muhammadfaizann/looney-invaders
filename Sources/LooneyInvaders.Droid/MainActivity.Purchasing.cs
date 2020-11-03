using System;
using System.Threading.Tasks;
using Android.App;
using Android.Hardware;
using CC.Mobile.Purchases;
using Debug = System.Diagnostics.Debug;
using LooneyInvaders.Model;
using LooneyInvaders.Services.App42;

namespace LooneyInvaders.Droid
{
    public partial class MainActivity : Activity, ISensorEventListener, IApp42ServiceInitialization
    {
        private IPurchaseService _svc;

        //In-Game Purchases
        private async void InGamePurchasesAsync()
        {
            try
            {
                _svc = new PurchaseService(ApiKey);

                await _svc.Init(this);
                var svcResume = _svc.Resume();
                if (svcResume != null)
                {
                    await svcResume;
                }
            }
            catch (Exception ex)
            {
                var mess = ex.Message;
                Debug.WriteLine($"Exception detected! In {nameof(InGamePurchasesAsync)}: {ex.StackTrace}");
            }
        }

        private async Task MakePurchase(IProduct product)
        {
            try
            {
                var purchase = await _svc.Purchase(product);

                if (purchase.Status == TransactionStatus.Purchased)
                {
                    if (product.ProductId == "credits_1_mil") Player.Instance.Credits += 1000000;
                    else if (product.ProductId == "credits_300_k") Player.Instance.Credits += 300000;
                    else if (product.ProductId == "credits_100_k") Player.Instance.Credits += 100000;
                    else if (product.ProductId == "ads_off") Settings.Instance.Advertisements = false;

                    PurchaseManager.FireOnPurchaseFinished();
                }
                else
                {
                    Debug.WriteLine("Failed Purchase: Cannot Purchase " + product.ProductId);
                    PurchaseManager.FireOnPurchaseFinished();
                }
            }
            catch (PurchaseError ex)
            {
                Debug.WriteLine($"Error with {product}:{ex.Message}");
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
