namespace XF7vikram7.AppClasses.Common.Extensions

{
    using System;
    using Xamarin.Forms;

    public static class ObjectExtensions
    {
        public static bool IsObjectADisabledViewIfAnEnabledViewDisableFor3Seconds(
            this object obj)
        {
            if (obj == null)
            {
                return false;
            }
            else if (obj is View)
            {
                View currentView = obj as View;

                if (currentView.IsEnabled)
                {
                    currentView.DisableViewFor3Seconds();
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
