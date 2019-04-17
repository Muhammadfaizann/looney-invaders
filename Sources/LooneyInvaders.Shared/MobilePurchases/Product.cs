namespace CC.Mobile.Purchases
{

    /// <summary>
    /// Example Implementation of IProduct
    /// </summary>
    public class Product : IProduct
    {
        public string ProductId { get; set; }
        public Product(string productId)
        {
            ProductId = productId;
        }

        public override string ToString()
        {
            return $"Product:{ProductId}";
        }
    }
}
