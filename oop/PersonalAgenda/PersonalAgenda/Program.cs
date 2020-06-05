using System;
using System.Collections.Generic;

namespace PersonalAgenda
{
    class Program
    {
        static void separatorLine()
        {
            Console.WriteLine("_____________________________________________________");
        }

        static void Main(string[] args)
        {
            try
            {
                // Create list of persons and activites
                List<Person> persons = new List<Person>();
                List<Activity> activites = new List<Activity>();

                // Read data from CSV files
                persons = ProcessData.parsePersonsCSVFile("../../../../persons.csv");
                activites = ProcessData.parseActivitesCSVFile("../../../../activites.csv");

                // Attach events to persons
                activites.ForEach(delegate (Activity activity)
                {
                    foreach(int participantId in activity.Participants)
                        for(int i = 0; i < persons.Count; i++)
                            if(persons[i].Id == participantId)
                                persons[i].PersonsAgenda.addActivity(activity);
                });

                bool exit = false;

                ProcessData.help();

                while (exit == false)
                {
                    separatorLine();
                    Console.Write("Enter your command: ");
                    exit = ProcessData.processCommand(Console.ReadLine(), persons, activites);
                }

                foreach (Person person in persons)
                {
                    Console.WriteLine(person.ToString());
                }
            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
            }
        }
    }
}
