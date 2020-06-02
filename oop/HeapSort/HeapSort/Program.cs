using System;

namespace HeapSort
{
    class Program
    {
        static void Main(string[] args)
        {
            HeapSortClass heapSort = new HeapSortClass();

            int[] nrs = new int[] { 345, -232, 1042, 0 -632, 943, 4, 1351, 202, 1452 };

            HeapSortClass.sort(ref nrs);

            Console.WriteLine(string.Join(", ", nrs));
        }
    }
}
