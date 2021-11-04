using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using epam_task_2.Cargo;

namespace epam_task_2.XmlManager
{
    class XmlManager
    {
        public static List<Cargo.Cargo> GetAllCargos()
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(@"../../Cargo.xml");
           
            XmlElement xRoot = xDoc.DocumentElement;
            List<Cargo.Cargo> cargos = new List<Cargo.Cargo>();
            foreach (XmlNode xnode in xRoot)
            {
                string id = "";
                string name = "";
                string weight = "";
                string temperature = "";
                string volum = "";
                
                foreach (XmlNode childnode in xnode.ChildNodes)
                {
                    switch (childnode.Name)
                    {
                        case "Id":
                            id = childnode.InnerText;
                            break;
                        case "name":
                            name = childnode.InnerText;
                            break;
                        case "weight":
                            weight = childnode.InnerText;
                            break;
                        case "temperature":
                            temperature = childnode.InnerText;
                            break;
                        case "volum":
                            volum = childnode.InnerText;
                            break;
                        default:
                            break;
                    }
                }

                Developer.CargoDeveloper.CargoDeveloper cargoDeveloper = new Developer.CargoDeveloper.CargoDeveloper();
                cargos.Add(cargoDeveloper.Create(Convert.ToInt32(id), name, Convert.ToDouble(weight), Convert.ToDouble(temperature), Convert.ToDouble(volum)));
            }
            return cargos; 
        }

        public static List<SemiTrailerCargo.SemiTrailerCargo> GetAllSemiTrailersCargos()
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(@"../../SemiTrailerCargo.xml");
            
            XmlElement xRoot = xDoc.DocumentElement;
            List<SemiTrailerCargo.SemiTrailerCargo> items = new List<SemiTrailerCargo.SemiTrailerCargo>();
            foreach (XmlNode xnode in xRoot)
            {
                string IdSemiTrailer = "";
                string IdCargo = "";
              
                foreach (XmlNode childnode in xnode.ChildNodes)
                {
                    switch (childnode.Name)
                    {
                        case "IdSemiTrailer":
                            IdSemiTrailer = childnode.InnerText;
                            break;
                        case "IdCargo":
                            IdCargo = childnode.InnerText;
                            break;
                        default:
                            break;
                    }
                }

                items.Add(new SemiTrailerCargo.SemiTrailerCargo(Convert.ToInt32(IdSemiTrailer), Convert.ToInt32(IdCargo)));
                
            }
            return items;
        }

        public static List<SemiTrailer.SemiTrailer> GetAllSemiTrailers()
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(@"../../SemiTrailer.xml");
            XmlElement xRoot = xDoc.DocumentElement;
            List<SemiTrailer.SemiTrailer> items = new List<SemiTrailer.SemiTrailer>();
            foreach (XmlNode xnode in xRoot)
            {
                string id = "";
                string name = "";
                string weight = "";
                string temperature = "";
                string volum = "";

                foreach (XmlNode childnode in xnode.ChildNodes)
                {
                    switch (childnode.Name)
                    {
                        case "Id":
                            id = childnode.InnerText;
                            break;
                        case "name":
                            name = childnode.InnerText;
                            break;
                        case "weight":
                            weight = childnode.InnerText;
                            break;
                        case "Temperature":
                            temperature = childnode.InnerText;
                            break;
                        case "Volum":
                            volum = childnode.InnerText;
                            break;
                        default:
                            break;
                    }
                }

                var semiTrailerCargos = GetAllSemiTrailersCargos();
                var filterSemiTrailerCargos = semiTrailerCargos.FindAll(x => x.IdSemiTrailer == Convert.ToInt32(id));
                var allCargos = GetAllCargos();
                List<Cargo.Cargo> cargos = new List<Cargo.Cargo>();
                Developer.SemiTrailerDeveloper.SemiTrailerDeveloper semiTrailerDeveloper = new Developer.SemiTrailerDeveloper.SemiTrailerDeveloper();
                Developer.CargoDeveloper.CargoDeveloper cargoDeveloper = new Developer.CargoDeveloper.CargoDeveloper();

                foreach (var item in filterSemiTrailerCargos)
                {
                    var needCargo = allCargos.FirstOrDefault(x => x.Id == item.IdCargo);

                    cargos.Add(cargoDeveloper.Create(Convert.ToInt32(id), name, Convert.ToDouble(weight), Convert.ToDouble(temperature), Convert.ToDouble(volum)));
                   
                }
                items.Add(semiTrailerDeveloper.Create(Convert.ToInt32(id), name, Convert.ToDouble(weight), Convert.ToDouble(temperature), Convert.ToDouble(volum), cargos));
                
            }
            return items;
        }

        public static List<Truck.Truck> GetAllTrucks()
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(@"../../Trucks.xml");

            XmlElement xRoot = xDoc.DocumentElement;
            List<Truck.Truck> items = new List<Truck.Truck>();
            foreach (XmlNode xnode in xRoot)
            {
                string id = "";
                string name = "";
                string weight = "";
                string idSemiTrailer = "";

                foreach (XmlNode childnode in xnode.ChildNodes)
                {
                    switch (childnode.Name)
                    {
                        case "Id":
                            id = childnode.InnerText;
                            break;
                        case "Name":
                            name = childnode.InnerText;
                            break;
                        case "Weight":
                            weight = childnode.InnerText;
                            break;
                        case "IdSemiTrailer":
                            idSemiTrailer = childnode.InnerText;
                            break;
                        default:
                            break;
                    }
                }

                var semiTrailers = GetAllSemiTrailers();

                var needSemiTrailer = semiTrailers.FirstOrDefault(x => x.Id == Convert.ToInt32(idSemiTrailer));
                Developer.TruckDeveloper.TruckDeveloper truckDeveloper = new Developer.TruckDeveloper.TruckDeveloper();
                items.Add(truckDeveloper.Create(Convert.ToInt32(id), name, Convert.ToDouble(weight), needSemiTrailer));
            }

            return items;
        }

        public static void SetCargo(string id, string name, string weight, string temperature, string volum)
        {
            
            var cargos = GetAllCargos();

            Developer.CargoDeveloper.CargoDeveloper cargoDeveloper = new Developer.CargoDeveloper.CargoDeveloper();
            cargos.Add(cargoDeveloper.Create(Convert.ToInt32(id), name, Convert.ToDouble(weight), Convert.ToDouble(temperature), Convert.ToDouble(volum)));

            List<XElement> xElements = new List<XElement>();
            XDocument xdoc = new XDocument();
            for (int i = 0; i < cargos.Count(); i++)
            {
                
                xElements.Add(new XElement("Cargo"));
                XElement Id = new XElement("", "");
                XElement Name = new XElement("", "");
                XElement Weight = new XElement("", "");
                XElement Temp = new XElement("", "");
                XElement Volum = new XElement("", "");
                switch (cargos[i].Name)
                {
                    case "AI92Fuel":
                        var AI92 = (Cargo.Fuel.AI92Fuel)(object)cargos[i];
                        Id = new XElement("Id", AI92.Id);
                        Name = new XElement("name", AI92.Name);
                        Weight = new XElement("weight", AI92.Weight);
                        Temp = new XElement("temperature", "");
                        Volum = new XElement("volum", "");
                        break;
                    case "AI95Fuel":
                        var AI95 = (Cargo.Fuel.AI95Fuel)(object)cargos[i];
                        Id = new XElement("Id", AI95.Id);
                        Name = new XElement("name", AI95.Name);
                        Weight = new XElement("weight", AI95.Weight);
                        Temp = new XElement("temperature", "");
                        Volum = new XElement("volum", "");
                        break;
                    case "AI98Fuel":
                        var AI98 = (Cargo.Fuel.AI98Fuel)(object)cargos[i];
                        Id = new XElement("Id", AI98.Id);
                        Name = new XElement("name", AI98.Name);
                        Weight = new XElement("weight", AI98.Weight);
                        Temp = new XElement("temperature", "");
                        Volum = new XElement("volum", "");
                        break;
                    case "Brick":
                        var Brick = (Cargo.Material.Brick)(object)cargos[i];
                        Id = new XElement("Id", Brick.Id);
                        Name = new XElement("name", Brick.Name);
                        Weight = new XElement("weight", Brick.Weight);
                        Temp = new XElement("temperature", "");
                        Volum = new XElement("volum", "");
                        break;
                    case "Piles":
                        var Piles = (Cargo.Material.Piles)(object)cargos[i];
                        Id = new XElement("Id", Piles.Id);
                        Name = new XElement("name", Piles.Name);
                        Weight = new XElement("weight", Piles.Weight);
                        Temp = new XElement("temperature", "");
                        Volum = new XElement("volum", "");
                        break;
                    case "Apple":
                        var Apple = (Cargo.Product.Apple)(object)cargos[i];
                        Id = new XElement("Id", Apple.Id);
                        Name = new XElement("name", Apple.Name);
                        Weight = new XElement("weight", Apple.Weight);
                        Temp = new XElement("temperature", Apple.Temperature);
                        Volum = new XElement("volum", Apple.Volum);
                        break;
                    case "Fish":
                        var Fish = (Cargo.Product.Fish)(object)cargos[i];
                        Id = new XElement("Id", Fish.Id);
                        Name = new XElement("name", Fish.Name);
                        Weight = new XElement("weight", Fish.Weight);
                        Temp = new XElement("temperature", Fish.Temperature);
                        Volum = new XElement("volum", Fish.Volum);
                        break;
                    default:
                        break;
                }

                xElements[i].Add(Id);
                xElements[i].Add(Name);
                xElements[i].Add(Weight);
                xElements[i].Add(Temp);
                xElements[i].Add(Volum);
            }

            XElement Cargos = new XElement("Cargos");

            foreach(var item in xElements)
            {
                Cargos.Add(item);
            }

            xdoc.Add(Cargos);
            xdoc.Save(@"../../Cargo.xml");
        }

        public static void SetSemiTrailerCargo(string idSemiTrailer, string idCargo)
        {
            var items = GetAllSemiTrailersCargos();

            List<XElement> xElements = new List<XElement>();
            XDocument xdoc = new XDocument();

            items.Add(new epam_task_2.SemiTrailerCargo.SemiTrailerCargo(Convert.ToInt32(idSemiTrailer), Convert.ToInt32(idCargo)));
            for (int i = 0; i < items.Count(); i++)
            {
                xElements.Add(new XElement("SemiTrailerCargo"));

                XElement IdSemiTrailer = new XElement("IdSemiTrailer", items[i].IdSemiTrailer);
                XElement IdCargo = new XElement("IdCargo", items[i].IdCargo);

                xElements[i].Add(IdSemiTrailer);
                xElements[i].Add(IdCargo);
            }

            XElement SemiTrailerCargo = new XElement("SemiTrailerCargos");

            foreach (var item in xElements)
            {
                SemiTrailerCargo.Add(item);
            }

            xdoc.Add(SemiTrailerCargo);
            xdoc.Save(@"../../SemiTrailerCargo.xml");
        }

        public static void SetSemiTrailer(string id, string name, string weight, string volum, string temperature)
        {
            var semiTrailer = GetAllSemiTrailers();
            Developer.SemiTrailerDeveloper.SemiTrailerDeveloper semiTrailerDeveloper = new Developer.SemiTrailerDeveloper.SemiTrailerDeveloper();

            semiTrailer.Add(semiTrailerDeveloper.Create(Convert.ToInt32(id), name, Convert.ToDouble(weight), Convert.ToDouble(temperature), Convert.ToDouble(volum), null));

            List<XElement> xElements = new List<XElement>();
            XDocument xdoc = new XDocument();
            for (int i = 0; i < semiTrailer.Count(); i++)
            {

                xElements.Add(new XElement("SemiTrailer"));
                XElement Id = new XElement("", "");
                XElement Name = new XElement("", "");
                XElement Weight = new XElement("", "");
                XElement Temp = new XElement("", "");
                XElement Volum = new XElement("", "");

                switch (semiTrailer[i].Name)
                {
                    case "AwningSemiTrailer":
                        var AwningSemiTrailer = (SemiTrailer.AwningSemiTrailer)(object)semiTrailer[i];
                        Id = new XElement("Id", AwningSemiTrailer.Id);
                        Name = new XElement("name", AwningSemiTrailer.Name);
                        Weight = new XElement("weight", AwningSemiTrailer.Weight);
                        Volum = new XElement("Volum", AwningSemiTrailer.Volum);
                        Temp = new XElement("Temperature", "");
                        break;
                    case "RefrigeratorSemiTrailer":
                        var RefrigeratorSemiTrailer = (SemiTrailer.RefrigeratorSemiTrailer)(object)semiTrailer[i];
                        Id = new XElement("Id", RefrigeratorSemiTrailer.Id);
                        Name = new XElement("name", RefrigeratorSemiTrailer.Name);
                        Weight = new XElement("weight", RefrigeratorSemiTrailer.Weight);
                        Volum = new XElement("Volum", "");
                        Temp = new XElement("Temperature", RefrigeratorSemiTrailer.Temperature);
                        break;
                    case "TankTruckSemiTrailer":
                        var TankTruckSemiTrailer = (SemiTrailer.TankTruckSemiTrailer)(object)semiTrailer[i];
                        Id = new XElement("Id", TankTruckSemiTrailer.Id);
                        Name = new XElement("name", TankTruckSemiTrailer.Name);
                        Weight = new XElement("weight", TankTruckSemiTrailer.Weight);
                        Volum = new XElement("Volum", "");
                        Temp = new XElement("Temperature", "");
                        break;
                    default:
                        break;
                }

                xElements[i].Add(Id);
                xElements[i].Add(Name);
                xElements[i].Add(Weight);
                xElements[i].Add(Temp);
                xElements[i].Add(Volum);
            }

            XElement SemiTrailers = new XElement("SemiTrailers");

            foreach (var item in xElements)
            {
                SemiTrailers.Add(item);
            }

            xdoc.Add(SemiTrailers);
            xdoc.Save(@"../../SemiTrailers.xml");
        }

        public static void SetTruck(string id, string name, string weight, string idSemiTrailer)
        {
            var trucks = GetAllTrucks();
            var semiTrailers = GetAllSemiTrailers();
            Developer.TruckDeveloper.TruckDeveloper truckDeveloper = new Developer.TruckDeveloper.TruckDeveloper();
            trucks.Add(truckDeveloper.Create(Convert.ToInt32(id), name, Convert.ToDouble(weight), null));

            List<XElement> xElements = new List<XElement>();
            XDocument xdoc = new XDocument();
            for (int i = 0; i < trucks.Count(); i++)
            {

                xElements.Add(new XElement("Truck"));
                XElement Id = new XElement("", "");
                XElement Name = new XElement("", "");
                XElement Weight = new XElement("", "");
                XElement IdSemiTrailer = new XElement("", "");
                var semiTrailer = semiTrailers.FirstOrDefault(x => x.Id == Convert.ToInt32(idSemiTrailer));
                switch (trucks[i].Name)
                {
                    case "TruckTractor":
                        var TruckTractor = (Truck.TruckTractor)(object)trucks[i];
                        Id = new XElement("Id", trucks[i].Id);
                        Name = new XElement("Name", trucks[i].Name);
                        Weight = new XElement("Weight", trucks[i].Weight);
                        IdSemiTrailer = new XElement("IdSemiTrailer", semiTrailer.Id);
                        break;
                    default:
                        break;
                }

                xElements[i].Add(Id);
                xElements[i].Add(Name);
                xElements[i].Add(Weight);
                xElements[i].Add(IdSemiTrailer);

            }

            XElement Trucks = new XElement("Trucks");

            foreach (var item in xElements)
            {
                Trucks.Add(item);
            }

            xdoc.Add(Trucks);
            xdoc.Save(@"../../Trucks.xml");
        }

        public static void DeleteCargo(int id)
        {
            var items = GetAllCargos();
            var item = items.FirstOrDefault(x => x.Id == id);
            items.Remove(item);

            foreach(var i in items)
            {
                switch (i.Name)
                {
                    case "AI92Fuel":
                        var AI92 = (Cargo.Fuel.AI92Fuel)(object)i;
                        SetCargo(AI92.Id.ToString(), AI92.Name, AI92.Weight.ToString(), "", "");
                        break;
                    case "AI95Fuel":
                        var AI95 = (Cargo.Fuel.AI95Fuel)(object)i;
                        SetCargo(AI95.Id.ToString(), AI95.Name, AI95.Weight.ToString(), "", "");
                        break;
                    case "AI98Fuel":
                        var AI98 = (Cargo.Fuel.AI98Fuel)(object)i;
                        SetCargo(AI98.Id.ToString(), AI98.Name, AI98.Weight.ToString(), "", "");
                        break;
                    case "Brick":
                        var Brick = (Cargo.Material.Brick)(object)i;
                        SetCargo(Brick.Id.ToString(), Brick.Name, Brick.Weight.ToString(), "", "");
                        break;
                    case "Piles":
                        var Piles = (Cargo.Material.Piles)(object)i;
                        SetCargo(Piles.Id.ToString(), Piles.Name, Piles.Weight.ToString(), "", "");
                        break;
                    case "Apple":
                        var Apple = (Cargo.Product.Apple)(object)i;
                        SetCargo(Apple.Id.ToString(), Apple.Name, Apple.Weight.ToString(), Apple.Temperature.ToString(), Apple.Volum.ToString());
                        break;
                    case "Fish":
                        var Fish = (Cargo.Product.Fish)(object)i;
                        SetCargo(Fish.Id.ToString(), Fish.Name, Fish.Weight.ToString(), Fish.Temperature.ToString(), Fish.Volum.ToString());
                        break;
                    default:
                        break;
                }
            }

        }

        public static void DeleteSemiTrailer(int id)
        {
            var items = GetAllSemiTrailers();
            var item = items.FirstOrDefault(x => x.Id == id);
            items.Remove(item);
            DeleteSemiTrailerCargo(id);
            foreach (var i in items)
            {
                
                switch (i.Name)
                {
                    case "AwningSemiTrailer":
                        var AwningSemiTrailer = (SemiTrailer.AwningSemiTrailer)(object)i;
                        SetSemiTrailer(AwningSemiTrailer.Id.ToString(), AwningSemiTrailer.Name, 
                            AwningSemiTrailer.Weight.ToString(), AwningSemiTrailer.Volum.ToString(), "");
                        break;
                    case "RefrigeratorSemiTrailer":
                        var RefrigeratorSemiTrailer = (SemiTrailer.RefrigeratorSemiTrailer)(object)i;
                        SetSemiTrailer(RefrigeratorSemiTrailer.Id.ToString(), RefrigeratorSemiTrailer.Name,
                            RefrigeratorSemiTrailer.Weight.ToString(), "", RefrigeratorSemiTrailer.Temperature.ToString());
                        break;
                    case "TankTruckSemiTrailer":
                        var TankTruckSemiTrailer = (SemiTrailer.TankTruckSemiTrailer)(object)i;
                        SetSemiTrailer(TankTruckSemiTrailer.Id.ToString(), TankTruckSemiTrailer.Name,
                            TankTruckSemiTrailer.Weight.ToString(), "", "");
                        break;
                    default:
                        break;
                }
            }
        }

        public static void DeleteSemiTrailerCargo(int idSemiTrailer)
        {
            var SemiTrailerCargos = GetAllSemiTrailersCargos();
            var items = SemiTrailerCargos.FindAll(x => x.IdSemiTrailer == idSemiTrailer);
            
            foreach(var item in items)
            {
                SemiTrailerCargos.Remove(item);
            }

            foreach (var i in SemiTrailerCargos)
            {
                SetSemiTrailerCargo(i.IdSemiTrailer.ToString(), i.IdCargo.ToString());
            }
        }

        public static void DeleteTruck(int id)
        {
            var items = GetAllTrucks();
            var item = items.FirstOrDefault(x => x.Id == id);
            items.Remove(item);
            DeleteSemiTrailer(item.SemiTrailer.Id);

            foreach (var i in items)
            {
                switch (i.Name)
                {
                    case "TruckTractor":
                        var TruckTractor = (Truck.TruckTractor)(object)i;
                        SetTruck(TruckTractor.Id.ToString(), TruckTractor.Name,
                            TruckTractor.Weight.ToString(), i.SemiTrailer.Id.ToString());
                        break; 
                    default:
                        break;
                }
            }
        }
    }
}
