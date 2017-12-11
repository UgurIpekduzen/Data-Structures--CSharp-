using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;
namespace Nesne_Vize
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack stack1 = new Stack(10);

            for (int i = 0; !stack1.isFull(); i++)
            {
                stack1.push((char)('A' + i));
            }

            WriteLine("stack1 iceriği: ");

            while (!stack1.isEmpty())
                WriteLine(stack1.pop());
        }
    }

    class Stack
    {
        char[] stack;
        int topOfStack;

        public Stack(int size)
        {
            stack = new char[size];
            topOfStack = 0;
        }

        public bool isFull() { return topOfStack == stack.Length; }

        public bool isEmpty() { return topOfStack == 0; }

        public void push(char ch)
        {
            if (isFull())
            {
                Console.WriteLine("Stack is full");
                return;
            }
            stack[topOfStack] = ch;
            topOfStack++;
        }

        public char pop()
        {
            if (isEmpty())
            {
                Console.WriteLine("Stack is empty");
                return (char)0;
            }
            topOfStack--;
            return stack[topOfStack];
        }
    }
}