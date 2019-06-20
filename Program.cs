using System;
using System.Threading;
using System.Threading.Tasks;

namespace erewr
{
    class Program
    {
        private static string result;

        static void Main()
        {
            SaySomething().Wait();
            SaySomething1().Wait();
        }

        static async Task SaySomething()
        {
            Console.WriteLine("Before");
            await Task.Factory.StartNew(async () => { await Task.Delay(5000); });
            Console.WriteLine("After");
        }

        static async Task SaySomething1()
        {
            Console.WriteLine("Before");
            await Task.Run(async () => { await Task.Delay(5000); Console.WriteLine("After 5 seconds sleep");  await Task.Delay(5000); });
            Console.WriteLine("After");
        }
    }
}
