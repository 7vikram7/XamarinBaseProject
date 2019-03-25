namespace XF7vikram7.AppClasses.PagesAndViewModels.Notification
{
    using System;
    using System.Collections.Generic;
    using XF7vikram7.AppClasses.PagesAndViewModels.Base;
    using Xamarin.Forms;

    public partial class NotificationPage : BasePage
    {
        public NotificationPage() : this(new NotificationPageModel())
        {
        }

        public NotificationPage(NotificationPageModel model)
        {
            this.PageModel = model;
            this.BindingContext = model;
            model.CorrespondingPage = this;
            this.InitializeComponent();

            listView.ItemTapped += (object sender, ItemTappedEventArgs e) =>
            {
                // don't do anything if we just de-selected the row
                if (e.Item == null)
                {
                    return;
                }

                ((ListView)sender).SelectedItem = null; // de-select the row
            };
        }
    }
}
