namespace TMS.Views.Popup
{
    using GalaSoft.MvvmLight.Ioc;
    using Rg.Plugins.Popup.Pages;
    using Rg.Plugins.Popup.Services;
    using TMS.ViewModel;
    using Xamarin.Forms.Xaml;

    /// <summary>
    /// Menu Popup
    /// </summary>
    /// <seealso cref="Rg.Plugins.Popup.Pages.PopupPage" />
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPopup : PopupPage
    {
        /// <summary>
        /// The landing page view model
        /// </summary>
        private readonly LandingPageViewModel landingPageViewModel;

        /// <summary>
        /// Initializes a new instance of the <see cref="MenuPopup"/> class.
        /// </summary>
        public MenuPopup()
        {
            InitializeComponent();
            landingPageViewModel = SimpleIoc.Default.GetInstance<LandingPageViewModel>();
            BindingContext = landingPageViewModel;
        }

        /// <summary>
        /// Layouts the children.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        protected override void LayoutChildren(double x, double y, double width, double height)
        {
            var maxHeight = height * 1;
            var maxWidth = width * 0.6;
            base.LayoutChildren(x, y, maxWidth, maxHeight);
        }

        /// <summary>
        /// Handles the SelectionChanged event of the Menu control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="Syncfusion.ListView.XForms.ItemSelectionChangedEventArgs"/> instance containing the event data.</param>
        private async void Menu_SelectionChanged(object sender, Syncfusion.ListView.XForms.ItemSelectionChangedEventArgs e)
        {
            switch(menuListView.SelectedItem)
            {
                case "Transaction History":
                    await PopupNavigation.Instance.PopAsync();
                    landingPageViewModel.NavigateToTransactionPage = true;
                    await landingPageViewModel.GetTransactionHistory();                  
                    break;
                case "Today's Price":
                    await PopupNavigation.Instance.PopAsync();
                    await landingPageViewModel.GetTodaysMarketPrice();
                    break;
                case "Profit/Loss":
                    await PopupNavigation.Instance.PopAsync();
                    await landingPageViewModel.GetProfitLoss();
                    break;
                default:
                    break;
            }
        }
    }
}