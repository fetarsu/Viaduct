using System;
using System.Windows.Input;
using FreshMvvm;
using Viaduct.Models;
using Viaduct.Services.Implementation;
using Xamarin.Forms;

namespace Viaduct.PageModels
{
    public class ReportPageModel : FreshBasePageModel
    {
        private readonly ReportService _reportService = new ReportService();
        private readonly UserService _userService = new UserService();
        public ReportPageModel()
        {
            StartCommand = new Command(StartMethod);
            AddCommand = new Command(AddMethod);  
            CloseCommand = new Command(CloseMethod);  
            ReopenCommand = new Command(ReopenMethod);

            //var report = _reportService.GetReport(DateTime.Now);
            //var x = report.Result;
        }
        
        public ICommand StartCommand { get; }
        public ICommand AddCommand { get; }
        public ICommand CloseCommand { get; }
        public ICommand ReopenCommand { get; }


        public string ReportState { get; set; }
        
        private async void StartMethod()
        {
            //Report report2 = new Report()
            //{
            //    State = 0,
            //    CardIncome = 0,
            //    Date = DateTime.Now,
            //    Revenue = 0
            //};
            //_reportService.AddReport(report2);

            //Report report2 = new Report()
            //{
            //    //Name = "aaxx"
            //};
            //await _reportService.AddReport(report2);
            await CoreMethods.PushPageModel<LoginPageModel>(null, true);
        }
        private void AddMethod()
        {
            throw new NotImplementedException();
        }
        private void CloseMethod()
        {
            throw new NotImplementedException();
        }
        private void ReopenMethod()
        {
            throw new NotImplementedException();
        }
    }
}