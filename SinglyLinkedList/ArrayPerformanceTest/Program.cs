using System.Diagnostics;
using System;
using SinglyLinkedList;

namespace ArrayPerformanceTest
{
    class Program
    {
        static void Main(string[] args)
        {
            const int antalPersoner = 10000;

            Console.WriteLine($"--- Array-inläggning ({antalPersoner} personer) ---\n");

            InsertAtBeginning(antalPersoner);
            InsertAtMiddle(antalPersoner);
            InsertAtEnd(antalPersoner);
        }

        static void InsertAtBeginning(int antal)
        {
            Person[] array = new Person[antal];
            int currentSize = 0;

            Stopwatch sw = Stopwatch.StartNew();

            for (int i = 0; i < antal; i++)
            {
                // Skifta höger
                for (int j = currentSize; j > 0; j--)
                {
                    array[j] = array[j - 1];
                }

                array[0] = new Person($"Person{i}", i, "Yrke");
                currentSize++;
            }

            sw.Stop();
            Console.WriteLine("I början: " + sw.Elapsed.TotalMilliseconds + " ms");
        }

        static void InsertAtMiddle(int antal)
        {
            Person[] array = new Person[antal];
            int currentSize = 0;

            Stopwatch sw = Stopwatch.StartNew();

            for (int i = 0; i < antal; i++)
            {
                int insertIndex = currentSize / 2;

                for (int j = currentSize; j > insertIndex; j--)
                {
                    array[j] = array[j - 1];
                }

                array[insertIndex] = new Person($"Person{i}", i, "Yrke");
                currentSize++;
            }

            sw.Stop();
            Console.WriteLine("I mitten: " + sw.Elapsed.TotalMilliseconds + " ms");
        }

        static void InsertAtEnd(int antal)
        {
            Person[] array = new Person[antal];

            Stopwatch sw = Stopwatch.StartNew();

            for (int i = 0; i < antal; i++)
            {
                array[i] = new Person($"Person{i}", i, "Yrke");
            }

            sw.Stop();
            Console.WriteLine("I slutet: " + sw.Elapsed.TotalMilliseconds + " ms");
        }
    }
}
