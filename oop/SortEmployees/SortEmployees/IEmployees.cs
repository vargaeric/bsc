namespace SortEmployees
{
    interface IEmployees
    {
        void add(Employee employee);
        void remove(Employee employee);
        void sort(bool sortByHireDate);
    }
}
