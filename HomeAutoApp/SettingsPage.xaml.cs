using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HomeAutoApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsPage : ContentPage
    {
        public SettingsPage()
        {
            InitializeComponent();

            this.Title = "Settings";
        }

        private void NameEntry_Completed(object sender, EventArgs e)
        {

        }

        private void IpEntry_Completed(object sender, EventArgs e)
        {

        }
    }
}