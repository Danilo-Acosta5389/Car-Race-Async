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
                model = "Impreza",
                year = 2010,
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
            Car car3 = new Car()
            {
                name = "Greaser",
                brand = "Mercury",
                model = "Montclair",
                year = 1957,
                speed = 120, // km/h
                traveledDistance = 0,
                raceTrackDistance = 10.0m,
                racingTime = 0
            };
            Car car4 = new Car()
            {
                name = "Time Machine",
                brand = "DMC",
                model = "Delorean",
                year = 1983,
                speed = 120, // km/h
                traveledDistance = 0,
                raceTrackDistance = 12.0m,
                racingTime = 0
            };




            Console.WriteLine("\nWelcome to the street race!");

            Console.WriteLine("\nPlease press any key to start the race");
            Console.ReadKey(true);


            //TODO: Put car methods in variable
            //      Create a list of tasks, containing the car methods and objects
            //      The program should only await for the list to run.

            var car1Task = CarIsRunning(car1);
            var car2Task = CarIsRunning(car2);
            var car3Task = CarIsRunning(car3);
            var car4Task = CarIsRunning(car4);

            var CarStatusTask = CarStatus(new List<Car> { car1, car2, car3, car4 });

            var raceTask = new List<Task> { car1Task, car2Task, car3Task, car4Task, CarStatusTask };

            while (raceTask.Count > 0)
            {
                Task raceGoalLine = await Task.WhenAny(raceTask);
                if (raceGoalLine == car1Task)
                {
                    Console.WriteLine($"\n {car1.name} made it into goal!");
                    Car carResult = car1Task.Result;
                    printCar(carResult);
                }
                else if (raceGoalLine == car2Task)
                {
                    Console.Write($"\n {car2.name} made it into goal!");
                    Car carResult = car2Task.Result;
                    printCar(carResult);
                }
                else if (raceGoalLine == car3Task)
                {
                    Console.Write($"\n {car3.name} made it into goal!");
                    Car carResult = car3Task.Result;
                    printCar(carResult);
                }
                else if (raceGoalLine == car4Task)
                {
                    Console.Write($"\n{car4.name} made it into goal!");
                    Car carResult = car4Task.Result;
                    printCar(carResult);
                }
                await raceGoalLine;
                raceTask.Remove(raceGoalLine);
            }
            Console.WriteLine("Race ended.");
            Console.WriteLine("\nPlease press any key to close app");
            Console.ReadKey(true);
            //PleasePressEnter();
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
            //Console.Write(".");
        }

        static void printCar(Car car)
        {
            Console.WriteLine($"\n{car.name}\n" +
                $"Travel distance {car.traveledDistance} km \n" +
                $"Speed {car.speed} km/h\n" +
                $"Race time: {car.racingTime} seconds\n");
        }

        public static async Task CarStatus(List<Car> cars)
        {
            while (true) 
            {
                //Maybe create a "Flag" in car object, when car has finished flag = true then break while loop.

                //Console.ReadKey(true);
                await Task.Delay(TimeSpan.FromSeconds(1));
                Console.Clear();
                cars.ForEach(car =>
                {
                    Console.WriteLine($"{car.RemainingTime()} seconds remaining");
                    Console.WriteLine($"{car.name} has been running for {car.racingTime} seconds and has traveled a distance of {car.traveledDistance} km");
                });
                Console.WriteLine();

                var totalRemaining = cars.Select(car => car.RemainingTime()).Sum();

                //var totalRemaining = (from egg in eggs
                //                     let remaining = egg.RemainingTime()
                //                     select remaining).Sum();
            }
        }

        //static void PleasePressEnter()
        //{
        //    Console.WriteLine("\nPlease press enter");
        //    while (Console.ReadKey(true).Key != ConsoleKey.Enter) { }
        //}
    }
}