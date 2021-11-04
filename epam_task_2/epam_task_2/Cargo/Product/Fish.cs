using System;
using System.Collections.Generic;
using System.Text;

namespace epam_task_2.Cargo.Product
{
    public class Fish : Product
    {
        public Fish(int id, string name, double weight, double temperature, double volum)
            :base(id, name, weight, temperature, volum)
        { }
    }
}
