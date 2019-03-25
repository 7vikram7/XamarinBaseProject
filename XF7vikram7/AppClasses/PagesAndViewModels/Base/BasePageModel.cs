﻿namespace XF7vikram7.AppClasses.PagesAndViewModels.Base
{
    using System;
    using System.ComponentModel;
    using XF7vikram7.AppClasses.Interfaces;
    using Xamarin.Forms;

    public class BasePageModel : INotifyPropertyChanged
    {
        #region Fields
        public readonly IDialogService DialogService;

        #endregion

        #region Constructor
        public BasePageModel()
        {
            DialogService = DependencyService.Get<IDialogService>();
        }

        #endregion

        #region Properties
        public event PropertyChangedEventHandler PropertyChanged;

        public BasePage CorrespondingPage
        {
            get;
            set;
        }

        #endregion

        #region Events
        #endregion
                 #region Page Lifecycle
        public virtual void OnAppearing()
        {
        }

        public virtual void OnDisappearing()
        {
        }

        #endregion

        #region Public Methods
        #endregion

        #region Private Methods
        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(
                    this,
                    new PropertyChangedEventArgs(propertyName));
            }
        }

        protected void ShowLoading()
        {
            DialogService.ShowLoading();
        }

        protected void StopLoading()
        {
            DialogService.HideLoading();
        }

        #endregion
    }
}
