using System;
using System.Threading.Tasks;
using Acr.UserDialogs;
using XF7vikram7.AppClasses.Interfaces;
using XF7vikram7.AppClasses.Services;
using XF7vikram7.Resources;
using Xamarin.Forms;

[assembly: Dependency(typeof(DialogService))]

namespace XF7vikram7.AppClasses.Services
{
    public class DialogService : IDialogService
    {
        #region Constructors
        public DialogService()
        {
        }
        #endregion Constructors

        #region Methods
        public void ShowLoading()
        {
            UserDialogs.Instance.ShowLoading(string.Empty);
        }

        public void HideLoading()
        {
            UserDialogs.Instance.HideLoading();
        }

        public void Alert(
            string title,
            string message)
        {
            UserDialogs.Instance.Alert(
                message,
                title,
                AppResources.App_Ok);
        }

        public async Task AlertAsync(
            string title,
            string message)
        {
            await UserDialogs.Instance.AlertAsync(
                message,
                title,
                AppResources.App_Ok);
        }

        public void Confirm(
            string title,
            string message,
            Action<bool> action)
        {
            ConfirmConfig dialogSettings = new ConfirmConfig()
            {
                CancelText = AppResources.App_Cancel,
                Message = message,
                OkText = AppResources.App_Ok,
                Title = title,
                OnAction = action
            };
            UserDialogs.Instance.Confirm(dialogSettings);
        }

        public async Task ConfirmAsync(
            string title,
            string message,
            Action<bool> action)
        {
            ConfirmConfig dialogSettings = new ConfirmConfig()
            {
                CancelText = AppResources.App_Cancel,
                Message = message,
                OkText = AppResources.App_Ok,
                Title = title,
                OnAction = action
            };
            await UserDialogs.Instance.ConfirmAsync(dialogSettings);
        }

        #endregion Methods
    }
}