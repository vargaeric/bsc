using System;

namespace HeapSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nrs = new int[] { 345, -232, 1042, 0 -632, 943, 4, 1351, 202, 1452 };

            Console.WriteLine($"Original array:\n{string.Join(", ", nrs)}\n");

            HeapSortClass.sort(ref nrs);

            Console.WriteLine($"Array sorted with heap sort:\n{string.Join(", ", nrs)}");
        }
    }
}
