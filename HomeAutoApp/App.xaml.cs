using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HomeAutoApp
{
    public partial class App : Application
    {
        public static string DB_PATH = string.Empty;

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

        public App(string DB_Path)
        {
            InitializeComponent();

            DB_PATH = DB_Path;

            var tabbedPage = new TabbedPage();
            var mainPage = new MainPage();
            var settingsPage = new SettingsPage();

            tabbedPage.Children.Add(mainPage);
            tabbedPage.Children.Add(settingsPage);

            tabbedPage.BarBackgroundColor = Color.FromHex("2D384D");

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
