using System;
using System.Collections.Generic;
using System.Text;

namespace epam_task_2.Developer.TruckDeveloper
{
    class TruckDeveloper
    {
        public Truck.Truck Create(int id, string name, double weight, SemiTrailer.SemiTrailer semiTrailer)
        {
            switch (name)
            {
                case "TruckTractor":
                    return new Truck.TruckTractor(id, name, weight, semiTrailer);
                default:
                    throw new Exception("Не существует такого тягоча");
            }

        }
    }
}
