
namespace Financial.Domain.Entities.Payments;

    public enum PaymentMethod
    {
        /// <summary>
        /// Cash payment method.
        /// </summary>
        Cash,

        /// <summary>
        /// Bank transfer payment method.
        /// </summary>
        BankTransfer,

        /// <summary>
        /// Debit card payment method.
        /// </summary>
        DebitCard,

        /// <summary>
        /// Credit card payment method.
        /// </summary>
        CreditCard,

        /// <summary>
        /// Wallet payment method.
        /// </summary>
        Wallet,

        /// <summary>
        /// External provider payment method.
        /// </summary>
        ExternalProvider
    }