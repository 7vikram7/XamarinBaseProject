namespace XF7vikram7.AppClasses.PagesAndViewModels.Notification
{
    using System.Collections.Generic;
    using System.Windows.Input;
    using XF7vikram7.AppClasses.Common.Extensions;
    using XF7vikram7.AppClasses.PagesAndViewModels.Base;
    using Xamarin.Forms;

    public class NotificationPageModel : BasePageModel
    {
        #region Fields
        private List<NotificationListItemModel> notificationsList = new
        List<NotificationListItemModel>();
        
        #endregion

        #region Constructor
        public NotificationPageModel()
        {
        }

        #endregion

        #region Properties


        public List<NotificationListItemModel> NotificationsList
        {
            get
            {
                return this.notificationsList;
            }

            set
            {
                if (this.notificationsList != value)
                {
                    this.notificationsList = value;
                    this.OnPropertyChanged("NotificationsList");
                }
            }
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

        #region Public Methods


        #endregion

        #region Private Methods
        #endregion

        private void OnLeftButtonTapped(object obj)
        {
            App.MainNavigationPage.PopAsync();
        }

        private void OnRightButtonTapped(object obj)
        {
        }

        private void OnInnerRightButtonTapped(object obj)
        {
            if (obj.IsObjectADisabledViewIfAnEnabledViewDisableFor3Seconds())
            {
                return;
            }

            App.NavigateToHome();
        }
    }
}