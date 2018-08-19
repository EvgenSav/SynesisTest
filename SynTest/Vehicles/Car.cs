using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SynTest.Vehicles {
    public class Car : Vehicle {
        public Car() {
            MaxSpeed = 180;
            Name = "Instance of Car";
            RearSeatsCount = 3;
        }
        public int RearSeatsCount { get; set; }
    }
}
