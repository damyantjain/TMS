namespace TMS.Views.Pages
{
    using Rg.Plugins.Popup.Extensions;
    using System;
    using TMS.ViewModel;
    using TMS.Views.Popup;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    /// <summary>
    /// Landing Page
    /// </summary>
    /// <seealso cref="Xamarin.Forms.ContentPage" />
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LandingPage : ContentPage
    {
        /// <summary>
        /// The landing page view model
        /// </summary>
        private readonly LandingPageViewModel landingPageViewModel;

        /// <summary>
        /// Initializes a new instance of the <see cref="LandingPage" /> class.
        /// </summary>
        public LandingPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            NavigationPage.SetHasBackButton(this, false);
            landingPageViewModel = App.ViewModelLocator.LandingPageViewModel;
            BindingContext = landingPageViewModel;
        }

        /// <summary>
        /// When overridden, allows application developers to customize behavior immediately prior to the <see cref="T:Xamarin.Forms.Page" /> becoming visible.
        /// </summary>
        /// <remarks>
        /// To be added.
        /// </remarks>
        protected override void OnAppearing()
        {
            base.OnAppearing();
            Device.BeginInvokeOnMainThread(async () => {
                await landingPageViewModel.GetStockNameList();
                if (NamePicker.SelectedItem == null)
                    await landingPageViewModel.GetUserAverageData("Total");
            });
            landingPageViewModel.BuySellPage = false;
            landingPageViewModel.BuyPressed = false;
            landingPageViewModel.SellPressed = false;
            landingPageViewModel.DataShown = true;
            landingPageViewModel.IsBalanceLabelVisible = true;
            landingPageViewModel.IsBalanceEditable = false;
        }

        /// <summary>
        /// Application developers can override this method to provide behavior when the back button is pressed.
        /// </summary>
        /// <returns>
        /// To be added.
        /// </returns>
        /// <remarks>
        /// To be added.
        /// </remarks>
        protected override bool OnBackButtonPressed()
        {
            base.OnBackButtonPressed();
            if (landingPageViewModel.DataShown)
                return false;
            else
            {
                landingPageViewModel.BuySellPage = false;
                landingPageViewModel.BuyPressed = false;
                landingPageViewModel.SellPressed = false;
                landingPageViewModel.DataShown = true;
                return true;
            }
        }

        /// <summary>
        /// Menus the button clicked.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
        private async void MenuButtonClicked(object sender, System.EventArgs e)
        {
            await Navigation.PushPopupAsync(new MenuPopup());
        }

        /// <summary>
        /// Pluses the button clicked.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
        private void PlusButtonClicked(object sender, System.EventArgs e)
        {
            ClearFields();
            if(landingPageViewModel.SelectedNameValue != null)
                landingPageViewModel.BuySellNameSelectedValue = landingPageViewModel.SelectedNameValue;
            datePicker.Date = DateTime.Now;
            BuyDateLabel.Text = DateTime.Now.ToString("dd/MMM/yyyy");
            landingPageViewModel.BuySellPage = true;
            landingPageViewModel.BuyPressed = true;
            landingPageViewModel.SellPressed = false;
            landingPageViewModel.DataShown = false;
        }

        /// <summary>
        /// Minuses the button clicked.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
        private void MinusButtonClicked(object sender, System.EventArgs e)
        {
            ClearFields();
            if(landingPageViewModel.SelectedNameValue != null)
                landingPageViewModel.BuySellNameSelectedValue = landingPageViewModel.SelectedNameValue;
            datePicker.Date = DateTime.Now;
            BuyDateLabel.Text = DateTime.Now.ToString("dd/MMM/yyyy");
            landingPageViewModel.BuySellPage = true;
            landingPageViewModel.SellPressed = true;
            landingPageViewModel.BuyPressed = false;
            landingPageViewModel.DataShown = false;
        }

        /// <summary>
        /// Clears the fields.
        /// </summary>
        private void ClearFields()
        {
            landingPageViewModel.IsValidationMessageVisible = false;
            BuyPriceLabel.Text = string.Empty;
            BuyShareNameLabel.Text = string.Empty;
            BuyQuantityLabel.Text = string.Empty;
            NameComboBox.SelectedItem = null;
        }

        /// <summary>
        /// Submits the buy clicked.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private async void SubmitBuyClicked(object sender, System.EventArgs e)
        {
            var IsCorrect = ValidateFields();
            if(IsCorrect)
                await landingPageViewModel.BuyStock(NameComboBox.SelectedItem,datePicker.Date);
            else
                landingPageViewModel.IsValidationMessageVisible = true;
        }

        /// <summary>
        /// Submits the sell clicked.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private async void SubmitSellClicked(object sender, EventArgs e)
        {
            var IsCorrect = ValidateFields();
            if (IsCorrect)
                await landingPageViewModel.SellStock(NameComboBox.SelectedItem, datePicker.Date);
            else
                landingPageViewModel.IsValidationMessageVisible = true;
        }

        /// <summary>
        /// Validates Fields for Transaction
        /// </summary>
        private bool ValidateFields()
        {            
            if (string.IsNullOrEmpty(BuyPriceLabel.Text) || string.IsNullOrEmpty(BuyShareNameLabel.Text) || string.IsNullOrEmpty(BuyQuantityLabel.Text) || string.IsNullOrEmpty(NameComboBox.Text))
            {
                landingPageViewModel.ValidationMessage = "Fields cannot be left empty";
                return false;
            }
            else if (!Double.TryParse(BuyPriceLabel.Text, out _) || !Double.TryParse(BuyQuantityLabel.Text, out _))
            {
                landingPageViewModel.ValidationMessage = "Price and Quantity must be a numerical value!!";
                return false;
            }
            else
                return true;
        }

        /// <summary>
        /// Users the selection changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="Syncfusion.XForms.ComboBox.SelectionChangedEventArgs"/> instance containing the event data.</param>
        private async void UserSelectionChanged(object sender, Syncfusion.XForms.ComboBox.SelectionChangedEventArgs e)
        {
            await landingPageViewModel.GetUserAverageData(NamePicker.SelectedItem.ToString());
        }

        /// <summary>
        /// Homes the button clicked.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void HomeButtonClicked(object sender, EventArgs e)
        {
            NamePicker.Clear();
            landingPageViewModel.GetUserAverageData("Total");
        }
        private void EditButtonClicked(object sender, EventArgs e)
        {
            landingPageViewModel.AddBalance = 0;
            landingPageViewModel.IsBalanceEditable = true;
            landingPageViewModel.IsBalanceLabelVisible = false;
        }

        private void TickButtonClicked(object sender, EventArgs e)
        {
            landingPageViewModel.IsBalanceLabelVisible = true;
            landingPageViewModel.IsBalanceEditable = false;
            landingPageViewModel.UpdateBalance();
        }

        private void SelectDate(object sender, EventArgs e)
        {
            datePicker.IsOpen = true;
        }

        private void Datepicker_DateSelected(object sender, Syncfusion.XForms.Pickers.DateChangedEventArgs e)
        {
            BuyDateLabel.Text = datePicker.Date.ToString("dd/MMM/yyyy");
        }
    }
}