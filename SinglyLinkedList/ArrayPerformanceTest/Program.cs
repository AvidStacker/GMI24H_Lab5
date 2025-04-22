using System.Diagnostics;
using System;

namespace ArrayPerformanceTest
{
    // Program som mäter tidsåtgång för inläggning av objekt i en array 
    // vid början, mitten och slutet, för att jämföra prestanda.
    class Program
    {
        static void Main(string[] args)
        {
            const int antalPersoner = 10000;

            Console.WriteLine($"--- Array-inläggning ({antalPersoner} personer) ---\n");

            InsertAtBeginning(antalPersoner); // Inläggning i början av arrayen
            InsertAtMiddle(antalPersoner);    // Inläggning i mitten av arrayen
            InsertAtEnd(antalPersoner);       // Inläggning i slutet av arrayen
        }

        // Lägger till personer i början av en array och mäter tiden det tar.
        // För varje ny inläggning skiftas befintliga element ett steg åt höger.
        static void InsertAtBeginning(int antal)
        {
            Person[] array = new Person[antal];
            int currentSize = 0;

            Stopwatch sw = Stopwatch.StartNew();

            for (int i = 0; i < antal; i++)
            {
                // Skiftar alla element åt höger för att göra plats i början
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

        // Lägger till personer i mitten av en array och mäter tiden det tar.
        // Skiftar elementen åt höger från mitten vid varje ny inläggning.
        static void InsertAtMiddle(int antal)
        {
            Person[] array = new Person[antal];
            int currentSize = 0;

            Stopwatch sw = Stopwatch.StartNew();

            for (int i = 0; i < antal; i++)
            {
                int insertIndex = currentSize / 2;

                // Skiftar alla element åt höger från insertIndex
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

        // Lägger till personer i slutet av en array och mäter tiden det tar.
        // Ingen skiftning krävs, vilket gör det till den mest effektiva operationen.
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
