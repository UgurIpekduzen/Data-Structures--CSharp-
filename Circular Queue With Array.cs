using System;
using System.Collections.Generic;
using System.Text;

namespace CircularQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue q = new Queue(6);

            q.Enqueue(2);
            q.Enqueue(5);
            q.Enqueue(3);
            q.Enqueue(1);
            q.Enqueue(6);
            q.Enqueue(8);
            q.Enqueue(7); //Kuyruk dolu yazmalı.
            q.Enqueue(9); //Kuyruk dolu yazmalı.
            q.Enqueue(12); //Kuyruk dolu yazmalı.

            for (int i = 0; i < q.Data.Length; i++) Console.Write(q.Data[i] + " ");

            Console.WriteLine();
            Console.WriteLine();

            int debug = q.Data.Length + 1;
            int poppedVar;
            for(int i = 0; i < debug; i++)
            {
                poppedVar = q.Dequeue();
                Console.WriteLine(poppedVar + " "); // Dizi tamamen boşaldığında kuyruk boş yazıp 0 döndürür. 
            }
        }
    }

    class Queue
    {
       public int []Data;
       public int Tail;
       public int Head;
       public int vars; //Eleman sayısını tutar

        public Queue(int Capacity)
        {
            Data = new int[Capacity];
            Tail = 3;
            Head = 3;
            vars = 0;
        }
        public bool isEmpty() { return vars == 0; }

        public bool isFull() { return vars == Capacity(); }

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
            if (Tail == Capacity()) Tail = 0;
            vars++; 
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
            if (Head == Capacity()) Head = 0;
            vars--;
            return i;
        }
    }
}
