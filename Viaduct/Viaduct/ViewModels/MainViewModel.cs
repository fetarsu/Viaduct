using FreshMvvm;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Viaduct.Views.Popups;
using Xamarin.Forms;

namespace Viaduct.PageModels
{
    internal class MainViewModel : FreshBasePageModel
    {
        public MainViewModel()
        {
            GoToReportCommand = new Command(GoToReport);
        }

        public ICommand GoToReportCommand { get; }

        [Obsolete]
        public async void GoToReport()
        {
            await PopupNavigation.PushAsync(new ChooseDayPopup());
            //await CoreMethods.PushPageModel<ReportViewModel>(null, true);
        }
    }
}
