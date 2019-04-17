using System;
using System.Threading.Tasks;

namespace LooneyInvaders.Model
{
    public class PurchaseManager
    {
        public delegate Task<bool> PurchaseDelegate(string productId);

        public static PurchaseDelegate PurchaseHandler;

        public static event EventHandler OnPurchaseFinished;

        public static void ClearEvents()
        {
            OnPurchaseFinished = null;
        }

        public static async Task<bool> Purchase(string productId)
        {
            if (PurchaseHandler != null)
                return await PurchaseHandler(productId);
            return false;
        }

        internal static void FireOnPurchaseFinished()
        {
            OnPurchaseFinished?.Invoke(null, EventArgs.Empty);
        }
    }
}
