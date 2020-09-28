namespace TMS.Views.Pages
{
    using TMS.ViewModel;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MarketPage : ContentPage
    {
        /// <summary>
        /// The landing page view model
        /// </summary>
        private readonly LandingPageViewModel landingPageViewModel;

        public MarketPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            NavigationPage.SetHasBackButton(this, false);
            landingPageViewModel = App.ViewModelLocator.LandingPageViewModel;
            BindingContext = landingPageViewModel;
        }
    }
}