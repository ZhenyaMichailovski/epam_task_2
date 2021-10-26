using System;
using System.Collections.Generic;
using System.Text;

namespace epam_task_2.Cargo.Material
{
    abstract class Material : Cargo
    {
        public Material(string name, double weight)
            : base(name, weight)
        { }
    }
}
