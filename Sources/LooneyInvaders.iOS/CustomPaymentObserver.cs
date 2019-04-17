using System;
using StoreKit;

namespace CC.Mobile.Purchases
{

    /// <summary>
    /// Acts as a listener for the payments in the StoreKit
    /// Provides an EventHandler where the results are being transmitted in .Net style
    /// </summary>
    internal class CustomPaymentObserver : SKPaymentTransactionObserver
    {
        public event EventHandler<TransactionStatusArgs> TransactionStatusChanged;

        // called when the transaction status is updated
        public override void UpdatedTransactions(SKPaymentQueue queue, SKPaymentTransaction[] transactions)
        {
            foreach (var transaction in transactions)
            {
                switch (transaction.TransactionState)
                {
                    case SKPaymentTransactionState.Purchased:
                        {
                            var args = new TransactionStatusArgs(transaction.TransactionIdentifier, transaction.Payment.ProductIdentifier, TransactionStatus.Purchased);
                            TransactionStatusChanged?.Invoke(this, args);
                            SKPaymentQueue.DefaultQueue.FinishTransaction(transaction);
                            break;
                        }
                    case SKPaymentTransactionState.Failed:
                        {
                            var args = new TransactionStatusArgs(transaction.TransactionIdentifier, transaction.Payment.ProductIdentifier, TransactionStatus.Failed);
                            TransactionStatusChanged?.Invoke(this, args);
                            SKPaymentQueue.DefaultQueue.FinishTransaction(transaction);
                            break;
                        }
                }
            }
        }
    }
}