using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veri_Yapıları_Sort_Algoritmaları
{
    class Program
    {
       

        static void Main(string[] args)
        {
            int[] dizi = { 0, 4, 6, 1, 9, 7, 8, 2, 3, 5 };

            Console.WriteLine("Dizinin Siralanmamis Elemanlari");
            for (int i = 0; i < dizi.Length; i++)
                Console.Write(dizi[i] + " ");

            //selectionSort(dizi);
            //insertionSort(dizi);
            //quickSort(dizi, 0, dizi.Length - 1);
            //mergeSort(dizi, 0, dizi.Length);

            Console.WriteLine("\nDizinin Siralanmis Elemanlari");
            for (int i = 0; i < dizi.Length; i++)
                Console.Write(dizi[i] + " ");
        }
 
        //Insertion Sort
        public static void insertionSort(int[] arr)
        {
            int j, temp;
            for (int i = 0; i < arr.Length; i++)
            {
                temp = arr[i];
                j = i;
                while (j > 0 && arr[j - 1] > temp)
                {
                    arr[j] = arr[j - 1];
                    j--;
                }
                arr[j] = temp;
            }
        }

        //Selection Sort
        static void selectionSort(int[] arr)
        {
            int min, temp;
            for(int i = 0;i < arr.Length; i++)
            {
                min = i;
                for(int j = i + 1;j < arr.Length; j++) if (arr[j] < arr[min]) min = j;

                temp = arr[min];
                arr[min] = arr[i];
                arr[i] = temp;
            }
        }
        
        //Merge Sort
        static void mergeSort(int[] arr, int first, int length)
        {
            int sol, sag;
            if (length > 1)
            {
                sol = length / 2;
                sag = length - sol;
                mergeSort(arr, first, sol);
                mergeSort(arr, first + sol, sag);

                merge(arr, first, sol, sag);
            }
        }

        static void merge(int[] arr, int first, int sol, int sag)
        {
            int[] temp = new int[sol + sag];
            int copied = 0;
            int copied1 = 0;
            int copied2 = 0;

            while ((copied1 < sol) && (copied2 < sag))
            {
                if (arr[first + copied1] < arr[first + sol + copied2])
                    temp[copied++] = arr[first + (copied1++)];
                else
                    temp[copied++] = arr[first + sol + (copied2++)];
            }

            while (copied1 < sol)
                temp[copied++] = arr[first + (copied1++)];
            while (copied2 < sag)
                temp[copied++] = arr[first + sol + (copied2++)];

            for (int i = 0; i < sol + sag; i++)
                arr[first + i] = temp[i];
        }

        //Quick Sort
        static void quickSort(int[] arr, int sol, int sag)
        {
            int i = sol, j = sag;
            int orta, bos;
            orta = arr[(sol + sag) / 2];

            while (i <= j)
            {
                while ((arr[i] < orta) && (i < sag)) i++;
                while ((orta < arr[j]) && (j > sol)) j--;

                if (i <= j)
                {
                    bos = arr[i];
                    arr[i] = arr[j];
                    arr[j] = bos;
                    i++;
                    j--;
                }
            }

            if (sol < j) quickSort(arr, sol, j);
            if (i < sag) quickSort(arr, i, sag);
        }
    }
}
