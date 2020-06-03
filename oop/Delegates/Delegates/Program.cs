using System;

namespace Delegates
{
    class EventDemo
    {
        public static void Main()
        {
            Publisher ev = new Publisher();
            SubscriberA subA = new SubscriberA();
            SubscriberB subB = new SubscriberB();

            ev.customEvent += new Iteration(subA.SubscriberAHandler);
            ev.customEvent += new Iteration(subB.SubscriberBHandler);

            ev.executeEvent(3);
        }
    }
}
