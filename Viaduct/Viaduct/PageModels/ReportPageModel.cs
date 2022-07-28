using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using FreshMvvm;
using Viaduct.Models;
using Viaduct.Resources;
using Viaduct.Resources.Controls;
using Viaduct.Services;
using Viaduct.Services.Data;
using Xamarin.Forms;

namespace Viaduct.PageModels
{
    public class ReportPageModel : FreshBasePageModel, INotifyPropertyChanged
    {
        private List<Transaction> transactions;
        Report readReport;
        private Transaction selectedItem;
        Transaction transaction = new Transaction();
        private bool isRefreshing;
        
        private readonly IReportService _reportService;
        private readonly ITransactionDataService _transactionDataService;
        
        public ReportPageModel(IReportService reportService, ITransactionDataService transactionDataService)
        {
            _reportService = reportService;
            _transactionDataService = transactionDataService;
            _reportService.ReportDate = OkCancelDatePicker.ReportPickedDate;
            string date = string.Format("{0}-{1}-{2}", _reportService.ReportDate.Year, _reportService.ReportDate.Month, _reportService.ReportDate.Day);
            ReportTitle = $"{Strings.ReportPage_ReportTitle} {_reportService.ReportDate.ToShortDateString()}";
            ReadTransactions(date);
            RefreshCommand = new Command(CmdRefresh);
        }

        public async void ReadTransactions(string date)
        {
            Transactions = await _transactionDataService.ReadTransactionsFromOneDay(date);
        }
        
        public string ReportTitle { get; set; }
        
        public List<Transaction> Transactions
        {
            get { return transactions; }
            set { transactions = value; OnPropertyChanged(nameof(Transactions)); }
        }
        
        public Transaction SelectedTransaction
        {
            get { return selectedItem; }
            set
            {
                selectedItem = value;
            }
        }
        
        private async void CmdRefresh()
        {
            IsRefreshing = true;
            await Task.Delay(3000);
            IsRefreshing = false;
        }
        
        public bool IsRefreshing
        {
            get { return isRefreshing; }
            set { isRefreshing = value; OnPropertyChanged(nameof(IsRefreshing)); }
        }
        public ICommand RefreshCommand { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }
    }
}