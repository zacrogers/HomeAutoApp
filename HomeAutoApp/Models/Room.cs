using System;
using System.Collections.Generic;
using System.Text;

namespace HomeAutoApp.Models
{
    public class Room
    {
        public Room(string name, PowerNode power, SensorNode sensor)
        {
            Name = name;
            powerNode = power;
            sensorNode = sensor;

        }
        public string Name { get; set; }
        public PowerNode powerNode { get; set; }
        public SensorNode sensorNode { get; set; }
    }
}
