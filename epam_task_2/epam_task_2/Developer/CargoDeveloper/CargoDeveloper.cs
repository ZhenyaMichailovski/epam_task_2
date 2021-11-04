using System;
using System.Collections.Generic;
using System.Text;

namespace epam_task_2.Developer.CargoDeveloper
{
    class CargoDeveloper
    {
        public Cargo.Cargo Create(int id, string name, double weight, double temperature, double volum)
        {
            switch (name)
            {
                case "AI92Fuel":
                    return new Cargo.Fuel.AI92Fuel(id, name, weight);
                case "AI95Fuel":
                    return new Cargo.Fuel.AI95Fuel(id, name, weight);
                case "AI98Fuel":
                    return new Cargo.Fuel.AI98Fuel(id, name, weight);
                case "Brick":
                    return new Cargo.Material.Brick(id, name, weight);
                case "Piles":
                    return new Cargo.Material.Piles(id, name, weight);
                case "Apple":
                    return new Cargo.Product.Apple(id, name, weight, temperature, volum);
                case "Fish":
                    return new Cargo.Product.Fish(id, name, weight, temperature, volum);
                default:
                    throw new Exception("Не существует такого топлива");

            }
        }
    }
}
