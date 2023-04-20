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
                raceTrackDistance= 12.0m,
                racingTime = 0
            };





            Console.WriteLine("\nWelcome to the street race!");

            Console.WriteLine("\nPlease press enter to start the race");
            while (Console.ReadKey(true).Key != ConsoleKey.Enter) { }


            //TODO: Put car methods in variable
            //      Create a list of tasks, containing the car methods and objects
            //      The program should only await for the list to run.

            var car1Task = CarIsRunning(car1);
            var car2Task = CarIsRunning(car2);

            var raceTask = new List<Task> { car1Task, car2Task };

            while (raceTask.Count > 0)
            {
                Task raceGoalLine = await Task.WhenAny(raceTask);
                if (raceGoalLine == car1Task)
                {
                    Console.Write($"{car1.name} made it into goal!");
                    Car carResult = car1Task.Result;
                    carStatus(carResult);
                }
                else if (raceGoalLine == car2Task)
                {
                    Console.Write($"{car2.name} made it into goal!");
                    Car carResult = car2Task.Result;
                    carStatus(carResult);
                }
                await raceGoalLine;
                raceTask.Remove(raceGoalLine);
            }

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
            Console.WriteLine($"{car.name}\n" +
                $"Travel distance {car.traveledDistance} km \n" +
                $"Speed {car.speed} km/h\n" +
                $"Race time: {car.racingTime} seconds\n");
        }

        static void PleasePressEnter()
        {
            Console.WriteLine("\nPlease press enter");
            while (Console.ReadKey(true).Key != ConsoleKey.Enter) { }
        }
    }
}