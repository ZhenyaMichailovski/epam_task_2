using System;
using System.Collections.Generic;
using System.Text;
using epam_task_2.Cargo;

namespace epam_task_2.SemiTrailer
{
    abstract class SemiTrailer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Weight { get; set; }

        public List<Cargo.Cargo> Cargos { get; set; }

        public SemiTrailer(int id, string name, double weight, List<Cargo.Cargo> cargos)
        {
            Id = id;
            Name = name;
            Weight = weight;
            Cargos = cargos;
        }
    }
}
