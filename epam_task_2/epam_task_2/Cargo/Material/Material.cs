using System;
using System.Collections.Generic;
using System.Text;

namespace epam_task_2.Cargo.Material
{
    public abstract class Material : Cargo
    {
        public Material(int id, string name, double weight)
            : base(id, name, weight)
        { }
    }
}
