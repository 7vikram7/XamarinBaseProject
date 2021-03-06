﻿namespace XF7vikram7.AppClasses.CustomViews.Base
{
    using System;
    using System.ComponentModel;
    using Xamarin.Forms;

    public class BaseViewModel : INotifyPropertyChanged
    {
        public BaseViewModel()
        {
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(
                    this,
                    new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
