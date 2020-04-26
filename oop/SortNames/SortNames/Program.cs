using System;
using System.IO;

namespace SortNames
{
    class Program
    {
        static void Main(string[] args)
        {
            string separators = "/\\`'\"()[]{}.,:; -!?";

            Person parseLine(string line)
            {
                Person person = new Person();
                string[] propNames = Person.propNames;
                // whichNameToAddChar: 0 - Lastname, 1 - Firstname, 2 - Middlename
                int whichNameToAddChar = 0;
                bool lastCharWasASep = false;
                string name = "";

                foreach (char character in line)
                {
                    if (separators.Contains(character))
                    {
                        lastCharWasASep = true;
                    }
                    else
                    {
                        if (lastCharWasASep)
                        {
                            person[propNames[whichNameToAddChar]] = name;
                            name = "";
                            whichNameToAddChar++;
                        }

                        name += character;

                        lastCharWasASep = false;
                    }

                    if (name != "")
                        person[propNames[whichNameToAddChar]] = name;
                }

                return person;
            }

            try
            {
                string path;

                Console.WriteLine("Give the path to the file with the names:");
                path = Console.ReadLine();

                string[] allLinesFromFile = File.ReadAllLines(@path);

                ListOfPersons listOfPersons = new ListOfPersons(allLinesFromFile.Length);
                string line;

                for (int i = 0; i < allLinesFromFile.Length; i++)
                {
                    line = allLinesFromFile[i];

                    listOfPersons.addPerson(parseLine(line), i);
                }
                
                listOfPersons.sortByName();
                string propName = Person.propNames[2];

                File.WriteAllLines(@"..\..\..\..\sortedNames.txt", listOfPersons.getOutputFormat());
            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
            }
        }
    }
}
