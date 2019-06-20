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
            SaySomething2().Wait();
        }

        static async Task SaySomething()
        {
            Console.WriteLine("SaySomething Before");
            await Task.Factory.StartNew(async () => { await Task.Delay(5000); Console.WriteLine("SaySomething After 5 seconds sleep"); await Task.Delay(5000); Console.WriteLine("SaySomething After 5 seconds sleep"); });
            Console.WriteLine("SaySomething After");
            var n = SomethingNumberAsync();
            await SomethingAsync();
        }

        static async Task SaySomething1()
        {
            Console.WriteLine("SaySomething1 Before");
            await Task.Run(async () => { await Task.Delay(5000); Console.WriteLine("SaySomething1 After 5 seconds sleep"); await Task.Delay(5000); Console.WriteLine("SaySomething1 After 5 seconds sleep"); });
            Console.WriteLine("SaySomething1 After");
        }

        static async Task SaySomething2()
        {
            Console.WriteLine("SaySomething2 Before");
            await await Task.Factory.StartNew(async () => { await Task.Delay(5000); });
            Console.WriteLine("SaySomething2 After");
        }

        static async Task<int> SomethingNumberAsync()
        {
            var i = await Task.FromResult(5);
            var k = await Task.FromResult(5);
            var z = await Task.FromResult(5);
            var s = await Task.FromResult("");
            return await Task.FromResult(i + k + z);
        }

        static async Task SomethingAsync()
        {
            var i = await Task.FromResult(5);
            var k = await Task.FromResult(5);
            var z = await Task.FromResult(5);
            await Task.FromResult(i + k + z);
        }
    }
}
