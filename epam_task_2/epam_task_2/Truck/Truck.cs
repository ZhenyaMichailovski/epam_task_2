using System;
using System.Collections.Generic;
using System.Text;

namespace epam_task_2.Truck
{
    public abstract class Truck
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Weight { get; set; }
        public SemiTrailer.SemiTrailer SemiTrailer { get; set; }

        public Truck(int id, string name, double weight, SemiTrailer.SemiTrailer semiTrailer)
        {
            Id = id;
            Name = name;
            Weight = weight;
            SemiTrailer = semiTrailer;
        }

        public override bool Equals(object obj)
        {
            Truck truck = obj as Truck;
            return (Id == truck.Id && Name == truck.Name && Weight == truck.Weight && SemiTrailer.Equals(truck.SemiTrailer));
        }
    }
}
