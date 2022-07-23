using System;
using System.Windows.Input;
using FreshMvvm;
using Viaduct.Models;
using Viaduct.Resources;
using Viaduct.Resources.Controls;
using Viaduct.Services;
using Viaduct.Services.Implementation;
using Xamarin.Forms;

namespace Viaduct.PageModels
{
    internal class ReportPageModel : FreshBasePageModel
    {
        private readonly ILoggedUserService _userService;
        private readonly IReportService _reportService;
        private string reportTitle;

        public ReportPageModel(ILoggedUserService userService, IReportService reportService)
        {
            _userService = userService;
            _reportService = reportService;
            reportTitle = $"{Strings.ReportPage_ReportFromDay} {OKCancelDatePicker.ReportPickedDate}";
            CheckIfReportExists();
        }

        public void CheckIfReportExists()
        {

        }

        public string ReportTitle
        {
            get => reportTitle;
            set => reportTitle = value;
        }
    }
}