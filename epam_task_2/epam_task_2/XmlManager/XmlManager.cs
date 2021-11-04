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
            xDoc.Load(@"D:\Git\epam_task_2\epam_task_2\epam_task_2\Cargo.xml");
           
            XmlElement xRoot = xDoc.DocumentElement;
            List<Cargo.Cargo> cargos = new List<Cargo.Cargo>();
            foreach (XmlNode xnode in xRoot)
            {
                string id = "";
                string name = "";
                double weight = 0;
                double temperature = 0;
                double volum = 0;
                
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
                            if(childnode.InnerText != "")
                                weight = Convert.ToDouble(childnode.InnerText);
                            break;
                        case "temperature":
                            if (childnode.InnerText != "")
                                temperature = Convert.ToDouble(childnode.InnerText);
                            break;
                        case "volum":
                            if (childnode.InnerText != "")
                                volum = Convert.ToDouble(childnode.InnerText);
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
            xDoc.Load(@"D:\Git\epam_task_2\epam_task_2\epam_task_2\SemiTrailerCargo.xml");
            
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
            xDoc.Load(@"D:\Git\epam_task_2\epam_task_2\epam_task_2\SemiTrailers.xml");
            XmlElement xRoot = xDoc.DocumentElement;
            List<SemiTrailer.SemiTrailer> items = new List<SemiTrailer.SemiTrailer>();
            foreach (XmlNode xnode in xRoot)
            {
                string id = "";
                string name = "";
                double weight = 0;
                double temperature = 0;
                double volum = 0;

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
                            if(childnode.InnerText != "")
                                weight = Convert.ToDouble(childnode.InnerText);
                            break;
                        case "Temperature":
                            if (childnode.InnerText != "")
                                temperature = Convert.ToDouble(childnode.InnerText);
                            break;
                        case "Volum":
                            if (childnode.InnerText != "")
                                volum = Convert.ToDouble(childnode.InnerText);
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
                    
                    cargos.Add(cargoDeveloper.Create(Convert.ToInt32(needCargo.Id), needCargo.Name, Convert.ToDouble(needCargo.Weight), -999, -999));
                   
                }
                items.Add(semiTrailerDeveloper.Create(Convert.ToInt32(id), name, Convert.ToDouble(weight), Convert.ToDouble(temperature), Convert.ToDouble(volum), cargos));
                
            }
            return items;
        }

        public static List<Truck.Truck> GetAllTrucks()
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(@"D:\Git\epam_task_2\epam_task_2\epam_task_2\Trucks.xml");

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

            if (cargos.FirstOrDefault(x => x.Id == Convert.ToInt32(id)) != null)
            {
                var item = cargos.FirstOrDefault(x => x.Id == Convert.ToInt32(id));
                cargos.Remove(item);
            }
            cargos.Add(cargoDeveloper.Create(Convert.ToInt32(id), name, Convert.ToDouble(weight), Convert.ToDouble(temperature), Convert.ToDouble(volum)));

            List<XElement> xElements = new List<XElement>();
            XDocument xdoc = new XDocument();
            for (int i = 0; i < cargos.Count(); i++)
            {
                
                xElements.Add(new XElement("Cargo"));
                XElement Id = new XElement("Id", "");
                XElement Name = new XElement("Name", "");
                XElement Weight = new XElement("Weight", "");
                XElement Temp = new XElement("Temp", "");
                XElement Volum = new XElement("Volum", "");
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
            xdoc.Save(@"D:\Git\epam_task_2\epam_task_2\epam_task_2\Cargo.xml");
        }

        public static void SetCargo(List<Cargo.Cargo> cargos)
        {
            Developer.CargoDeveloper.CargoDeveloper cargoDeveloper = new Developer.CargoDeveloper.CargoDeveloper();

            List<XElement> xElements = new List<XElement>();
            XDocument xdoc = new XDocument();
            for (int i = 0; i < cargos.Count(); i++)
            {

                xElements.Add(new XElement("Cargo"));
                XElement Id = new XElement("Id", "");
                XElement Name = new XElement("Name", "");
                XElement Weight = new XElement("Weight", "");
                XElement Temp = new XElement("Temp", "");
                XElement Volum = new XElement("Volum", "");
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

            foreach (var item in xElements)
            {
                Cargos.Add(item);
            }

            xdoc.Add(Cargos);
            xdoc.Save(@"D:\Git\epam_task_2\epam_task_2\epam_task_2\Cargo.xml");
        }

        public static void SetSemiTrailerCargo(string idSemiTrailer, string idCargo)
        {
            var items = GetAllSemiTrailersCargos();

            List<XElement> xElements = new List<XElement>();
            XDocument xdoc = new XDocument();
            if (items.FirstOrDefault(x => x.IdCargo == Convert.ToInt32(idCargo) && x.IdSemiTrailer == Convert.ToInt32(idSemiTrailer)) != null)
            {
                var item = items.FirstOrDefault(x => x.IdCargo == Convert.ToInt32(idCargo) && x.IdSemiTrailer == Convert.ToInt32(idSemiTrailer));
                items.Remove(item);
            }
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
            xdoc.Save(@"D:\Git\epam_task_2\epam_task_2\epam_task_2\SemiTrailerCargo.xml");
        }
        public static void SetSemiTrailerCargo(List<SemiTrailerCargo.SemiTrailerCargo> semiTrailersCargo)
        {
            List<XElement> xElements = new List<XElement>();
            XDocument xdoc = new XDocument();
            for (int i = 0; i < semiTrailersCargo.Count(); i++)
            {
                xElements.Add(new XElement("SemiTrailerCargo"));

                XElement IdSemiTrailer = new XElement("IdSemiTrailer", semiTrailersCargo[i].IdSemiTrailer);
                XElement IdCargo = new XElement("IdCargo", semiTrailersCargo[i].IdCargo);

                xElements[i].Add(IdSemiTrailer);
                xElements[i].Add(IdCargo);
            }

            XElement SemiTrailerCargo = new XElement("SemiTrailerCargos");

            foreach (var item in xElements)
            {
                SemiTrailerCargo.Add(item);
            }

            xdoc.Add(SemiTrailerCargo);
            xdoc.Save(@"D:\Git\epam_task_2\epam_task_2\epam_task_2\SemiTrailerCargo.xml");
        }

        public static void SetSemiTrailer(string id, string name, string weight, string volum, string temperature)
        {
            var semiTrailer = GetAllSemiTrailers();
            Developer.SemiTrailerDeveloper.SemiTrailerDeveloper semiTrailerDeveloper = new Developer.SemiTrailerDeveloper.SemiTrailerDeveloper();

            if (semiTrailer.FirstOrDefault(x => x.Id == Convert.ToInt32(id)) != null)
            {
                var item = semiTrailer.FirstOrDefault(x => x.Id == Convert.ToInt32(id));
                semiTrailer.Remove(item);
            }
            semiTrailer.Add(semiTrailerDeveloper.Create(Convert.ToInt32(id), name, Convert.ToDouble(weight), Convert.ToDouble(temperature), Convert.ToDouble(volum), null));

            List<XElement> xElements = new List<XElement>();
            XDocument xdoc = new XDocument();
            for (int i = 0; i < semiTrailer.Count(); i++)
            {

                xElements.Add(new XElement("SemiTrailer"));
                XElement Id = new XElement("Id", "1");
                XElement Name = new XElement("name", "1");
                XElement Weight = new XElement("weight", "1");
                XElement Temp = new XElement("Volum", "1");
                XElement Volum = new XElement("Temperature", "1");

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
            xdoc.Save(@"D:\Git\epam_task_2\epam_task_2\epam_task_2\SemiTrailers.xml");
        }

        public static void SetTruck(string id, string name, string weight, string idSemiTrailer)
        {
            var trucks = GetAllTrucks();
            var semiTrailers = GetAllSemiTrailers();
            Developer.TruckDeveloper.TruckDeveloper truckDeveloper = new Developer.TruckDeveloper.TruckDeveloper();

            if (trucks.FirstOrDefault(x => x.Id == Convert.ToInt32(id)) != null)
            {
                var item = trucks.FirstOrDefault(x => x.Id == Convert.ToInt32(id));
                trucks.Remove(item);
            }
            trucks.Add(truckDeveloper.Create(Convert.ToInt32(id), name, Convert.ToDouble(weight), null));

            List<XElement> xElements = new List<XElement>();
            XDocument xdoc = new XDocument();
            for (int i = 0; i < trucks.Count(); i++)
            {

                xElements.Add(new XElement("Truck"));
                XElement Id = new XElement("Id", "1");
                XElement Name = new XElement("Name", "1");
                XElement Weight = new XElement("Weight", "1");
                XElement IdSemiTrailer = new XElement("IdSemiTrailer", "1");
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
            xdoc.Save(@"D:\Git\epam_task_2\epam_task_2\epam_task_2\Trucks.xml");
        }
        public static void SetTruck(List<Truck.Truck> trucks)
        {
            var semiTrailers = GetAllSemiTrailers();
            Developer.TruckDeveloper.TruckDeveloper truckDeveloper = new Developer.TruckDeveloper.TruckDeveloper();

            List<XElement> xElements = new List<XElement>();
            XDocument xdoc = new XDocument();
            for (int i = 0; i < trucks.Count(); i++)
            {

                xElements.Add(new XElement("Truck"));
                XElement Id = new XElement("Id", "1");
                XElement Name = new XElement("Name", "1");
                XElement Weight = new XElement("Weight", "1");
                XElement IdSemiTrailer = new XElement("IdSemiTrailer", "1");
                var semiTrailer = semiTrailers.FirstOrDefault(x => x.Id == Convert.ToInt32(trucks[i].SemiTrailer.Id));
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
            xdoc.Save(@"D:\Git\epam_task_2\epam_task_2\epam_task_2\Trucks.xml");
        }
        public static void DeleteCargo(int id)
        {
            var items = GetAllCargos();
            var item = items.FirstOrDefault(x => x.Id == id);
            items.Remove(item);

            SetCargo(items);
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
                            AwningSemiTrailer.Weight.ToString(), AwningSemiTrailer.Volum.ToString(), "0");
                        break;
                    case "RefrigeratorSemiTrailer":
                        var RefrigeratorSemiTrailer = (SemiTrailer.RefrigeratorSemiTrailer)(object)i;
                        SetSemiTrailer(RefrigeratorSemiTrailer.Id.ToString(), RefrigeratorSemiTrailer.Name,
                            RefrigeratorSemiTrailer.Weight.ToString(), "0", RefrigeratorSemiTrailer.Temperature.ToString());
                        break;
                    case "TankTruckSemiTrailer":
                        var TankTruckSemiTrailer = (SemiTrailer.TankTruckSemiTrailer)(object)i;
                        SetSemiTrailer(TankTruckSemiTrailer.Id.ToString(), TankTruckSemiTrailer.Name,
                            TankTruckSemiTrailer.Weight.ToString(), "0", "0");
                        break;
                    default:
                        break;
                }
            }
        }

        public static void DeleteSemiTrailerCargo(int idSemiTrailer, int idCargo)
        {
            var SemiTrailerCargos = GetAllSemiTrailersCargos();
            var items = SemiTrailerCargos.FindAll(x => x.IdSemiTrailer == idSemiTrailer && x.IdCargo == idCargo);
            
            foreach(var item in items)
            {
                SemiTrailerCargos.Remove(item);
            }
            
            SetSemiTrailerCargo(SemiTrailerCargos);
            
        }

        public static void DeleteSemiTrailerCargo(int idSemiTrailer)
        {
            var SemiTrailerCargos = GetAllSemiTrailersCargos();
            var items = SemiTrailerCargos.FindAll(x => x.IdSemiTrailer == idSemiTrailer);

            foreach (var item in items)
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
