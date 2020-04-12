using System;
using System.IO;

namespace ReadFile
{
    class File
    {
        string[] allLines;
        string vowels = "aeiou";
        string consonants = "bcdfghjklmnpqrstvwxzy";

        public File(string path)
        {
            string[] allLinesFromFile = System.IO.File.ReadAllLines(@path);

            allLines = new string[allLinesFromFile.Length];
            allLines = allLinesFromFile;
        }

        public int NrOfChars()
        {
            int nrOfChars = 0;

            foreach (var line in allLines)
            {
                nrOfChars += line.Length;
            }

            return nrOfChars;
        }

        public int NrOfVowelsOrConsonants(bool searchForVowels = true)
        {
            bool match;
            int counter = 0;
            string charsToMatch;

            switch (searchForVowels)
            {
                case false:
                    charsToMatch = consonants;
                    break;
                default:
                    charsToMatch = vowels;
                    break;
            }

            for (int i = 0; i < allLines.Length; i++)
            {
                string lineWithLowerCase = allLines[i].ToLower();

                for (int j = 0; j < lineWithLowerCase.Length; j++)
                {
                    match = false;

                    for (int k = 0; k < charsToMatch.Length && match == false; k++)
                    {
                        if (lineWithLowerCase[j] == charsToMatch[k])
                        {
                            match = true;
                            counter++;
                        };
                    }
                }
            }

            return counter;
        }

        public int NrOfLines()
            => allLines.Length;
    }

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                File givenFile = new File(args[0]);

                Console.WriteLine("Number of characters in the file: {0}.",
                    Convert.ToString(givenFile.NrOfChars()));
                Console.WriteLine("Number of vowels in the file: {0}.",
                    Convert.ToString(givenFile.NrOfVowelsOrConsonants()));
                Console.WriteLine("Number of consonants in the file: {0}.",
                    Convert.ToString(givenFile.NrOfVowelsOrConsonants(false)));
                Console.WriteLine("Number of lines in the file: {0}.",
                    Convert.ToString(givenFile.NrOfLines()));
            }
            catch (IOException error)
            {
                Console.WriteLine(error.Message);
            }
        }
    }
}
