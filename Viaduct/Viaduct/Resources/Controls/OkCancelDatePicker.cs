using FreshMvvm;
using System;
using System.Collections.Generic;
using System.Text;
using Viaduct.PageModels;
using Viaduct.Services;
using Xamarin.Forms;

namespace Viaduct.Resources.Controls
{
    public class OKCancelDatePicker : DatePicker
    {
        public static readonly BindableProperty UserCancelledProperty = BindableProperty.Create(nameof(UserCancelled), typeof(bool), typeof(OKCancelDatePicker), false);
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