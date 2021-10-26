using System;
using System.Collections.Generic;
using System.Text;

namespace epam_task_2.SemiTrailer
{
    class AwningSemiTrailer : SemiTrailer
    {
        public double Volum { get; set; }
        public AwningSemiTrailer(string name, double weight, double volum, List<Cargo.Cargo> cargos)
            : base (name, weight, cargos)
        {
            Volum = volum;
        }
    }
}
