using System;
using System.Collections.Generic;
using System.Text;

namespace epam_task_2.SemiTrailer
{
    public class TankTruckSemiTrailer : SemiTrailer
    {
        public TankTruckSemiTrailer(int id, string name, double weight, List<Cargo.Cargo> cargos)
            : base(id , name, weight, cargos)
        { }
    }
}
