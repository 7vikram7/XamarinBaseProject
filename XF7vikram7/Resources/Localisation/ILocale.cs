namespace XF7vikram7
{
    using System;
    using System.Globalization;

    // <summary>
    // Implementations of this interface MUST convert iOS and Android
    // platform-specific locales to a value supported in .NET because
    // ONLY valid .NET cultures can have their RESX resources loaded and used.
    // </summary>
    // <remarks>
    // Lists of valid .NET cultures can be found here:
    //   http://www.localeplanet.com/dotnet/
    //   http://www.csharp-examples.net/culture-names/
    // You should always test all the locales implemented in your application.
    // </remarks>
    public interface ILocale
    {
        // <summary>
        // This method must evaluate platform-specific locale settings
        // and convert them (when necessary) to a valid .NET locale.
        // </summary>
        CultureInfo GetCurrentCultureInfo();

        // <summary>
        // CurrentCulture and CurrentUICulture must be set in the platform project,
        // because the Thread object can't be accessed in a PCL.
        // </summary>
        void SetLocale(CultureInfo ci);
    }

    // <summary>
    // Helper class for splitting locales like
    //   iOS: ms_MY, gsw_CH
    //   Android: in-ID
    // into parts so we can create a .NET culture (or fallback culture)
    // </summary>
    public class PlatformCulture
    {
        public PlatformCulture(string platformCultureString)
        {
            if (string.IsNullOrEmpty(platformCultureString))
            {
                throw new ArgumentException(
                    "Expected culture identifier",
                    "platformCultureString");    // in C# 6 use nameof(platformCultureString)
            }

            this.PlatformString = platformCultureString.Replace(
                                      "_",
                                      "-"); // .NET expects dash, not underscore
            var dashIndex = this.PlatformString.IndexOf(
                                "-",
                                StringComparison.Ordinal);
            if (dashIndex > 0)
            {
                var parts = this.PlatformString.Split('-');
                this.LanguageCode = parts[0];
                this.LocaleCode = parts[1];
            }
            else
            {
                this.LanguageCode = string.Empty;
                this.LocaleCode = string.Empty;
            }
        }

        public string PlatformString
        {
            get;

            private set;
        }

        public string LanguageCode
        {
            get;

            private set;
        }

        public string LocaleCode
        {
            get;
            private set;
        }

        public override string ToString()
        {
            return this.PlatformString;
        }
    }
}
