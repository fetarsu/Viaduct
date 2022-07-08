using FreshMvvm;
using System;
using Viaduct.PageModels;
using Viaduct.Services;
using Viaduct.Services.Data;
using Viaduct.Services.Data.Implementation;
using Viaduct.Services.Implementation;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Viaduct
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            SetupIOC();
            SetUpNavigation();

        }

        public void SetUpNavigation()
        {
            //var page = FreshPageModelResolver.ResolvePageModel<MainViewModel>();
            //var basicNavContainer = new FreshNavigationContainer(page);
            //MainPage = basicNavContainer;
            var tabbedNavigation = new FreshTabbedNavigationContainer();
            tabbedNavigation.AddTab<MainViewModel>("Logowanie", "user.png", null);
            tabbedNavigation.AddTab<ReportMenuPageModel>("Raport", "report.png", null);
            MainPage = tabbedNavigation;
        }

        public void SetupIOC()
        {
            FreshIOC.Container.Register<ICashMachine, CashMachine>();
            FreshIOC.Container.Register<IReportService, ReportService>();
            FreshIOC.Container.Register<IUserDataService, UserDataService>();
            FreshIOC.Container.Register<IUserService, UserService>();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
