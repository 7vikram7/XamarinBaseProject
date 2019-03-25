namespace XF7vikram7.AppClasses.Interfaces
{
    using System;
    using System.Threading.Tasks;

    public interface IDialogService
    {
        void ShowLoading();

        void HideLoading();

        void Alert(string title, string message);

        Task AlertAsync(string title, string message);

        void Confirm(string title, string message, Action<bool> action);

        Task ConfirmAsync(string title, string message, Action<bool> action);
    }
}