using System;
using System.Collections.Generic;
using System.Text;

namespace epam_task_2.SemiTrailer
{
    public class RefrigeratorSemiTrailer : SemiTrailer
    {
        public double Temperature { get; set; }
        public RefrigeratorSemiTrailer(int id, string name, double weight, double temperature, List<Cargo.Cargo> cargos)
            : base(id, name, weight, cargos)
        {
            Temperature = temperature;
        }
    }
}
