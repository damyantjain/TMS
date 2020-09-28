using System;
using Xamarin.Forms;

namespace TMS.Model
{
    /// <summary>
    /// Portfolio
    /// </summary>
    public class Portfolio
    {

        /// <summary>
        /// Gets or sets the transaction identifier.
        /// </summary>
        /// <value>
        /// The transaction identifier.
        /// </value>
        public Guid TransactionId { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the company.
        /// </summary>
        /// <value>
        /// The company.
        /// </value>
        public string Company { get; set; }

        /// <summary>
        /// Gets or sets the quantity.
        /// </summary>
        /// <value>
        /// The quantity.
        /// </value>
        public double Quantity { get; set; }

        /// <summary>
        /// Gets or sets the average price.
        /// </summary>
        /// <value>
        /// The average price.
        /// </value>
        public double Price { get; set; }

        /// <summary>
        /// Gets or sets the date.
        /// </summary>
        /// <value>
        /// The date.
        /// </value>
        public string Date { get; set; }

        /// <summary>
        /// Gets or sets the type of the transaction.
        /// </summary>
        /// <value>
        /// The type of the transaction.
        /// </value>
        public string TransactionType { get; set; }

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

        /// <summary>
        /// Gets or sets the total price.
        /// </summary>
        /// <value>
        /// The total price.
        /// </value>
        public double Total { get; set; }
    }
}
