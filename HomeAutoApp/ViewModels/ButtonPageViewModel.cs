using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Xamarin.Forms;
using System.Text;
using System.Linq;

namespace HomeAutoApp.ViewModels
{
    class ButtonPageViewModel : INotifyPropertyChanged
    {
        private PowerNode powerNode;
        private SensorNode sensorNode;
        private static readonly string onColor = "00662C";
        private static readonly string offColor = "95110F";

        private List<bool> powerNodeStates;
        private List<Color> buttonColors;

        public ButtonPageViewModel()
        {
            powerNode = new PowerNode("Bedroom", "http://192.168.1.79", 4);
            //sensorNode = new SensorNode("Bedroom", "http://192.168.1.92");

            ButtonColors = new List<Color>();

            powerNodeStates = powerNode.getStates();

            foreach (int val in Enumerable.Range(0, powerNodeStates.Count))
            {
                ButtonColors.Add(Color.FromHex(offColor));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        #region Properties

        public List<bool> PowerNodeStates
        {
            get { return powerNodeStates; }
            set
            {
                powerNodeStates = value;
                OnPropertyChanged("PowerNodeStates");

                List<Color> newColors = new List<Color>();

                for (int i = 0; i < powerNodeStates.Count; i++)
                {
                    if(powerNodeStates[i])
                    {
                        newColors.Add(Color.FromHex(onColor));
                    }
                    else 
                    {
                        newColors.Add(Color.FromHex(offColor));
                    }
                }
                ButtonColors = newColors;
            }
        }

        public List<Color> ButtonColors
        {
            get { return buttonColors; }
            set
            {
                buttonColors = value;
                OnPropertyChanged("ButtonColors");
            }
        }

        #endregion

        #region Methods
        void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private void Button1_Clicked()
        {
            PowerNodeStates = powerNode.getStates();

            if (PowerNodeStates.ElementAt(0))
            {
                powerNode.channelOff(1);
            }
            else
            {
                powerNode.channelOn(1);
            }
        }

        private void Button2_Clicked()
        {
            PowerNodeStates = powerNode.getStates();

            if (PowerNodeStates.ElementAt(1))
            {
                powerNode.channelOff(2);
            }
            else
            {
                powerNode.channelOn(2);
            }
        }

        private void Button3_Clicked()
        {
            PowerNodeStates = powerNode.getStates();

            if (PowerNodeStates.ElementAt(2))
            {
                powerNode.channelOff(3);
            }
            else
            {
                powerNode.channelOn(3);
            }
        }

        private void Button4_Clicked()
        {
            PowerNodeStates = powerNode.getStates();

            if (PowerNodeStates.ElementAt(3))
            {
                powerNode.channelOff(4);
            }
            else
            {
                powerNode.channelOn(4);
            }
        }

        #endregion
    }
}
