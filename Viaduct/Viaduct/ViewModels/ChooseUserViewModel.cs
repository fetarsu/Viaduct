using FreshMvvm;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Viaduct.PageModels
{
    public class ChooseUserViewModel : FreshBasePageModel
    {
        public ChooseUserViewModel()
        {
            AdminCommand = new Command(StartAsAdmin);
            ManagerCommand = new Command(StartAsManager);
            DelivererCommand = new Command(StartAsDelivere);
            UserCommand = new Command(StartAsUser);
        }

        public ICommand AdminCommand { get; }
        public ICommand ManagerCommand { get; }
        public ICommand DelivererCommand { get; }
        public ICommand UserCommand { get; }

        private void StartAsAdmin()
        {
            GoToMainPage();
        }
        private void StartAsManager()
        {
            GoToMainPage();
        }
        private void StartAsDelivere()
        {
            GoToMainPage();
        }
        private void StartAsUser()
        {
            GoToMainPage();
        }

        private async void GoToMainPage()
        {
            await CoreMethods.PushPageModel<MainViewModel>(null, true);
        }


    }
}
