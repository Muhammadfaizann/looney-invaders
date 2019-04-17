namespace CC.Mobile.Purchases
{

    /// <summary>
    /// Purchasing result
    /// </summary>
    public class Purchase
    {
        public IProduct Product { get; }
        public string TransactionId { get; }
        public TransactionStatus Status { get; }

        public Purchase(IProduct product, string transactionId, TransactionStatus status)
        {
            Product = product;
            TransactionId = transactionId;
            Status = status;
        }
    }
}
