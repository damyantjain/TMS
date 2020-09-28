namespace TMS.ViewModel
{
    using Acr.UserDialogs;
    using GalaSoft.MvvmLight;
    using GalaSoft.MvvmLight.Ioc;
    using TMS.Services;

    /// <summary>
    /// Base View Model
    /// </summary>
    /// <seealso cref="GalaSoft.MvvmLight.ViewModelBase" />
    public class BaseViewModel : ViewModelBase
    {

        /// <summary>
        /// The is busy
        /// </summary>
        private bool isBusy;

        public BaseViewModel()
        {
            if (this.Dialogs == null && SimpleIoc.Default.IsRegistered<IUserDialogs>())
            {
                this.Dialogs = SimpleIoc.Default.GetInstance<IUserDialogs>();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is busy.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is busy; otherwise, <c>false</c>.
        /// </value>
        public bool IsBusy
        {
            get
            {
                return this.isBusy;
            }

            set
            {
                Set(nameof(IsBusy), ref this.isBusy, value);
                RaisePropertyChanged(nameof(IsBusy));
            }
        }

        /// <summary>
        /// Gets the dialogs.
        /// </summary>
        /// <value>
        /// The dialogs.
        /// </value>
        public IUserDialogs Dialogs { get; internal set; }

        /// <summary>
        /// Gets the navigation service.
        /// </summary>
        /// <value>
        /// The navigation service.
        /// </value>
        public IPageNavigationService NavigationService => SimpleIoc.Default.GetInstance<IPageNavigationService>();
    }
}
