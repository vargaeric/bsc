using System;

namespace NamesClass
{
    class Program
    {
        static void Main(string[] args)
        {
            try 
            {
                Names names = new Names(6);

                // This line will throw IndexOutOfRangeException and stops the program
                // names[-1] = "King Luke";

                names[2] = "Cooper Ryan";
                names[4] = "Jordan Larry";

                // This line will throw IndexOutOfRangeException and stops the program
                // names[8] = "Jack Samuel";

                names.printAllTheNames();

                Console.WriteLine(names["Cooper Ryan"]);

                // This line will throw custom exception ("There is no such name in the list!")
                // and stops the program
                Console.WriteLine(names["King Arnold"]);
            }
            catch(Exception error)
            {
                Console.WriteLine(error.Message);
            }
        }
    }
}
