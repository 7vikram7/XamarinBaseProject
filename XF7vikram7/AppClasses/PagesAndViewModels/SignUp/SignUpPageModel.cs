namespace XF7vikram7.AppClasses.PagesAndViewModels.SignUp
{
    using System.Windows.Input;
    using XF7vikram7.AppClasses.Common.Extensions;
    using XF7vikram7.AppClasses.DataModels;
    using XF7vikram7.AppClasses.PagesAndViewModels.Base;
    using XF7vikram7.AppClasses.PagesAndViewModels.ForgotPassword;
    using Resources;
    using Xamarin.Forms;
    using XF7vikram7.AppClasses.PagesAndViewModels.SignUpCreateAccount;

    public class SignUpPageModel : BasePageModel
    {
        #region Fields
        private string emailAddress;
        private string password;
        private bool hasInitialSessionCheckBeenPerformed = false;
        private bool isRememberMeChecked = false;

        #endregion

        #region Constructor
        public SignUpPageModel()
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

        public bool IsRememberMeChecked
        {
            get
            {
                return this.isRememberMeChecked;
            }

            set
            {
                if (this.isRememberMeChecked != value)
                {
                    this.isRememberMeChecked = value;
                    this.OnPropertyChanged("IsRememberMeChecked");
                }
            }
        }

        #endregion

        #region Events
        public ICommand ForgotPasswordCommand
        {
            get
            {
                return new Command(this.OnForgotPasswordCommand);
            }
        }

        public ICommand SignUpCommand
        {
            get
            {
                return new Command(this.OnSignUpCommand);
            }
        }

        public ICommand SignInCommand
        {
            get
            {
                return new Command(this.OnSignInCommand);
            }
        }

        public ICommand ShowPasswordCommand
        {
            get
            {
                return new Command(this.OnShowPasswordCommand);
            }
        }

        public ICommand RememberMeCommand
        {
            get
            {
                return new Command(this.OnRememberMeCommand);
            }
        }

        #endregion

        #region Page Lifecycle
        public override void OnAppearing()
        {
            if (!this.hasInitialSessionCheckBeenPerformed)
            {
                if (App.IsUserLoggedIn())
                {
                    SessionData.PopulateSessionDataFromProperties();
                    App.InitiateAndNavigateToMainPage(false);
                    this.hasInitialSessionCheckBeenPerformed = true;
                }
            }
        }

        #endregion

        #region Public Methods
        public void OnEmailTextChanged(string text)
        {
            // TODO: integrate the remember me service
            //if (!string.IsNullOrEmpty(RememberMeService.UserName))
            //{
            //    if (RememberMeService.UserName == text)
            //    {
            //        if (RememberMeService.Password != null)
            //        {
            //            this.Password = RememberMeService.Password;
            //        }
            //    }
            //}
        }

        #endregion

        #region Private Methods
        #endregion

        private void OnForgotPasswordCommand(object obj)
        {
            if (obj.IsObjectADisabledViewIfAnEnabledViewDisableFor3Seconds())
            {
                return;
            }

            App.MainNavigationPage.PushAsync(new ForgotPasswordPage());
        }

        private void OnSignUpCommand(object obj)
        {
            if (obj.IsObjectADisabledViewIfAnEnabledViewDisableFor3Seconds())
            {
                return;
            }

            App.MainNavigationPage.PushAsync(new SignUpCreateAccountPage());
        }

        private void OnSignInCommand(object obj)
        {
            if (this.EmailAddress == null || this.EmailAddress == string.Empty)
            {
                // TODO: write an interface for model to show an alert on its page
                this.CorrespondingPage.DisplayAlert(
                    AppResources.App_Error,
                    AppResources.SignUp_EnterEmailValidation,
                    AppResources.App_Ok);
                return;
            }

            if (this.Password == null || this.Password == string.Empty)
            {
                // TODO: write an interface for model to show an alert on its page
                this.CorrespondingPage.DisplayAlert(
                    AppResources.App_Error,
                    AppResources.SignUp_EnterPasswordValidation,
                    AppResources.App_Ok);
                return;
            }

            this.Login();
        }

        private void OnShowPasswordCommand(object obj)
        {
            if (obj is Entry)
            {
                Entry passwordEntry = obj as Entry;
                passwordEntry.IsPassword = !passwordEntry.IsPassword;
            }
        }

        private void OnRememberMeCommand(object obj)
        {
            this.IsRememberMeChecked = !this.IsRememberMeChecked;
        }

        private async void Login()
        {
         

            //if (sessionDataModel != default(SessionDataModel))
            //{
            //    SessionData.SetDataFromSessionDataModel(sessionDataModel);

            //    // TODO : integrate the remember me service
            //    //RememberMeService.DeleteCredentials();

            //    //if (this.isRememberMeChecked)
            //    //{
            //    //    RememberMeService.SaveCredentials(this.EmailAddress, this.Password);
            //    //}

                App.InitiateAndNavigateToMainPage(false);
            //}
        }
    }
}
