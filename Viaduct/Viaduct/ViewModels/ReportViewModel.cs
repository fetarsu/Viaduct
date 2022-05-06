using System;
using System.Windows.Input;
using FreshMvvm;
using Viaduct.Models;
using Viaduct.Services.Implementation;
using Xamarin.Forms;

namespace Viaduct.PageModels
{
    public class ReportViewModel : FreshBasePageModel
    {
        private readonly ReportService _reportService = new ReportService();
        private readonly UserService _userService = new UserService();
        public ReportViewModel()
        {
            StartCommand = new Command(StartMethod);
            AddCommand = new Command(AddMethod);  
            CloseCommand = new Command(CloseMethod);  
            ReopenCommand = new Command(ReopenMethod);
        }
        
        public ICommand StartCommand { get; }
        public ICommand AddCommand { get; }
        public ICommand CloseCommand { get; }
        public ICommand ReopenCommand { get; }


        public string ReportState { get; set; }
        
        private async void StartMethod()
        {
            await CoreMethods.PushPageModel<ChooseUserViewModel>(null, true);
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