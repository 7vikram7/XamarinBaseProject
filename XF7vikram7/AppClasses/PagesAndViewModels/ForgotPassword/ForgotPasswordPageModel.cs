namespace XF7vikram7.AppClasses.PagesAndViewModels.ForgotPassword
{
    using System;
    using System.Windows.Input;
    using XF7vikram7.AppClasses.PagesAndViewModels.Base;
    using XF7vikram7.AppClasses.WebServices;
    using XF7vikram7.Resources;
    using Xamarin.Forms;

    public class ForgotPasswordPageModel : BasePageModel
    {
        #region Fields
        private string emailAddress;

        #endregion

        #region Constructor
        public ForgotPasswordPageModel()
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

        #endregion

        #region Events
        public ICommand ResetPasswordCommand
        {
            get
            {
                return new Command(this.OnResetPasswordCommand);
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

        private void OnResetPasswordCommand(object obj)
        {
            if (this.EmailAddress == null || this.EmailAddress == string.Empty)
            {
                // TODO: write an interface for model to show an alert on its page
                this.CorrespondingPage.DisplayAlert(
                    AppResources.App_Error,
                    AppResources.ForgotPassword_EnterEmailValidation,
                    AppResources.App_Ok);
                return;
            }

            this.CallForgotPassword();
        }

        private void OnBackCommand(object obj)
        {
            App.MainNavigationPage.PopAsync();
        }

        private async void CallForgotPassword()
        {
            this.ShowLoading();

            // TODO: put in place proper error handling for APIs
            bool result = await
                          PasswordRestServices.Instance.ForgotPassword(
                              this.EmailAddress,
                              new System.Threading.CancellationToken(),
                              (obj) =>
            {
                if (obj.Status.GetHashCode() == BaseRestService.KStatusCode404)
                {
                    this.CorrespondingPage.DisplayAlert(
                        AppResources.App_Error,
                        AppResources.ForgotPassword_EmailNotFound,
                        AppResources.App_Ok);
                }
            });

            this.StopLoading();

            if (result)
            {
                await this.CorrespondingPage.DisplayAlert(
                    AppResources.App_Error,
                    AppResources.ForgotPassword_EmailSentToResetPassword,
                    AppResources.App_Ok);

                await App.MainNavigationPage.PopAsync();
            }
        }
    }
}
