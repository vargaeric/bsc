using System;

namespace CustomStackClass
{
    internal class CustomStack<DataType>
    {
        private DataType[] elements;
        private int currentPosition = 0;
        public bool Empty
        {
            get
            {
                return currentPosition == 0;
            }
        }

        public CustomStack(int size)
        {
            elements = new DataType[size];
        }

        public void push(DataType newElement)
        {
            if (currentPosition < elements.Length)
            {
                elements[currentPosition] = newElement;
                currentPosition++;
            }
            else
                throw new Exception("You can't add new elements because the stack is full!");
        }
        public DataType pop()
        {
            if (currentPosition != 0)
            {
                currentPosition--;
                return elements[currentPosition];
            }
            else
                throw new Exception("You can't pop element because the stack is empty!");
        }

        public void Clear()
        {
            currentPosition = 0;
        }
    }
}