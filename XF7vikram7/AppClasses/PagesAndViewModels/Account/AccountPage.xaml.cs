namespace XF7vikram7.AppClasses.PagesAndViewModels.Account
{
    using XF7vikram7.AppClasses.PagesAndViewModels.Base;

    public partial class AccountPage : BasePage
    {
        public AccountPage() : this(new AccountPageModel())
        {
        }

        public AccountPage(AccountPageModel model)
        {
            this.BindingContext = model;
            model.CorrespondingPage = this;
            this.InitializeComponent();
        }
    }
}