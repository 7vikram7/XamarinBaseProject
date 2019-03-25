namespace XF7vikram7.AppClasses.PagesAndViewModels.Notification
{
    using System;
    using System.Windows.Input;
    using XF7vikram7.AppClasses.DataModels;
    using XF7vikram7.AppClasses.PagesAndViewModels.Base;
    using Resources;
    using Xamarin.Forms;

    // TODO: create a separate list item for the cell instead of defining the UI in the list view
    public class NotificationListItemModel : BaseItemModel
    {
        #region Fields
        private string title;
        private string text;
        private string notificationDateTime;

        #endregion

        #region Constructor

        public NotificationListItemModel()
        {
        }

        #endregion

        #region Properties

        public string Title
        {
            get
            {
                return this.title;
            }

            set
            {
                if (this.title != value)
                {
                    this.title = value;
                    this.OnPropertyChanged("Title");
                }
            }
        }

        public string Text
        {
            get
            {
                return this.text;
            }

            set
            {
                if (this.text != value)
                {
                    this.text = value;
                    this.OnPropertyChanged("Text");
                }
            }
        }

        public string NotificationDateTime
        {
            get
            {
                return this.notificationDateTime;
            }

            set
            {
                if (this.notificationDateTime != value)
                {
                    this.notificationDateTime = value;
                    this.OnPropertyChanged("NotificationDateTime");
                }
            }
        }

        #endregion

        #region Events
        public ICommand Command
        {
            get
            {
                return new Command(this.OnCommand);
            }
        }

        #endregion

        #region Public Methods
        #endregion

        #region Private Methods
        #endregion

        private void OnCommand(object obj)
        {
        }
    }
}
