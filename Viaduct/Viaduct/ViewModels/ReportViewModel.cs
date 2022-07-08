using System;
using System.Windows.Input;
using FreshMvvm;
using Viaduct.Models;
using Viaduct.Services;
using Viaduct.Services.Implementation;
using Xamarin.Forms;

namespace Viaduct.PageModels
{
    internal class ReportViewModel : FreshBasePageModel
    {
        public bool _isVisibleAddReportButton;
        private readonly IUserService _userService;

        public ReportViewModel(IUserService userService)
        {
            _userService = userService;
            IsVisibleAddReportButton = ShowAddReportIfUserLogged();
        }

        public bool IsVisibleAddReportButton
        {
            get => _isVisibleAddReportButton;
            set => _isVisibleAddReportButton = value;
        }

        public bool ShowAddReportIfUserLogged()
        {
            if(_userService.loggedUser != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //private async void StartMethod()
        //{
        //    await CoreMethods.PushPageModel<ChooseUserViewModel>(null, true);
        //}
    }
}