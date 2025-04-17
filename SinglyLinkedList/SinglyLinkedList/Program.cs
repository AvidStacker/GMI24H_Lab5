using System;
using System.Diagnostics;

namespace SinglyLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            ListReferenceBased<Person> list = new ListReferenceBased<Person>();

            Person p1 = new Person("Pelle", 1, "Fiskare");
            list.Add(p1, 1);
            Person p2 = new Person("Stefan", 2, "Bagare");
            list.Add(p2, 2);
            Person p3 = new Person("Anna", 3, "Advokat");
            list.Add(p3, 3);

            bool running = true;

            while (running)
            {
                Console.WriteLine("\n--- MENY ---");
                Console.WriteLine("1. Lägg till person");
                Console.WriteLine("2. Ta bort person");
                Console.WriteLine("3. Visa antal personer");
                Console.WriteLine("4. Är listan tom?");
                Console.WriteLine("5. Töm listan");
                Console.WriteLine("6. Hämta person på specifikt index");
                Console.WriteLine("7. Skriv ut hela listan");
                Console.WriteLine("8. Avsluta");
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
                        Console.Write("\nAnge position att lägga till på (1 till " + (list.Size() + 1) + "): ");
                        int position = int.Parse(Console.ReadLine());

                        try
                        {
                            Person p = new Person(name, id, profession);

                            Stopwatch stopwatch = Stopwatch.StartNew(); // Startar mätning
                            list.Add(p, position);
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
                        Console.Write("\nAnge position att ta bort (1 till " + list.Size() + "): ");
                        int index = int.Parse(Console.ReadLine());
                        try
                        {
                            Stopwatch stopwatch = Stopwatch.StartNew(); // Startar tidtagning
                            list.Remove(index);
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
                        Console.WriteLine("\nAntal personer i listan: " + list.Size());
                        break;

                    case "4":
                        Console.WriteLine(list.IsEmpty() ? "\nListan är tom." : "\nListan är inte tom.");
                        break;

                    case "5":
                        list.RemoveAll();
                        Console.WriteLine("\nListan har tömts.");
                        break;

                    case "6":
                        Console.Write("\nAnge index att hämta (1 till " + list.Size() + "): ");
                        int fetchIndex = int.Parse(Console.ReadLine());
                        try
                        {
                            Node<Person> foundNode = list.GetNode(fetchIndex);
                            Person foundPerson = foundNode.GetItem();
                            Console.WriteLine("\nPerson på index " + fetchIndex + " är: \nNamn: " + foundPerson.GetName() + ", Id: " + foundPerson.GetId() + ", Yrke: " + foundPerson.GetProfession());
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("\nFel: " + ex.Message);
                        }
                        break;

                    case "7":
                        list.PrintList();
                        break;

                    case "8":
                        running = false;
                        break;

                    default:
                        Console.WriteLine("\nOgiltigt val. Försök igen.");
                        break;
                }
            }

            Console.WriteLine("\nProgrammet avslutas.");
        }
    }
}
