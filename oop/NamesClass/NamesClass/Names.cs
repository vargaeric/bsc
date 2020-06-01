using System;
using System.Collections.Generic;

namespace NamesClass
{
    class Names
    {
        List<string> names;
        int length;

        public Names(int length)
        {
            names = new List<string>();

            for (int i = 0; i < length; i++)
                names.Add("John Smith");

            this.length = length;
        }

        public string this[int index]
        {
            get
            {
                if (index >= 0 && index < length)
                    return names[index];
                else
                    throw new IndexOutOfRangeException();
            }

            set
            {
                if (index >= 0 && index < length)
                    names[index] = value;
                else
                    throw new IndexOutOfRangeException();
            }
        }

        public string this[string index]
        {
            get
            {
                for (int i = 0; i < length; i++)
                    if (names[i] == index)
                        return "The name was in the list!";

                throw new Exception("There is no such name in the list!");
            }
        }

        public void printAllTheNames()
        {
            Console.WriteLine("All the names in the list:");

            for(int i = 0; i < length; i++)
                Console.WriteLine($"{names[i]}");

            Console.WriteLine();
        }

    }
}
