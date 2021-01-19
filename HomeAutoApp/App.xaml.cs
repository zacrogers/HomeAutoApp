using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HomeAutoApp
{
    public partial class App : Application
    {
        public static string DB_PATH = string.Empty;
        public readonly int NUM_ROOMS = 4;

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
            //var mainPage = new MainPage();
            var page0 = new MainPage(0);
            var page1 = new MainPage(1);
            var page2 = new MainPage(2);
            var page3 = new MainPage(3);
            var settingsPage = new SettingsPage(NUM_ROOMS);

            //tabbedPage.Children.Add(mainPage);
            tabbedPage.Children.Add(page0);
            tabbedPage.Children.Add(page1);
            tabbedPage.Children.Add(page2);
            tabbedPage.Children.Add(page3);
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
