namespace XF7vikram7.AppClasses.PagesAndViewModels.Base
{
    using System;
    using System.Collections.Generic;
    using Xamarin.Forms;

    public partial class BasePage : ContentPage
    {
        #region Fields
        #endregion

        #region Constructor

        public BasePage()
        {
            this.InitializeComponent();
        }

        #endregion

        #region Properties
        public BasePageModel PageModel
        {
            get;
            set;
        }

        #endregion

        #region Event Handlers
        #endregion

        #region Public Methods
        #endregion

        #region Page Lifecycle
        protected override void OnAppearing()
        {
            if (this.PageModel != null)
            {
                this.PageModel.OnAppearing();
            }
        }

        protected override void OnDisappearing()
        {
            if (this.PageModel != null)
            {
                this.PageModel.OnDisappearing();
            }
        }

        #endregion
        #region Private Methods
        #endregion
    }
}
