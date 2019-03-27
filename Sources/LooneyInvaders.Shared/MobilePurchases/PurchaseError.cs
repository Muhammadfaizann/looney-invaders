using System;

namespace CC.Mobile.Purchases
{
 
    /// <summary>
    /// Generic error returned from the IPurchase service implementation
    /// </summary>
    public class PurchaseError : Exception
    {
        public PurchaseError() : base("Purchasing error") { }
        public PurchaseError(string message) : base(message) { }
    }
    
}
