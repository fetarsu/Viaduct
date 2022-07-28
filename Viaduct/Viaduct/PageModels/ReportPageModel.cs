using System;
using FreshMvvm;
using Viaduct.Resources;
using Viaduct.Resources.Controls;
using Viaduct.Services;

namespace Viaduct.PageModels
{
    public class ReportPageModel : FreshBasePageModel
    {
        private readonly IReportService _reportService;
        
        public ReportPageModel(IReportService reportService)
        {
            _reportService = reportService;
            _reportService.ReportDate = OkCancelDatePicker.ReportPickedDate;
            ReportTitle = $"{Strings.ReportPage_ReportTitle} {_reportService.ReportDate.ToShortDateString()}";
        }
        
        
        public string ReportTitle { get; set; }
    }
}