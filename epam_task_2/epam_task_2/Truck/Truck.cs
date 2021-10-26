using System;
using System.Collections.Generic;
using System.Text;

namespace epam_task_2.Truck
{
    abstract class Truck
    {
        public string Name { get; set; }
        public double Weight { get; set; }
        public SemiTrailer.SemiTrailer SemiTrailer { get; set; }

        public Truck(string name, double weight, SemiTrailer.SemiTrailer semiTrailer)
        {
            Name = name;
            Weight = weight;
            SemiTrailer = semiTrailer;
        }
    }
}
