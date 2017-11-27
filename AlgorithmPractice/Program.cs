using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using System.Timers;

namespace AlgorithmPractice
{
   public class Program : Methods
    {


        public static void Main(string[] args)
        {
            int[] Arr = { 2, 4, 3, 5, 10, 8, 9, 15, 20, 17, 16, 1, 6, 14, 19, 11, 13, 18, 7, 12 };
            Console.Write("Which Algorithm is Fastest? Here is your input method");
          
            Waiting();
            ThreadCount(Arr);
            Waiting();
            ThreadCount2(Arr);
           
            Console.ReadKey();
            
        }


    }


    public class Methods
    {

        public static void ThreadCount(int[] Arr)
        {

            Stopwatch Select = Stopwatch.StartNew();
          
            SelectionSort(Arr);
            Select.Stop();

            Console.Write(String.Format(" Time taken: {0}ms, ", Select.Elapsed.TotalMilliseconds));

        }
        public static void ThreadCount2(int[] Arr)
        {
            Stopwatch Insert = Stopwatch.StartNew();
            
            InsertionSort(Arr);
            Insert.Stop();
            Console.Write(" Time taken: {0}ms, ", Insert.Elapsed.TotalMilliseconds);
        }
        //The waiting method is to simulate a loading time
        public static void Waiting()
        {

            int Co = 4000;

            Console.WriteLine("Calculating Please Wait..");
            Parallel.Invoke(() => Thread.Sleep(Co),
            () => For());
         //using parrelel programming we can invoke two methods running at the same time. 

        }
        public static void For()
        {
            
            for (int i = 0; i < 10; i++)
            {
                Console.Write(". ");
                Thread.Sleep(400);
            }


        }

        //start of the algorithmic Sorts
        public static void SelectionSort(int[] arr)
        {
            Console.WriteLine("\n Selection Sort: ");
            int Posmin;
            int Temp;
            for (int i = 0; i < arr.Length; i++)
            {
                Posmin = i;
                for (int j = i + 1; j < arr.Length; j++)
                {

                    if (arr[j] < arr[Posmin])
                    {
                        Posmin = j;
                    }
                }
                if (Posmin != i)
                {
                    Temp = arr[i];
                    arr[i] = arr[Posmin];
                    arr[Posmin] = Temp;
                }
                Console.Write(String.Format("{0}, ", arr[i]));
            }

        }

        public static void InsertionSort(int[] Arr)
        {
            Console.WriteLine("\n Insertion Sort: ");
            for (int i = 1; i < Arr.Length; i++)
            {
                int Temp = Arr[i];
                int j = i;
                while ((j > 0) && (Arr[j - 1] > Temp))
                {
                    Arr[j] = Arr[j - 1];
                    j--;
                    Arr[j] = Temp;
                }
            }
            foreach (int val in Arr)
            {
                Console.Write(val + ", ");
            }
        }

        
    }

}
