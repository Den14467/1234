using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleApplication9
{
    class Program
    {
        static int[] array = { 1, 2, 3, 4, 5, 6, 7, 8 };

        static int result = 0;
        static void Main(string[] args)
        {
            int[] multiplicationResults = new int[array.Length / 2];


            Thread[] threads = new Thread[multiplicationResults.Length];


            for (int i = 0; i < multiplicationResults.Length; i++)
            {
                int index = i;
                threads[i] = new Thread(() => MultiplyAndSum(index * 2, index * 2 + 1));
                threads[i].Start();
            }
            foreach (var thread in threads)
            {
                thread.Join();
            }


            Console.WriteLine("Результат: " + result);
            Console.ReadKey();
        }
       
        static void MultiplyAndSum(int index1, int index2)
        {
            int multiplicationResult = array[index1] * array[index2];

            Interlocked.Add(ref result, multiplicationResult);
        }
        
    }
}
