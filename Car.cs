using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb3_Threads
{
    public class Car
    {
        public string Name { get; set; }
        public int Speed { get; set; }
        public int Distance { get; set; }

        public Car(string name, int speed, int distance)
        {
            Name = name;
            Speed = speed;
            Distance = distance;
        }

        public static List<Car> cars = new List<Car>();

        public static List<Car> GetAllCars()
        {
            return cars;
        }

        public void OutOfGas()
        {
            Console.WriteLine($"{Name} has run out of gas and will have to refuel!");
            Thread.Sleep(30000);
        }

        public void FlatTire()
        {
            Console.WriteLine($"{Name} has gotten a flat tire!");
            Thread.Sleep(20000);
        }

        public void BirdStrike()
        {
            Console.WriteLine($"Oh no! {Name} has hit a bird!");
            Thread.Sleep(10000);
        }

        public void EngineFailure(int speed)
        {
            Console.WriteLine($"{Name} has gotten an engine failure and will slow down");
            Speed -= 5;
        }

        public void StartRace(Car car)
        {
            cars.Add(car);
            Stopwatch stopwatch = Stopwatch.StartNew();
            stopwatch.Start();

            while (Distance <= 12000)
            {
                Distance += Speed;
                Console.WriteLine($"{Name} Distance: {Distance}");
                Thread.Sleep(1000);
                if (stopwatch.Elapsed.TotalSeconds > 5)
                {
                    Events();
                    stopwatch.Restart();
                }
            }
        }

        public void Events()
        {
            Random ran = new Random();
            int eve = ran.Next(1, 51);
            if (eve == 42)
            {
                OutOfGas();
            }
            else if (eve == 2 && eve == 3)
            {
                FlatTire();
            }
            else if (eve >= 4 && eve <= 8)
            {
                BirdStrike();
            }
            else if (eve >= 8 && eve <= 18)
            {
                EngineFailure(Speed);
            }
        }

        public static void CheckOnCars(List<Car> cars)
        {
            while (Console.ReadKey(true).Key == ConsoleKey.Enter)
            {
                foreach (var car in cars)
                {
                    Console.WriteLine($"{car.Name} is running at {car.Speed}km/h");
                }
            }
        }
    }
}
