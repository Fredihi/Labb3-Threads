using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Timers;

namespace Labb3_Threads
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Car car1 = new Car("Lightning McQueen", 120, 0);
            Car car2 = new Car("Trailblazer", 120, 0);

            Thread c1 = new Thread(() =>
            {
                car1.StartRace(car1);
                Console.WriteLine($"{car1.Name} has reached the finish line!");
            });

            Thread c2 = new Thread(() =>
            {
                car2.StartRace(car2);
                Console.WriteLine($"{car2.Name} has reached the finish line!");
            });

            Thread c3 = new Thread(() =>
            {
                Car.CheckOnCars(Car.GetAllCars());
            });

            c1.Start();
            c2.Start();
            c3.Start();
        }
    }
}