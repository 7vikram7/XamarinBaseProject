namespace XF7vikram7.AppClasses.PagesAndViewModels.Account
{
    using System.Windows.Input;
    using XF7vikram7.AppClasses.Common.Extensions;
    using XF7vikram7.AppClasses.DataModels;
    using XF7vikram7.AppClasses.PagesAndViewModels.Base;
    using XF7vikram7.Resources;
    using Xamarin.Forms;

    public class AccountPageModel : BasePageModel
    {
        #region Fields
        private string oldPassword;
        private string newPassword;
        private string confirmPassword;
        private bool isChangePasswordViewVisible = false;

        #endregion

        #region Constructor
        public AccountPageModel()
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

        public string Email
        {
            get
            {
                return SessionData.Instance.Email;
            }
        }

        public string PhoneNumber
        {
            get
            {
                return SessionData.Instance.Phone;
            }
        }

        public string OldPassword
        {
            get
            {
                return this.oldPassword;
            }

            set
            {
                if (this.oldPassword != value)
                {
                    this.oldPassword = value;
                    this.OnPropertyChanged("OldPassword");
                }
            }
        }

        public string NewPassword
        {
            get
            {
                return this.newPassword;
            }

            set
            {
                if (this.newPassword != value)
                {
                    this.newPassword = value;
                    this.OnPropertyChanged("NewPassword");
                }
            }
        }

        public string ConfirmPassword
        {
            get
            {
                return this.confirmPassword;
            }

            set
            {
                if (this.confirmPassword != value)
                {
                    this.confirmPassword = value;
                    this.OnPropertyChanged("ConfirmPassword");
                }
            }
        }

        public bool IsChangePasswordViewVisible
        {
            get
            {
                return this.isChangePasswordViewVisible;
            }

            set
            {
                if (this.isChangePasswordViewVisible != value)
                {
                    this.isChangePasswordViewVisible = value;
                    this.OnPropertyChanged("IsChangePasswordViewVisible");
                    this.OnPropertyChanged("ChangePasswordViewStatusImageSource");
                    this.OnPropertyChanged("FacilitiesViewStatusImageSource");
                }
            }
        }

        // TODO: setImage
        public string ChangePasswordViewStatusImageSource
        {
            get
            {
                return this.isChangePasswordViewVisible ? "top_arrow_black" :
                       "bottom_arrow_black";
            }
        }

        #endregion

        #region Computed Properties
        #endregion

        #region Events
        public ICommand LeftButtonTapped
        {
            get
            {
                return new Command(this.OnLeftButtonTapped);
            }
        }

        public ICommand HeaderTapped
        {
            get
            {
                return new Command(this.OnHeaderTapped);
            }
        }

        public ICommand RightButtonTapped
        {
            get
            {
                return new Command(this.OnRightButtonTapped);
            }
        }

        public ICommand ChangePasswordTapped
        {
            get
            {
                return new Command(this.OnChangePasswordTapped);
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

        private async void OnHeaderTapped(object obj)
        {
            this.IsChangePasswordViewVisible = !this.IsChangePasswordViewVisible;
        }

        private void OnChangePasswordTapped(object obj)
        {
            if (obj.IsObjectADisabledViewIfAnEnabledViewDisableFor3Seconds())
            {
                return;
            }

            if (string.IsNullOrEmpty(this.OldPassword))
            {
                this.CorrespondingPage.DisplayAlert(
                    AppResources.App_Error,
                    AppResources.Account_EnterOldPassword,
                    AppResources.App_Ok);
                return;
            }
            else if (string.IsNullOrEmpty(this.NewPassword))
            {
                this.CorrespondingPage.DisplayAlert(
                    AppResources.App_Error,
                    AppResources.Account_EnterNewPassword,
                    AppResources.App_Ok);
                return;
            }
            else if (string.IsNullOrEmpty(this.ConfirmPassword))
            {
                this.CorrespondingPage.DisplayAlert(
                    AppResources.App_Error,
                    AppResources.Account_EnterConfirmPassword,
                    AppResources.App_Ok);
                return;
            }
            else if (this.NewPassword != this.ConfirmPassword)
            {
                this.CorrespondingPage.DisplayAlert(
                    AppResources.App_Error,
                    AppResources.Account_NewPasswordDoNotMatch,
                    AppResources.App_Ok);
                return;
            }
        }

        private void OnRightButtonTapped(object obj)
        {
            this.Logout();
        }

        private async void Logout()
        {
            App.ClearSessionDataAndLogoutNavigation();
        }
    }
}
