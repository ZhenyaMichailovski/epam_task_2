using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace epam_task_2
{
    class DeveloperLogic
    {
        public List<Truck.Truck> ViewingThePark()
        {
            return XmlManager.XmlManager.GetAllTrucks();
        }

        public SemiTrailer.SemiTrailer FindingSemiTrailerAccordingToTheSample(SemiTrailer.SemiTrailer semiTrailer)
        {
            var items = XmlManager.XmlManager.GetAllSemiTrailers();
            return items.FirstOrDefault(x => x.Id == semiTrailer.Id);
        }

        public SemiTrailer.SemiTrailer FindingSemiTrailerByType(string name)
        {
            var items = XmlManager.XmlManager.GetAllSemiTrailers();
            return items.FirstOrDefault(x => x.Name == name);
        }

        public void LoadTheRefregetorSemiTrailer(int id, List<Cargo.Product.Product> product)
        {
            var items = XmlManager.XmlManager.GetAllSemiTrailers();
            var trailer = (SemiTrailer.RefrigeratorSemiTrailer)(object)items.FirstOrDefault(x => x.Id == id && x.Name == "RefrigeratorSemiTrailer");

            if(trailer != null)
            {
                foreach (var item in product)
                    if (item.Temperature != trailer.Temperature && trailer.Weight >= product.Sum(x => x.Weight))
                        throw new Exception("Недопустимость по грузу");

                XmlManager.XmlManager.SetSemiTrailer(trailer.Id.ToString(), trailer.Name, trailer.Weight.ToString(), "", trailer.Temperature.ToString());

                foreach(var item in product)
                {
                    XmlManager.XmlManager.SetSemiTrailerCargo(trailer.Id.ToString(), item.Id.ToString());
                }
            }
        }

        public void LoadTheAwningSemiTrailer(int id, List<Cargo.Product.Product> product)
        {
            var items = XmlManager.XmlManager.GetAllSemiTrailers();
            var trailer = (SemiTrailer.AwningSemiTrailer)(object)items.FirstOrDefault(x => x.Id == id && x.Name == "AwningSemiTrailer");

            if (trailer != null)
            {
                foreach (var item in product)
                    if (trailer.Weight >= product.Sum(x => x.Weight))
                        throw new Exception("Недопустимость по грузу");

                XmlManager.XmlManager.SetSemiTrailer(trailer.Id.ToString(), trailer.Name, trailer.Weight.ToString(), trailer.Volum.ToString(), "");

                foreach (var item in product)
                {
                    XmlManager.XmlManager.SetSemiTrailerCargo(trailer.Id.ToString(), item.Id.ToString());
                }
            }
        }

        public void LoadTheTankTruckSemiTrailer(int id, List<Cargo.Product.Product> product)
        {
            var items = XmlManager.XmlManager.GetAllSemiTrailers();
            var trailer = (SemiTrailer.TankTruckSemiTrailer)(object)items.FirstOrDefault(x => x.Id == id && x.Name == "TankTruckSemiTrailer");

            if (trailer != null)
            {
                foreach (var item in product)
                    if (trailer.Weight >= product.Sum(x => x.Weight))
                        throw new Exception("Недопустимость по грузу");

                XmlManager.XmlManager.SetSemiTrailer(trailer.Id.ToString(), trailer.Name, trailer.Weight.ToString(), "", "");

                foreach (var item in product)
                {
                    XmlManager.XmlManager.SetSemiTrailerCargo(trailer.Id.ToString(), item.Id.ToString());
                }
            }
        }

        public void PutTheTrailerToTheTractor(int id, int idTrailer)
        {
            var trucks = XmlManager.XmlManager.GetAllTrucks();
            var truck = trucks.FirstOrDefault(x => x.Id == id);
            var trailers = XmlManager.XmlManager.GetAllSemiTrailers();
            var trailer = trailers.FirstOrDefault(x => x.Id == idTrailer);

            XmlManager.XmlManager.SetTruck(truck.Id.ToString(), truck.Name, truck.Weight.ToString(), trailer.Id.ToString());
            
        }

        public List<(Truck.Truck, SemiTrailer.SemiTrailer)> FindingHitchesForCargo(int idCargo)
        {
            var semiTrailerCargos = XmlManager.XmlManager.GetAllSemiTrailersCargos();
            var needSemiTrailerCargos = semiTrailerCargos.FindAll(x => x.IdCargo == idCargo).ToList();
            var semiTrailers = XmlManager.XmlManager.GetAllSemiTrailers();
            var trucks = XmlManager.XmlManager.GetAllTrucks();
            List<(Truck.Truck, SemiTrailer.SemiTrailer)> items = new List<(Truck.Truck, SemiTrailer.SemiTrailer)>();

            foreach(var item in needSemiTrailerCargos)
            {
                var semiTrailer = semiTrailers.FirstOrDefault(x => x.Id == item.IdSemiTrailer);
                var truck = trucks.FirstOrDefault(x => x.SemiTrailer.Id == semiTrailer.Id);

                items.Add((truck, semiTrailer));
            }

            return items;
        }
    }
}
