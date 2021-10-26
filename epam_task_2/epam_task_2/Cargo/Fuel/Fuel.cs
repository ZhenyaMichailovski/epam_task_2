using System;
using System.Collections.Generic;
using System.Text;

namespace epam_task_2.Cargo.Fuel
{
    abstract class Fuel : Cargo
    {
        public Fuel(string name, double weight)
            :base(name, weight)
        { }
    }
}
