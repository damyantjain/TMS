namespace TMS.Model
{
    using Newtonsoft.Json;

    /// <summary>
    /// Market
    /// </summary>
    public class Market
    {

        /// <summary>
        /// Gets or sets the name of the company.
        /// </summary>
        /// <value>
        /// The name of the company.
        /// </value>
        [JsonProperty("companyName")]
        public string CompanyName { get; set; }

        /// <summary>
        /// Gets or sets the no of transactions.
        /// </summary>
        /// <value>
        /// The no of transactions.
        /// </value>
        [JsonProperty("noOfTransactions")]
        public double NoOfTransactions { get; set; }

        /// <summary>
        /// Gets or sets the maximum price.
        /// </summary>
        /// <value>
        /// The maximum price.
        /// </value>
        [JsonProperty("maxPrice")]
        public double MaxPrice { get; set; }

        /// <summary>
        /// Gets or sets the minimum price.
        /// </summary>
        /// <value>
        /// The minimum price.
        /// </value>
        [JsonProperty("minPrice")]
        public double MinPrice { get; set; }

        /// <summary>
        /// Gets or sets the closing price.
        /// </summary>
        /// <value>
        /// The closing price.
        /// </value>
        [JsonProperty("ClosingPrice")]
        public double ClosingPrice { get; set; }

        /// <summary>
        /// Gets or sets the traded shares.
        /// </summary>
        /// <value>
        /// The traded shares.
        /// </value>
        [JsonProperty("tradedShares")]
        public double TradedShares { get; set; }

        /// <summary>
        /// Gets or sets the amount.
        /// </summary>
        /// <value>
        /// The amount.
        /// </value>
        [JsonProperty("amount")]
        public double Amount { get; set; }

        /// <summary>
        /// Gets or sets the previous closing.
        /// </summary>
        /// <value>
        /// The previous closing.
        /// </value>
        [JsonProperty("previousClosing")]
        public double PreviousClosing { get; set; }

        /// <summary>
        /// Gets or sets the difference.
        /// </summary>
        /// <value>
        /// The difference.
        /// </value>
        [JsonProperty("difference")]
        public double Difference { get; set; }
    }
}
