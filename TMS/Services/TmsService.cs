namespace TMS.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Firebase.Database;
    using Firebase.Database.Query;
    using Microsoft.Toolkit.Parsers.Rss;
    using Newtonsoft.Json;
    using TMS.Core;
    using TMS.Model;

    /// <summary>
    /// TMS Service
    /// </summary>
    /// <seealso cref="TMS.Services.ITmsService" />
    public class TmsService : ITmsService
    {

        /// <summary>
        /// The firebase
        /// </summary>
        private readonly FirebaseClient firebase = new FirebaseClient(Constants.AppConfiguration.FireBaseUrl);

        /// <summary>
        /// Setups the aws connection.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public async Task<List<Portfolio>> GetUserPortfolio(string name)
        {
            return (await firebase
              .Child(Constants.TableNamePortfolio)
              .OnceAsync<Portfolio>()).Select(item => new Portfolio
              {
                  TransactionId = item.Object.TransactionId,
                  Name = item.Object.Name,
                  Date = item.Object.Date,
                  Price = item.Object.Price,
                  Company = item.Object.Company,
                  Quantity = item.Object.Quantity
              }).Where(x => x.Name.Equals(name)).ToList();
        }

        /// <summary>
        /// Posts the portfolio data.
        /// </summary>
        /// <param name="portfolio">The portfolio.</param>
        public async Task PostPortfolioData(PostPortfolio portfolio)
        {
            await firebase
              .Child(Constants.TableNamePortfolio).Child(portfolio.TransactionId.ToString())
              .PutAsync(portfolio);
        }

        /// <summary>
        /// Posts the average data.
        /// </summary>
        /// <param name="average">The average.</param>
        /// <param name="userName">Name of the user.</param>
        public async Task PostAverageData(Average average, string userName)
        {
            await firebase
             .Child(Constants.TableNameAverage).Child(userName).Child(average.ShareName)
             .PutAsync<Average>(average);
        }

        /// <summary>
        /// Gets the average data.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <returns></returns>
        public async Task<List<Average>> GetAverageData(string userName)
        {
            return (await firebase
                     .Child(Constants.TableNameAverage).Child(userName)
                     .OnceAsync<Average>()).Select(item => new Average
                     {
                         TotalPrice = item.Object.TotalPrice,
                         ShareName = item.Object.ShareName,
                         AveragePrice = item.Object.AveragePrice,
                         Quantity = item.Object.Quantity
                     }).ToList();
        }

        /// <summary>
        /// Gets the specific total average data.
        /// </summary>
        /// <param name="shareName">Name of the share.</param>
        /// <returns></returns>
        public async Task<Average> GetSpecificTotalAverageData(string shareName)
        {
            string url = $"{Constants.AppConfiguration.FireBaseUrl}{Constants.TableNameAllAverage}{Constants.ForwardSlash}{shareName}{Constants.DotJson}";
            using (var client = new HttpClient())
            {
                var result = await client.GetStringAsync(url);
                var average = JsonConvert.DeserializeObject<Average>(result);
                return average;
            }
        }

        /// <summary>
        /// Gets the specific average data.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="stockName">Name of the stock.</param>
        /// <returns></returns>
        public async Task<Average> GetSpecificAverageData(string userName, string stockName)
        {
            string url = $"{Constants.AppConfiguration.FireBaseUrl}{Constants.TableNameAverage}{Constants.ForwardSlash}{userName}{Constants.ForwardSlash}{stockName}{Constants.DotJson}";
            using (var client = new HttpClient())
            {
                var result = await client.GetStringAsync(url);
                var average = JsonConvert.DeserializeObject<Average>(result);
                return average;
            }
        }

        /// <summary>
        /// Gets the users.
        /// </summary>
        /// <returns></returns>
        public async Task<List<User>> GetUser()
        {
            return (await firebase
              .Child(Constants.TableNamePersons)
              .OnceAsync<User>()).Select(item => new User
              {
                  Name = item.Object.Name,
                  PersonId = item.Object.PersonId
              }).ToList();
        }

        /// <summary>
        /// Gets the portfolio data.
        /// </summary>
        /// <returns></returns>
        public async Task<List<Portfolio>> GetPortfolioData()
        {
            return (await firebase
              .Child(Constants.TableNamePortfolio)
              .OnceAsync<Portfolio>()).Select(item => new Portfolio
              {
                  TransactionId = item.Object.TransactionId,
                  Name = item.Object.Name,
                  Company = item.Object.Company,
                  Quantity = item.Object.Quantity,
                  Price = item.Object.Price,
                  Date = item.Object.Date,
                  TransactionType = item.Object.TransactionType,
                  Total = item.Object.Total
              }).ToList();
        }

        /// <summary>
        /// Gets the stocks.
        /// </summary>
        /// <returns></returns>
        public async Task<List<Stocks>> GetStocks()
        {
            return (await firebase
              .Child(Constants.TableNameStocks)
              .OnceAsync<Stocks>()).Select(item => new Stocks
              {
                  StockName = item.Object.StockName
              }).ToList();
        }

        /// <summary>
        /// Posts the portfolio data.
        /// </summary>
        /// <param name="stocks">The stocks.</param>
        public async Task PostStockName(Stocks stocks)
        {
            await firebase
              .Child(Constants.TableNameStocks)
              .PostAsync(stocks);
        }

        /// <summary>
        /// Gets the portfolio data with key.
        /// </summary>
        /// <returns></returns>
        public async Task<Dictionary<string,Portfolio>> GetPortfolioDataWithKey()
        {
            string url = $"https://db-tms.firebaseio.com/Portfolio.json";
            using (var client = new HttpClient())
            {
                var result = await client.GetStringAsync(url);
                var average = JsonConvert.DeserializeObject<Dictionary<string,Portfolio>>(result);
                return average;
            }
        }

        /// <summary>
        /// Deletes the portfolio data.
        /// </summary>
        /// <param name="TransactionId">The transaction identifier.</param>
        public async Task DeletePortfolioData(string TransactionId)
        {
            await firebase
              .Child(Constants.TableNamePortfolio).Child(TransactionId)
              .DeleteAsync();
        }

        /// <summary>
        /// Deletes the specific share data.
        /// </summary>
        /// <param name="personName">Name of the person.</param>
        /// <param name="shareName">Name of the share.</param>
        public async Task DeleteSpecificShareData(string personName, string shareName)
        {
            await firebase
              .Child(Constants.TableNameAverage).Child(personName).Child(shareName)
              .DeleteAsync();
        }

        /// <summary>
        /// Gets the todays price.
        /// </summary>
        /// <returns></returns>
        public async Task<List<Market>> GetTodaysPrice()
        {
            var url = "https://nepse-data-api.herokuapp.com/data/todaysprice";
            using (var client = new HttpClient())
            {
                var result = await client.GetStringAsync(url);
                var market = JsonConvert.DeserializeObject<List<Market>>(result);
                return market;
            }
        }

        /// <summary>
        /// Logs the profit loss.
        /// </summary>
        /// <param name="profitLoss">The profit loss.</param>
        public async Task LogProfitLoss(ProfitLoss profitLoss)
        {
            await firebase
              .Child(Constants.TableNameProfitLoss).Child(profitLoss.TransactionId.ToString())
              .PutAsync(profitLoss);
        }

        /// <summary>
        /// Gets the profit loss data.
        /// </summary>
        /// <returns></returns>
        public async Task<List<ProfitLoss>> GetProfitLossData()
        {
            return (await firebase
              .Child(Constants.TableNameProfitLoss)
              .OnceAsync<ProfitLoss>()).Select(item => new ProfitLoss
              {
                  TransactionId = item.Object.TransactionId,
                  Name = item.Object.Name,
                  Company = item.Object.Company,
                  Price = item.Object.Price,
                  Date = item.Object.Date,
                  ProfitLossIdentifier = item.Object.ProfitLossIdentifier
              }).ToList();
        }

        public async Task DeleteProfitLossData(string transactionID)
        {
            await firebase
              .Child(Constants.TableNameProfitLoss).Child(transactionID)
              .DeleteAsync();
        }

        public async Task<Balance> GetPreviousBalanceDetails(string userName)
        {
            string url = $"{Constants.AppConfiguration.FireBaseUrl}{Constants.TableNameBalance}{Constants.ForwardSlash}{userName}{Constants.DotJson}";
            using (var client = new HttpClient())
            {
                var result = await client.GetStringAsync(url);
                var balanceDetails = JsonConvert.DeserializeObject<Balance>(result);
                return balanceDetails;
            }
        }

        public async Task PutUpdatedBalanceDetails(Balance balance, string userName)
        {
            await firebase
             .Child(Constants.TableNameBalance).Child(userName)
             .PutAsync<Balance>(balance);
        }
        
        public async Task<Balance> GetPreviousBalanceDetailsTotal()
        {
            var balanceDetails =  (await firebase
             .Child(Constants.TableNameBalance)
             .OnceAsync<Balance>()).Select(item => new Balance
             {
                 TotalBalance = item.Object.TotalBalance
             }).ToList();
            return new Balance()
            {
                TotalBalance = balanceDetails.Sum(x => x.TotalBalance)
            };
            
        }

        /// <summary>
        /// Parses this instance.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<RssSchema>> Parse()
        {
            var url = "https://excitingnepal.com/feed/";
            string feed = null;

            using (var client = new HttpClient())
            {
                feed = await client.GetStringAsync(url);
            }

            if (feed == null) return new List<RssSchema>();

            var parser = new RssParser();
            var rss = parser.Parse(feed);
            return rss;
        }
    }
}