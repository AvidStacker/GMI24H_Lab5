using System;

namespace SinglyLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            ListReferenceBased list = new ListReferenceBased();
            bool running = true;

            while (running)
            {
                Console.WriteLine("\n--- MENY ---");
                Console.WriteLine("1. Lägg till person");
                Console.WriteLine("2. Ta bort person");
                Console.WriteLine("3. Visa antal personer");
                Console.WriteLine("4. Är listan tom?");
                Console.WriteLine("5. Töm listan");
                Console.WriteLine("6. Avsluta");
                Console.Write("Välj ett alternativ: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Ange namn: ");
                        string name = Console.ReadLine();
                        Console.Write("Ange ID (heltal): ");
                        int id = int.Parse(Console.ReadLine());
                        Console.Write("Ange yrke: ");
                        string profession = Console.ReadLine();
                        Console.Write("Ange position att lägga till på (1 till " + (list.Size() + 1) + "): ");
                        int position = int.Parse(Console.ReadLine());

                        try
                        {
                            Person p = new Person(name, id, profession);
                            list.Add(p, position);
                            Console.WriteLine("Person tillagd.");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Fel: " + ex.Message);
                        }
                        break;

                    case "2":
                        Console.Write("Ange position att ta bort (1 till " + list.Size() + "): ");
                        int index = int.Parse(Console.ReadLine());
                        try
                        {
                            list.Remove(index);
                            Console.WriteLine("Person borttagen.");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Fel: " + ex.Message);
                        }
                        break;

                    case "3":
                        Console.WriteLine("Antal personer i listan: " + list.Size());
                        break;

                    case "4":
                        Console.WriteLine(list.IsEmpty() ? "Listan är tom." : "Listan är inte tom.");
                        break;

                    case "5":
                        list.RemoveAll();
                        Console.WriteLine("Listan har tömts.");
                        break;

                    case "6":
                        running = false;
                        break;

                    default:
                        Console.WriteLine("Ogiltigt val. Försök igen.");
                        break;
                }
            }

            Console.WriteLine("Programmet avslutas.");
        }
    }
}
