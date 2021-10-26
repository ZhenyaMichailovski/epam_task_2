using System;
using System.Collections.Generic;
using System.Text;

namespace epam_task_2.Cargo.Product
{
    class Fish : Product
    {
        public Fish(string name, double weight, double temperature, double volum)
            :base(name, weight, temperature, volum)
        { }
    }
}
