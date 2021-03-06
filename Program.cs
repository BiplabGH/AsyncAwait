﻿using System;
using System.Threading.Tasks;

namespace AsyncAwait
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(SumTwoOperationsAsync().GetAwaiter().GetResult());
        }

        public static async Task<int> SumTwoOperationsAsync()
        {
            var firstTask = GetOperationOneAsync();
            var secondTask = GetOperationTwoAsync(); //This task waits for the other task to complete. A log can be beneficial.
            return await firstTask + await secondTask;
        }


        private static async Task<int> GetOperationOneAsync()
        {
            await Task.Delay(5000); // Just to simulate an operation taking time
            Console.WriteLine("GetOperationOneAsync");
            return 10;
        }

        private static async Task<int> GetOperationTwoAsync()
        {
            await Task.Delay(100); // Just to simulate an operation taking time
            Console.WriteLine("GetOperationTwoAsync");
            return 5;
        }
    }
}
