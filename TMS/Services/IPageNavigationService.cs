namespace TMS.Services
{
    using GalaSoft.MvvmLight.Views;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Xamarin.Forms;

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="GalaSoft.MvvmLight.Views.INavigationService" />
    public interface IPageNavigationService : INavigationService
    {
        /// <summary>
        /// Gets or sets the pages.
        /// </summary>
        /// <value>
        /// The pages.
        /// </value>
        Dictionary<string, Type> Pages { get; set; }

        /// <summary>
        /// Gets the main navigation.
        /// </summary>
        /// <value>
        /// The main navigation.
        /// </value>
        INavigation MainNavigation { get; }

        /// <summary>
        /// Removes the page.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        bool RemovePage(string key);

        /// <summary>
        /// Navigates to.
        /// </summary>
        /// <param name="pageKey">The page key.</param>
        /// <param name="parameter">The parameter.</param>
        /// <param name="isModal">if set to <c>true</c> [is modal].</param>
        void NavigateTo(string pageKey, object parameter, bool isModal = false);

        /// <summary>
        /// Pops to page.
        /// </summary>
        /// <param name="pageName">Name of the page.</param>
        /// <returns></returns>
        Task PopToPage(string pageName);

        /// <summary>
        /// Closes the modal and navigate.
        /// </summary>
        /// <param name="pageKey">The page key.</param>
        void CloseModalAndNavigate(string pageKey);

        /// <summary>
        /// Goes the back.
        /// </summary>
        /// <param name="parentTab">The parent tab.</param>
        void GoBack(Page parentTab);

        /// <summary>
        /// Goes the back.
        /// </summary>
        /// <param name="Animated">if set to <c>true</c> [animated].</param>
        void GoBack(bool Animated);

        /// <summary>
        /// Goes the back.
        /// </summary>
        /// <param name="isMasterNavigation">if set to <c>true</c> [is master navigation].</param>
        /// <param name="Animated">if set to <c>true</c> [animated].</param>
        /// <param name="toRootPage">if set to <c>true</c> [to root page].</param>
        void GoBack(bool isMasterNavigation, bool Animated, bool toRootPage = false);

        /// <summary>
        /// Gets the main page.
        /// </summary>
        /// <value>
        /// The main page.
        /// </value>
        Page MainPage { get; }

        /// <summary>
        /// Pops to master detail root page.
        /// </summary>
        void PopToMasterDetailRootPage();

        /// <summary>
        /// Changes the tab.
        /// </summary>
        /// <param name="tabIndex">Index of the tab.</param>
        void ChangeTab(int tabIndex);
    }
}
