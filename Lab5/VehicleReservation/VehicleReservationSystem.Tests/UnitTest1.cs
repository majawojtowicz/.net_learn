namespace VehicleReservationSystem.Tests
{
    public class Tests
    {

        private RentalCompany rentalCompany;
        private Car car;
        private Motorcycle motorcycle;
        private List<Vehicle> vehicles;
        [SetUp]
        public void Setup()
        {
            rentalCompany= new RentalCompany();
            car = new Car(1, "Toyota", "Corolla", 2020, "Sedan");
            motorcycle = new Motorcycle(2, "Yamaha", "MT-07", 2021, 689);
            vehicles = new List<Vehicle>() { car, motorcycle };
        }

        [Test]
        public void CreatVehiclesCheckAttributes()
        {
            Assert.AreEqual(1,car.Id);
            Assert.AreEqual("Toyota", car.Brand);
            Assert.AreEqual("Corolla", car.Model);
            Assert.AreEqual(2020, car.Year);
            Assert.AreEqual("Sedan", car.BodyType);
            Assert.IsTrue(car.IsAvailable);

            Assert.AreEqual(2, motorcycle.Id);
            Assert.AreEqual("Yamaha", motorcycle.Brand);
            Assert.AreEqual("MT-07", motorcycle.Model);
            Assert.AreEqual(2021, motorcycle.Year);
            Assert.AreEqual(689, motorcycle.EngineCapacity);
            Assert.IsTrue(motorcycle.IsAvailable);
        }

        [Test]

        public void CheckReservationCancelReservation()
        {
            car.Reserve("John Doe");
            Assert.IsFalse(car.IsAvailable);

            car.CancelReservation();
            Assert.IsTrue(car.IsAvailable);
        }

        [Test]
            
        public void ExtensionMethod()
        {
            car.Reserve("John Doe");
            var availableVehicles = vehicles.GetAvailableVehicles();
            Assert.AreEqual(1, availableVehicles.Count);
            Assert.AreEqual(motorcycle.Id, availableVehicles[0].Id);
        }

        [Test]

        public void NewReservationEvent()
        {
            rentalCompany.AddVehicle(car);
            string evMess = null;
            rentalCompany.OnNewReservation += message => evMess = message;
            rentalCompany.ReserveVehicle(car.Id, "John Doe");

            Assert.IsNotNull(evMess);
            StringAssert.Contains("John Doe", evMess);
        }
    }
}