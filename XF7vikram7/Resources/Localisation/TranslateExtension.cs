namespace XF7vikram7
{
    using System;
    using System.Globalization;
    using System.Reflection;
    using System.Resources;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    // You exclude the 'Extension' suffix when using in Xaml markup
    [ContentProperty("Text")]
    public class TranslateExtension : IMarkupExtension
    {
        private const string ResourceId = "XF7vikram7.Resources.AppResources";

        private static readonly Lazy<ResourceManager> ResMgr = new
        Lazy<ResourceManager>(() => new ResourceManager(
            ResourceId,
            typeof(TranslateExtension).GetTypeInfo().Assembly));

        private readonly CultureInfo ci;

        public TranslateExtension()
        {
            if (Device.RuntimePlatform == Device.iOS
                    || Device.RuntimePlatform == Device.Android)
            {
                this.ci = DependencyService.Get<ILocale>().GetCurrentCultureInfo();
            }
        }

        public string Text
        {
            get;
            set;
        }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (this.Text == null)
            {
                return string.Empty;
            }

            var translation = ResMgr.Value.GetString(this.Text, this.ci);

            if (translation == null)
            {
#if DEBUG
                throw new ArgumentException(
                    string.Format(
                        "Key '{0}' was not found in resources '{1}' for culture '{2}'.",
                        this.Text
                        , ResourceId,
                        this.ci.Name),
                    "Text");
#else
                translation = Text; // returns the key, which GETS DISPLAYED TO THE USER
#endif
            }

            return translation;
        }
    }
}
