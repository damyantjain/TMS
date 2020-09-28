namespace TMS
{
    using GalaSoft.MvvmLight.Ioc;
    using Newtonsoft.Json;
    using System.IO;
    using System.Reflection;
    using TMS.Core;
    using TMS.Model;
    using TMS.Services;
    using TMS.ViewModel;
    using TMS.Views.Pages;
    using Xamarin.Forms;

    /// <summary>
    /// App
    /// </summary>
    /// <seealso cref="Xamarin.Forms.Application" />
    public partial class App : Application
    {
        /// <summary>
        /// The view model locator
        /// </summary>
        private static ViewModelLocator _viewModelLocator;

        /// <summary>
        /// Initializes a new instance of the <see cref="App"/> class.
        /// </summary>
        public App()
        {
            Initialize();
            RegisterVM();
            ConfigurePages();
            InitializeComponent();
            MainPage = new NavigationPage(new LandingPage());
        }
                
        /// <summary>
        /// Registers the vm.
        /// </summary>
        private void RegisterVM()
        {
            SimpleIoc.Default.Register<LandingPageViewModel>();
            SimpleIoc.Default.Register<ITmsService,TmsService>();
            SimpleIoc.Default.Register<IPageNavigationService, PageNavigationService>();

        }

        /// <summary>
        /// Configures the pages.
        /// </summary>
        private void ConfigurePages()
        {
            var vml = ViewModelLocator;
            vml.NavigationService.Pages.Clear();
            vml.NavigationService.Pages.Add("TransactionHistoryPage", typeof(TransactionHistoryPage));
            vml.NavigationService.Pages.Add("MarketPage", typeof(MarketPage));
            vml.NavigationService.Pages.Add("ProfitLossPage", typeof(ProfitLossPage));
        }


        /// <summary>
        /// Gets the view model locator.
        /// </summary>
        /// <value>
        /// The view model locator.
        /// </value>
        public static ViewModelLocator ViewModelLocator
        {
            get
            {
                if (_viewModelLocator == null)
                {
                    _viewModelLocator = new ViewModelLocator();
                }

                return _viewModelLocator;
            }
        }

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        private void Initialize()
        {
            var assembly = IntrospectionExtensions.GetTypeInfo(typeof(App)).Assembly;
            Stream stream = assembly.GetManifestResourceStream("TMS.Core.Config.json");
            using (var reader = new StreamReader(stream))
            {
                var json = reader.ReadToEnd();
                Constants.AppConfiguration = JsonConvert.DeserializeObject<AppConfiguration>(json);
            }
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense(Constants.AppConfiguration.SyncfusionKey);
        }

        /// <summary>
        /// Application developers override this method to perform actions when the application starts.
        /// </summary>
        /// <remarks>
        /// To be added.
        /// </remarks>
        protected override void OnStart()
        {
        }

        /// <summary>
        /// Application developers override this method to perform actions when the application enters the sleeping state.
        /// </summary>
        /// <remarks>
        /// To be added.
        /// </remarks>
        protected override void OnSleep()
        {
        }

        /// <summary>
        /// Application developers override this method to perform actions when the application resumes from a sleeping state.
        /// </summary>
        /// <remarks>
        /// To be added.
        /// </remarks>
        protected override void OnResume()
        {
        }
    }
}
