using FreshMvvm;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Viaduct.Services;
using Xamarin.Forms;

namespace Viaduct.PageModels
{
    internal class ReportMenuPageModel : FreshBasePageModel
    {
        public bool _isVisibleAddReportButton;
        private readonly IUserService _userService;

        public ReportMenuPageModel(IUserService userService)
        {
            _userService = userService;
            IsVisibleAddReportButton = ShowAddReportIfUserLogged();
            GoToReportCommand = new Command(GoToReport);
            GoToReportCommand = new Command(GoToReport);
        }

        public ICommand GoToReportCommand { get; }

        public bool IsVisibleAddReportButton
        {
            get => _isVisibleAddReportButton;
            set => _isVisibleAddReportButton = value;
        }

        public bool ShowAddReportIfUserLogged()
        {
            //if (_userService.loggedUser != null)
            //{
                return true;
            //}
            //else
            //{
            //    return false;
            //}
        }

        public void GoToReport(object sender)
        {
            var pickerDate = sender as Xamarin.Forms.DatePicker;
            pickerDate.IsVisible = true;
            pickerDate.Focus();
        }

        //private async void StartMethod()
        //{
        //    await CoreMethods.PushPageModel<ChooseUserViewModel>(null, true);
        //}
    }
}
