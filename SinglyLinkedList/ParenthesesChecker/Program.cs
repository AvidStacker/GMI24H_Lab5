using System;
using System.Diagnostics;
using SinglyLinkedList;

namespace ParenthesesChecker
{
    internal class Program
    {
        static void Main()
        {
            bool running = true;

            while (running)
            {
                Console.WriteLine("\n--- Parentes Checker ---");
                Console.WriteLine("1. Testa ett uttryck med en Stack");
                Console.WriteLine("2. Testa ett uttryck med MyLinkedList");
                Console.WriteLine("3. Testa ett uttryck med en Array");
                Console.WriteLine("4. Exit");
                Console.Write("Välj ett alternativ (1, 2, 3 eller 4): ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Ange ett uttryck: ");
                        string input = Console.ReadLine();
                        Stopwatch swStack = Stopwatch.StartNew();
                        if (AreParenthesesBalancedWithStack(input))
                        {
                            swStack.Stop();
                            Console.WriteLine("Parenteserna i uttrycket är korrekt balanserade (Stack).");
                            Console.WriteLine("Tidsåtgång för Stack: " + swStack.Elapsed.TotalMilliseconds + " ms");
                        }
                        else
                        {
                            swStack.Stop();
                            Console.WriteLine("Parenteserna i uttrycket är inte korrekt balanserade (Stack).");
                            Console.WriteLine("Tidsåtgång för Stack: " + swStack.Elapsed.TotalMilliseconds + " ms");
                        }
                        break;

                    case "2":
                        Console.Write("Ange ett uttryck: ");
                        string inputLinkedList = Console.ReadLine();
                        Stopwatch swLinkedList = Stopwatch.StartNew();
                        if (AreParenthesesBalancedWithLinkedList(inputLinkedList))
                        {
                            swLinkedList.Stop();
                            Console.WriteLine("Parenteserna i uttrycket är korrekt balanserade (MyLinkedList).");
                            Console.WriteLine("Tidsåtgång för MyLinkedList: " + swLinkedList.Elapsed.TotalMilliseconds + " ms");
                        }
                        else
                        {
                            swLinkedList.Stop();
                            Console.WriteLine("Parenteserna i uttrycket är inte korrekt balanserade (MyLinkedList).");
                            Console.WriteLine("Tidsåtgång för MyLinkedList: " + swLinkedList.Elapsed.TotalMilliseconds + " ms");
                        }
                        break;

                    case "3":
                        Console.Write("Ange ett uttryck: ");
                        string inputArray = Console.ReadLine();
                        Stopwatch swArray = Stopwatch.StartNew();
                        if (AreParenthesesBalancedWithArray(inputArray))
                        {
                            swArray.Stop();
                            Console.WriteLine("Parenteserna i uttrycket är korrekt balanserade (Array).");
                            Console.WriteLine("Tidsåtgång för Array: " + swArray.Elapsed.TotalMilliseconds + " ms");
                        }
                        else
                        {
                            swArray.Stop();
                            Console.WriteLine("Parenteserna i uttrycket är inte korrekt balanserade (Array).");
                            Console.WriteLine("Tidsåtgång för Array: " + swArray.Elapsed.TotalMilliseconds + " ms");
                        }
                        break;

                    case "4":
                        Console.WriteLine("Avslutar programmet!");
                        running = false;
                        break;

                    default:
                        Console.WriteLine("Ogiltigt alternativ. Vänligen välj 1, 2, 3 eller 4.");
                        break;
                }
            }
        }

        // Stack Implementation
        static bool AreParenthesesBalancedWithStack(string expression)
        {
            Stack<char> stack = new Stack<char>();

            foreach (char ch in expression)
            {
                if (ch == '(')
                {
                    stack.Push(ch);
                }
                else if (ch == ')')
                {
                    if (stack.Count == 0)
                    {
                        return false;
                    }
                    stack.Pop();
                }
            }

            return stack.Count == 0;
        }

        // LinkedList Implementation
        static bool AreParenthesesBalancedWithLinkedList(string expression)
        {
            ListReferenceBased<char> linkedList = new ListReferenceBased<char>();

            foreach (char ch in expression)
            {
                if (ch == '(')
                {
                    linkedList.Add(ch, 1);
                }
                else if (ch == ')')
                {
                    if (linkedList.Size() == 0)
                    {
                        return false;
                    }
                    linkedList.Remove(1);
                }
            }

            return linkedList.Size() == 0;
        }

        // Array Implementation
        static bool AreParenthesesBalancedWithArray(string expression)
        {
            char[] array = new char[expression.Length];
            int top = -1;

            foreach (char ch in expression)
            {
                if (ch == '(')
                {
                    array[++top] = ch;
                }
                else if (ch == ')')
                {
                    if (top == -1)
                    {
                        return false;
                    }
                    top--;
                }
            }

            return top == -1;
        }
    }
}
