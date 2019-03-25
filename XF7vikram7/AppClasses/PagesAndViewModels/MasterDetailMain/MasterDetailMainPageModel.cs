namespace XF7vikram7.AppClasses.PagesAndViewModels.MasterDetailMain
{
    using System;
    using System.Windows.Input;
    using XF7vikram7.AppClasses.PagesAndViewModels.Base;
    using Xamarin.Forms;

    public class MasterDetailMainPageModel : BasePageModel
    {
        #region Fields
        private string emailAddress;

        #endregion

        #region Constructor
        public MasterDetailMainPageModel()
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
        #endregion

        #region Public Methods
        #endregion

        #region Private Methods
        #endregion
    }
}
