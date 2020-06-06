namespace LR
{
    class Program
    {
        static void Main(string[] args)
        {
            LRClass lr = new LRClass("../../../../input.txt");

            lr.ReadData();
            lr.ProcessData();
            lr.ShowResults();
        }
    }
}
