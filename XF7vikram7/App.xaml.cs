using System.Collections.Generic;
using System.Threading.Tasks;
using Acr.UserDialogs;
using XF7vikram7.AppClasses.DataModels;
using XF7vikram7.AppClasses.Interfaces;
using XF7vikram7.AppClasses.PagesAndViewModels.ForgotPassword;
using XF7vikram7.AppClasses.PagesAndViewModels.MasterDetailMain;
using XF7vikram7.AppClasses.PagesAndViewModels.SignUp;
using XF7vikram7.AppClasses.Services;
using XF7vikram7.AppClasses.WebServices;
using Xamarin.Forms;

namespace XF7vikram7
{
    public partial class App : Application
    {
        #region Fields
        #endregion

        #region Constructor
        public App()
        {
            InitializeComponent();

            MainNavigationPage = new NavigationPage(new SignUpPage());
            this.MainPage = MainNavigationPage;
        }
        #endregion

        #region Properties

        // TODO: Create better navigation interface
        public static NavigationPage MainNavigationPage
        {
            get;
            set;
        }

        public static NavigationPage MasterSliderNavigationPage
        {
            get;
            set;
        }

        public static MasterDetailMainPage MainMasterDetailPage
        {
            get;
            set;
        }

        public static App AppInstance
        {
            get;
            set;
        }
        #endregion

        #region Event Handlers
        #endregion

        #region Public Methods

        public static async void InitiateAndNavigateToMainPage(bool isAfterSignUp)
        {
            //await App.PopulateUserFacilities();

            //if (isAfterSignUp)
            //{
            //    var asyncResult = App.MainNavigationPage.PopToRootAsync(false);
            //}

            MainMasterDetailPage = new MasterDetailMainPage();
            await MainNavigationPage.PushAsync(MainMasterDetailPage, false);
        }

        public static void LogoutNavigation()
        {
            MainNavigationPage.PopToRootAsync();
        }

        public static async void NavigateToHome()
        {
            while (!(MainNavigationPage.CurrentPage is MasterDetailPage))
            {
                await MainNavigationPage.PopAsync(false);
            }

            //var result = MasterSliderNavigationPage.PopToRootAsync();

            //if (MainMasterDetailPage != null)
            //{
                //MainMasterDetailPage.IsPresented = false;
            //}
        }

        public static void ToggleMasterDetailPresentation()
        {
            if (MainMasterDetailPage != null)
            {
                MainMasterDetailPage.IsPresented = !MainMasterDetailPage.IsPresented;
            }
        }

        public static bool IsUserLoggedIn()
        {
            bool result = false;

            if (Application.Current.Properties.ContainsKey(SessionData.KSessionId)
                    && Application.Current.Properties.ContainsKey(SessionData.KUserId))
            {
                result = true;
            }

            return result;
        }

        public static void ClearSessionDataAndLogoutNavigation()
        {
            SessionData.DeleteSessionDataFromProperties();
            SessionData.ClearCacheSessionData();
            App.LogoutNavigation();
        }

        #endregion

        #region Page Lifecycle

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        #endregion

        #region Private Methods

        #endregion

    }
}
