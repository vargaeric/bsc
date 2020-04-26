namespace SortNames
{
    internal class ListOfPersons
    {
        string roAlphabet = "aăâbcdefghiîjklmnopqrsștțuvwxyz";

        Person[] listOfPersons;
        int length;

        public ListOfPersons(int length)
        {
            this.length = length;
            listOfPersons = new Person[length];
        }

        public void addPerson(Person person, int index)
            => listOfPersons[index] = person;

        public string[] getOutputFormat()
        {
            string[] output = new string[length];

            for (int i = 0; i < length; i++)
            {
                listOfPersons[i].formatAllNames(true);

                output[i] += listOfPersons[i].LastName + " ";
                output[i] += listOfPersons[i].MiddleName == ""
                    ? listOfPersons[i].FirstName
                    : listOfPersons[i].FirstName + " ";
                output[i] += listOfPersons[i].MiddleName;
            }
            
            return output;
        }

        public void sortByName()
        {
            string[] propNames = Person.propNames;

            // Change the first letters to lower case before sort
            foreach (Person person in listOfPersons)
                person.formatAllNames(false);

            bool changeTheTwoPersons(Person person1, Person person2)
            {
                for (int i = 0; i < propNames.Length; i++)
                {
                    string name1 = (string)person1[propNames[i]];
                    string name2 = (string)person2[propNames[i]];

                    for (int j = 0; j < name1.Length && j < name2.Length; j++)
                        if (roAlphabet.IndexOf(name1[j]) != roAlphabet.IndexOf(name2[j]))
                            return roAlphabet.IndexOf(name1[j]) > roAlphabet.IndexOf(name2[j]);
                }

                return false;
            }

            string name;

            for (int i = 0; i < length - 1; i++)
                for (int j = i + 1; j < length; j++)
                    if (changeTheTwoPersons(listOfPersons[i], listOfPersons[j]))
                        for (int k = 0; k < propNames.Length; k++)
                        {
                            name = (string) listOfPersons[i][propNames[k]];
                            listOfPersons[i][propNames[k]] = listOfPersons[j][propNames[k]];
                            listOfPersons[j][propNames[k]] = name;
                        }
        }
    }
}