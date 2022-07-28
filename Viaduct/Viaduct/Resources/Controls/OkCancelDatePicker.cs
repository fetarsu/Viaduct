using FreshMvvm;
using System;
using Viaduct.PageModels;
using Xamarin.Forms;

namespace Viaduct.Resources.Controls
{
    public class OkCancelDatePicker : DatePicker
    {
        public static readonly BindableProperty UserCancelledProperty = BindableProperty.Create(nameof(UserCancelled), typeof(bool), typeof(OkCancelDatePicker), false);
        public static DateTime ReportPickedDate;

        public bool UserCancelled
        {
            get => (bool)GetValue(UserCancelledProperty);
            set => SetValue(UserCancelledProperty, value);
        }

        public void OnPickerClosed()
        {
            if (UserCancelled)
            {
                // User cancelled.
                _ = 0;   // Dummy code, to set a breakpoint on. You can remove this.
            }
            else
            {
                ReportPickedDate = this.Date;
                var page = FreshPageModelResolver.ResolvePageModel<ReportPageModel>();
                var basicNavContainer = new FreshNavigationContainer(page);
                Application.Current.MainPage = basicNavContainer;
            }
        }
    }
}