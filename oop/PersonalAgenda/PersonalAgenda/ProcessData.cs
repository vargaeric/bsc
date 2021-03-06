﻿using System;
using System.IO;
using System.Collections.Generic;

namespace PersonalAgenda
{
    internal class ProcessData
    {
        private static string pathToPersonsCSVFile;
        private static string pathToActivitesCSVFile;
        private static string personsCSVFileHeader;
        private static string activitesCSVFileHeader;

        public static List<Person> parsePersonsCSVFile(string path)
        {
            pathToPersonsCSVFile = path;

            List<Person> persons = new List<Person>();

            string[] allLinesFromFile = File.ReadAllLines(@path);

            personsCSVFileHeader = allLinesFromFile[0];

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
            pathToActivitesCSVFile = path;

            List<Activity> activites = new List<Activity>();

            string[] allLinesFromFile = File.ReadAllLines(@path);

            activitesCSVFileHeader = allLinesFromFile[0];

            for (int i = 1; i < allLinesFromFile.Length; i++)
            {
                string[] activityInfos = allLinesFromFile[i].Split(", ");

                List<int> participantsIds = new List<int>(Array.ConvertAll(activityInfos[5].Split(";"), int.Parse));

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

        public static void writePersonsCSVFile(List<Person> persons, string path)
        {
            string[] output = new string[persons.Count + 1];

            output[0] = personsCSVFileHeader;

            for(int i = 0; i < persons.Count; i++)
            {
                output[i + 1] = Convert.ToString(persons[i].Id) + ", ";
                output[i + 1] += persons[i].LastName + ", ";
                output[i + 1] += persons[i].FirstName + ", ";
                output[i + 1] += getDateTimeInString(persons[i].Birthdate) + ", ";
                output[i + 1] += persons[i].Email;
            }

            File.WriteAllLines(@path, output);
        }

        public static void writeActivitesCSVFile(List<Activity> activites, string path)
        {
            string[] output = new string[activites.Count + 1];

            output[0] = activitesCSVFileHeader;

            for (int i = 0; i < activites.Count; i++)
            {
                output[i + 1] = Convert.ToString(activites[i].Id) + ", ";
                output[i + 1] += activites[i].Name + ", ";
                output[i + 1] += activites[i].Description + ", ";
                output[i + 1] += getDateTimeInString(activites[i].StartDate) + ", ";
                output[i + 1] += getDateTimeInString(activites[i].EndDate) + ", ";

                int[] participantsIds = activites[i].Participants.ToArray();
                output[i + 1] += string.Join(";", Array.ConvertAll(participantsIds, id => id.ToString()));
            }

            File.WriteAllLines(@path, output);
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
            commands += "save (write the modified data in the files)\n";
            commands += "create-person (creates a new person)\n";
            commands += "create-event (creates a new event)\n";
            commands += "delete-person (deletes a person)\n";
            commands += "delete-event (deletes an event)\n";
            commands += "search-person (search for a person)\n";
            commands += "search-event (search for an event)\n";
            commands += "see-person-events (list all the events of a person)\n";
            commands += "generate-report (list all the events of a person in a given interval)\n";
            commands += "exit (exit the program)\n";

            Console.WriteLine(commands);
        }

        public static void save(List<Person> persons, List<Activity> activites)
        {
            writePersonsCSVFile(persons, pathToPersonsCSVFile);
            writeActivitesCSVFile(activites, pathToActivitesCSVFile);

            Console.WriteLine("The data has been successfully saved in the files!");
        }

        public static bool processCommand(string commandInput, List<Person> persons, List<Activity> activites)
        {
            bool exitProgram = false;

            if (commandInput.Contains("help"))
            {
                help();
            }
            else if (commandInput.Contains("save"))
            {
                save(persons, activites);
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
                deletePerson(persons, activites);
            }
            else if (commandInput.Contains("delete-event"))
            {
                deleteEvent(activites, persons);
            }
            else if (commandInput.Contains("search-person"))
            {
                searchPerson(persons);
            }
            else if (commandInput.Contains("search-event"))
            {
                searchEvent(activites);
            }
            else if (commandInput.Contains("see-person-events"))
            {
                seePersonEvents(persons);
            }
            else if (commandInput.Contains("generate-report"))
            {
                generateReport(persons);
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

            Console.Write("Last name = ");
            string lastName = Console.ReadLine();

            Console.Write("First name = ");
            string firstName = Console.ReadLine();

            Console.Write("Birthdate name = ");
            string birthdate = Console.ReadLine();

            Console.Write("Email name = ");
            string email = Console.ReadLine();

            Person newPerson = new Person(id, lastName, firstName, birthdate, email);
            persons.Add(newPerson);
        }

        public static void createEvent(List<Activity> activites, List<Person> persons)
        {
            int id = activites[activites.Count - 1].Id + 1;

            Console.Write("Name = ");
            string name = Console.ReadLine();

            Console.Write("Description = ");
            string description = Console.ReadLine();

            Console.Write("Start date = ");
            string startDate = Console.ReadLine();

            Console.Write("End date = ");
            string endDate = Console.ReadLine();


            Console.Write("Participants Ids (separated with ;) = ");
            string participantsIdsString = Console.ReadLine();

            List<int> participantsIds = new List<int>(Array.ConvertAll(participantsIdsString.Split(";"), int.Parse));

            bool participantExists = true;

            for (int i = 0; i < participantsIds.Count && participantExists == true; i++)
            {
                participantExists = false;

                for (int j = 0; j < persons.Count; j++)
                {
                    if (participantsIds[i] == persons[j].Id)
                        participantExists = true;
                }
            }

            // If the above for has ended and the variable participantExists is false
            // it means that one of the given participants does not exists in the persons list
            if (participantExists == false)
                Console.WriteLine("One of the given participants does not exits in the person list!");
            else
            {
                Activity newActivity = new Activity(id, name, description, startDate, endDate, participantsIds);

                for (int i = 0; i < participantsIds.Count; i++)
                    for (int j = 0; j < persons.Count; j++)
                        if (persons[j].Id == participantsIds[i])
                            persons[j].Agenda.addActivity(newActivity);

                activites.Add(newActivity);
            }
        }

        public static void deletePerson(List<Person> persons, List<Activity> activites)
        {
            Console.Write("Give the ID of the person you want to delete = ");
            int personToDeleteID = Convert.ToInt32(Console.ReadLine());

            Person personToDelete = null;
            int participantId;

            for (int i = 0; i < persons.Count && personToDelete == null; i++)
                if (persons[i].Id == personToDeleteID)
                    personToDelete = persons[i];

            if (personToDelete != null)
            {
                persons.Remove(personToDelete);

                for (int i = 0; i < activites.Count; i++)
                {
                    participantId = -1;

                    for (int j = 0; j < activites[i].Participants.Count; j++)
                        if (activites[i].Participants[j] == personToDeleteID)
                            participantId = activites[i].Participants[j];

                    if (participantId != -1)
                        activites[i].Participants.Remove(participantId);

                    // If the activity does not have any participants remove it completely from the list
                    if(activites[i].Participants.Count == 0)
                    {
                        activites.Remove(activites[i]);
                        i--;
                    }
                }
            }
            else
                Console.WriteLine("There is no person with the given ID.");
        }

        public static void deleteEvent(List<Activity> activites, List<Person> persons)
        {
            Console.Write("Give the ID of the activity you want to delete = ");
            int activityToDeleteID = Convert.ToInt32(Console.ReadLine());

            Activity activityToDelete = null;

            for (int i = 0; i < activites.Count && activityToDelete == null; i++)
                if (activites[i].Id == activityToDeleteID)
                    activityToDelete = activites[i];

            if (activityToDelete != null)
            {
                activites.Remove(activityToDelete);

                foreach(Person person in persons)
                    person.Agenda.removeActivity(activityToDelete);
            }
            else
            {
                Console.WriteLine("There is no activity with the given ID.");
            }
        }

        public static void searchPerson(List<Person> persons)
        {
            Console.Write("Give the last name / first name / full name of the person = ");

            string searchByThisText = Console.ReadLine();

            bool found = false;

            for(int i = 0; i < persons.Count; i++)
                if ($"{persons[i].LastName.ToLower()} {persons[i].FirstName.ToLower()}".Contains(searchByThisText.ToLower()))
                {
                    found = true;
                    Console.WriteLine(persons[i].ToString());
                }

            if (!found)
                Console.WriteLine("Could not find a person with this name.");
        }

        public static void searchEvent(List<Activity> activites)
        {
            Console.Write("Give some keywords in the event name or description = ");

            string searchByThisText = Console.ReadLine();

            bool found = false;

            for (int i = 0; i < activites.Count; i++)
                if ($"{activites[i].Name.ToLower()} {activites[i].Description.ToLower()}".Contains(searchByThisText.ToLower()))
                {
                    found = true;
                    Console.WriteLine(activites[i].ToString());
                }

            if (!found)
                Console.WriteLine("Could not find activity with this name or description.");
        }

        public static void seePersonEvents(List<Person> persons)
        {
            Console.Write("Give the person's ID to see all his/her events = ");

            int personId = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine();

            for (int i = 0; i < persons.Count; i++)
                if (persons[i].Id == personId)
                {
                    persons[i].Agenda.sortActivitesByDate();
                    Console.WriteLine(persons[i].Agenda.ToString());
                }
        }

        public static void generateReport(List<Person> persons)
        {
            Console.Write("Give the person's ID to see his/her events in a given interval = ");

            int personId = Convert.ToInt32(Console.ReadLine());

            Console.Write("Give the start date of the interval = ");

            DateTime startDate = getDateTimeFormat(Console.ReadLine());

            Console.Write("Give the end date of the interval = ");

            DateTime endDate = getDateTimeFormat(Console.ReadLine());

            Console.WriteLine();

            bool afterTheStartDate = false;
            bool passedTheEndDate = false;

            for (int i = 0; i < persons.Count; i++)
                if (persons[i].Id == personId)
                {
                    persons[i].Agenda.sortActivitesByDate();

                    for (int j = 0; j < persons[i].Agenda.activites.Count && !passedTheEndDate; j++)
                    {
                        // True if the activity start date after the given start date or in that exact same second
                        if (DateTime.Compare(startDate, persons[i].Agenda.activites[j].StartDate) == -1
                            || DateTime.Compare(startDate, persons[i].Agenda.activites[j].StartDate) == 0
                        )
                            afterTheStartDate = true;

                        // Will give true if the activity start date is after the given end date
                        if (DateTime.Compare(endDate, persons[i].Agenda.activites[j].StartDate) == -1)
                            passedTheEndDate = true;

                        if (afterTheStartDate && !passedTheEndDate)
                            Console.WriteLine(persons[i].Agenda.activites[j]);
                    }
                }
        }
    }
}