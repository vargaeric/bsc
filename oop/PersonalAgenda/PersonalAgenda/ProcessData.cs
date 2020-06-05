using System;
using System.IO;
using System.Collections.Generic;
using Microsoft.VisualBasic.FileIO;

namespace PersonalAgenda
{
    internal class ProcessData
    {
        public static List<Person> parsePersonsCSVFile(string path)
        {
            List<Person> persons = new List<Person>();

            string[] allLinesFromFile = File.ReadAllLines(@path);

            for (int i = 1; i < allLinesFromFile.Length; i++)
            {
                string[] personInfos = allLinesFromFile[i].Split(", ");

                Person person = new Person(
                    Convert.ToInt32(personInfos[0]),
                    personInfos[1],
                    personInfos[2],
                    personInfos[3],
                    personInfos[4]
                );

                persons.Add(person);
            }

            return persons;
        }

        public static List<Activity> parseActivitesCSVFile(string path)
        {
            List<Activity> activites = new List<Activity>();

            string[] allLinesFromFile = File.ReadAllLines(@path);

            for (int i = 1; i < allLinesFromFile.Length; i++)
            {
                string[] activityInfos = allLinesFromFile[i].Split(", ");

                int[] participantsIds = Array.ConvertAll(activityInfos[5].Split(";"), int.Parse);

                Activity activity = new Activity(
                    Convert.ToInt32(activityInfos[0]),
                    activityInfos[1],
                    activityInfos[2],
                    activityInfos[3],
                    activityInfos[4],
                    participantsIds
                );

                activites.Add(activity);
            }

            return activites;
        }

        public static DateTime getDateTimeFormat(string date)
        {
            DateTime formatedDateTime;
            var usCulture = new System.Globalization.CultureInfo("en-US");

            if (DateTime.TryParse(date, usCulture.DateTimeFormat, System.Globalization.DateTimeStyles.None, out formatedDateTime))
            {
                formatedDateTime = DateTime.ParseExact(date, "yyyy-MM-dd HH:mm:ss", usCulture.DateTimeFormat);
                return formatedDateTime;
            }
            else
                throw new Exception("Invalid date format, cannot convert to valid DateTime object!");
        }

        public static string getDateTimeInString(DateTime date)
            => date.ToString("yyyy-MM-dd HH:mm:ss");

        public static void help()
        {
            string commands = "";

            commands += "The commands can be the following ones:\n";
            commands += "help (list all the commands)\n";
            commands += "create-person (creates a new person)\n";
            commands += "create-event (creates a new event)\n";
            commands += "delete-person (deletes a person)\n";
            commands += "delete-event (deletes an event)\n";
            commands += "search-person (search for a person)\n";
            commands += "search-event (search for an event)\n";
            commands += "exit (exit the program)\n";

            Console.WriteLine(commands);
        }

        public static bool processCommand(string commandInput, List<Person> persons, List<Activity> activites)
        {
            bool exitProgram = false;

            if (commandInput.Contains("help"))
            {
                help();
            }
            else if (commandInput.Contains("create-person"))
            {
                createPerson(persons);
            }
            else if (commandInput.Contains("create-event"))
            {
                createEvent(activites, persons);
            }
            else if (commandInput.Contains("delete-person"))
            {
                deletePerson(persons);
            }
            else if (commandInput.Contains("delete-event"))
            {
                deleteEvent(activites, persons);
            }
            else if (commandInput.Contains("search-person"))
            {
                searchPerson();
            }
            else if (commandInput.Contains("search-event"))
            {
                searchEvent();
            }
            else if (commandInput.Contains("exit"))
            {
                exitProgram = true;
            }
            else
            {
                Console.WriteLine($"There is no command \"{commandInput}\"!");
                help();
            }    

            return exitProgram;
        }

        public static void createPerson(List<Person> persons)
        {
            int id = persons[persons.Count - 1].Id + 1;

            Console.Write("Last name=");
            string lastName = Console.ReadLine();

            Console.Write("First name=");
            string firstName = Console.ReadLine();

            Console.Write("Birthdate name=");
            string birthdate = Console.ReadLine();

            Console.Write("Email name=");
            string email = Console.ReadLine();

            Person newPerson = new Person(id, lastName, firstName, birthdate, email);
            persons.Add(newPerson);
        }

        public static void createEvent(List<Activity> activites, List<Person> persons)
        {
            int id = activites[activites.Count - 1].Id + 1;

            Console.Write("Name=");
            string name = Console.ReadLine();

            Console.Write("Description=");
            string description = Console.ReadLine();

            Console.Write("Start date=");
            string startDate = Console.ReadLine();

            Console.Write("End date=");
            string endDate = Console.ReadLine();


            Console.Write("Participants Ids (separated with ;)=");
            string participantsIdsString = Console.ReadLine();

            int[] participantsIds = Array.ConvertAll(participantsIdsString.Split(";"), int.Parse);

            Activity newActivity = new Activity(id, name, description, startDate, endDate, participantsIds);

            for (int i = 0; i < participantsIds.Length; i++)
                for (int j = 0; j < persons.Count; j++)
                    if (persons[j].Id == participantsIds[i])
                        persons[j].PersonsAgenda.addActivity(newActivity);

            activites.Add(newActivity);
        }

        public static void deletePerson(List<Person> persons)
        {
            Console.WriteLine("All the persons with their IDs:");

            foreach(Person person in persons)
                Console.WriteLine($"{person.Id} - {person.LastName} {person.FirstName}");

            Console.Write("Give the ID of the person you wan to delete= ");
            int personToDelete = Convert.ToInt32(Console.ReadLine());

            int personToDeleteIndex = -1;

            for (int i = 0; i < persons.Count; i++)
                if (persons[i].Id == personToDelete)
                    personToDeleteIndex = i;

            if (personToDeleteIndex != -1)
            {
                persons.RemoveAt(personToDeleteIndex);
            }
            else
            {
                Console.WriteLine("There is no person with the given ID.");
            }
        }

        public static void deleteEvent(List<Activity> activites, List<Person> persons)
        {

        }

        public static void searchPerson()
        {

        }

        public static void searchEvent()
        {

        }
    }
}