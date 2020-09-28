namespace TMS.Core
{
    using GalaSoft.MvvmLight.Ioc;
    using TMS.Services;
    using TMS.ViewModel;

    /// <summary>
    /// View Model Locator
    /// </summary>
    public class ViewModelLocator
    {

        /// <summary>
        /// Gets the landing page vm.
        /// </summary>
        /// <value>
        /// The landing page vm.
        /// </value>
        public LandingPageViewModel LandingPageViewModel
        {
            get
            {
                return SimpleIoc.Default.GetInstance<LandingPageViewModel>();
            }
        }

        public IPageNavigationService NavigationService => SimpleIoc.Default.GetInstance<IPageNavigationService>();
    }


}
