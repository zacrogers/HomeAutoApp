﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using HomeAutoApp.Models;

namespace HomeAutoApp
{
    public partial class MainPage : ContentPage
    {
        private int _pageIndex;

        public PowerNode powerNode;
        public SensorNode sensorNode;

        public string onColor = "00662C";
        public string offColor = "95110F";

        public List<string> sensorVals;

        public string light = "Test";

        Color[] buttonColors = { };

        public MainPage()
        {
            powerNode = new PowerNode("Bedroom", "http://192.168.1.79", 4);
            sensorNode = new SensorNode("Bedroom", "http://192.168.1.92");

            sensorVals = sensorNode.getValues();

            Title = powerNode.Name;

            InitializeComponent();
            updateButtonColors();

            LightLabel.Text = $"Light:{sensorVals[0]}";
            TempLabel.Text = $"Temp:{sensorVals[1]}";
            HumidLabel.Text = $"Hum:{sensorVals[2]}";
        }

        public MainPage(int pageIndex)
        {
            _pageIndex = pageIndex;

            powerNode = new PowerNode("Bedroom", "http://192.168.1.79", 4);
            sensorNode = new SensorNode("Bedroom", "http://192.168.1.92");

            sensorVals = sensorNode.getValues();

            Title = powerNode.Name;

            InitializeComponent();
            updateButtonColors();

            LightLabel.Text = $"Light:{sensorVals[0]}";
            TempLabel.Text = $"Temp:{sensorVals[1]}";
            HumidLabel.Text = $"Hum:{sensorVals[2]}";
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            sensorVals = sensorNode.getValues();
            LightLabel.Text = $"Light:{sensorVals[0]}";
            TempLabel.Text = $"Temp:{sensorVals[1]}";
            HumidLabel.Text = $"Hum:{sensorVals[2]}";
        }

        void updateButtonColors()
        {
            var states = powerNode.getStates();

            Button1.BackgroundColor = states.ElementAt(0) ? Color.FromHex(onColor) : Color.FromHex(offColor);
            Button2.BackgroundColor = states.ElementAt(1) ? Color.FromHex(onColor) : Color.FromHex(offColor);
            Button3.BackgroundColor = states.ElementAt(2) ? Color.FromHex(onColor) : Color.FromHex(offColor);
            Button4.BackgroundColor = states.ElementAt(3) ? Color.FromHex(onColor) : Color.FromHex(offColor);
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

            updateButtonColors();
        }

        private void Button2_Clicked(object sender, EventArgs e)
        {
            var states = powerNode.getStates();

            if (states.ElementAt(1))
            {
                powerNode.channelOff(2);
            }
            else
            {
                powerNode.channelOn(2);
            }

            updateButtonColors();
        }

        private void Button3_Clicked(object sender, EventArgs e)
        {
            var states = powerNode.getStates();

            if (states.ElementAt(2))
            {
                powerNode.channelOff(3);
            }
            else
            {
                powerNode.channelOn(3);
            }

            updateButtonColors();
        }

        private void Button4_Clicked(object sender, EventArgs e)
        {
            var states = powerNode.getStates();

            if (states.ElementAt(3))
            {
                powerNode.channelOff(4);
            }
            else
            {
                powerNode.channelOn(4);
            }

            updateButtonColors();
        }
    }
}
