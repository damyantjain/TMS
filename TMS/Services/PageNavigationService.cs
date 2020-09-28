namespace TMS.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Xamarin.Forms;

    /// <summary>
    /// PageNavigationService
    /// </summary>
    /// <seealso cref="West.Kiosk.Common.Services.IPageNavigationService" />
    public class PageNavigationService : IPageNavigationService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PageNavigationService"/> class.
        /// </summary>
        public PageNavigationService()
        {
            Pages = new Dictionary<string, Type>();
        }

        /// <summary>
        /// Gets or sets the pages.
        /// </summary>
        /// <value>
        /// The pages.
        /// </value>
        public Dictionary<string, Type> Pages { get; set; }

        /// <summary>
        /// Main page
        /// </summary>
        /// <value>
        /// The main page.
        /// </value>
        public Page MainPage
        {
            get
            {
                return Application.Current.MainPage;
            }
        }

        /// <summary>
        /// Gets the main page.
        /// </summary>
        /// <value>
        /// The main page.
        /// </value>
        public INavigation MainNavigation
        {
            get
            {
                if (MainPage.Navigation.NavigationStack.Last() is MasterDetailPage)
                    return ((MasterDetailPage)MainPage.Navigation.NavigationStack.Last()).Detail.Navigation;
                else
                    return MainPage.Navigation;
            }
        }

        /// <summary>
        /// Current Page Key
        /// </summary>
        public string CurrentPageKey => string.Empty;

        /// <summary>
        /// Close model and navigate
        /// </summary>
        /// <param name="pageKey">The page key.</param>
        public virtual void CloseModalAndNavigate(string pageKey)
        {
            this.GoBack();
            this.NavigateTo(pageKey);
        }

        /// <summary>
        /// Go back
        /// </summary>
        /// <param name="parentTab">The parent tab.</param>
        public virtual void GoBack(Page parentTab)
        {
            try
            {
                parentTab.Navigation.PopAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Go back
        /// </summary>
        public virtual void GoBack()
        {
            this.GoBack(true);
        }

        /// <summary>
        /// Go the back.
        /// </summary>
        /// <param name="Animated">if set to <c>true</c> [animated].</param>
        public void GoBack(bool Animated)
        {
            if (MainNavigation.ModalStack.Count > 0)
            {
                MainNavigation.PopModalAsync(Animated);
            }
            else
            {
                MainNavigation.PopAsync(Animated);
            }
        }

        /// <summary>
        /// Navigate to
        /// </summary>
        /// <param name="pageKey">The page key.</param>
        /// <param name="parameter">The parameter.</param>
        /// <param name="isModal">if set to <c>true</c> [is modal].</param>
        public virtual void NavigateTo(string pageKey, object parameter, bool isModal = false)
        {
            this.NavigateAction(pageKey, parameter, isModal);
        }

        /// <summary>
        /// Navigates the action.
        /// </summary>
        /// <param name="pageKey">The page key.</param>
        /// <param name="parameter">The parameter.</param>
        /// <param name="isModal">if set to <c>true</c> [is modal].</param>
        private async Task NavigateAction(string pageKey, object parameter, bool isModal = false)
        {
            object[] parameters = null;
            if (parameter != null)
            {
                parameters = new object[] { parameter };
            }
            Type pageType = Pages[pageKey];

            // var currentPage = pageType.GetConstructors();

            if (IsAlreadyInNavigationStack(pageKey))
            {
                await PopToPage(pageKey);
            }
            else
            {
                Page displayPage = (Page)Activator.CreateInstance(pageType, parameters);

                if (!isModal)
                {
                    await MainNavigation.PushAsync(displayPage);
                }
                else
                {
                    await MainNavigation.PushModalAsync(displayPage);
                }
            }
        }
        /// <summary>
        /// Navigate to
        /// </summary>
        /// <param name="pageKey">The key corresponding to the page
        /// that should be displayed.</param>
        public virtual void NavigateTo(string pageKey)
        {
            NavigateTo(pageKey, null);
        }

        /// <summary>
        /// Is already in navigation stack
        /// </summary>
        /// <param name="pageKey">The page key.</param>
        /// <returns>
        ///   <c>true</c> if [is already in navigation stack] [the specified page key]; otherwise, <c>false</c>.
        /// </returns>
        private bool IsAlreadyInNavigationStack(string pageKey)
        {
            var pages = MainNavigation.NavigationStack.ToList();

            foreach (var item in pages)
            {
                var name = item.GetType().FullName;

                if (this.Pages.ContainsKey(pageKey))
                {
                    Type page = this.Pages[pageKey];

                    if (name.Equals(page.ToString()))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Pop to page
        /// </summary>
        /// <param name="pageName">Name of the page.</param>
        public virtual async Task PopToPage(string pageName)
        {
            Type destination = this.Pages[pageName];
            List<Page> toRemove = new List<Page>();
            if (destination == null) return;

            //First, we get the navigation stack as a list
            var pages = this.MainNavigation.NavigationStack.ToList();

            //Then we invert it because it's from first to last and we need in the inverse order
            pages.Reverse();

            //Then we discard the current page
            pages.RemoveAt(0);

            foreach (var page in pages)
            {
                if (page.GetType() == destination) break;

                toRemove.Add(page);
            }

            foreach (var rvPage in toRemove)
            {
                this.MainNavigation.RemovePage(rvPage);
            }

            await this.MainNavigation.PopAsync();
        }

        /// <summary>
        /// Remove page
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public virtual bool RemovePage(string key)
        {
            foreach (var item in this.MainNavigation.NavigationStack)
            {
                var name = item.GetType().FullName;

                if (this.Pages.ContainsKey(key))
                {
                    Type page = this.Pages[key];

                    if (name.Equals(page.ToString()))
                    {
                        this.MainNavigation.RemovePage(item);
                        return true;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Go back
        /// </summary>
        /// <param name="isMasterNavigation">if set to <c>true</c> [is master navigation].</param>
        /// <param name="Animated">if set to <c>true</c> [animated].</param>
        /// <param name="toRootPage">if set to <c>true</c> [to root page].</param>
        public virtual void GoBack(bool isMasterNavigation, bool Animated, bool toRootPage = false)
        {
        }

        /// <summary>
        /// pop to master detail root page
        /// </summary>
        public virtual void PopToMasterDetailRootPage()
        {
        }

        /// <summary>
        /// Navigate to
        /// </summary>
        /// <param name="pageKey">The key corresponding to the page
        /// that should be displayed.</param>
        /// <param name="parameter">The parameter that should be passed
        /// to the new page.</param>
        public virtual void NavigateTo(string pageKey, object parameter)
        {
            this.NavigateTo(pageKey, parameter, false);
        }

        /// <summary>
        /// Change Tab
        /// </summary>
        /// <param name="tabIndex">Index of the tab.</param>
        public virtual void ChangeTab(int tabIndex)
        {
        }
    }
}
