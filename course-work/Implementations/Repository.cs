using Car.Parking.System.Models;
using System;
using System.Linq;

namespace Car.Parking.System
{
    public class Repository
    {
        private ParkingDbContext dbContext;

        public Repository(ParkingDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void InsertData()
        {
            Console.WriteLine("Enter Parking Name");
            string parkingName = Console.ReadLine();
            Console.WriteLine("Enter Car Name");
            string carName = Console.ReadLine();
            Console.WriteLine("Enter Car's part name");
            string partname = Console.ReadLine();
            Console.WriteLine("Enter Car's year");
            int year = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Car's color");
            string color = Console.ReadLine();
            Console.WriteLine("Enter Car's price");
            double price = double.Parse(Console.ReadLine());


            Part part = new Part(partname);

            CarModel car = new CarModel(carName, year, color, price);
            car.Parts.Add(part);

            ParkingModel parking = new ParkingModel(parkingName);
            parking.Cars.Add(car);

            this.dbContext.Parking.Add(parking);
            this.dbContext.SaveChanges();
        }

        public ParkingModel GetParkingName()
        {
            Console.WriteLine("Search parking by name:");
            string parkingName = Console.ReadLine();
            return this.dbContext.Parking.Where(s => s.Name.Equals(parkingName)).FirstOrDefault();
        }



        public CarModel GetCarByName()
        {
            Console.WriteLine("Search car by name:");
            string carName = Console.ReadLine();
            return this.dbContext.CarModel.Where(s => s.Name.Equals(carName)).FirstOrDefault();
        }

        public Part GetPartByName()
        {
            Console.WriteLine("Search part by name:");
            string partName = Console.ReadLine();
            return this.dbContext.Part.Where(s => s.PartName.Equals(partName)).FirstOrDefault();
        }

        public void DeleteCar()
        {
            Console.WriteLine("Delete car by name:");
            string carName = Console.ReadLine();
            CarModel car = this.dbContext.CarModel.Where(s => s.Name.Equals(carName)).FirstOrDefault();
            
            if (car != null)
            {
                Console.WriteLine("Deleted: " + car);
                this.dbContext.CarModel.Remove(car);
                this.dbContext.SaveChanges();
            }
            else
            {
                Console.WriteLine("This car does not exist");
            }

        }
    }
}
