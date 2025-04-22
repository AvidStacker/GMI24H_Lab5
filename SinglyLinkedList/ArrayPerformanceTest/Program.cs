using System;
using System.Diagnostics;

namespace ArrayPerformanceTest
{
    // Program som mäter tidsåtgång för inläggning av objekt i en array 
    // vid början, mitten och slutet, för att jämföra prestanda.
    class Program
    {
        static void Main(string[] args)
        {
            const int antalPersoner = 10000;

            // Skapa en array med unika personer (så ID inte krockar)
            Person[] personer = GenerateUniquePersons(antalPersoner);

            Console.WriteLine($"--- Array-inläggning ({antalPersoner} personer) ---\n");

            InsertAtBeginning(personer); // Inläggning i början av arrayen
            InsertAtMiddle(personer);    // Inläggning i mitten av arrayen
            InsertAtEnd(personer);       // Inläggning i slutet av arrayen
        }

        // Skapar en array av unika Person-objekt för testerna
        static Person[] GenerateUniquePersons(int antal)
        {
            Person[] personer = new Person[antal];

            for (int i = 0; i < antal; i++)
            {
                personer[i] = new Person($"Person{i}", i + 1, "Yrke"); // ID startar från 1
            }

            return personer;
        }

        // Lägger till personer i början av en array och mäter tiden det tar.
        // För varje ny inläggning skiftas befintliga element ett steg åt höger.
        static void InsertAtBeginning(Person[] personer)
        {
            Person[] array = new Person[personer.Length];
            int currentSize = 0;

            Stopwatch sw = Stopwatch.StartNew();

            foreach (var person in personer)
            {
                // Skiftar alla element åt höger för att göra plats i början
                for (int j = currentSize; j > 0; j--)
                {
                    array[j] = array[j - 1];
                }

                array[0] = person;
                currentSize++;
            }

            sw.Stop();
            Console.WriteLine("I början: " + sw.Elapsed.TotalMilliseconds + " ms");
        }

        // Lägger till personer i mitten av en array och mäter tiden det tar.
        // Skiftar elementen åt höger från mitten vid varje ny inläggning.
        static void InsertAtMiddle(Person[] personer)
        {
            Person[] array = new Person[personer.Length];
            int currentSize = 0;

            Stopwatch sw = Stopwatch.StartNew();

            foreach (var person in personer)
            {
                int insertIndex = currentSize / 2;

                // Skiftar alla element åt höger från insertIndex
                for (int j = currentSize; j > insertIndex; j--)
                {
                    array[j] = array[j - 1];
                }

                array[insertIndex] = person;
                currentSize++;
            }

            sw.Stop();
            Console.WriteLine("I mitten: " + sw.Elapsed.TotalMilliseconds + " ms");
        }

        // Lägger till personer i slutet av en array och mäter tiden det tar.
        // Ingen skiftning krävs, vilket gör det till den mest effektiva operationen.
        static void InsertAtEnd(Person[] personer)
        {
            Person[] array = new Person[personer.Length];

            Stopwatch sw = Stopwatch.StartNew();

            for (int i = 0; i < personer.Length; i++)
            {
                array[i] = personer[i];
            }

            sw.Stop();
            Console.WriteLine("I slutet: " + sw.Elapsed.TotalMilliseconds + " ms");
        }
    }
}
