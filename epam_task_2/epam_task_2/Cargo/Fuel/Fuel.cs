using System;
using System.Collections.Generic;
using System.Text;

namespace epam_task_2.Cargo.Fuel
{
    public abstract class Fuel : Cargo
    {
        public Fuel(int id, string name, double weight)
            :base(id, name, weight)
        { }
    }
}
