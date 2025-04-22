using System;
using System.Diagnostics;

namespace SinglyLinkedList
{
    class Program
    {
        // Huvudmetoden som kör menyvalet för användaren och hanterar listoperationer.

        static void Main(string[] args)
        {
            ListReferenceBased<Person> linkedlinkedList = new ListReferenceBased<Person>();

            bool running = true;

            while (running)
            {
                Console.WriteLine("\n--- MENY ---");
                Console.WriteLine("1. Lägg till person");
                Console.WriteLine("2. Ta bort person");
                Console.WriteLine("3. Visa antal personer");
                Console.WriteLine("4. Är linkedListan tom?");
                Console.WriteLine("5. Töm linkedListan");
                Console.WriteLine("6. Hämta person på specifikt index");
                Console.WriteLine("7. Skriv ut hela linkedListan");
                Console.WriteLine("8. Kör prestandatest (InsertAtBeginning/Middle/End)");
                Console.WriteLine("9. Avsluta");

                Console.Write("Välj ett alternativ: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("\nAnge namn: ");
                        string name = Console.ReadLine();
                        Console.Write("Ange ID (heltal): ");
                        int id = int.Parse(Console.ReadLine());
                        Console.Write("Ange yrke: ");
                        string profession = Console.ReadLine();
                        Console.Write("\nAnge position att lägga till på (1 till " + (linkedlinkedList.Size() + 1) + "): ");
                        int position = int.Parse(Console.ReadLine());

                        try
                        {
                            Person p = new Person(name, id, profession);

                            Stopwatch stopwatch = Stopwatch.StartNew(); // Startar mätning
                            linkedlinkedList.Add(p, position);
                            stopwatch.Stop(); // Stoppar mätning

                            Console.WriteLine("\nPerson tillagd.");
                            Console.WriteLine("Tidsåtgång för tillägg: " + stopwatch.Elapsed.TotalMilliseconds + " ms");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("\nFel: " + ex.Message);
                        }
                        break;

                    case "2":
                        Console.Write("\nAnge position att ta bort (1 till " + linkedlinkedList.Size() + "): ");
                        int index = int.Parse(Console.ReadLine());
                        try
                        {
                            Stopwatch stopwatch = Stopwatch.StartNew(); // Startar tidtagning
                            linkedlinkedList.Remove(index);
                            stopwatch.Stop(); // Stoppar tidtagning

                            Console.WriteLine("\nPerson borttagen.");
                            Console.WriteLine("Tidsåtgång för borttagning: " + stopwatch.Elapsed.TotalMilliseconds + " ms");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("\nFel: " + ex.Message);
                        }
                        break;

                    case "3":
                        Console.WriteLine("\nAntal personer i linkedListan: " + linkedlinkedList.Size());
                        break;

                    case "4":
                        Console.WriteLine(linkedlinkedList.IsEmpty() ? "\nlinkedListan är tom." : "\nlinkedListan är inte tom.");
                        break;

                    case "5":
                        linkedlinkedList.RemoveAll();
                        Console.WriteLine("\nlinkedListan har tömts.");
                        break;

                    case "6":
                        Console.Write("\nAnge index att hämta (1 till " + linkedlinkedList.Size() + "): ");
                        int fetchIndex = int.Parse(Console.ReadLine());
                        try
                        {
                            Node<Person> foundNode = linkedlinkedList.GetNode(fetchIndex);
                            Person foundPerson = foundNode.GetItem();
                            Console.WriteLine("\nPerson på index " + fetchIndex + " är: \nNamn: " + foundPerson.GetName() + ", Id: " + foundPerson.GetId() + ", Yrke: " + foundPerson.GetProfession());
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("\nFel: " + ex.Message);
                        }
                        break;

                    case "7":
                        linkedlinkedList.PrintList();
                        break;

                    case "8":
                        const int antalPersoner = 10000;
                        Console.WriteLine($"\n--- Länkad linkedLista-inläggning ({antalPersoner} personer) ---\n");

                        ListReferenceBased<Person> testLinkedList = new ListReferenceBased<Person>();

                        InsertAtBeginningLinkedList(testLinkedList, antalPersoner);
                        InsertAtMiddleLinkedList(testLinkedList, antalPersoner);
                        InsertAtEndLinkedList(testLinkedList, antalPersoner);
                        break;

                    case "9":
                        running = false;
                        break;

                    default:
                        Console.WriteLine("\nOgiltigt val. Försök igen.");
                        break;
                }
            }

            Console.WriteLine("\nProgrammet avslutas.");
        }

        // Lägger till ett givet antal personer i början av listan och mäter tidsåtgången.
        static void InsertAtBeginningLinkedList(ListReferenceBased<Person> linkedList, int antal)
        {
            int startingIndex = linkedList.Size();

            Stopwatch sw = Stopwatch.StartNew();

            for (int i = startingIndex; i < startingIndex + antal; i++)
            {
                try
                {
                    Person person = new Person($"Person{i}", i + 1, "Yrke"); // i + 1 to avoid ID 0
                    linkedList.Add(person, 1);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine("Fel vid inläggning av person: " + ex.Message);
                }
            }

            sw.Stop();
            Console.WriteLine("I början (LinkedlinkedList): " + sw.Elapsed.TotalMilliseconds + " ms");
        }

        // Lägger till ett givet antal personer i mitten av listan och mäter tidsåtgången.
        static void InsertAtMiddleLinkedList(ListReferenceBased<Person> linkedList, int antal)
        {
            int startingIndex = linkedList.Size();

            Stopwatch sw = Stopwatch.StartNew();

            for (int i = startingIndex; i < startingIndex + antal; i++)
            {
                try
                {
                    int middlePosition = linkedList.Size() / 2 + 1;
                    Person person = new Person($"Person{i}", i + 1, "Yrke");
                    linkedList.Add(person, middlePosition);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine("Fel vid inläggning av person: " + ex.Message);
                }
            }

            sw.Stop();
            Console.WriteLine("I mitten (LinkedlinkedList): " + sw.Elapsed.TotalMilliseconds + " ms");
        }

        // Lägger till ett givet antal personer i slutet av listan och mäter tidsåtgången.
        static void InsertAtEndLinkedList(ListReferenceBased<Person> linkedList, int antal)
        {
            int startingIndex = linkedList.Size();

            Stopwatch sw = Stopwatch.StartNew();

            for (int i = startingIndex; i < startingIndex + antal; i++)
            {
                try
                {
                    int endPosition = linkedList.Size() + 1;
                    Person person = new Person($"Person{i}", i + 1, "Yrke");
                    linkedList.Add(person, endPosition);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine("Fel vid inläggning av person: " + ex.Message);
                }
            }

            sw.Stop();
            Console.WriteLine("I slutet (LinkedlinkedList): " + sw.Elapsed.TotalMilliseconds + " ms");
        }

    }
}
