using System;

namespace SortEmployees
{
    class Employee
    {
        public string FullName { get; }
        public DateTime HireDate { get; }

        public Employee(string fullName, DateTime hireDate)
        {
            FullName = fullName;
            HireDate = hireDate;
        }

        public override string ToString()
            => $"{FullName} {FormatDateTime.getDateTimeInString(HireDate)}";
    }
}
