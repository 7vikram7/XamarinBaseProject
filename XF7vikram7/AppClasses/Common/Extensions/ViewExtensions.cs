namespace XF7vikram7.AppClasses.Common.Extensions
{
    using System;
    using Xamarin.Forms;

    public static class ViewExtensions
    {
        private const long KTicksInThreeSeconds = 30000000;

        public static void DisableViewFor3Seconds(this View currentView)
        {
            currentView.IsEnabled = false;

            Device.StartTimer(
                new TimeSpan(
                    KTicksInThreeSeconds),
                () =>
            {
                currentView.IsEnabled = true;

                return false;
            });

            return;
        }
    }
}