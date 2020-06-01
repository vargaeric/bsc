using System.Collections.Generic;

namespace StudentsClass
{
    class ListOfStudents
    {
        List<Student> listOfStudents;
        readonly int nrOfStudents;

        public ListOfStudents(string[] listOfStudents)
        {
            this.listOfStudents = new List<Student>();

            foreach (string lineWithStudentInfo in listOfStudents)
                this.listOfStudents.Add(new Student(lineWithStudentInfo));

            nrOfStudents = this.listOfStudents.Count;
        }

        public void sort()
        {
            bool compareTwoStudents(Student student1, Student student2)
            {
                if (student1.AverageGrade != student2.AverageGrade)
                    return student1.AverageGrade < student2.AverageGrade;

                for (int j = 0; j < student1.LastName.Length && j < student2.LastName.Length; j++)
                    if (student1.LastName[j] != student2.LastName[j])
                        return student1.LastName[j] > student2.LastName[j];

                for (int j = 0; j < student1.FirstName.Length && j < student2.FirstName.Length; j++)
                    if (student1.FirstName[j] != student2.FirstName[j])
                        return student1.FirstName[j] > student2.FirstName[j];

                return false;
            }

            Student permanentStudent;

            for (int i = 0; i < nrOfStudents - 1; i++)
                for (int j = i + 1; j < nrOfStudents; j++)
                    if (compareTwoStudents(listOfStudents[i], listOfStudents[j]))
                        {
                            permanentStudent = listOfStudents[i];
                            listOfStudents[i] = listOfStudents[j];
                            listOfStudents[j] = permanentStudent;
                        }
        }

        public string[] getOutputFormat()
        {
            string[] output = new string[nrOfStudents];

            for(int i = 0; i < nrOfStudents; i++)
                output[i] = listOfStudents[i].getOutputFormat();

            return output;
        }
    }
}
