namespace Delegates
{
    public delegate void Iteration(int p);
    class Publisher
    {
        public event Iteration customEvent;
        public void executeEvent(int p)
        {
            if (customEvent != null)
                for (int i = 0; i < p; i++)
                    customEvent(p);
        }
    }
}
