using System;
using System.Collections.Generic;
using System.Text;

namespace epam_task_2.Truck
{
    class TruckTractor : Truck
    {
        public TruckTractor(string name, double weight, SemiTrailer.SemiTrailer semiTrailer)
            : base (name, weight, semiTrailer)
        { }
    }
}
