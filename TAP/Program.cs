using System;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

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

        private async static Task TestAwaitMultiple()
        {
            Stopwatch timer = new();
            timer.Start();
            for (int i = 0; i < 5; i++)
                await Task.Delay(200);
            timer.Stop();
            Console.WriteLine($"Текущий поток: {Thread.CurrentThread.ManagedThreadId}. Время выполнения: {timer.Elapsed}");
            return;
        }

        private async static Task TestAwaitMultiple2()
        {
            Stopwatch timer = new();
            HashSet<Task> Tasks = new();
            timer.Start();
            for (int i = 0; i < 5; i++)
                Tasks.Append(Task.Delay(200));
            Task.WaitAll(Tasks.ToArray());
            timer.Stop();
            Console.WriteLine($"Текущий поток: {Thread.CurrentThread.ManagedThreadId}. Время выполнения: {timer.Elapsed}");
            return;
        }

        private async static Task TestRun()
        {
            Task.Run(() => Console.WriteLine($"Текущий поток: {Thread.CurrentThread.ManagedThreadId}"));
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
                //TestAwaitMultiple();
                //TestAwaitMultiple2();
                //TestRun();
            }
            Console.WriteLine("Работа основного потока завершена...");
            Console.ReadKey();
        }
    }
}
