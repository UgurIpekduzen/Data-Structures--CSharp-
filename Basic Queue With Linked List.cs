using System;
using System.Collections.Generic;
using System.Text;

namespace Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue q = new Queue();
            QueueNode N1 = new QueueNode(2);
            QueueNode N2 = new QueueNode(3);
            QueueNode N3 = new QueueNode(4);
            QueueNode N4 = new QueueNode(5);
            QueueNode N5 = new QueueNode(6);

            q.push(N1);
            q.Show();
            q.push(N2);
            q.Show();
            q.push(N3);
            q.Show();
            q.push(N4);
            q.Show();
            q.push(N5);
            q.Show();

            q.pop();
            q.Show();
            q.pop();
            q.Show();
            q.pop();
            q.Show();
            q.pop();
            q.Show();
            q.pop();
            q.Show();
            q.pop();
            q.Show();

        }
    }
    class QueueNode
    {
        public int num;
        public QueueNode next;

        public QueueNode(int num) { this.num = num; }
    }

    class Queue
    {
        QueueNode Tail;
        QueueNode Head;
        int count;

        public bool IsEmpty() { return count == 0; }

        public void push(QueueNode N)
        {
            if (IsEmpty())
            {
                Tail = N;
                Head = N;
            }
            else
            {
                Tail.next = N;
                Tail = Tail.next;
            }
            count++;
        }

        public void pop()
        {
            if (IsEmpty())
                Console.WriteLine("Queue is empty");
            else
                Head = Head.next;

            count--;
        }

        public void Show()
        {
            if (IsEmpty())
                Console.WriteLine("Liste bos");
            else
            {
                QueueNode Current = this.Head;
                for (int i = 0; i < count; i++)
                {
                    Console.Write("{0}  ", Current.num);
                    Current = Current.next;
                }
                Console.WriteLine();
            }
        }
    }

}
