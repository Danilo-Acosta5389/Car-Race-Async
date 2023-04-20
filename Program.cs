using System.Diagnostics;

namespace CarRace
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Car car1 = new Car()
            {
                name = "Tokyo Drifter",
                brand = "Subaru",
                model = "WRX GT",
                year = 2022,
                speed = 120,  // km/h
                traveledDistance = 0,
                raceTrackDistance = 10.0m,
                racingTime = 0
            };
            Car car2 = new Car()
            {
                name = "Snow-White-My-Queen",
                brand = "Toyota",
                model = "Camry",
                year = 1999,
                speed = 120, // km/h
                traveledDistance = 0,
                raceTrackDistance= 10.0m,
                racingTime = 0
            };


            Console.WriteLine("\nWelcome to the street race!");

            Console.WriteLine("\nPlease press enter to start the race");
            while (Console.ReadKey(true).Key != ConsoleKey.Enter) { }
            await CarIsRunning(car1);
            carStatus(car1);
            PleasePressEnter();
        }

        static async Task<Car> CarIsRunning(Car car)
        {
            Console.WriteLine($"\n{car.name} starts running ...");
            int RaceTime = 10;
            while (true)
            {
                await Wait(RaceTime);

                // TODO: Create a condition that takes time to be met
                // Example: every seccond the car runs for x km,
                // when y km is met return car

                car.traveledDistance += (0.1m * RaceTime);
                car.racingTime += RaceTime;


                if (car.traveledDistance >= car.raceTrackDistance)
                {
                    Console.WriteLine($"\n{car.name} has stopped ...");
                    return car;
                }
            }
        }

        static async Task Wait(int delay = 10)
        {
            await Task.Delay(TimeSpan.FromSeconds(delay / 10));
            Console.Write(".");
        }

        static void carStatus(Car car)
        {
            Console.WriteLine($"{car.name} has traveled {car.traveledDistance} km in {car.racingTime} seconds");
        }

        static void PleasePressEnter()
        {
            Console.WriteLine("\nPlease press enter to close.");
            while (Console.ReadKey(true).Key != ConsoleKey.Enter) { }
        }
    }
}