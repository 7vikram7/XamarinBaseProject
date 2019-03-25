namespace XF7vikram7.AppClasses.PagesAndViewModels.ForgotPassword
{
    using System;
    using System.Collections.Generic;
    using XF7vikram7.AppClasses.PagesAndViewModels.Base;
    using Xamarin.Forms;

    public partial class ForgotPasswordPage : BasePage
    {
        public ForgotPasswordPage() : this(new ForgotPasswordPageModel())
        {
        }

        public ForgotPasswordPage(ForgotPasswordPageModel model)
        {
            this.BindingContext = model;
            model.CorrespondingPage = this;
            this.InitializeComponent();
        }
    }
}
