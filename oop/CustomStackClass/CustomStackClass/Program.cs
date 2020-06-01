using System;

namespace CustomStackClass
{
    class Program
    {
        static void Main(string[] args)
        {
            void popAllElements<DataType>(CustomStack<DataType> stack)
            {
                while (!stack.Empty)
                    Console.WriteLine(stack.pop());

                Console.WriteLine();
            }

            try
            {
                CustomStack<int> customStack1 = new CustomStack<int>(5);

                customStack1.push(1000);
                customStack1.push(800);
                customStack1.push(600);
                customStack1.push(500);

                Console.WriteLine($"{customStack1.pop()}\n");

                customStack1.push(400);
                customStack1.push(200);

                // This line will throw custom exception ("You can't add new elements
                // because the stack is full!") and stops the program
                // customStack1.push(0);
                
                popAllElements(customStack1);

                CustomStack<string> customStack2 = new CustomStack<string>(4);

                customStack2.push("Jacob");
                customStack2.push("Thomas");
                customStack2.push("Charlie");
                customStack2.Clear();
                customStack2.push("Zoe");
                customStack2.push("Eric");
                customStack2.push("Benjamin");
                customStack2.push("Alex");

                popAllElements(customStack2);

                // This line will throw custom exception ("You can't pop element because
                // the stack is empty!" the stack is full!") and stops the program
                customStack2.pop();

            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
            }
        }
    }
}
