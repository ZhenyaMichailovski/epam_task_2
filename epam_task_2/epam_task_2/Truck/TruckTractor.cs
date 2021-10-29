using System;
using System.Collections.Generic;
using System.Text;

namespace epam_task_2.Truck
{
    class TruckTractor : Truck
    {
        public TruckTractor(int id, string name, double weight, SemiTrailer.SemiTrailer semiTrailer)
            : base (id, name, weight, semiTrailer)
        { }
    }
}
