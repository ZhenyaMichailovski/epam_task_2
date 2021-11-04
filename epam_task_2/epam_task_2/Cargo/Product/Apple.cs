using System;
using System.Collections.Generic;
using System.Text;

namespace epam_task_2.Cargo.Product
{
    public class Apple : Product
    {
        public Apple(int id, string name, double weight, double temperature, double volum)
            : base(id, name, weight, temperature, volum)
        { }
    }
}
