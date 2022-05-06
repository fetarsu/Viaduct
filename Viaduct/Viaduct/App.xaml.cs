using FreshMvvm;
using System;
using Viaduct.PageModels;
using Viaduct.Services;
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
            var page = FreshPageModelResolver.ResolvePageModel<ChooseUserViewModel>();
            var basicNavContainer = new FreshNavigationContainer(page);
            MainPage = basicNavContainer;
        }

        public void SetupIOC()
        {
            FreshIOC.Container.Register<ICashMachine, CashMachine>();
            FreshIOC.Container.Register<IReportService, ReportService>();
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
