using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Web_Server_Asynchronous_Processing
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            var task = new List<Task>();

            for (int i = 0; i < 100; i++)
            {
                var current = i;
                var tasks = Task.Run(() =>
                {
                    Console.WriteLine($"Task {current}");
                });

                task.Add(tasks);
            }

            for (int i = 100; i < 200; i++)
            {
                var current = i;
                var tasks = Task.Run(() =>
                {
                    Console.WriteLine($"Task {current}");
                });
                task.Add(tasks);
            }
            var evenNumberTasks = Task.Run(() =>
            {
                for (int i = 0; i < 100; i+=2)
                {
                    Console.WriteLine($"even number task {i}");
                }
            });
            var oddNumberTasks = Task.Run(() =>
            {
                for (int i = 1; i < 100; i += 2)
                {
                    Console.WriteLine($"odd number task {i}");
                }
            });
            Task.WaitAll(evenNumberTasks, oddNumberTasks);
            Task.WaitAll(task.ToArray());

            var startThread = new RunningThread();
            startThread.Run();

            var runningTasks = new RunningTasks();
            var result = runningTasks.Run();
            Task.WaitAll(result);

            var cookingBudger = new AsyncCooker();
            var cookingBudgersResult = cookingBudger.Work();
            Task.WaitAll(cookingBudgersResult);
        }
    }
}
