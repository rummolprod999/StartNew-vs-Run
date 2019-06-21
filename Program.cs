using System;
using System.Threading;
using System.Threading.Tasks;

namespace erewr
{
    class Program
    {
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
            _ = SomethingNumberAsync();
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
            var m = await Task.FromResult("");
            await Task.Delay(3000);
            var i = await Task.FromResult(5);
            var k = await Task.FromResult(5 + i);
            var z = await Task.FromResult(5 + k);
            var s = await Task.FromResult("" + m);
            return await Task.FromResult(i + k + z);
        }

        static async Task SomethingAsync()
        {
            var i = await Task.FromResult(5);
            var k = await Task.FromResult(5);
            var z = await Task.FromResult(5);
            await Task.FromResult(i + k + z);
        }

        static async Task<int> MethodAsync()
        {

            return await Task.Run(() => 1);
        }

        static async Task Outher1Async()
        {

            var n = await MethodAsync();
            Console.WriteLine(n);
        }

        static async Task Outher2Async()
        {

            await Outher1Async();
        }
    }
}
