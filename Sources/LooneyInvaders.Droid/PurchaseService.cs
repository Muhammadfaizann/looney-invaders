using System.Collections.Generic;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using IAB = Xamarin.InAppBilling;

namespace CC.Mobile.Purchases
{
    public class PurchaseService : IPurchaseService
    {
        private readonly string _publicKey;
        private IAB.InAppBillingServiceConnection _inAppSvc;
        private TaskCompletionSource<Purchase> _currentPurchaseTask;
        private TaskCompletionSource<bool> _serviceStatusTask;
        private IProduct _currentProduct;
        private Purchase _currentPurchase;

        /// <summary>
        /// Gets a value indicating whether this <see cref="T:PurchaseExample.Droid.PurchaseService"/> is started.
        /// </summary>
        /// <value><c>true</c> if is started; otherwise, <c>false</c>.</value>
        static object toGetIsStarted = new object();
        static bool _isStarted;
        public bool IsStarted
        {
            get
            {
                lock (toGetIsStarted) { return _isStarted; }
            }
            private set
            {
                lock (toGetIsStarted) { _isStarted = value; }
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:PurchaseExample.Droid.PurchaseService"/> class.
        /// </summary>
        /// <param name="publicKey">Public key.</param>
        public PurchaseService(string publicKey)
        {
            _publicKey = publicKey;
        }

        /// <summary>
        /// Inits the service with an activity;
        /// </summary>
        /// <param name="context">Context.</param>
        public Task<IPurchaseService> Init(object context = null)
        {
            var activity = context as Activity;
            try
            {
                _inAppSvc = new IAB.InAppBillingServiceConnection(activity, _publicKey);
                _inAppSvc.OnConnected += IABServiceConnectionOnConnected;
                _inAppSvc.OnDisconnected += IABServiceConnectionOnDisconnected;
                _inAppSvc.OnInAppBillingError += IABServiceConnectionOnIABError;
            }
            catch (System.Exception ex)
            { var mess = ex.Message; }

            return Task.FromResult(this as IPurchaseService);
        }

        private void IABServiceConnectionOnConnected()
        {
            IsStarted = true;
            _serviceStatusTask?.SetResult(IsStarted);
            _serviceStatusTask = null;
            if (_inAppSvc?.BillingHandler != null)
            {
                _inAppSvc.BillingHandler.OnProductPurchased += OnProductPurchased;
                _inAppSvc.BillingHandler.OnProductPurchasedError += OnProductPurchasedError;
                _inAppSvc.BillingHandler.OnPurchaseConsumed += OnPurchaseConsumed;
                _inAppSvc.BillingHandler.OnPurchaseConsumedError += OnPurchaseConsumedError;
                _inAppSvc.BillingHandler.OnProductPurchasedError += OnProductPurchasedError;
                _inAppSvc.BillingHandler.OnPurchaseFailedValidation += OnPurchaseFailedValidation;
                _inAppSvc.BillingHandler.OnUserCanceled += OnUserCanceled;
            }
        }

        private void IABServiceConnectionOnDisconnected()
        {
            IsStarted = false;
            _serviceStatusTask?.SetResult(IsStarted);
            _serviceStatusTask = null;
            if (_inAppSvc?.BillingHandler != null)
            {
                _inAppSvc.BillingHandler.OnProductPurchased -= OnProductPurchased;
                _inAppSvc.BillingHandler.OnProductPurchasedError -= OnProductPurchasedError;
                _inAppSvc.BillingHandler.OnPurchaseConsumed -= OnPurchaseConsumed;
                _inAppSvc.BillingHandler.OnPurchaseConsumedError -= OnPurchaseConsumedError;
                _inAppSvc.BillingHandler.OnProductPurchasedError -= OnProductPurchasedError;
                _inAppSvc.BillingHandler.OnPurchaseFailedValidation -= OnPurchaseFailedValidation;
                _inAppSvc.BillingHandler.OnUserCanceled -= OnUserCanceled;
            }
        }

        private void IABServiceConnectionOnIABError(IAB.InAppBillingErrorType errorType, string message)
        {
            IsStarted = false;
            _serviceStatusTask?.SetException(new PurchaseError($"{errorType.ToString()}:{message}"));
            _serviceStatusTask = null;
        }

        public Task<bool> Resume()
        {
            return SetObserver();
        }

        public async Task<bool> Pause()
        {
            //in case when there is ongoing purchase the service will not be paused
            if (IsStarted && _currentProduct == null)
            {
                return await UnsetObserver();
            }
            return false;
        }

        public async Task<Purchase> Purchase(IProduct product)
        {
            _currentPurchaseTask = new TaskCompletionSource<Purchase>();
            _currentProduct = product;

            var products = new List<string> { product.ProductId };
            var inAppProducts = _inAppSvc.BillingHandler != null
                ? await _inAppSvc.BillingHandler.QueryInventoryAsync(products, IAB.ItemType.Product)
                : null;
            if (inAppProducts == null || inAppProducts.Count == 0)
            {
                _currentPurchaseTask = null;
                throw new PurchaseError("Product not found");
            }
            _inAppSvc.BillingHandler.BuyProduct(inAppProducts[0]);
            return await _currentPurchaseTask.Task;
        }
        /// <summary>
        /// This method must be invoked in the Activities OnActivityResult
        /// </summary>
        public void HandleActivityResult(int requestCode, Result resultCode, Intent data)
        {
            if (resultCode == Result.Canceled)
            {
                SetResultAndReset(TransactionStatus.Cancelled);
            }
            _inAppSvc.BillingHandler.HandleActivityResult(requestCode, resultCode, data);
        }

        private void OnProductPurchased(int response, IAB.Purchase purchase, string purchaseData, string purchaseSignature)
        {
            _currentPurchase = new Purchase(_currentProduct, purchase.OrderId, TransactionStatus.Purchased);
            _inAppSvc.BillingHandler.ConsumePurchase(purchase);
        }

        private void OnPurchaseFailedValidation(IAB.Purchase purchase, string purchaseData, string purchaseSignature)
        {
            _currentPurchase = new Purchase(_currentProduct, purchase.OrderId, TransactionStatus.Failed);
            SetResultAndReset(_currentPurchase);
        }

        private void OnPurchaseConsumed(string token)
        {
            SetResultAndReset(_currentPurchase);
        }

        private void OnProductPurchasedError(int responseCode, string sku)
        {
            var res = InAppPurchaseResponse.ByCode(responseCode);
            SetErrorAndReset(new PurchaseError($"Cannot Purchase: {res.Description}"));
        }

        private void OnPurchaseConsumedError(int responseCode, string token)
        {
            var res = InAppPurchaseResponse.ByCode(responseCode);
            SetErrorAndReset(new PurchaseError($"Cannot Consume the purchase: {res.Description}"));
        }

        private void OnUserCanceled()
        {
            _currentPurchaseTask.SetCanceled();
            _currentPurchaseTask = null;
        }

        private Task<bool> SetObserver()
        {
            if (!IsStarted && _serviceStatusTask == null)
            {
                _serviceStatusTask = new TaskCompletionSource<bool>();
                _inAppSvc.Connect();
                return _serviceStatusTask?.Task;
            }

            throw new PurchaseError("Another task is already running and must be waited");
        }

        private Task<bool> UnsetObserver()
        {
            if (IsStarted && _serviceStatusTask == null)
            {
                _serviceStatusTask = new TaskCompletionSource<bool>();
                // Attempt to connect to the service
                _inAppSvc.Disconnect();
                return _serviceStatusTask.Task;
            }

            throw new PurchaseError("Another task is already running and must be waited");
        }


        private void SetResultAndReset(TransactionStatus status, string transactionId = null)
        {
            _currentPurchase = new Purchase(_currentProduct, transactionId, TransactionStatus.Cancelled);
            SetResultAndReset(_currentPurchase);
        }

        private void SetErrorAndReset(PurchaseError error)
        {
            _currentPurchaseTask?.SetException(error);
            Reset();
        }

        private void SetResultAndReset(Purchase purchase)
        {
            _currentPurchaseTask?.SetResult(purchase);
            Reset();
        }

        private void Reset()
        {
            _currentProduct = null;
            _currentPurchaseTask = null;
            _currentPurchase = null;
        }

        public void Dispose()
        {
            if (_inAppSvc != null)
            {
                if (_inAppSvc?.BillingHandler != null)
                {
                    _inAppSvc.BillingHandler.OnProductPurchased -= OnProductPurchased;
                    _inAppSvc.BillingHandler.OnProductPurchasedError -= OnProductPurchasedError;
                    _inAppSvc.BillingHandler.OnPurchaseConsumed -= OnPurchaseConsumed;
                    _inAppSvc.BillingHandler.OnPurchaseConsumedError -= OnPurchaseConsumedError;
                    _inAppSvc.BillingHandler.OnProductPurchasedError -= OnProductPurchasedError;
                    _inAppSvc.BillingHandler.OnUserCanceled -= OnUserCanceled;
                }
                _inAppSvc.OnConnected -= IABServiceConnectionOnConnected;
                _inAppSvc.OnDisconnected -= IABServiceConnectionOnDisconnected;
                _inAppSvc.OnInAppBillingError -= IABServiceConnectionOnIABError;
                _inAppSvc.Disconnect();
                _inAppSvc = null;
            }

            _currentProduct = null;
            _currentPurchase = null;
            if (_currentPurchaseTask != null)
                _currentPurchaseTask.SetCanceled();
        }


    }

    public class InAppPurchaseResponse
    {
        public static Dictionary<int, InAppPurchaseResponse> All = new Dictionary<int, InAppPurchaseResponse>
        {
            {0, new InAppPurchaseResponse(0, "Success")},
            {1, new InAppPurchaseResponse(1, "User pressed back or canceled a dialog")},
            {2, new InAppPurchaseResponse(2, "Network connection is down")},
            {3, new InAppPurchaseResponse(3, "Billing API version is not supported for the type requested")},
            {4, new InAppPurchaseResponse(4, "Requested product is not available for purchase")},
            {5, new InAppPurchaseResponse(5, "Invalid arguments provided to the API. This error can also indicate that the application was not correctly signed or properly set up for In-app Billing in Google Play, or does not have the necessary permissions in its manifest")},
            {6, new InAppPurchaseResponse(6, "Fatal error during the API action")},
            {7, new InAppPurchaseResponse(7, "Failure to purchase since item is already owned")},
            {8, new InAppPurchaseResponse(8, "Failure to consume since item is not owned")}
        };

        public int Code { get; set; }
        public string Description { get; set; }

        public static InAppPurchaseResponse ByCode(int code) => All[code];

        public InAppPurchaseResponse(int code, string description = "")
        {
            Code = code;
            Description = description;
        }
    }
}
