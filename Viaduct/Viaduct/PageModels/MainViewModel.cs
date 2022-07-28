using FreshMvvm;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Viaduct.Models;
using Viaduct.Pages;
using Viaduct.Services;
using Viaduct.Services.Data;
using Viaduct.Views.Popups;
using Xamarin.Forms;

namespace Viaduct.PageModels
{
    internal class MainViewModel : FreshBasePageModel
    {
        TabbedPage _tabbedPage;
        private string _login;
        private IUserDataService _userDataService;
        private IUserService _userService;

        [Obsolete]
        public MainViewModel(IUserDataService userDataService, IUserService userService)
        {
            _tabbedPage = App.Current.MainPage as TabbedPage;
            _userDataService = userDataService;
            _userService = userService;
            LoginCommand = new Command(TryToLogin);
        }

        public ICommand GoToReportCommand { get; }
        public ICommand LoginCommand { get; set; }
        public string Login
        {
            get => _login;
            set => _login = value;
        }

        public async void TryToLogin(object sender)
        {
            var passwordEntry = sender as Xamarin.Forms.Entry;
            var user = await _userDataService.GetUserByLogin(_login);
            if (user != null)
            {
                try
                {
                    var result = PasswordHasher.Verify(passwordEntry.Text, user.Password);
                    if (result)
                    {
                        _userService.loggedUser = user;
                        await AddTabAsync();
                    }
                    else
                    {
                        //popup z informacją o niepoprawnym haśle
                    }
                }
                catch (Exception ex)
                {

                }
            }
        }

        public async Task AddTabAsync()
        {
            //var tabbedNavigation = new FreshTabbedNavigationContainer("secondNavPage");
            //tabbedNavigation.AddTab<MainViewModel>("Contacts2", "contacts.png", null);
            //await CoreMethods.PushNewNavigationServiceModal(tabbedNavigation);
        }

        [Obsolete]
        public async void GoToReport()
        {
            await PopupNavigation.PushAsync(new ChooseDayPopup());
            //await CoreMethods.PushPageModel<ReportViewModel>(null, true);
        }
    }
}
