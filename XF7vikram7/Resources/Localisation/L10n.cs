namespace XF7vikram7
{
    using System;
    using System.Diagnostics;
    using System.Globalization;
    using System.Reflection;
    using System.Resources;
    using Xamarin.Forms;

    public class L10n
    {
        private const string ResourceId = "XF7vikram7.Resources.AppResources";

        public static void SetLocale(CultureInfo ci)
        {
            DependencyService.Get<ILocale>().SetLocale(ci);
        }

        // <remarks>
        // Maybe we can cache this info rather than querying every time
        // </remarks>
        [Obsolete]
        public static string Locale()
        {
            return DependencyService.Get<ILocale>().GetCurrentCultureInfo().ToString();
        }

        public static string Localize(string key, string comment)
        {
            // Platform-specific
            ResourceManager temp = new ResourceManager(
                ResourceId,
                typeof(L10n).GetTypeInfo().Assembly);
            Debug.WriteLine("Localize " + key);

            string result = string.Empty;
            try
            {
                CultureInfo ci = DependencyService.Get<ILocale>().GetCurrentCultureInfo();

                // Uncomment to Test required Culture
                // CultureInfo ci = new CultureInfo("");
                result = temp.GetString(key, ci);

                if (result == null)
                {
                    result = key; // HACK: return the key, which GETS displayed to the user
                }

                return result;
            }
            catch (Exception e)
            {
                if (e != null)
                {
                    result = key; // HACK: return the key, which GETS displayed to the user
                }
            }

            return result;
        }
    }
}
