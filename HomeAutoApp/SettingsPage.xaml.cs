using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using HomeAutoApp.Models;

namespace HomeAutoApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsPage : ContentPage
    {
        int _numRooms = 0;
        public SettingsPage()
        {
            InitializeComponent();

            this.Title = "Settings";
        }

        public SettingsPage(int numRooms)
        {
            _numRooms = numRooms;
            InitializeComponent();

            BindingContext = new ViewModels.SettingsPageViewModel();

            this.Title = "Settings";
        }

        private void Button_Clicked(object sender, EventArgs e)
        {

        }
    }
}