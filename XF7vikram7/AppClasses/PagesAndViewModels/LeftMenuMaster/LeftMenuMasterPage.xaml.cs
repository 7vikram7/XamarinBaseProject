namespace XF7vikram7.AppClasses.PagesAndViewModels.LeftMenuMaster
{
    using System;
    using System.Collections.Generic;
    using XF7vikram7.AppClasses.PagesAndViewModels.Base;
    using XF7vikram7.AppClasses.PagesAndViewModels.LeftMenuMaster;
    using Xamarin.Forms;

    public partial class LeftMenuMasterPage : BasePage
    {
        #region Fields
        #endregion

        #region Constructor
        public LeftMenuMasterPage() : this(new LeftMenuMasterPageModel())
        {
        }

        public LeftMenuMasterPage(LeftMenuMasterPageModel model)
        {
            this.PageModel = model;
            this.BindingContext = model;
            model.CorrespondingPage = this;

            this.InitializeComponent();
        }

        #endregion

        #region Properties
        public ListView ListView
        {
            get
            {
                return this.listView;
            }
        }

        #endregion

        #region Events
        #endregion

        #region Public Methods
        #endregion

        #region Private Methods
        #endregion
    }
}
