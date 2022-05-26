using FreshMvvm;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Viaduct.Models;
using Viaduct.Services.Data;
using Xamarin.Forms;

namespace Viaduct.PageModels
{
    public class ChooseUserViewModel : FreshBasePageModel
    {
        IUserService _userService;
        public ChooseUserViewModel(IUserService userService)
        {
            _userService = userService;
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
            var user = new User()
            {
                Name = "aa12",
                Password = "ssss",
                Permission = 1
            };

            var x = _userService.SaveUserAsync(user, true);
 //           GoToMainPage();
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
