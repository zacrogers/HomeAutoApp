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


        private void Button_Clicked(object sender, EventArgs e)
        {
            PowerNode node = new PowerNode(NameEntry.Text, IpEntry.Text, 4);

            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.DB_PATH))
            {
                conn.CreateTable<PowerNode>();
                var numRows = conn.Insert(node);

                if(numRows > 0)
                {
                    DisplayAlert("Success", $"{NameEntry.Text} Node added", "Ok");
                }
            }
        }
    }
}