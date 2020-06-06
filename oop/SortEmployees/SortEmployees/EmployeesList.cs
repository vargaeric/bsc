using System;
using System.Collections.Generic;

namespace SortEmployees
{
    class EmployeesList : IEmployees
    {
        private List<Employee> employeesList;

        public EmployeesList()
        {
            employeesList = new List<Employee>();
        }

        public EmployeesList(List<Employee> employeesList)
        {
            this.employeesList = employeesList;
        }

        public void add(Employee angajat)
        {
            employeesList.Add(angajat);
        }

        public void remove(Employee angajat)
        {
            employeesList.Remove(angajat);
        }

        public void sort(bool sortByHireDate = false)
        {
            Employee auxEmp;

            int compareTwoEmployees(Employee employeeOne, Employee employeeTwo)
                => sortByHireDate
                    ? DateTime.Compare(employeeOne.HireDate, employeeTwo.HireDate)
                    : string.Compare(employeeOne.FullName, employeeTwo.FullName);

            for (int i = 0; i < employeesList.Count - 1; i++)
                for (int j = i + 1; j < employeesList.Count; j++)
                    if (compareTwoEmployees(employeesList[i], employeesList[j]) == 1)
                    {
                        auxEmp = employeesList[i];
                        employeesList[i] = employeesList[j];
                        employeesList[j] = auxEmp;
                    }
        }

        public string[] getOutputFormat(bool simplifyHireDate = false)
        {
            string[] output = new string[employeesList.Count];

            for (int i = 0; i < employeesList.Count; i++)
            {
                output[i] = employeesList[i].FullName + " ";
                output[i] += simplifyHireDate
                    ? FormatDateTime.yearsAndMonthsInString(employeesList[i].HireDate)
                    : FormatDateTime.getDateTimeInString(employeesList[i].HireDate);
            }

            return output;
        }
    }
}
