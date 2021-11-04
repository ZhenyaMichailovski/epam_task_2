using System;
using System.Collections.Generic;
using System.Text;
using epam_task_2.Cargo;

namespace epam_task_2.SemiTrailer
{
    public abstract class SemiTrailer
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

        public override bool Equals(object obj)
        {
            SemiTrailer semiTrailer = obj as SemiTrailer;
            if (Cargos.Count == semiTrailer.Cargos.Count)
            {
                for (int i = 0; i < semiTrailer.Cargos.Count; i++)
                    if (!Cargos[i].Equals(semiTrailer.Cargos[i]))
                        return false;
                return (Id == semiTrailer.Id && Name == semiTrailer.Name && Weight == semiTrailer.Weight);
            }
            else return false;
        }
    }
}
