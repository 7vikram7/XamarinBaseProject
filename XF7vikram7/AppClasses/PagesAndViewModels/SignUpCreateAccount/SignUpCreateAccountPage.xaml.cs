namespace XF7vikram7.AppClasses.PagesAndViewModels.SignUpCreateAccount
{
    using System;
    using System.Collections.Generic;
    using XF7vikram7.AppClasses.PagesAndViewModels.Base;
    using Xamarin.Forms;

    public partial class SignUpCreateAccountPage : BasePage
    {
        public SignUpCreateAccountPage() : this(new SignUpCreateAccountPageModel())
        {
        }

        public SignUpCreateAccountPage(SignUpCreateAccountPageModel model)
        {
            this.BindingContext = model;
            model.CorrespondingPage = this;
            this.InitializeComponent();
        }
    }
}