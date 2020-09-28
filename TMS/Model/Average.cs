namespace TMS.Model
{
    /// <summary>
    /// 
    /// </summary>
    public class Average
    {

        /// <summary>
        /// Gets or sets the name of the share.
        /// </summary>
        /// <value>
        /// The name of the share.
        /// </value>
        public string ShareName { get; set; }

        /// <summary>
        /// Gets or sets the average price.
        /// </summary>
        /// <value>
        /// The average price.
        /// </value>
        public double AveragePrice { get; set; }

        /// <summary>
        /// Gets or sets the quantity.
        /// </summary>
        /// <value>
        /// The quantity.
        /// </value>
        public double Quantity { get; set; }

        /// <summary>
        /// Gets or sets the total price.
        /// </summary>
        /// <value>
        /// The total price.
        /// </value>
        public double TotalPrice { get; set; }
    }
}
