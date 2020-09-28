namespace TMS.Core
{
    using TMS.Model;

    public static class Constants
    {
        public static AppConfiguration AppConfiguration { get; set; }

        public const string ForwardSlash = "/";
        public const string DotJson = ".json";
        public const string Buy = "Buy";
        public const string Sell = "Sell";
        public const string Profit = "Profit";
        public const string Loss = "Loss";

        public const string TableNameAverage = "Average";
        public const string TableNamePortfolio = "Portfolio";
        public const string TableNamePersons= "Persons";
        public const string TableNameStocks= "Stocks";
        public const string TableNameAllAverage = "AllAverage";
        public const string TableNameProfitLoss = "ProfitLoss";
        public const string TableNameBalance = "Balance";
        
    }
}
