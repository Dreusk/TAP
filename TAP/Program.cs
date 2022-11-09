using System;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace TAP
{
    internal class Program
    {
        private static void Start()
        {
            Console.Write("Для начала нажмите любую клавишу... ");
            Console.ReadKey();
            Console.WriteLine();
        }

        private async static Task TestSync()
        {
            Thread.Sleep(200);
            Console.WriteLine($"Текущий поток: {Thread.CurrentThread.ManagedThreadId}");
            return;
        }

        private async static Task TestAsync()
        {
            Task.Delay(200);
            Console.WriteLine($"Текущий поток: {Thread.CurrentThread.ManagedThreadId}");
            return;
        }

        private async static Task TestAwait()
        {
            await Task.Delay(200);
            Console.WriteLine($"Текущий поток: {Thread.CurrentThread.ManagedThreadId}");
            return;
        }

        private async static Task TestWait()
        {
            Task.Delay(200).Wait();
            Console.WriteLine($"Текущий поток: {Thread.CurrentThread.ManagedThreadId}");
            return;
        }

        static void Main(string[] args)
        {
            Start();
            for (int i = 0; i < 20; i++)
            {
                //TestSync();
                //TestAsync();
                //TestAwait();
                //TestWait();
            }
            Console.WriteLine("Работа основного потока завершена...");
            Console.ReadKey();
        }
    }
}
