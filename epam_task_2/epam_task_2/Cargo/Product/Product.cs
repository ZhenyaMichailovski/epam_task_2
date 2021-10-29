using System;
using System.Collections.Generic;
using System.Text;

namespace epam_task_2.Cargo.Product
{
    abstract class Product : Cargo
    {
        public double Volum { get; set; }
        public double Temperature { get; set; }
        public Product(int id, string name, double weight, double temperature, double volum)
            : base (id, name, weight)
        {
            Temperature = temperature;
            Volum = volum;
        }
    }
}
