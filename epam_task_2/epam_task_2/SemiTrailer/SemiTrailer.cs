using System;
using System.Collections.Generic;
using System.Text;
using epam_task_2.Cargo;

namespace epam_task_2.SemiTrailer
{
    abstract class SemiTrailer
    {
        public string Name { get; set; }
        public double Weight { get; set; }

        public List<Cargo.Cargo> Cargos { get; set; }

        public SemiTrailer(string name, double weight, List<Cargo.Cargo> cargos)
        {
            Name = name;
            Weight = weight;
            Cargos = cargos;
        }
    }
}
