using System;
using System.Collections.Generic;
using System.Text;

namespace epam_task_2.SemiTrailer
{
    class RefrigeratorSemiTrailer : SemiTrailer
    {
        public double Temperature { get; set; }
        public RefrigeratorSemiTrailer(string name, double weight, double temperature, List<Cargo.Cargo> cargos)
            : base(name, weight, cargos)
        {
            Temperature = temperature;
        }
    }
}
