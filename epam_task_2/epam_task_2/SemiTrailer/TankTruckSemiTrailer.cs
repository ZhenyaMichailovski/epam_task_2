using System;
using System.Collections.Generic;
using System.Text;

namespace epam_task_2.SemiTrailer
{
    class TankTruckSemiTrailer : SemiTrailer
    {
        public TankTruckSemiTrailer(string name, double weight, List<Cargo.Cargo> cargos)
            : base(name, weight, cargos)
        { }
    }
}
