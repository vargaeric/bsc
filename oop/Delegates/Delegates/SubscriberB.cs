using System;

namespace Delegates
{
    class SubscriberB
    {
        public void SubscriberBHandler(int p)
        {
            Console.WriteLine($"SubscriberB's text: This text will appaer {p} times!");
        }
    }
}
