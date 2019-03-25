namespace XF7vikram7.AppClasses.PagesAndViewModels.LeftMenuMaster
{
    using System;
    using System.Windows.Input;
    using XF7vikram7.AppClasses.DataModels;
    using XF7vikram7.AppClasses.PagesAndViewModels.Base;
    using Xamarin.Forms;

    // TODO: create a separate list item for the cell instead of defining the UI in the list view
    public class LeftMenuItemModel : BaseItemModel
    {
        #region Fields
        private bool isSelected;

        #endregion

        #region Constructor
        public LeftMenuItemModel()
        {
        }

        #endregion

        #region Properties
  
        public string Title
        {
            get;
            set;
        }

        public bool IsSelected
        {
            get
            {
                return this.isSelected;
            }

            set
            {
                if (this.isSelected != value)
                {
                    this.isSelected = value;
                    this.OnPropertyChanged("IsSelected");
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
        private void OnCommand(object obj)
        {
        }
        #endregion
    }
}
