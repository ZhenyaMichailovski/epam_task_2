using System;
using System.Collections.Generic;
using System.Text;

namespace epam_task_2.Developer.SemiTrailerDeveloper
{
    class SemiTrailerDeveloper
    {
        public epam_task_2.SemiTrailer.SemiTrailer Create(int id, string name, double weight, double temperaturem, double volum, List<Cargo.Cargo> cargos)
        {
            switch (name)
            {
                case "AwningSemiTrailer":
                    return new SemiTrailer.AwningSemiTrailer(id, name, weight, volum, cargos);
                case "RefrigeratorSemiTrailer":
                    return new SemiTrailer.RefrigeratorSemiTrailer(id, name, weight, temperaturem, cargos);
                case "TankTruckSemiTrailer":
                    return new SemiTrailer.TankTruckSemiTrailer(id, name, weight, cargos);
                default:
                    throw new Exception("Не существует таких полуприцепов");
            }
        }
    }
}
