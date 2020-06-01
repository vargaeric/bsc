using System;

namespace StudentsClass
{
    class Student
    {
        public string LastName { get; }
        public string FirstName { get; }
        public int[] grades;
        public double AverageGrade { get; }

        public Student(string lineWithStudentInfo)
        {
            int grade;
            int sumOfGrades = 0;
            string[] studentInfo = lineWithStudentInfo.Split(" ");
            int nrOfGrades = studentInfo.Length - 3;

            LastName = studentInfo[0];
            FirstName = studentInfo[1];
            grades = new int[nrOfGrades];

            for (int i = 3; i < studentInfo.Length; i++)
            {
                grade = int.Parse(studentInfo[i]);
                grades[i - 3] = grade;
                sumOfGrades += grade;
            }

            AverageGrade = Math.Round(Convert.ToDouble(sumOfGrades) / nrOfGrades, 2);
        }

        public string getOutputFormat()
        {
            string output = $"({AverageGrade}) {LastName} {FirstName} {grades.Length}";

            foreach (int grade in grades)
                output += " " + Convert.ToString(grade);

            return output;
        }
    }
}
