namespace TMS.ViewModel
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Windows.Input;
    using TMS.Core;
    using TMS.Model;
    using TMS.Services;
    using Xamarin.Forms;
    using MvvmHelpers.Commands;
    using Acr.UserDialogs;
    using MoreLinq;

    /// <summary>
    /// Landing Page VIew Model
    /// </summary>
    /// <seealso cref="TMS.ViewModel.BaseViewModel" />
    public class LandingPageViewModel : BaseViewModel
    {
        /// <summary>
        /// The portfolio table
        /// </summary>
        private ObservableCollection<Portfolio> portfolioTable;

        /// <summary>
        /// The menu list
        /// </summary>
        private ObservableCollection<string> menuList;

        /// <summary>
        /// The average table
        /// </summary>
        private ObservableCollection<Average> averageTable;

        /// <summary>
        /// The share name list
        /// </summary>
        private ObservableCollection<Stocks> shareNameList;

        /// <summary>
        /// The transaction history list
        /// </summary>
        private ObservableCollection<Portfolio> transactionHistoryList;

        /// <summary>
        /// The transaction history duplicate list
        /// </summary>
        private ObservableCollection<Portfolio> transactionHistoryDuplicateList;

        /// <summary>
        /// The market list
        /// </summary>
        private ObservableCollection<Market> marketList;

        /// <summary>
        /// The profi loss list
        /// </summary>
        private ObservableCollection<ProfitLoss> profiLossList;

        /// <summary>
        /// The temporary market list
        /// </summary>
        private ObservableCollection<Market> tempMarketList;

        /// <summary>
        /// The buy pressed
        /// </summary>
        private bool buyPressed;

        /// <summary>
        /// The is validation message visible
        /// </summary>
        private bool isValidationMessageVisible;

        /// <summary>
        /// The buy sell page
        /// </summary>
        private bool buySellPage;

        /// <summary>
        /// The data shown
        /// </summary>
        private bool dataShown;
        /// <summary>
        /// The sell pressed
        /// </summary>
        private bool sellPressed;

        /// <summary>
        /// The is balance editable
        /// </summary>
        private bool isBalanceEditable;

        /// <summary>
        /// The is balance label visible
        /// </summary>
        private bool isBalanceLabelVisible;

        /// <summary>
        /// The selected name value
        /// </summary>
        private string selectedNameValue;

        /// <summary>
        /// The buy sell name selected value
        /// </summary>
        private string buySellNameSelectedValue;

        /// <summary>
        /// The share name selected item
        /// </summary>
        private string shareNameSelectedItem;


        /// <summary>
        /// The share name
        /// </summary>
        private string shareName;

        /// <summary>
        /// The validation message
        /// </summary>
        private string validationMessage;

        /// <summary>
        /// The buy price
        /// </summary>
        private double price;

        /// <summary>
        /// The buy quantity
        /// </summary>
        private double quantity;

        /// <summary>
        /// The net worth
        /// </summary>
        private double netWorth;

        /// <summary>
        /// The balance
        /// </summary>
        private double balance;

        /// <summary>
        /// The add balance
        /// </summary>
        private double addBalance;

        /// <summary>
        /// The total item market list
        /// </summary>
        private int totalItemMarketList;

        /// <summary>
        /// ITms Service
        /// </summary>
        private readonly ITmsService tmsService;

        /// <summary>
        /// Initializes a new instance of the <see cref="LandingPageViewModel" /> class.
        /// </summary>
        /// <param name="tmsService">The TMS service.</param>
        public LandingPageViewModel(ITmsService tmsService)
        {
            this.tmsService = tmsService;
            InitializeMenu();
            InitializeCommands();
        }

        /// <summary>
        /// Gets or sets the net worth.
        /// </summary>
        /// <value>
        /// The net worth.
        /// </value>
        public double NetWorth
        {
            get
            {
                return this.netWorth;
            }

            set
            {
                Set(nameof(NetWorth), ref this.netWorth, value);
                RaisePropertyChanged(nameof(NetWorth));
            }
        }

        /// <summary>
        /// Gets or sets the balance.
        /// </summary>
        /// <value>
        /// The balance.
        /// </value>
        public double Balance
        {
            get
            {
                return this.balance;
            }

            set
            {
                Set(nameof(Balance), ref this.balance, value);
                RaisePropertyChanged(nameof(Balance));
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [navigate to transaction page].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [navigate to transaction page]; otherwise, <c>false</c>.
        /// </value>
        public bool NavigateToTransactionPage { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is quantity negative.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is quantity negative; otherwise, <c>false</c>.
        /// </value>
        public bool IsBalanceNegative { get; set; }

        /// <summary>
        /// Gets or sets the portfolio table.
        /// </summary>
        /// <value>
        /// The portfolio table.
        /// </value>
        public ObservableCollection<Portfolio> PortfolioTable
        {
            get
            {
                return this.portfolioTable;
            }

            set
            {
                Set(nameof(PortfolioTable), ref this.portfolioTable, value);
                RaisePropertyChanged(nameof(PortfolioTable));
            }
        }


        /// <summary>
        /// Gets or sets the average table.
        /// </summary>
        /// <value>
        /// The average table.
        /// </value>
        public ObservableCollection<Average> AverageTable
        {
            get
            {
                return this.averageTable;
            }

            set
            {
                Set(nameof(AverageTable), ref this.averageTable, value);
                RaisePropertyChanged(nameof(AverageTable));
            }
        }

        /// <summary>
        /// Gets or sets the share name list.
        /// </summary>
        /// <value>
        /// The share name list.
        /// </value>
        public ObservableCollection<Stocks> ShareNameList
        {
            get
            {
                return this.shareNameList;
            }

            set
            {
                Set(nameof(ShareNameList), ref this.shareNameList, value);
                RaisePropertyChanged(nameof(ShareNameList));
            }
        }

        /// <summary>
        /// Gets or sets the transaction history list.
        /// </summary>
        /// <value>
        /// The transaction history list.
        /// </value>
        public ObservableCollection<Portfolio> TransactionHistoryList
        {
            get
            {
                return this.transactionHistoryList;
            }

            set
            {
                Set(nameof(TransactionHistoryList), ref this.transactionHistoryList, value);
                RaisePropertyChanged(nameof(TransactionHistoryList));
            }
        }
        public ObservableCollection<Portfolio> TransactionHistoryDuplicateList
        {
            get
            {
                return this.transactionHistoryDuplicateList;
            }

            set
            {
                Set(nameof(TransactionHistoryDuplicateList), ref this.transactionHistoryDuplicateList, value);
                RaisePropertyChanged(nameof(TransactionHistoryDuplicateList));
            }
        }

        /// <summary>
        /// Gets or sets the market list.
        /// </summary>
        /// <value>
        /// The market list.
        /// </value>
        public ObservableCollection<Market> MarketList
        {
            get
            {
                return this.marketList;
            }

            set
            {
                Set(nameof(MarketList), ref this.marketList, value);
                RaisePropertyChanged(nameof(MarketList));
            }
        }

        /// <summary>
        /// Gets or sets the profi loss list.
        /// </summary>
        /// <value>
        /// The profi loss list.
        /// </value>
        public ObservableCollection<ProfitLoss> ProfitLossList
        {
            get
            {
                return this.profiLossList;
            }

            set
            {
                Set(nameof(ProfitLossList), ref this.profiLossList, value);
                RaisePropertyChanged(nameof(ProfitLossList));
            }
        }

        /// <summary>
        /// Gets or sets the menu list.
        /// </summary>
        /// <value>
        /// The menu list.
        /// </value>
        public ObservableCollection<string> MenuList
        {
            get
            {
                return this.menuList;
            }

            set
            {
                Set(nameof(MenuList), ref this.menuList, value);
                RaisePropertyChanged(nameof(MenuList));
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [buy pressed].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [buy pressed]; otherwise, <c>false</c>.
        /// </value>
        public bool BuyPressed
        {
            get
            {
                return this.buyPressed;
            }

            set
            {
                Set(nameof(BuyPressed), ref this.buyPressed, value);
                RaisePropertyChanged(nameof(BuyPressed));
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is balance editable.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is balance editable; otherwise, <c>false</c>.
        /// </value>
        public bool IsBalanceEditable
        {
            get
            {
                return this.isBalanceEditable;
            }

            set
            {
                Set(nameof(IsBalanceEditable), ref this.isBalanceEditable, value);
                RaisePropertyChanged(nameof(IsBalanceEditable));
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is balance label visible.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is balance label visible; otherwise, <c>false</c>.
        /// </value>
        public bool IsBalanceLabelVisible
        {
            get
            {
                return this.isBalanceLabelVisible;
            }

            set
            {
                Set(nameof(IsBalanceLabelVisible), ref this.isBalanceLabelVisible, value);
                RaisePropertyChanged(nameof(IsBalanceLabelVisible));
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is validation message visible.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is validation message visible; otherwise, <c>false</c>.
        /// </value>
        public bool IsValidationMessageVisible
        {
            get
            {
                return this.isValidationMessageVisible;
            }

            set
            {
                Set(nameof(IsValidationMessageVisible), ref this.isValidationMessageVisible, value);
                RaisePropertyChanged(nameof(IsValidationMessageVisible));
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [buy sell page].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [buy sell page]; otherwise, <c>false</c>.
        /// </value>
        public bool BuySellPage
        {
            get
            {
                return this.buySellPage;
            }

            set
            {
                Set(nameof(BuySellPage), ref this.buySellPage, value);
                RaisePropertyChanged(nameof(BuySellPage));
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [sell pressed].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [sell pressed]; otherwise, <c>false</c>.
        /// </value>
        public bool SellPressed
        {
            get
            {
                return this.sellPressed;
            }

            set
            {
                Set(nameof(SellPressed), ref this.sellPressed, value);
                RaisePropertyChanged(nameof(SellPressed));
            }
        }

        /// <summary>
        /// Gets or sets the selected name value.
        /// </summary>
        /// <value>
        /// The selected name value.
        /// </value>
        public string SelectedNameValue
        {
            get
            {
                return this.selectedNameValue;
            }

            set
            {
                Set(nameof(SelectedNameValue), ref this.selectedNameValue, value);
                RaisePropertyChanged(nameof(SelectedNameValue));
            }
        }

        /// <summary>
        /// Gets or sets the buy sell name selected value.
        /// </summary>
        /// <value>
        /// The buy sell name selected value.
        /// </value>
        public string BuySellNameSelectedValue
        {
            get
            {
                return this.buySellNameSelectedValue;
            }

            set
            {
                Set(nameof(BuySellNameSelectedValue), ref this.buySellNameSelectedValue, value);
                RaisePropertyChanged(nameof(BuySellNameSelectedValue));
            }
        }

        /// <summary>
        /// Gets or sets the share name selected item.
        /// </summary>
        /// <value>
        /// The share name selected item.
        /// </value>
        public string ShareNameSelectedItem
        {
            get
            {
                return this.shareNameSelectedItem;
            }

            set
            {
                Set(nameof(ShareNameSelectedItem), ref this.shareNameSelectedItem, value);
                RaisePropertyChanged(nameof(ShareNameSelectedItem));
            }
        }


        /// <summary>
        /// Gets or sets a value indicating whether [data shown].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [data shown]; otherwise, <c>false</c>.
        /// </value>
        public bool DataShown
        {
            get
            {
                return this.dataShown;
            }

            set
            {
                Set(nameof(DataShown), ref this.dataShown, value);
                RaisePropertyChanged(nameof(DataShown));
            }
        }


        /// <summary>
        /// Gets or sets the name of the share.
        /// </summary>
        /// <value>
        /// The name of the share.
        /// </value>
        public string ShareName
        {
            get
            {
                return this.shareName;
            }

            set
            {
                Set(nameof(ShareName), ref this.shareName, value);
                RaisePropertyChanged(nameof(ShareName));
            }
        }

        /// <summary>
        /// Gets or sets the validation message.
        /// </summary>
        /// <value>
        /// The validation message.
        /// </value>
        public string ValidationMessage
        {
            get
            {
                return this.validationMessage;
            }

            set
            {
                Set(nameof(ValidationMessage), ref this.validationMessage, value);
                RaisePropertyChanged(nameof(ValidationMessage));
            }
        }

        /// <summary>
        /// Gets or sets the buy price.
        /// </summary>
        /// <value>
        /// The buy price.
        /// </value>
        public double Price
        {
            get
            {
                return this.price;
            }

            set
            {
                Set(nameof(Price), ref this.price, value);
                RaisePropertyChanged(nameof(Price));
            }
        }

        /// <summary>
        /// Gets or sets the add balance.
        /// </summary>
        /// <value>
        /// The add balance.
        /// </value>
        public double AddBalance
        {
            get
            {
                return this.addBalance;
            }

            set
            {
                Set(nameof(AddBalance), ref this.addBalance, value);
                RaisePropertyChanged(nameof(AddBalance));
            }
        }

        /// <summary>
        /// Gets or sets the refresh portfolio data command.
        /// </summary>
        /// <value>
        /// The refresh portfolio data command.
        /// </value>
        public ICommand RefreshPortfolioDataCommand { get; set; }

        /// <summary>
        /// Gets or sets the load more market list command.
        /// </summary>
        /// <value>
        /// The load more market list command.
        /// </value>
        public ICommand LoadMoreMarketListCommand { get; set; }

        /// <summary>
        /// Gets or sets the update balance command.
        /// </summary>
        /// <value>
        /// The update balance command.
        /// </value>
        public ICommand UpdateBalanceCommand { get; set; }

        /// <summary>
        /// Gets or sets the buy quantity.
        /// </summary>
        /// <value>
        /// The buy quantity.
        /// </value>
        public double Quantity
        {
            get
            {
                return this.quantity;
            }

            set
            {
                Set(nameof(Quantity), ref this.quantity, value);
                RaisePropertyChanged(nameof(Quantity));
            }
        }

        /// <summary>
        /// Refreshes the portfolio data.
        /// </summary>
        public async Task RefreshPortfolioData()
        {
            if (!string.IsNullOrEmpty(SelectedNameValue))
                await GetUserAverageData(SelectedNameValue);
            else
                await GetUserAverageData("Total");
        }

        /// <summary>
        /// Gets the stock name list.
        /// </summary>
        public async Task GetStockNameList()
        {
            var result = await tmsService.GetStocks();
            if (result != null && result.Any())
                ShareNameList = new ObservableCollection<Stocks>(result);
            else
                ShareNameList = new ObservableCollection<Stocks>();
        }

        /// <summary>
        /// Gets thr users portfolio
        /// </summary>
        /// <param name="name">The name.</param>
        public async Task GetUserAverageData(string name)
        {
            this.IsBusy = true;
            SetLandingPageView();
            var avgResult = await tmsService.GetAverageData(name);
            if (avgResult != null)
            {
                AverageTable = null;
                AverageTable = new ObservableCollection<Average>(avgResult);
                NetWorth = AverageTable.Sum(x => x.TotalPrice);
                Balance balanceDetails;
                if (name == "Total")
                {
                    balanceDetails = await tmsService.GetPreviousBalanceDetailsTotal();
                }
                else
                {
                    balanceDetails = await tmsService.GetPreviousBalanceDetails(name);
                }
                if (balanceDetails != null)
                    Balance = balanceDetails.TotalBalance - NetWorth;
                else
                    Balance = 0;
            }
            this.IsBusy = false;
        }

        /// <summary>
        /// Sets the landing page view.
        /// </summary>
        private void SetLandingPageView()
        {
            if (!DataShown)
            {
                BuySellPage = false;
                DataShown = true;
                SellPressed = false;
                BuyPressed = false;
            }
        }

        /// <summary>
        /// Buys the stock.
        /// </summary>
        /// <param name="selectedUser">The selected user.</param>
        public async Task BuyStock(object selectedUser, DateTime dateTime)
        {
            IsValidationMessageVisible = false;
            this.IsBusy = true;

            var basePrice = Quantity * Price;
            var commission = CalculateCommission(basePrice);
            var newPrice = basePrice + commission;
            var transactionId = Guid.NewGuid();
            var portfolio = new PostPortfolio()
            {
                TransactionId = transactionId,
                Date = dateTime.ToString(),
                Price = Price,
                Company = ShareName.ToUpper(),
                Quantity = Quantity,
                Name = selectedUser.ToString(),
                TransactionType = Constants.Buy, 
                Total = newPrice
            };
            await tmsService.PostPortfolioData(portfolio);
            await UpdateStockDB();
            await CalculateBuyAverage(selectedUser, newPrice, transactionId);
            ResetValue();
            this.IsBusy = false;
        }

        /// <summary>
        /// Sells the stock.
        /// </summary>
        /// <param name="selectedUser">The selected user.</param>
        public async Task SellStock(object selectedUser, DateTime dateTime)
        {
            IsValidationMessageVisible = false;
            this.IsBusy = true;
            var basePrice = Quantity * Price;
            var commission = CalculateCommission(basePrice);
            var newPrice = basePrice - commission;
            var transactionId = Guid.NewGuid();
            var portfolio = new PostPortfolio()
            {
                TransactionId = transactionId,
                Date = dateTime.ToString(),
                Price = Price,
                Company = ShareName.ToUpper(),
                Quantity = Quantity,
                Name = selectedUser.ToString(),
                TransactionType = Constants.Sell, 
                Total = newPrice
            };
            await CalculateSellAverage(selectedUser, newPrice, transactionId);
            if (!IsBalanceNegative)
            {
                await tmsService.PostPortfolioData(portfolio);
                await UpdateStockDB();
                ResetValue();
            }
            else
            {
                this.IsBusy = false;
                UserDialogs.Instance.Alert("Selling quantity is more than available quantity.", okText: "OK");
            }            
            this.IsBusy = false;
        }

        /// <summary>
        /// Updates the stock database.
        /// </summary>
        private async Task UpdateStockDB()
        {
            if (ShareNameList.FirstOrDefault(x => x.StockName.Equals(ShareName.ToUpper())) == null)
            {
                var stock = new Stocks() { StockName = ShareName.ToUpper() };
                await tmsService.PostStockName(stock);
                await GetStockNameList();
            }
        }

        /// <summary>
        /// Resets the value.
        /// </summary>
        private void ResetValue()
        {
            Price = 0;
            ShareName = null;
            Quantity = 0;
        }

        /// <summary>
        /// Calculates the buy average.
        /// </summary>
        /// <param name="selectedUser">The selected user.</param>
        /// <param name="newPrice">The new price.</param>
        public async Task CalculateBuyAverage(object selectedUser, double newPrice, Guid transactionId)
        {
            var newQuantity = Quantity;
            var postAvg = await PostCalculatedAverage(selectedUser, newPrice, newQuantity, 1, transactionId);
            
                var shareSpecificTotalAvg = await tmsService.GetSpecificAverageData("Total", ShareName.ToUpper());
                await CalculateSpecificAverage(shareSpecificTotalAvg, postAvg, 1, newPrice);
                await tmsService.PostAverageData(postAvg, selectedUser.ToString());
                SelectedNameValue = selectedUser.ToString();
                await GetUserAverageData(selectedUser.ToString());            
        }

        /// <summary>
        /// Calculates the sell average.
        /// </summary>
        /// <param name="selectedUser">The selected user.</param>
        /// <param name="newPrice">The new price.</param>
        public async Task CalculateSellAverage(object selectedUser, double newPrice, Guid transactionId)
        {   
            var newQuantity = -Quantity;
            var postAvg = await PostCalculatedAverage(selectedUser, newPrice, newQuantity, -1, transactionId);
            if (!IsBalanceNegative)
            {
                var shareSpecificTotalAvg = await tmsService.GetSpecificAverageData("Total", ShareName.ToUpper());
                await CalculateSpecificAverage(shareSpecificTotalAvg, postAvg, -1, newPrice);
                if (postAvg != null)
                    await tmsService.PostAverageData(postAvg, selectedUser.ToString());
                else
                    await tmsService.DeleteSpecificShareData(selectedUser.ToString(), ShareName.ToUpper());
                SelectedNameValue = selectedUser.ToString();
                await GetUserAverageData(selectedUser.ToString());
            }
        }

        /// <summary>
        /// Updates the average.
        /// </summary>
        /// <param name="portfolioData">The portfolio data.</param>
        public async Task UpdateAverage(Portfolio portfolioData)
        {
            double totalDeletionPrice;
            double newTotalPrice;
            double newQunatity;
            var shareSpecificTotalAvg = await tmsService.GetSpecificAverageData("Total", portfolioData.Company.ToUpper());
            if (shareSpecificTotalAvg != null)
            {
                var deletionBasePrice = portfolioData.Price * portfolioData.Quantity;
                var commission = CalculateCommission(deletionBasePrice);
                if (portfolioData.TransactionType.Equals("Buy"))
                {
                    totalDeletionPrice = deletionBasePrice + commission;
                    newTotalPrice = shareSpecificTotalAvg.TotalPrice - totalDeletionPrice;
                    newQunatity = shareSpecificTotalAvg.Quantity - portfolioData.Quantity;
                }
                else
                {
                    totalDeletionPrice = deletionBasePrice - commission;
                    newTotalPrice = shareSpecificTotalAvg.TotalPrice + totalDeletionPrice;
                    newQunatity = shareSpecificTotalAvg.Quantity + portfolioData.Quantity;
                }
                if (newQunatity != 0)
                {
                    var newAvgPrice = newTotalPrice / newQunatity;
                    var postAvg = new Average()
                    {
                        TotalPrice = newTotalPrice,
                        Quantity = newQunatity,
                        ShareName = portfolioData.Company.ToUpper(),
                        AveragePrice = newAvgPrice
                    };
                    await tmsService.PostAverageData(postAvg, "Total");
                }
                else
                {
                    await tmsService.DeleteSpecificShareData("Total", portfolioData.Company.ToUpper());
                }


                var avgResult = await tmsService.GetSpecificAverageData(portfolioData.Name, portfolioData.Company);
                if (avgResult != null)
                {
                    double specificTotalPrice;
                    double specificQuantity;
                    if (portfolioData.TransactionType.Equals("Buy"))
                    {
                       specificTotalPrice = avgResult.TotalPrice - totalDeletionPrice;
                       specificQuantity = avgResult.Quantity - portfolioData.Quantity;
                    }
                    else
                    {
                        specificTotalPrice = avgResult.TotalPrice + totalDeletionPrice;
                        specificQuantity = avgResult.Quantity + portfolioData.Quantity;
                    }
                    if (specificQuantity != 0)
                    {

                        var specificAvg = specificTotalPrice / specificQuantity;
                        var postSpecifcAvg = new Average()
                        {
                            TotalPrice = specificTotalPrice,
                            Quantity = specificQuantity,
                            ShareName = portfolioData.Company,
                            AveragePrice = specificAvg
                        };
                        await tmsService.PostAverageData(postSpecifcAvg, portfolioData.Name);
                    }
                    else
                    {
                        await tmsService.DeleteSpecificShareData(portfolioData.Name, portfolioData.Company.ToUpper());
                    }
                }
                else
                {
                    await UpdatePreviousData(portfolioData, 0);
                }
            }
            else
            {
                await UpdatePreviousData(portfolioData, 1);
            }
            NavigateToTransactionPage = false;
            await GetTransactionHistory();
        }


        /// <summary>
        /// Updates the previous data.
        /// </summary>
        /// <param name="portfolioData">The portfolio data.</param>
        /// <param name="check">The check.</param>
        private async Task UpdatePreviousData(Portfolio portfolioData, int check)
        {
            await tmsService.DeleteSpecificShareData(portfolioData.Name, portfolioData.Company.ToUpper());
            var updatedPortfolio = await tmsService.GetPortfolioData();
            var result = updatedPortfolio.Where(x => x.Name == portfolioData.Name).Select(x => x).Where(y => y.Company == portfolioData.Company).Select(x => x);
            var totalPrice = result.Sum(x => x.Total);
            var totalQuantity = result.Sum(x => x.Quantity);
            var average = totalPrice / totalQuantity;
            var postAvg = new Average()
            {
                TotalPrice = totalPrice,
                Quantity = totalQuantity,
                ShareName = portfolioData.Company,
                AveragePrice = average
            };
            if (check == 1)
            {
                await tmsService.PostAverageData(postAvg, "Total");
            }

            await tmsService.PostAverageData(postAvg, portfolioData.Name);
            var prevBalance = await tmsService.GetPreviousBalanceDetails(portfolioData.Name);
            double profitLoss;
            profitLoss = portfolioData.Total - totalPrice;
            var balanceDetails = new Balance()
            {
                TotalBalance = prevBalance.TotalBalance - profitLoss
            };
            await tmsService.PutUpdatedBalanceDetails(balanceDetails, portfolioData.Name);

        }

        /// <summary>
        /// Posts the calculated average.
        /// </summary>
        /// <param name="selectedUser">The selected user.</param>
        /// <param name="newPrice">The new price.</param>
        /// <param name="quantity">The quantity.</param>
        /// <param name="multiplier">The multiplier.</param>
        /// <returns></returns>
        public async Task<Average> PostCalculatedAverage(object selectedUser, double newPrice, double quantity, double multiplier, Guid transactionId)
        {
            double totalPrice;
            double totalQuantity;
            double averagePrice;
            IsBalanceNegative = false;

            var avgResult = await tmsService.GetSpecificAverageData(selectedUser.ToString(), ShareName.ToUpper());
            if (avgResult != null)
            {
                var previousAvg = avgResult.AveragePrice;
                var previousQty = avgResult.Quantity;
                var totalPreviousPrice = previousAvg * previousQty;
                totalQuantity = previousQty + quantity;
                if (totalQuantity > 0)
                {
                    if (multiplier == 1)
                        averagePrice = (totalPreviousPrice + newPrice) / totalQuantity;
                    else
                        averagePrice = (totalPreviousPrice - newPrice) / totalQuantity;
                    totalPrice = totalQuantity * averagePrice;
                }
                else if(totalQuantity == 0)
                {
                    var profitLossValue = newPrice - avgResult.TotalPrice;
                    string pLIdentifier;
                    if (profitLossValue > 0)
                        pLIdentifier = "Profit";
                    else if (profitLossValue < 0)
                        pLIdentifier = "Loss";
                    else
                        pLIdentifier = "Even";
                    profitLossValue = Math.Abs(profitLossValue);
                    var postPL = new ProfitLoss()
                    {
                        TransactionId = transactionId,
                        Company = avgResult.ShareName,
                        Date = DateTime.UtcNow.ToString(),
                        Name = selectedUser.ToString(),
                        Price = profitLossValue,
                        ProfitLossIdentifier = pLIdentifier,
                    };
                    await tmsService.LogProfitLoss(postPL);
                    var currentBalance = await tmsService.GetPreviousBalanceDetails(selectedUser.ToString());
                    var balanceDetails = new Balance()
                    {
                        TotalBalance = currentBalance.TotalBalance + (newPrice - avgResult.TotalPrice)
                    };
                    await tmsService.PutUpdatedBalanceDetails(balanceDetails, selectedUser.ToString());
                    return null;
                }
                else
                {
                    IsBalanceNegative = true;
                    return null;
                }
            }
            else
            {
                totalQuantity = quantity;
                totalPrice = newPrice;
                averagePrice = newPrice / totalQuantity;
            }
            var postAvg = new Average()
            {
                TotalPrice = totalPrice,
                Quantity = totalQuantity,
                ShareName = this.ShareName.ToUpper(),
                AveragePrice = averagePrice
            };
            return postAvg;
        }


        /// <summary>
        /// Calculates the commission.
        /// </summary>
        /// <param name="basePrice">The base price.</param>
        /// <returns></returns>
        public double CalculateCommission(double basePrice)
        {
            double commission;
            
            if (basePrice <= 50000)
                commission = 0.6;
            else if (Price >= 50000 && Price < 500000)
                commission = 0.55;
            else if (Price >= 500000 && Price < 2000000)
                commission = 0.5;
            else if (Price >= 2000000 && Price < 10000000)
                commission = 0.45;
            else
                commission = 0.4;

            var dpPrice = 25;
            var commissionPrice = basePrice * commission / 100;
            var seboPrice = basePrice * 0.015 / 100;
            return commissionPrice + seboPrice + dpPrice;
        }

        /// <summary>
        /// Calculates the specific average.
        /// </summary>
        /// <param name="prevAvgData">The previous average data.</param>
        /// <param name="newAvg">The new average.</param>
        /// <param name="multiplier">The multiplier.</param>
        /// <param name="newPrice">The new price.</param>
        private async Task CalculateSpecificAverage(Average prevAvgData, Average newAvg, int multiplier, double newPrice)
        {
            if(prevAvgData != null)
            {
                var finalPrice = multiplier * newPrice;
                double totalQuantity;
                if (multiplier == 1)
                    totalQuantity = prevAvgData.Quantity + Quantity;
                else
                    totalQuantity = prevAvgData.Quantity - Quantity;
                if (totalQuantity != 0)
                {
                    var totalAvg = (prevAvgData.TotalPrice + finalPrice) / totalQuantity;
                    var postAvg = new Average()
                    {
                        TotalPrice = totalQuantity * totalAvg,
                        Quantity = totalQuantity,
                        ShareName = this.ShareName.ToUpper(),
                        AveragePrice = totalAvg
                    };
                    await tmsService.PostAverageData(postAvg, "Total");
                }
                else
                {
                    await tmsService.DeleteSpecificShareData("Total", ShareName.ToUpper());
                }
            }
            else
            {
                await tmsService.PostAverageData(newAvg,"Total");
            }
        }

        /// <summary>
        /// Gets the transaction history.
        /// </summary>
        public async Task GetTransactionHistory()
        {
            this.IsBusy = true;
            var result = await tmsService.GetPortfolioDataWithKey();
            if(result != null && result.Any())
            {   
                var valueList = new List<Portfolio>(result.Values.OrderByDescending(x => DateTime.Parse(x.Date)));
                foreach (var item in valueList)
                {
                    DateTime transactionDate;
                    if(DateTime.TryParse(item.Date, out transactionDate))
                        item.Date = transactionDate.ToString("dd/MM/y");
                    if (item.TransactionType == Constants.Buy)
                    {
                        item.TransactionColor = Color.FromHex("#effcf2");
                        item.TransactionBorderColor = Color.FromHex("#43b75e");
                    }
                    else
                    {
                        item.TransactionColor = Color.FromHex("#ffefef");
                        item.TransactionBorderColor = Color.FromHex("#f93232");
                    }
                }
                TransactionHistoryList = new ObservableCollection<Portfolio>(valueList);
                TransactionHistoryDuplicateList = new ObservableCollection<Portfolio>(valueList);
            }
            else
            {
                TransactionHistoryList = new ObservableCollection<Portfolio>();
                TransactionHistoryDuplicateList = new ObservableCollection<Portfolio>();
            }
            if (NavigateToTransactionPage)
                this.NavigationService.NavigateTo("TransactionHistoryPage");
            this.NavigateToTransactionPage = false;
            this.IsBusy = false;
        }

        /// <summary>
        /// Deletes the portfolio data.
        /// </summary>
        /// <param name="portfolioData">The portfolio data.</param>
        public async Task DeletePortfolioData(Portfolio portfolioData)
        {
            this.IsBusy = true;
            await tmsService.DeletePortfolioData(portfolioData.TransactionId.ToString());
            await UpdateAverage(portfolioData);
            await tmsService.DeleteProfitLossData(portfolioData.TransactionId.ToString());
            this.IsBusy = false;
        }

        /// <summary>
        /// Gets the todays market price.
        /// </summary>
        public async Task GetTodaysMarketPrice()
        {
            this.IsBusy = true;
            var result = await tmsService.GetTodaysPrice();
            totalItemMarketList = result.Count;
            foreach (var item in result)
            {
                item.CompanyName = String.Join(String.Empty, item.CompanyName.Split(new[] { ' ' }).Select(word => word.First()));
            }
            tempMarketList = new ObservableCollection<Market>(result);
            MarketList = new ObservableCollection<Market>(tempMarketList.Take(15));
            this.NavigationService.NavigateTo("MarketPage");
            this.IsBusy = false;
        }
        /// <summary>
        /// Determines whether this instance [can load more market list] the specified argument.
        /// </summary>
        /// <param name="arg">The argument.</param>
        /// <returns>
        ///   <c>true</c> if this instance [can load more market list] the specified argument; otherwise, <c>false</c>.
        /// </returns>
        private bool CanLoadMoreMarketList(object arg)
        {
            if (MarketList.Count >= totalItemMarketList)
                return false;
            return true;
        }

        /// <summary>
        /// Loads the more market list.
        /// </summary>
        /// <param name="obj">The object.</param>
        private void LoadMoreMarketList(object obj)
        {
            var index = MarketList.Count;
            var count = index + 15 >= totalItemMarketList ? totalItemMarketList - index : 15;
            AddProducts(index, count);
        }

        /// <summary>
        /// Adds the products.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <param name="count">The count.</param>
        private void AddProducts(int index, int count)
        {
            for (int i = index; i < index + count; i++)
            {
                MarketList.Add(tempMarketList[i]);
            }
        }

        /// <summary>
        /// Gets the profit loss.
        /// </summary>
        public async Task GetProfitLoss()
        {
            this.IsBusy = true;
            var result = await tmsService.GetProfitLossData();
            foreach (var item in result)
            {
                DateTime transactionDate;
                if (DateTime.TryParse(item.Date, out transactionDate))
                    item.Date = transactionDate.ToString("dd/MM/y");
                if (item.ProfitLossIdentifier == Constants.Profit)
                {
                    item.TransactionColor = Color.FromHex("#effcf2");
                    item.TransactionBorderColor = Color.FromHex("#43b75e");
                }
                else if(item.ProfitLossIdentifier == Constants.Loss)
                {
                    item.TransactionColor = Color.FromHex("#ffefef");
                    item.TransactionBorderColor = Color.FromHex("#f93232");
                }
                else
                {
                    item.TransactionColor = Color.FromHex("#fefbeb");
                    item.TransactionBorderColor = Color.FromHex("#f9d815");
                }
            }
            ProfitLossList = new ObservableCollection<ProfitLoss>(result);
            this.NavigationService.NavigateTo("ProfitLossPage");
            this.IsBusy = false;
        }

        /// <summary>
        /// Updates the balance.
        /// </summary>
        public async Task UpdateBalance()
        {
            if(!string.IsNullOrEmpty(SelectedNameValue) && Double.TryParse(AddBalance.ToString(),out _))
            {
                double totalBalance = AddBalance;
                var previousBalanceDetails = await tmsService.GetPreviousBalanceDetails(SelectedNameValue);
                if(previousBalanceDetails != null)
                {
                    totalBalance += previousBalanceDetails.TotalBalance ;
                }
                var postBalance = new Balance()
                {
                    TotalBalance = totalBalance
                };
                await tmsService.PutUpdatedBalanceDetails(postBalance, SelectedNameValue);
                await RefreshPortfolioData();
            }
        }

        public void SortHistory(string name)
        {
            TransactionHistoryList = null;
            if (name != "All")
            {
                var result = TransactionHistoryDuplicateList.Where(x => x.Name == name).ToList();
                TransactionHistoryList = new ObservableCollection<Portfolio>(result);
            }
            else
            {
                TransactionHistoryList = new ObservableCollection<Portfolio>(TransactionHistoryDuplicateList);
            }
        }

        /// <summary>
        /// Updates the average.
        /// </summary>
        private void InitializeMenu()
        {
            MenuList = new ObservableCollection<string>();
            MenuList.Add("Transaction History");
            MenuList.Add("Today's Price");
            MenuList.Add("Profit/Loss");
        }

        /// <summary>
        /// Initializes the commands.
        /// </summary>
        private void InitializeCommands()
        {
            RefreshPortfolioDataCommand = new AsyncCommand(RefreshPortfolioData);
            LoadMoreMarketListCommand = new MvvmHelpers.Commands.Command<object>(LoadMoreMarketList, CanLoadMoreMarketList);
        }
    }
}
