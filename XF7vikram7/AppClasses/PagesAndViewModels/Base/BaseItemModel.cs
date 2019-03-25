namespace XF7vikram7.AppClasses.PagesAndViewModels.Base
{
    using System;
    using System.ComponentModel;
    using Xamarin.Forms;

    public class BaseItemModel : INotifyPropertyChanged
    {
        public BaseItemModel()
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
