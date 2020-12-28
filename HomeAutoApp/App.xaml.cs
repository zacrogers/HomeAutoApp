using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HomeAutoApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            var tabbedPage = new TabbedPage();
            var mainPage = new MainPage();
            var settingsPage = new SettingsPage();

            tabbedPage.Children.Add(mainPage);
            tabbedPage.Children.Add(settingsPage);

            MainPage = tabbedPage;
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
