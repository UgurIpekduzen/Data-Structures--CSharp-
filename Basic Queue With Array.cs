using System;
using System.Collections.Generic;
using System.Text;

namespace Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue q = new Queue(10);

            q.Enqueue(5);

            int i = q.Dequeue();
            Console.WriteLine(i + " ");
            int j = q.Dequeue();
            Console.WriteLine(j + " ");
           

        }
    }

    class Queue
    {
        int []Data;
        int Tail;
        int Head;

        public Queue(int Capacity)
        {
            Data = new int[Capacity];
            Tail = 0;
            Head = 0;
        }
        public bool isEmpty() { return (Tail == Head); }

        public bool isFull() { return Tail == Capacity(); }

        public int Capacity() { return Data.Length; }

        public void Enqueue(int i)
        {
            if(isFull())
            {
                Console.WriteLine("Queue is full");
                return;
            }

            Data[Tail] = i;
            Tail++;
        }

        public int Dequeue()
        {
            if(isEmpty())
            {
                Console.WriteLine("Queue is empty");
                return 0;
            }
            int i = Data[Head];
            Head++;
            return i;
        }
    }

}
