using System;

namespace epam_task_2.Cargo
{
    abstract public class Cargo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Weight { get; set; }

        public Cargo(int id, string name, double weight)
        {
            Id = id;
            Name = name;
            Weight = weight;
        }
    }
}
