using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
namespace HashTable
{
    class Program
    {
        static void Main(string[] args)
        {
            HashTable h1 = new HashTable();

            h1.Add(23);
            h1.Add(57);
            h1.Add(88);
            h1.Add(78);
            h1.Add(63);

            h1.Add(3);
            h1.Add(92);
            h1.Add(52);
            h1.Add(30);
            h1.Add(112);
            h1.Add(142);

            //Silmeden önce
            h1.ShowData();
            WriteLine();

            h1.Remove(78);
            h1.Remove(23);
            h1.Remove(63);
            h1.Remove(30);
            h1.Remove(52);
            h1.Remove(32);

            //Sildikten Sonra
            h1.ShowData();
        }
    }

    class Node
    {
        public int Key;
        public Node Next;

        public Node(int Key)
        {
            this.Key = Key;
            Next = null;
        }

        public override string ToString() { return Key.ToString(); }
    }

    class HashTable
    {
        Node[] Data;
        int MAX;

        public HashTable(int MAX = 10)
        {
            this.MAX = MAX;
            Data = new Node[MAX];
            for (int i = 0; i < MAX; i++) Data[i] = null;
        }
        public void Add(int Key)
        {
            Node NewNode = new Node(Key);
            int Mode = Key % MAX;
            if (Data[Mode] == null)
            {
                Data[Mode] = NewNode;
                return;
            }

            Node Temp = Data[Mode];
            while (Temp.Next != null) Temp = Temp.Next;

            Temp.Next = NewNode;
        }
        public Node Get(int Key)
        {
            int Mode = Key % MAX;
            Node Temp = Data[Mode];
            while (Temp != null)
            {
                if (Temp.Key == Key) return Temp;
                Temp = Temp.Next;
            }
            return null;
        }
        public bool Remove(int Key)
        {
            int Mode = Key % MAX;
            if (Data[Mode] == null) return false;

            //Sondan siler.
            if (Data[Mode].Next == null)
            {
                if (Data[Mode].Key == Key)
                {
                    Data[Mode] = null;
                    return true;
                }
                return false;
            }
            //Baştan siler.
            if (Data[Mode].Key == Key)
            {
                Data[Mode] = Data[Mode].Next;
                return true;
            }
            //Aranan eleman diğer iki eleman arasındaysa, aradan siler.

            Node Temp = Data[Mode];

            if (Temp.Next != null)
            {
                if (Temp.Next.Key == Key)
                {
                    Temp.Next = Temp.Next.Next;
                    return true;
                }
            }
            return false; // Hiçbir şey bulamazsa false döndür.
        }
        public void ShowData()
        {
            for (int i = 0; i < MAX; i++)
            {
                if (Data[i] == null) Write("i = " + i + " null");
                else
                {
                    Write("i = " + i);
                    ShowDataCells(i);
                }
                WriteLine();
            }
        }
        void ShowDataCells(int i)
        {
            int CellEl = 0;
            Node Temp = Data[i];
            if (Temp != null)
            {
                do
                {
                    CellEl = Temp.Key;
                    Write(" " + CellEl);
                    Temp = Temp.Next;
                } while (Temp != null);
            }
        }
    }
}
