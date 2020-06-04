using System;

namespace PersonalAgenda
{
    internal class Person
    {
        public int Id { get; }
        public string LastName { get; }
        public string FirstName { get; }
        public DateTime Birthdate { get; }
        public string Email { get; }
        public Agenda PersonsAgenda { get; }
        public Person(int id, string lastName, string firstName, string birthdate, string email)
        {
            Id = id;
            LastName = lastName;
            FirstName = firstName;
            Birthdate = ProcessData.getDateTimeFormat(birthdate);
            Email = email;
            PersonsAgenda = new Agenda();
        }

        public override string ToString()
        {
            string output = "";

            output += $"-----Person ({Id})----------\n";
            output += $"Full name: {LastName} {FirstName}\n";
            output += $"Birthdate: {ProcessData.getDateTimeInString(Birthdate)}\n";
            output += $"Email: {Email}\n";
            output += "-------------------------\n";

            return output;
        }
    }
}