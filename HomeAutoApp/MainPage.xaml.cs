using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HomeAutoApp
{
    public partial class MainPage : ContentPage
    {

        public PowerNode powerNode;
        string ipAddress = string.Empty;

        public MainPage()
        {
            powerNode = new PowerNode("http://192.168.1.79", 4);

            this.Title = "Bedroom";

            InitializeComponent();
        }

        private void Button1_Clicked(object sender, EventArgs e)
        {
            var states = powerNode.getStates();

            if (states.ElementAt(0)) 
            {
                powerNode.channelOff(1);
            }
            else 
            {
                powerNode.channelOn(1);
            }

        }

        private void Button2_Clicked(object sender, EventArgs e)
        {

        }

        private void Button3_Clicked(object sender, EventArgs e)
        {

        }

        private void Button4_Clicked(object sender, EventArgs e)
        {

        }
    }
}
