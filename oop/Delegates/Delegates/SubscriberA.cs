using System;

namespace Delegates
{
    class SubscriberA
    {
        public void SubscriberAHandler(int p)
        {
            Console.WriteLine($"SubscriberA's text: This text will appaer {p} times!");
        }
    }
}
