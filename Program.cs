using System.Diagnostics;

namespace CarRace
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Car car1 = new Car("\u001b[1m\x1b[31mTokyo Drifter\x1b[0m", "Subaru", "Impreza", 2010, 120, 0, 0);
            Car car2 = new Car("\x1b[1m\x1b[37mSnow-White-My-Queen\x1b[0m", "Toyota", "Camry", 1999, 120, 0, 0);
            Car car3 = new Car("\u001b[1m\x1b[32mGreaser\x1b[0m", "Mercury", "Montclair", 1957, 120, 0, 0);
            Car car4 = new Car("\u001b[1m\x1b[34mTime Machine\x1b[0m", "DMC", "Delorean", 1983, 120, 0, 0);

            Console.WriteLine("\nWelcome to the street race!");

            Console.WriteLine("\nPlease press any key to start the race\n");
            //Console.ReadKey(true);

            var car1Task = CarIsRunning(car1);
            var car2Task = CarIsRunning(car2);
            var car3Task = CarIsRunning(car3);
            var car4Task = CarIsRunning(car4);
            var CarStatusTask = CarStatus(new List<Car> { car1, car2, car3, car4 });
            List<Task> raceTaskList = new List<Task> { car1Task, car2Task, car3Task, car4Task, CarStatusTask };
            List<Car> raceScoreBoard = new List<Car>();

            
            while (raceTaskList.Count > 0)
            {
                
                
                Task raceGoalLine = await Task.WhenAny(raceTaskList);
                if (raceGoalLine == car1Task)
                {
                    Console.WriteLine($"\n{car1.name} has passed the goal line");
                    printCar(car1);
                    raceScoreBoard.Add(car1);
                    displayWinner(raceScoreBoard, car1);
                }
                else if (raceGoalLine == car2Task)
                {
                    Console.WriteLine($"\n{car2.name} has passed the goal line");
                    printCar(car2);
                    raceScoreBoard.Add(car2);
                    displayWinner(raceScoreBoard, car2);
                }
                else if (raceGoalLine == car3Task)
                {
                    Console.WriteLine($"\n{car3.name} has passed the goal line");
                    printCar(car3);
                    raceScoreBoard.Add(car3);
                    displayWinner(raceScoreBoard, car3);
                }
                else if (raceGoalLine == car4Task)
                {
                    Console.WriteLine($"\n{car4.name} has passed the goal line");
                    printCar(car4);
                    raceScoreBoard.Add(car4);
                    displayWinner(raceScoreBoard, car4);
                }

                await raceGoalLine;
                raceTaskList.Remove(raceGoalLine);
            }
            
            Console.WriteLine("Race ended.");
            Console.WriteLine("\n{0,-5}     {1,-30}{2,-4}  mm:ss:ms", "Place", "Car","Time");
            for (int i = 0; i < raceScoreBoard.Count; i++)
            {
                string time = TimeSpan.FromMinutes(raceScoreBoard[i].racingTime).ToString("c");
                Console.WriteLine("\n {0,-1}.       {1,-40}   {2,-5}", i + 1, raceScoreBoard[i].name, time);
            }
            Console.WriteLine("\nPlease press any key to close app");
            Console.ReadKey(true);
        }

        static async Task<Car> CarIsRunning(Car car)
        {
            int tick = 0;
            car.raceTrackDistance = 1000; // meters
            Console.WriteLine($"{car.name} starts running ...");
            //int RaceTime = 300; //300 seconds == 5 minutes
            while (true)
            {
                await Wait(1);

                tick++;
                if (tick == 5)
                {
                    int ranEv = await RandomEvent(car);
                    if (ranEv == 1) car.racingTime += 30;
                    else if (ranEv == 2) car.racingTime += 20;
                    else if (ranEv == 3) car.racingTime += 10;
                    else if (ranEv == 4) car.speed -= 10;
                    
                    //Console.WriteLine("TICK for " + car.name);
                    tick = 0;
                }
                //Console.WriteLine(tick);

                car.racingTime += 1;
                car.hasTraveledDist += SpeedConverter(car.speed);

                if (car.hasTraveledDist >= car.raceTrackDistance)
                {
                    return car;
                }
            }
        }

        

        static async Task Wait(int delay)
        {
            await Task.Delay(TimeSpan.FromSeconds(delay));
            //Console.Write(".");
        }

        static void printCar(Car car)
        {
            decimal dist = Math.Round(car.hasTraveledDist, 2);
            double time = Math.Round(car.racingTime, 2);
            Console.WriteLine($"\n{car.name}\n" +
                $"Travel distance {dist} m \n" +
                $"Speed {car.speed} km/h\n" +
                $"Race time: {time} seconds\n");
        }

        public static async Task CarStatus(List<Car> cars)
        {
            bool carRunning = true;
            while (carRunning) 
            {
                //Maybe create a "Flag" in car object, when car has finished flag = true then break while loop.

                //Console.ReadKey(true);
                await Wait(1);
                //Console.Clear();
                cars.ForEach(car =>
                {
                    decimal dist = Math.Round(car.hasTraveledDist, 2);
                    string time = TimeSpan.FromMinutes(car.racingTime).ToString("c");
                    Console.WriteLine($"\n{car.name} has been running for {time} seconds");
                    Console.WriteLine($"Speed is {car.speed} km/h and has traveled a total distance of {dist} m");
                    if (car.hasTraveledDist >= car.raceTrackDistance)
                    {
                        Console.WriteLine($"{car.name} has stopped\n");
                        carRunning = false;
                    }
                });
                Console.WriteLine();
            }
        }

        public static void displayWinner(List<Car> carList, Car car)
        {
            if (carList[0] == car)
            {
                //Console.BackgroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"\x1b[1m\x1b[43m{car.name}\x1b[1m\x1b[43m Came first place and is the winner!!!\x1b[0m");
                //Console.ResetColor();
            }
        }

        public static decimal SpeedConverter(int speed)
        {
            //Divide any speed with 3.6 and get the exact meters per second
            return (speed / 3.6m);

        }

        static async Task<int> RandomEvent(Car car)
        {
            RandomEvent event1 = new RandomEvent("Empty tank", "Needs to refuel! Will lose at least 30 seconds on that", 30, 0);
            RandomEvent event2 = new RandomEvent("Flat tire", "They must change tire. It will cost at least 20 seconds of the race...", 20, 0);
            RandomEvent event3 = new RandomEvent("Bird on the windshield", "They have to clean that mess up. Will lose 10 seconds at least!", 10, 0);
            RandomEvent event4 = new RandomEvent("Engine failure", "Will slow the car speed with 10 km/h", 0, 10);
            
            Random random = new Random();
            int chance = random.Next(1, 51);

            if (chance == 1)
            {
                Console.WriteLine($"{car.name} is in trouble, seems like an {event1.eventName}. {event1.description}");
                //event1.duration += car.racingTime;
                await Wait(3);
                return 1;

            }
            else if (chance <= 3)
            {
                Console.WriteLine($"{car.name} is in trouble, looks like a {event2.eventName}! {event2.description}");
                //event1.duration += car.racingTime;
                await Wait(2);
                return 2;
            }
            else if (chance <= 8)
            {
                Console.WriteLine($"{car.name} is in trouble, and there is a {event3.eventName}! {event3.description}");
                //event1.duration += car.racingTime;
                await Wait(1);
                return 3;
            }
            else if (chance <= 18)
            {
                Console.WriteLine($"{car.name} is in trouble, and it looks like {event4.eventName}. {event4.description}");
                //event1.speedDecrease -= car.speed;
                return 4;
            }
            else return 0;

        }

    }
}