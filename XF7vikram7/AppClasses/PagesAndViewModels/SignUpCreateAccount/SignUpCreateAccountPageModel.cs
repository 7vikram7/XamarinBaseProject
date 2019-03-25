namespace XF7vikram7.AppClasses.PagesAndViewModels.SignUpCreateAccount
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Input;
    using XF7vikram7.AppClasses.DataModels;
    using XF7vikram7.AppClasses.PagesAndViewModels.Base;
    using XF7vikram7.AppClasses.PagesAndViewModels.ForgotPassword;
    using XF7vikram7.AppClasses.WebServices;
    using XF7vikram7.Resources;
    using Xamarin.Forms;

    public class SignUpCreateAccountPageModel : BasePageModel
    {
        #region Fields
        private string emailAddress;
        private string password;
        private string confirmPassword;

        #endregion

        #region Constructor
        public SignUpCreateAccountPageModel()
        {
        }

        #endregion

        #region Properties
        public string EmailAddress
        {
            get
            {
                return this.emailAddress;
            }

            set
            {
                if (this.emailAddress != value)
                {
                    this.emailAddress = value;
                    this.OnPropertyChanged("EmailAddress");
                }
            }
        }

        public string Password
        {
            get
            {
                return this.password;
            }

            set
            {
                if (this.password != value)
                {
                    this.password = value;
                    this.OnPropertyChanged("Password");
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

        #endregion

        #region Events
        public ICommand CreateAccountCommand
        {
            get
            {
                return new Command(this.OnCreateAccountCommand);
            }
        }

        public ICommand BackCommand
        {
            get
            {
                return new Command(this.OnBackCommand);
            }
        }

        #endregion

        #region Public Methods
        #endregion

        #region Private Methods
        #endregion

        private void OnCreateAccountCommand(object obj)
        {
            if (this.EmailAddress == null || this.EmailAddress == string.Empty)
            {
                // TODO: write an interface for model to show an alert on its page
                this.CorrespondingPage.DisplayAlert(
                    AppResources.App_Error,
                    AppResources.SignUpCreateAccount_EnterEmailValidation,
                    AppResources.App_Ok);
                return;
            }

            if (this.Password == null || this.Password == string.Empty)
            {
                // TODO: write an interface for model to show an alert on its page
                this.CorrespondingPage.DisplayAlert(
                    AppResources.App_Error,
                    AppResources.SignUpCreateAccount_EnterPasswordValidation,
                    AppResources.App_Ok);
                return;
            }

            if (this.Password != this.ConfirmPassword)
            {
                // TODO: write an interface for model to show an alert on its page
                this.CorrespondingPage.DisplayAlert(
                    AppResources.App_Error,
                    AppResources.SignUpCreateAccount_PasswordNotMatchingValidation,
                    AppResources.App_Ok);
                return;
            }
        }

        private void OnBackCommand(object obj)
        {
            App.MainNavigationPage.PopAsync();
        }
    }
}
