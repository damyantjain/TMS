namespace TMS.Model
{
    using System;
    using Xamarin.Forms;

    /// <summary>
    /// Profit Loss
    /// </summary>
    public class ProfitLoss
    {
        /// <summary>
        /// Gets or sets the transaction identifier.
        /// </summary>
        /// <value>
        /// The transaction identifier.
        /// </value>
        public Guid TransactionId { get; set; }

        /// <summary>
        /// Gets or sets the date.
        /// </summary>
        /// <value>
        /// The date.
        /// </value>
        public string Date { get; set; }

        /// <summary>
        /// Gets or sets the price.
        /// </summary>
        /// <value>
        /// The price.
        /// </value>
        public double Price { get; set; }

        /// <summary>
        /// Gets or sets the company.
        /// </summary>
        /// <value>
        /// The company.
        /// </value>
        public string Company { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the profit loss identifier.
        /// </summary>
        /// <value>
        /// The profit loss identifier.
        /// </value>
        public string ProfitLossIdentifier { get; set; }

        /// <summary>
        /// Gets or sets the color of the transaction.
        /// </summary>
        /// <value>
        /// The color of the transaction.
        /// </value>
        public Color TransactionColor { get; set; }

        /// <summary>
        /// Gets or sets the color of the transaction border.
        /// </summary>
        /// <value>
        /// The color of the transaction border.
        /// </value>
        public Color TransactionBorderColor { get; set; }

    }
}
