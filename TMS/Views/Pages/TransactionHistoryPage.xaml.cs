namespace TMS.Views.Pages
{
    using GalaSoft.MvvmLight.Ioc;
    using TMS.Model;
    using TMS.ViewModel;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    /// <summary>
    /// Transaction History Page
    /// </summary>
    /// <seealso cref="Xamarin.Forms.ContentPage" />
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TransactionHistoryPage : ContentPage
    {
        /// <summary>
        /// The landing page view model
        /// </summary>
        private readonly LandingPageViewModel landingPageViewModel;

        /// <summary>
        /// Initializes a new instance of the <see cref="TransactionHistoryPage"/> class.
        /// </summary>
        public TransactionHistoryPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            NavigationPage.SetHasBackButton(this, false);
            landingPageViewModel = SimpleIoc.Default.GetInstance<LandingPageViewModel>();
            BindingContext = landingPageViewModel;
            NamePicker.SelectedValue = "All";
        }

        /// <summary>
        /// Deletes the button clicked.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private async void DeleteButtonClicked(object sender, System.EventArgs e)
        {
            var button = (Button)sender;
            var portfolioData = button.CommandParameter as Portfolio;
            await landingPageViewModel.DeletePortfolioData(portfolioData);
            tramsactionHistoryList.ResetSwipe();
        }

        /// <summary>
        /// Users the selection changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="Syncfusion.XForms.ComboBox.SelectionChangedEventArgs"/> instance containing the event data.</param>
        private void UserSelectionChanged(object sender, Syncfusion.XForms.ComboBox.SelectionChangedEventArgs e)
        {
            landingPageViewModel.SortHistory(NamePicker.SelectedValue.ToString());
        }
    }
}