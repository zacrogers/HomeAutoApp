using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using HomeAutoApp.Models;

namespace HomeAutoApp.ViewModels
{
    public class SettingsPageViewModel : INotifyPropertyChanged
    {
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


        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Room> Rooms { get; set; }

        void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
