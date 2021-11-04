using System;

namespace epam_task_2.Cargo
{
    public abstract class Cargo
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

        public override bool Equals(object obj)
        {
            Cargo cargo = obj as Cargo;
            return (Id == cargo.Id && Name == cargo.Name && Weight == cargo.Weight);
            
        }
    }
}
