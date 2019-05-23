using System.Threading.Tasks;
using StoreKit;

namespace CC.Mobile.Purchases
{
    /// <summary>
    /// Purchase service  implementation for ios.
    /// </summary>
    public class PurchaseService : IPurchaseService
    {
        private CustomPaymentObserver _paymentObserver;
        private TaskCompletionSource<Purchase> _currentPurchaseTask;
        private IProduct _currentProduct;

        public bool IsStarted { get; private set; }

        /// <summary>
        /// The context is not used in the iOS app so id does not need to be supplied
        /// </summary>
        /// <param name="context">Context.</param>
        public Task<IPurchaseService> Init(object context = null)
        {
            return Task.FromResult(this as IPurchaseService);
        }

        /// <summary>
        /// Resumes the service and sets it to operational state
        /// returns the resulting state of the service started=true
        /// </summary>
        public Task<bool> Resume(int timeoutMS = LooneyInvaders.AppConstants.PurchasingTimeoutMS)
        {
            SetObserver();
            IsStarted = true;
            return Task.FromResult(true);
        }

        /// <summary>
        /// Pauses the purchase service
        /// returns the resulting state of the service started=true
        /// in case when there is ongoing purchase the service will not be paused
        /// </summary>
        public Task<bool> Pause(int timeoutMS = LooneyInvaders.AppConstants.PurchasingTimeoutMS)
        {
            //in case when there is ongoing purchase the service will not be paused
            if (IsStarted && _currentProduct == null)
            {
                UnsetObserver();
                IsStarted = false;
            }

            return Task.FromResult(IsStarted);
        }

        /// <summary>
        /// Starts the purchase process
        /// </summary>
        /// <returns>a purchase result containing the transaction 
        /// and it's state along with the product.</returns>
        /// <param name="product">Product.</param>
        public async Task<Purchase> Purchase(IProduct product)
        {
            if (await Resume())
            {
                _currentProduct = product;
                _currentPurchaseTask = new TaskCompletionSource<Purchase>();
                var payment = SKPayment.CreateFrom(product.ProductId);
                SKPaymentQueue.DefaultQueue.AddPayment(payment);
                return await _currentPurchaseTask.Task;
            }

            throw new PurchaseError("Service cannot be started or there is annother active purchase");
        }

        private void SetObserver()
        {
            _paymentObserver = new CustomPaymentObserver();
            SKPaymentQueue.DefaultQueue.AddTransactionObserver(_paymentObserver);
            _paymentObserver.TransactionStatusChanged += OnTransactionStatusChanged;
        }

        private void UnsetObserver()
        {
            SKPaymentQueue.DefaultQueue.RemoveTransactionObserver(_paymentObserver);
            _paymentObserver.TransactionStatusChanged -= OnTransactionStatusChanged;
            _paymentObserver = null;
        }

        private void OnTransactionStatusChanged(object sender, TransactionStatusArgs e)
        {
            if (e.ProductId == _currentProduct?.ProductId)
            {
                if (_currentPurchaseTask == null)
                    throw new PurchaseError("There was no purchase registered in the service");
                var purchase = new Purchase(_currentProduct, e.TransactionId, e.Status);
                _currentPurchaseTask.TrySetResult(purchase);
                _currentPurchaseTask = null;
                _currentProduct = null;
            }

            //else if (e.Status != TransactionStatus.Failed)
            //{
            //    throw new PurchaseError("Got purchase notification for unexpected product");
            //}
        }

        public void Dispose()
        {
            _currentProduct = null;
            if (_currentPurchaseTask != null)
                _currentPurchaseTask.TrySetCanceled();
        }
    }

}