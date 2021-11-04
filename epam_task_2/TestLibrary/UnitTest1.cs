using epam_task_2;
using epam_task_2.Cargo;
using epam_task_2.Cargo.Fuel;
using epam_task_2.Cargo.Material;
using epam_task_2.Cargo.Product;
using epam_task_2.SemiTrailer;
using epam_task_2.Truck;
using NUnit.Framework;
using System.Collections.Generic;

namespace TestLibrary
{
    public class Tests
    {
        private DeveloperLogic developerLogic = new DeveloperLogic();
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestViewingTheParkMethod()
        {
            var items = developerLogic.ViewingThePark();

            List<Truck> trucks = new List<Truck>
            {
                new TruckTractor(1, "TruckTractor", 20, new AwningSemiTrailer(1, "AwningSemiTrailer", 15, 20, new List<Cargo>
                {
                    new Brick(2, "Brick", 10),
                })),
                new TruckTractor(2, "TruckTractor", 20, new RefrigeratorSemiTrailer(2, "RefrigeratorSemiTrailer", 20, 3, new List<Cargo>
                {
                    new Apple(3, "Apple", 10, -999, -999),
                })),
                new TruckTractor(3, "TruckTractor", 25, new TankTruckSemiTrailer(3, "TankTruckSemiTrailer", 25, new List<Cargo>
                {
                    new AI92Fuel(1, "AI92Fuel", 10),
                })),
            };
            Assert.AreEqual(items, trucks);
        }

        [Test]
        public void TestFindingSemiTrailerAccordingToTheSampleMethod()
        {
            var item = developerLogic.FindingSemiTrailerAccordingToTheSample(new AwningSemiTrailer(1, "AwningSemiTrailer", 15, 20, new List<Cargo>
                {
                    new Brick(2, "Brick", 10),
                }));

            var semiTrailer = new AwningSemiTrailer(1, "AwningSemiTrailer", 15, 20, new List<Cargo>
                {
                    new Brick(2, "Brick", 10),
                });

            Assert.AreEqual(item, semiTrailer);
        }

        [Test]
        public void TestFindingSemiTrailerByTypeMethod()
        {
            var item = developerLogic.FindingSemiTrailerByType("AwningSemiTrailer");

            var semiTrailer = new AwningSemiTrailer(1, "AwningSemiTrailer", 15, 20, new List<Cargo>
                {
                    new Brick(2, "Brick", 10),
                });

            Assert.AreEqual(item, semiTrailer);

        }

        [Test]
        public void TestFindingHitchesForCargoMethod()
        {
            var items = developerLogic.FindingHitchesForCargo(1);

            List<(Truck, SemiTrailer)> ps = new List<(Truck, SemiTrailer)>();
            Truck truck = new TruckTractor(3, "TruckTractor", 25, new TankTruckSemiTrailer(3, "TankTruckSemiTrailer", 25, new List<Cargo>
                {
                    new AI92Fuel(1, "AI92Fuel", 10),
                }));
            SemiTrailer semiTrailer = new TankTruckSemiTrailer(3, "TankTruckSemiTrailer", 25, new List<Cargo>
                {
                    new AI92Fuel(1, "AI92Fuel", 10),
                });
            ps.Add((truck, semiTrailer));

            Assert.AreEqual(ps, items);
        }

        [Test]
        public void TestLoadTheRefregetorSemiTrailerMethod()
        {
            developerLogic.LoadTheRefregetorSemiTrailer(2, new List<Product>
                {
                    new Apple(4, "Apple", 4, 3, 10),
                });

            var items = developerLogic.FindingHitchesForCargo(4);

            developerLogic.DeleteSemiTrailerCargo(2, 4);
            developerLogic.DeleteCargoById(4);

            Truck truck = new TruckTractor(2, "TruckTractor", 20, new RefrigeratorSemiTrailer(2, "RefrigeratorSemiTrailer", 20, 3, new List<Cargo>
                {
                    new Apple(3, "Apple", 10, -999, -999),
                    new Apple(4, "Apple", 4, -999, -999)
                }));
            SemiTrailer semiTrailer = new RefrigeratorSemiTrailer(2, "RefrigeratorSemiTrailer", 20, 3, new List<Cargo>
                {
                    new Apple(3, "Apple", 10, -999, -999),
                    new Apple(4, "Apple", 4, -999, -999)
                });
            List<(Truck, SemiTrailer)> ps = new List<(Truck, SemiTrailer)>();
            ps.Add((truck, semiTrailer));
            Assert.AreEqual(ps, items);
        }
    }
}