using System.Diagnostics;

namespace CarRace
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            decimal raceTime = 0;
            decimal trackDistance = 10;

            Car car1 = new Car()
            {
                name = "Tokyo Drifter",
                brand = "Subaru",
                model = "Impreza",
                year = 2010,
                speed = 120,  // km/h also 33.33 m/s
                hasTraveledDist = 0, //km
                raceTrackDistance = trackDistance,
                racingTime = raceTime
            };
            Car car2 = new Car()
            {
                name = "Snow-White-My-Queen",
                brand = "Toyota",
                model = "Camry",
                year = 1999,
                speed = 120, // km/h
                hasTraveledDist = 0, //km
                raceTrackDistance = trackDistance,
                racingTime = raceTime
            };
            Car car3 = new Car()
            {
                name = "Greaser",
                brand = "Mercury",
                model = "Montclair",
                year = 1957,
                speed = 120, // km/h
                hasTraveledDist = 0, //km
                raceTrackDistance = trackDistance,
                racingTime = raceTime
            };
            Car car4 = new Car()
            {
                name = "Time Machine",
                brand = "DMC",
                model = "Delorean",
                year = 1983,
                speed = 120, // km/h
                hasTraveledDist = 0, //km
                raceTrackDistance = trackDistance,
                racingTime = raceTime
            };
           
            Console.WriteLine("\nWelcome to the street race!");

            Console.WriteLine("\nPlease press any key to start the race\n");
            Console.ReadKey(true);


            //TODO: Put car methods in variable
            //      Create a list of tasks containing the car methods and objects
            //      The program should only await for the list to run.

            var car1Task = CarIsRunning(car1);
            var car2Task = CarIsRunning(car2);
            var car3Task = CarIsRunning(car3);
            var car4Task = CarIsRunning(car4);

            var CarStatusTask = CarStatus(new List<Car> { car1, car2, car3, car4 });

            var raceTaskList = new List<Task> { car1Task, car2Task, car3Task, car4Task, CarStatusTask };

            List<Car> raceScoreBoard = new List<Car>();

            while (raceTaskList.Count > 0)
            {
                Task raceGoalLine = await Task.WhenAny(raceTaskList);
                if (raceGoalLine == car1Task)
                {
                    Console.WriteLine($"\n{car1.name} has passed the goal line");
                    //Car carResult = car1Task.Result;
                    //Console.WriteLine(raceTaskList[0].Id);
                    //printCar(car1);
                    raceScoreBoard.Add(car1);
                    if (raceScoreBoard[0] == car1)
                    {
                        Console.WriteLine($"{car1.name} Came first place and is the winner!!!");
                    }
                }
                else if (raceGoalLine == car2Task)
                {
                    Console.WriteLine($"\n{car2.name} has passed the goal line");
                    //Console.WriteLine(raceTaskList[0].Id);
                    //printCar(car2);
                    raceScoreBoard.Add(car2);
                    if (raceScoreBoard[0] == car2)
                    {
                        Console.WriteLine($"{car2.name} Came first place and is the winner!!!");
                    }
                }
                else if (raceGoalLine == car3Task)
                {
                    Console.WriteLine($"\n{car3.name} has passed the goal line");
                    //Console.WriteLine(raceTaskList[0].Id);
                    //printCar(car3);
                    raceScoreBoard.Add(car3);
                    if (raceScoreBoard[0] == car3)
                    {
                        Console.WriteLine($"{car3.name} Came first place and is the winner!!!");
                    }
                }
                else if (raceGoalLine == car4Task)
                {
                    Console.WriteLine($"\n{car4.name} has passed the goal line");
                    //Console.WriteLine(raceTaskList[0].Id);
                    //printCar(car4);
                    raceScoreBoard.Add(car4);
                    if (raceScoreBoard[0] == car4)
                    {
                        Console.WriteLine($"{car4.name} Came first place and is the winner!!!");
                    }
                }

                await raceGoalLine;
                raceTaskList.Remove(raceGoalLine);
            }
            Console.WriteLine("Race ended.");
            Console.WriteLine("\nRace Scoreboard: ");


            for (int i = 0; i < raceScoreBoard.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {raceScoreBoard[i].name}   Time: {raceScoreBoard[i].racingTime}");
            }
            Console.WriteLine("\nPlease press any key to close app");
            Console.ReadKey(true);
            //PleasePressEnter();
        }

        static async Task<Car> CarIsRunning(Car car)
        {
            Console.WriteLine($"{car.name} starts running ...");
            int RaceTime = 300;
            while (true)
            {
                await Wait(RaceTime);

                // TODO: Create a condition that takes time to be met
                // Example: every seccond the car runs for x km,
                // when y km is met return car


                //TODO: Add 1 km every 30 second

                //car.traveledDistance += (0.1m * RaceTime);
                car.hasTraveledDist += 1;
                car.racingTime += (0.1m * RaceTime);


                if (car.hasTraveledDist >= car.raceTrackDistance)
                {
                    return car;
                }
            }
        }

        static async Task Wait(int delay = 10)
        {
            await Task.Delay(TimeSpan.FromSeconds(delay / delay));
            //Console.Write(".");
        }

        static void printCar(Car car)
        {
            Console.WriteLine($"\n{car.name}\n" +
                $"Travel distance {car.hasTraveledDist} km \n" +
                $"Speed {car.speed} km/h\n" +
                $"Race time: {car.racingTime} seconds\n");
        }

        public static async Task CarStatus(List<Car> cars)
        {
            bool carRunning = true;
            while (carRunning) 
            {
                //Maybe create a "Flag" in car object, when car has finished flag = true then break while loop.

                //Console.ReadKey(true);
                await Task.Delay(1000);
                //Console.Clear();
                cars.ForEach(car =>
                {
                    Console.WriteLine($"\n{car.name} has been running for {car.racingTime} seconds");
                    Console.WriteLine($"Speed is {car.speed} km/h and has traveled a total distance of {car.hasTraveledDist} km");
                    if (car.hasTraveledDist >= car.raceTrackDistance)
                    {
                        Console.WriteLine($"{car.name} has stopped\n");
                        carRunning = false;
                    }
                });
                Console.WriteLine();
                

                //var totalRemaining = cars.Select(car => car.RemainingTime()).Sum();

                //var totalRemaining = (from egg in eggs
                //                     let remaining = egg.RemainingTime()
                //                     select remaining).Sum();
            }
        }
    }
}