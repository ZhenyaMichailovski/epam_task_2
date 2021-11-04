using System;
using System.Collections.Generic;
using System.Text;

namespace epam_task_2.SemiTrailer
{
    public class AwningSemiTrailer : SemiTrailer
    {
        public double Volum { get; set; }
        public AwningSemiTrailer(int id, string name, double weight, double volum, List<Cargo.Cargo> cargos)
            : base (id, name, weight, cargos)
        {
            Volum = volum;
        }
    }
}
