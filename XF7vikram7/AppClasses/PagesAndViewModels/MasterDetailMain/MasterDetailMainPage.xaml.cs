namespace XF7vikram7.AppClasses.PagesAndViewModels.MasterDetailMain
{
    using XF7vikram7.AppClasses.PagesAndViewModels.Home;
    using XF7vikram7.AppClasses.PagesAndViewModels.LeftMenuMaster;
    using Xamarin.Forms;
    using XF7vikram7.AppClasses.DataModels;

    public partial class MasterDetailMainPage : MasterDetailPage
    {
        #region Fields
        #endregion

        #region Constructor
        public MasterDetailMainPage() : this(new MasterDetailMainPageModel())
        {
        }

        public MasterDetailMainPage(MasterDetailMainPageModel model)
        {
            // TODO: check if this can be done from XAML
            NavigationPage.SetHasNavigationBar(this, false);
            this.BindingContext = model;
            this.InitializeComponent();

            this.SetLeftMenuFacilitiesAndDetailPage();

            masterPage.ListView.ItemSelected += this.OnItemSelected;
        }

        #endregion

        #region Properties
        #endregion

        #region Events
        #endregion

        #region Page Lifecycle
        protected override bool OnBackButtonPressed()
        {
            return true;
        }

        #endregion

        #region Public Methods
        public void SetLeftMenuFacilitiesAndDetailPage()
        {
            LeftMenuMasterPage leftMenuPage = this.masterPage as LeftMenuMasterPage;
            LeftMenuMasterPageModel leftMenuPageModel = leftMenuPage.PageModel as
                    LeftMenuMasterPageModel;

            leftMenuPageModel.PopulateLeftMenuItemList();

            if (SessionData.Instance.LeftMenuItems.Count > 0)
            {
                HomePageModel homePageModel = new HomePageModel()
                {
                    Title = SessionData.Instance.LeftMenuItems[0].Title
                };

                SetDetailPage(homePageModel);
            }
            else
            {
            HomePageModel homePageModel = new HomePageModel()
            {
                Title = "Test Title",
                SubTitle = "Test Sub Title"
            };

            SetDetailPage(homePageModel);
            }
        }

        #endregion

        #region Private Methods

        // TODO: check if this can be moved to PageModel Via Binding
        private void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as LeftMenuItemModel;
            if (item != null)
            {
                HomePageModel homePageModel= new HomePageModel();
                homePageModel.Title = item.Title;

                SetDetailPage(homePageModel);

                masterPage.ListView.SelectedItem = null;
                this.IsPresented = false;
            }

            ((ListView)sender).SelectedItem = null; // de-select the row

        }

        private void SetDetailPage(HomePageModel homePageModel)
        {
            App.MasterSliderNavigationPage = new NavigationPage(new HomePage(
                homePageModel));
            this.Detail = App.MasterSliderNavigationPage;
        }
        #endregion
    }
}
