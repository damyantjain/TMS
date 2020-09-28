namespace TMS.Services
{
    using Microsoft.Toolkit.Parsers.Rss;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using TMS.Model;

    /// <summary>
    /// TMS Service
    /// </summary>
    public interface ITmsService
    {
        /// <summary>
        /// Gets the user portfolio.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        Task<List<Portfolio>> GetUserPortfolio(string name);

        /// <summary>
        /// Posts the portfolio data.
        /// </summary>
        /// <param name="portfolio">The portfolio.</param>
        /// <returns></returns>
        Task PostPortfolioData(PostPortfolio portfolio);

        /// <summary>
        /// Posts the average data.
        /// </summary>
        /// <param name="average">The average.</param>
        /// <param name="userName">Name of the user.</param>
        /// <returns></returns>
        Task PostAverageData(Average average, string userName);

        /// <summary>
        /// Gets the average data.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <returns></returns>
        Task<List<Average>> GetAverageData(string userName);

        /// <summary>
        /// Gets the users.
        /// </summary>
        /// <returns></returns>
        Task<List<User>> GetUser();

        /// <summary>
        /// Gets the specific average data.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="stockName">Name of the stock.</param>
        /// <returns></returns>
        Task<Average> GetSpecificAverageData(string userName, string stockName);

        /// <summary>
        /// Gets the portfolio data.
        /// </summary>
        /// <returns></returns>
        Task<List<Portfolio>> GetPortfolioData();

        /// <summary>
        /// Gets the stocks.
        /// </summary>
        /// <returns></returns>
        Task<List<Stocks>> GetStocks();

        /// <summary>
        /// Posts the name of the stock.
        /// </summary>
        /// <param name="stocks">The stocks.</param>
        /// <returns></returns>
        Task PostStockName(Stocks stocks);

        /// <summary>
        /// Gets the specific total average data.
        /// </summary>
        /// <param name="shareName">Name of the share.</param>
        /// <returns></returns>
        Task<Average> GetSpecificTotalAverageData(string shareName);

        /// <summary>
        /// Gets the portfolio data with key.
        /// </summary>
        /// <returns></returns>
        Task<Dictionary<string, Portfolio>> GetPortfolioDataWithKey();

        /// <summary>
        /// Deletes the portfolio data.
        /// </summary>
        /// <param name="TransactionId">The transaction identifier.</param>
        /// <returns></returns>
        Task DeletePortfolioData(string TransactionId);

        /// <summary>
        /// Deletes the specific share data.
        /// </summary>
        /// <param name="personName">Name of the person.</param>
        /// <param name="shareName">Name of the share.</param>
        /// <returns></returns>
        Task DeleteSpecificShareData(string personName, string shareName);

        /// <summary>
        /// Gets the todays price.
        /// </summary>
        /// <returns></returns>
        Task<List<Market>> GetTodaysPrice();

        /// <summary>
        /// Logs the profit loss.
        /// </summary>
        /// <param name="profitLoss">The profit loss.</param>
        /// <returns></returns>
        Task LogProfitLoss(ProfitLoss profitLoss);

        /// <summary>
        /// Gets the profit loss data.
        /// </summary>
        /// <returns></returns>
        Task<List<ProfitLoss>> GetProfitLossData();

        /// <summary>
        /// Gets the previous balance details.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <returns></returns>
        Task<Balance> GetPreviousBalanceDetails(string userName);

        /// <summary>
        /// Puts the updated balance details.
        /// </summary>
        /// <param name="balance">The balance.</param>
        /// <param name="userName">Name of the user.</param>
        /// <returns></returns>
        Task PutUpdatedBalanceDetails(Balance balance, string userName);

        /// <summary>
        /// Gets the previous balance details total.
        /// </summary>
        /// <returns></returns>
        Task<Balance> GetPreviousBalanceDetailsTotal();

        /// <summary>
        /// Deletes the profit loss.
        /// </summary>
        /// <param name="transactionID">The transaction identifier.</param>
        /// <returns></returns>
        Task DeleteProfitLossData(string transactionID);

        /// <summary>
        /// Parses this instance.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<RssSchema>> Parse();
    }
}
