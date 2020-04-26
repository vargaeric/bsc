using System;
using System.Reflection;

namespace SortNames
{
    internal class Person
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public static string[] propNames = new string[3] { "LastName", "FirstName", "MiddleName"};

        public Person(string lastName = "", string firstName = "", string middleName = "")
        {
            LastName = lastName;
            FirstName = firstName;
            MiddleName = middleName;
        }

        public object this[string propertyName]
        {
            get
            {
                Type myType = typeof(Person);
                PropertyInfo myPropInfo = myType.GetProperty(propertyName);
                return myPropInfo.GetValue(this, null);
            }
            set
            {
                Type myType = typeof(Person);
                PropertyInfo myPropInfo = myType.GetProperty(propertyName);
                myPropInfo.SetValue(this, value, null);

            }
        }

        string formatOneName(string name, bool capitalize)
        {
            string formatedName = "";

            formatedName += capitalize
                ? char.ToUpper(name[0])
                : char.ToLower(name[0]);

            for (int i = 1; i < name.Length; i++)
                formatedName += char.ToLower(name[i]);

            return formatedName;
        }

        public void formatAllNames(bool capitalize = true)
        {
            if (LastName != "")
                LastName = formatOneName(LastName, capitalize);

            if (FirstName != "")
                FirstName = formatOneName(FirstName, capitalize);

            if (MiddleName != "")
                MiddleName = formatOneName(MiddleName, capitalize);
        }
    }
}