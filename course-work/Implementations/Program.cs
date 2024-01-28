using System;

namespace Car.Parking.System
{
    public class Program
 
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting...");

            ParkingDbContext dbContext = new ParkingDbContext();

            var repository = new Repository(dbContext);


            while (true)
            {
                Console.WriteLine("Choose command: Register Car, See Data, Delete Car, Exit");

                string input = Console.ReadLine();

                if (input.Equals("Register Car"))
                {
                    repository.InsertData();
                }
                else if (input.Equals("See Data"))
                {
                    Console.WriteLine("Choose what to see: Cars, Parts, Parkings");

                    var readInput = Console.ReadLine();

                    if (readInput.Equals("Cars"))
                    {
                        var car = repository.GetCarByName();
                        Console.WriteLine(car.ToString());
                    }
                    else if (readInput.Equals("Parts"))
                    {
                        var part = repository.GetPartByName();
                        Console.WriteLine(part.ToString());
                    }
                    else if (readInput.Equals("Parkings"))
                    {
                        var parking = repository.GetParkingName();
                        Console.WriteLine(parking.ToString());
                    }
                }
                else if (input.Equals("Delete Car"))
                {
                    repository.DeleteCar();
                }
                else
                {
                    Console.WriteLine("Exiting the parking...");
                    return;
                }
            }
        }
    }
}