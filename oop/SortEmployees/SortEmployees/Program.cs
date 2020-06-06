using System;
using System.IO;

namespace SortEmployees
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string[] allLinesFromFile = File.ReadAllLines(@"../../../../employees.txt");

                string[] employeesInfos;
                string employeeName;
                DateTime hireDate;

                EmployeesList employeesList = new EmployeesList();

                for (int i = 0; i < allLinesFromFile.Length; i++)
                {
                    employeesInfos = allLinesFromFile[i].Split(" ");

                    employeeName = $"{employeesInfos[0]} {employeesInfos[1]}";
                    hireDate = FormatDateTime.getDateTimeFormat(employeesInfos[2]);

                    employeesList.add(new Employee(employeeName, hireDate));
                }

                employeesList.sort();

                File.WriteAllLines(@"../../../../employeesSortedByName.txt", employeesList.getOutputFormat());

                employeesList.sort(true);

                File.WriteAllLines(@"../../../../employeesSortedByHireDate.txt", employeesList.getOutputFormat(true));
            }
            catch(Exception error)
            {
                Console.WriteLine(error.Message);
            }
        }
    }
}
