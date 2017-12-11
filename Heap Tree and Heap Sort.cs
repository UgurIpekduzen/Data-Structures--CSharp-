using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeapTreeAndHeapSort
{
    class Program
    {   
        static void Main(string[] args)
        {
            Heap h1 = new Heap();
            int []arr = { 4, 7, 1, 78, 32, 67, 13, 25, 49, 80 };
            
             //Heap Sort
            h1.BuildHeap(arr, 10);
            while(h1.ElNum > 0)
            {
                int temp = h1.Get();
                Console.Write(temp + " ");
            }

            for (int i = 0; i < arr.Length; i++) h1.Add(arr[i]);
            
        }
            
    }

    class Heap
    {
        public int ElNum { get; private set; }
        int[] Data;
        int MAX;

        public Heap (int MAX = 10)
        {
            ElNum = 0;
            this.MAX = MAX;
            Data = new int[MAX];
        }

        int GetLeftChild(int i) { return 2 * i + 1; }
        int GetRightChild(int i) { return 2 * i + 2; }
        int GetParent(int i) { return (i - 1) / 2; }

        public int Get()
        {
            if (ElNum == 0) return 0;

            int e = Data[0];
            Data[0] = Data[ElNum - 1];
            ElNum--;

            HeapifyDown(0);
            return e;
        }
        public bool Add(int e)
        {
            if (ElNum == MAX) return false;
            ElNum++;
            Data[ElNum - 1] = e;
            HeapifyUp(ElNum - 1);
            return true;
        }

        void HeapifyDown(int i)
        {
            int Left = GetLeftChild(i);
            int Right = GetRightChild(i);
            int min;

            if (Right >= ElNum)
            {
                if (Left >= ElNum) return;
                else min = Left;
            }
            else
            {
                if (Data[Left] < Data[Right]) min = Left;
                else min = Right;
            }

            if (Data[min] < Data[i])
            {
                int temp = Data[i];
                Data[i] = Data[min];
                Data[min] = temp;
                HeapifyDown(min);
            }
        }
        void HeapifyUp(int i)
        {
            if (i == 0) return;
            int ParentIndex = GetParent(i);
            if (Data[ParentIndex] > Data[i])
            {
                int temp = Data[i];
                Data[i] = Data[ParentIndex];
                Data[ParentIndex] = temp;
                HeapifyUp(ParentIndex);
            }
        }

        public bool BuildHeap(int[] arr, int ElNum)
        {
            if (ElNum > MAX) return false;

            this.ElNum = ElNum;
            for (int i = 0; i < ElNum; i++) Data[i] = arr[i];

            int k = (ElNum - 1) / 2;
            for (int i = k; i >= 0; i--) HeapifyDown(i);
            return true;
        }
    }
}
