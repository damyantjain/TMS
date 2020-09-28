namespace TMS.Views.Pages
{
    using TMS.ViewModel;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    /// <summary>
    /// Profit/Loss Page
    /// </summary>
    /// <seealso cref="Xamarin.Forms.ContentPage" />
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfitLossPage : ContentPage
    {

        /// <summary>
        /// The landing page view model
        /// </summary>
        private readonly LandingPageViewModel landingPageViewModel;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProfitLossPage"/> class.
        /// </summary>
        public ProfitLossPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            NavigationPage.SetHasBackButton(this, false);
            landingPageViewModel = App.ViewModelLocator.LandingPageViewModel;
            BindingContext = landingPageViewModel;
        }
    }
}