using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using HomeAutoApp.Models;
using Xamarin.Forms;

namespace HomeAutoApp.ViewModels
{
    public class SettingsPageViewModel : INotifyPropertyChanged
    {
        private Room selectedRoom;

        public SettingsPageViewModel()
        {
            Rooms = new ObservableCollection<Room>();

            var powerNode = new PowerNode("Bedroom", "http://192.168.1.79", 4);
            var sensorNode = new SensorNode("Bedroom", "http://192.168.1.92");

            var r1 = new Room("Bedroom", powerNode, sensorNode);
            var r2 = new Room("Lounge", powerNode, sensorNode);
            var r3 = new Room("Kitchen", powerNode, sensorNode);
            var r4 = new Room("Other", powerNode, sensorNode);

            Rooms.Add(r1);
            Rooms.Add(r2);
            Rooms.Add(r3);
            Rooms.Add(r4);

        }

        #region Properties
        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand SaveCommand 
        { 
            get
            {
                return new Command((e) =>
                {
                    var item = (e as Room);
                    var n = item.Name;
                    var s = item.sensorNode.BaseUrl;
                    var p = item.powerNode.BaseUrl;

                });

            }
        }

        public ObservableCollection<Room> Rooms { get; set; }


        public Room ListViewSelectedRoom
        {
            get { return selectedRoom; }

            set
            {
                selectedRoom = value;
                OnPropertyChanged("ListViewSelectedRoom");

                if(selectedRoom != null)
                {

                }
            }
        }
        #endregion

        void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
