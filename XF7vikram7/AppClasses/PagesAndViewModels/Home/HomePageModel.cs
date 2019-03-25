namespace XF7vikram7.AppClasses.PagesAndViewModels.Home
{

    using System.Windows.Input;
    using XF7vikram7.AppClasses.Common.Extensions;
    using XF7vikram7.AppClasses.PagesAndViewModels.Base;
    using XF7vikram7.AppClasses.PagesAndViewModels.Notification;
    using Xamarin.Forms;

    public class HomePageModel : BasePageModel
    {
        #region Fields

        #endregion

        #region Constructor
        public HomePageModel()
        {
        }

        #endregion

        #region Object Properties


        public string Title
        {
            get;
            set;
        }

        public string SubTitle
        {
            get;
            set;
        }

        #endregion

        #region Events
        public ICommand LeftButtonTapped
        {
            get
            {
                return new Command(this.OnLeftButtonTapped);
            }
        }

        public ICommand RightButtonTapped
        {
            get
            {
                return new Command(this.OnRightButtonTapped);
            }
        }

        public ICommand InnerRightButtonTapped
        {
            get
            {
                return new Command(this.OnInnerRightButtonTapped);
            }
        }

        #endregion

        #region Page Lifecycle
        public override void OnAppearing()
        {

        }

        #endregion

        #region Public Methods
        #endregion

        #region Private Methods
        private void OnLeftButtonTapped(object obj)
        {
            App.ToggleMasterDetailPresentation();
        }

        private void OnRightButtonTapped(object obj)
        {
            if (obj.IsObjectADisabledViewIfAnEnabledViewDisableFor3Seconds())
            {
                return;
            }

            App.MainNavigationPage.PushAsync(new NotificationPage());
        }

        private void OnInnerRightButtonTapped(object obj)
        {
            if (obj.IsObjectADisabledViewIfAnEnabledViewDisableFor3Seconds())
            {
                return;
            }

            App.NavigateToHome();
        }


        #endregion
    }
}
