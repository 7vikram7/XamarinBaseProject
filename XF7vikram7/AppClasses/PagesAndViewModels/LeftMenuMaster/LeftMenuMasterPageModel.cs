namespace XF7vikram7.AppClasses.PagesAndViewModels.LeftMenuMaster
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Windows.Input;
    using XF7vikram7.AppClasses.Common.Extensions;
    using XF7vikram7.AppClasses.DataModels;
    using XF7vikram7.AppClasses.PagesAndViewModels.Account;
    using XF7vikram7.AppClasses.PagesAndViewModels.Base;
    using XF7vikram7.AppClasses.PagesAndViewModels.Notification;
    using XF7vikram7.AppClasses.WebServices;
    using XF7vikram7.Resources;
    using Xamarin.Forms;

    public class LeftMenuMasterPageModel : BasePageModel
    {
        #region Fields
        private ObservableCollection<LeftMenuItemModel>
        leftMenuItemModelsList;

        #endregion

        #region Constructor

        public LeftMenuMasterPageModel()
        {
        }

        #endregion

        #region Properties
        public string Name
        {
            get
            {
                return SessionData.Instance.Name;
            }
        }

        public ObservableCollection<LeftMenuItemModel>
        LeftMenuItemModelsList
        {
            get
            {
                return this.leftMenuItemModelsList;
            }

            set
            {
                if (this.leftMenuItemModelsList != value)
                {
                    this.leftMenuItemModelsList = value;
                    this.OnPropertyChanged("LeftMenuItemModelsList");
                }
            }
        }

        #endregion

        #region Computed Properties
        #endregion

        #region Events
        public ICommand HomeCommand
        {
            get
            {
                return new Command(this.OnHomeCommand);
            }
        }

        public ICommand NotificationCommand
        {
            get
            {
                return new Command(this.OnNotificationCommand);
            }
        }

        public ICommand LogoutCommand
        {
            get
            {
                return new Command(this.OnLogoutCommand);
            }
        }

        public ICommand ShowAccountCommand
        {
            get
            {
                return new Command(this.OnShowAccountCommand);
            }
        }

        public ICommand AddCommand
        {
            get
            {
                return new Command(this.OnAddCommand);
            }
        }

        #endregion

        #region Public Methods
        public void PopulateLeftMenuItemList()
        {
            ObservableCollection<LeftMenuItemModel> itemsList = new
            ObservableCollection<LeftMenuItemModel>();

            foreach (LeftMenuItemModel currentModel in
                     SessionData.Instance.LeftMenuItems)
            {
                itemsList.Add(new LeftMenuItemModel
                {
                    Title = currentModel.Title
                });
            }

            this.LeftMenuItemModelsList = itemsList;
        }

        #endregion

        #region Private Methods
        private void OnHomeCommand(object obj)
        {
            App.NavigateToHome();
        }

        private void OnNotificationCommand(object obj)
        {
            if (obj.IsObjectADisabledViewIfAnEnabledViewDisableFor3Seconds())
            {
                return;
            }

            App.MainNavigationPage.PushAsync(new NotificationPage());
        }

        private void OnLogoutCommand(object obj)
        {
            this.Logout();
        }

        private void OnShowAccountCommand(object obj)
        {
            if (obj.IsObjectADisabledViewIfAnEnabledViewDisableFor3Seconds())
            {
                return;
            }

            App.MainNavigationPage.PushAsync(new AccountPage());
        }

        private void OnAddCommand(object obj)
        {

        }

        private void Logout()
        {
            App.ClearSessionDataAndLogoutNavigation();
        }

        #endregion
    }
}