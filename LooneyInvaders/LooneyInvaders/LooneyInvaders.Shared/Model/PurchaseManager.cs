using System;
using System.Collections.Generic;
using System.Text;

namespace LooneyInvaders.Model
{
    public class PurchaseManager
    {
        public delegate bool PurchaseDelegate(string productId);

        public static PurchaseDelegate PurchaseHandler;

        public static event EventHandler OnPurchaseFinished;

        public static void ClearEvents()
        {
            OnPurchaseFinished = null;
        }

        public static bool Purchase(string productId)
        {
            if (PurchaseHandler != null) return PurchaseHandler(productId);
            else return false;
        }

        internal static void FireOnPurchaseFinished()
        {
            if (OnPurchaseFinished != null) OnPurchaseFinished(null, EventArgs.Empty);
        }
    }
}
