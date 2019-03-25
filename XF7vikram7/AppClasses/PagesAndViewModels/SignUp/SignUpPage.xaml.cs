namespace XF7vikram7.AppClasses.PagesAndViewModels.SignUp
{
    using Xamarin.Forms;
    using XF7vikram7.AppClasses.PagesAndViewModels.Base;

    public partial class SignUpPage : BasePage
    {
        public SignUpPage() : this(new SignUpPageModel())
        {
        }

        public SignUpPage(SignUpPageModel model)
        {
            this.PageModel = model;
            this.BindingContext = model;
            model.CorrespondingPage = this;
            this.InitializeComponent();
        }

        void HandleEmail_TextChanged(object sender,
                                     Xamarin.Forms.TextChangedEventArgs e)
        {
            if (sender is Entry)
            {
                SignUpPageModel model = this.PageModel as SignUpPageModel;
                Entry emailEntry = sender as Entry;
                model.OnEmailTextChanged(emailEntry.Text);
            }
        }
    }
}
