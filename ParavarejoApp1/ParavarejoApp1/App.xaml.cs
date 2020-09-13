using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ParavarejoApp1.Services;
using ParavarejoApp1.Views;
using System.Globalization;

namespace ParavarejoApp1
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
            //CultureInfo.CurrentCulture = new CultureInfo("pt-BR");
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
