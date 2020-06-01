using System;
using System.IO;

namespace StudentsClass
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string[] allLinesFromFile = File.ReadAllLines(@"..\..\..\..\students.txt");

                ListOfStudents listOfStudents = new ListOfStudents(allLinesFromFile);

                listOfStudents.sort();

                File.WriteAllLines(@"..\..\..\..\sortedStudents.txt", listOfStudents.getOutputFormat());
            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
            }
        }
    }
}
