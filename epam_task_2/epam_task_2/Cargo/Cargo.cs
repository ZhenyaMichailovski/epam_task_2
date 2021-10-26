using System;

namespace epam_task_2.Cargo
{
    abstract public class Cargo
    {
        public string Name { get; set; }
        public double Weight { get; set; }

        public Cargo(string name, double weight)
        {
            Name = name;
            Weight = weight;
        }
    }
}
