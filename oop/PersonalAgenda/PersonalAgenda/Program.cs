using System;
using System.Collections.Generic;

namespace PersonalAgenda
{
    class Program
    {
        // Read and process the commands given by user
        static void processCommands(bool exit, List<Person> persons, List<Activity> activites)
        {
            try
            {
                while (exit == false)
                {
                    Console.WriteLine("_____________________________________________________\n");
                    Console.Write("Enter your command = ");

                    string usersCommand = Console.ReadLine();

                    Console.WriteLine();

                    exit = ProcessData.processCommand(usersCommand, persons, activites);
                }
            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);

                // Despite getting into an error we want to process commands in continue from
                // the user if he/she did not wanted to exit
                if (exit == false)
                    processCommands(exit, persons, activites);
            }
        }

        static void Main(string[] args)
        {
            bool exit = false;

            // Create list of persons and activites
            List<Person> persons = new List<Person>();
            List<Activity> activites = new List<Activity>();

            string pathToPersonsCSVFile = "../../../../persons.csv";
            string pathToActivitesCSVFile = "../../../../activites.csv";

            bool errorParsingCSVFiles = false;

            try
            {
                // Read data from CSV files
                persons = ProcessData.parsePersonsCSVFile(pathToPersonsCSVFile);
                activites = ProcessData.parseActivitesCSVFile(pathToActivitesCSVFile);
            }
            catch (Exception error)
            {
                errorParsingCSVFiles = true;

                Console.WriteLine("Something went wrong while trying to parse data from the CSV files:");
                Console.WriteLine(error.Message);
            }

            // We should only continue if reading data from the CSV files was successful
            if (!errorParsingCSVFiles)
                try
                {
                    // Attach events to persons
                    activites.ForEach(delegate (Activity activity)
                    {
                        foreach (int participantId in activity.Participants)
                            for (int i = 0; i < persons.Count; i++)
                                if (persons[i].Id == participantId)
                                    persons[i].PersonsAgenda.addActivity(activity);
                    });

                    ProcessData.help();

                    processCommands(exit, persons, activites);
                }
                catch (Exception error)
                {
                    Console.WriteLine("Something went wrong while trying to attach events to the persons.");
                    Console.WriteLine(error.Message);
                }
        }
    }
}
