namespace XF7vikram7.AppClasses.PagesAndViewModels.Home
{
    using XF7vikram7.AppClasses.PagesAndViewModels.Base;

    public partial class HomePage : BasePage
    {
        #region Fields
        #endregion

        #region Constructor
        public HomePage() : this(new HomePageModel())
        {
        }

        public HomePage(HomePageModel model)
        {
            this.PageModel = model;
            this.BindingContext = model;
            model.CorrespondingPage = this;
            this.InitializeComponent();
        }

        #endregion

        #region Object Properties

        #endregion

        #region Events
        #endregion

        #region Public Methods
        #endregion

        #region Private Methods
        #endregion
    }
}