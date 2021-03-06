﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace Analisis_Algoritmos_Proyecto1
{
    class Program
    {

        static void Main(string[] args)
        {
            //bubble sort
            //insert sort --laur
            //selection sort --laur
            //merge sort
            //heap sort en un mismo arreglo
            //quick sort en un mismo arreglo
            //radix sort
            int[] size = { 10, 100, 1000, 10000, 100000, 1000000 };
            
            #region
            /*
            //Merge sort
            
            string path = "C:\\Users\\Ithamar\\Desktop\\Clases\\Analisis de Algoritmos\\Results\\merge.csv";
            int[] number;
            Random r = new Random();
            for (int i = 0; i < 6; i++)
            {
                Console.WriteLine("MergeSort con: " + size[i]);
                //declarar array de int
                number = new int[size[i]];
                for (int j = 0; j < size[i]; j++)
                {
                    number[i] = r.Next(1, size[i]);
                }
                //correr aqui
                for (int k = 0; k < 10; k++)
=======
            /**
              for (int i = 0; i < 6; i++)
                {
                for (int j = 0; j < 10; j++)
>>>>>>> 45c75ed1305a02cefb08f9d547a334392a0e16d0
                {
                    Stopwatch sw = new Stopwatch();
                    sw.Start();
                    MergeSort_Recursive(number, 0, size[i] - 1);
                    sw.Stop();
                    
                    File.AppendAllText(path, sw.Elapsed.ToString() + ",");
                    Console.WriteLine("Tiempo: " + sw.Elapsed);
                }
                File.AppendAllText(path, Environment.NewLine);
            }
<<<<<<< HEAD
            */
            #endregion


            #region
            
            //Bubble sort
           /*/ for (int i = 0; i < 4; i++)
            {
                 for (int j = 0; j < 1; j++)
                 {
                     bubble_sort(size[4]);
                 }
                 string path = "C:\\Users\\Ithamar\\Desktop\\Clases\\Analisis de Algoritmos\\Results\\bubble2.csv";
                 File.AppendAllText(path, Environment.NewLine);
             }*/
            /*
            //Insertion Sort
             for (int i = 0; i < 6; i++)
             {
                 for (int j = 0; j < 10; j++)
                 {
                     InsertionSort(size[i]);
                 }
                 string path = "C:\\Users\\Ithamar\\Desktop\\Clases\\Analisis de Algoritmos\\Results\\insertion.csv";
                 File.AppendAllText(path, Environment.NewLine);
             }*/

            #endregion

            #region
            
            //Heap Sort
            Thread th = new Thread(RunHeapSort);
            th.Start();

            //Radix Sort
            Thread tr = new Thread(RunRadixSort);
            tr.Start();
            
            #endregion

            #region

            //RunQuickSort();

            #endregion

            Console.ReadKey();
        }


        public static void RunQuickSort()
        {
            int[] size = { 10, 100, 1000, 10000, 100000, 1000000 };
            string path = "C:\\Users\\Ithamar\\Desktop\\Clases\\Analisis de Algoritmos\\Results\\quick.csv";
            int[] number;
            Random r = new Random();
            for (int i = 0; i < 6; i++)
            {
                Console.WriteLine("Quick sort con: " + size[i]);
                //declarar array de int
                number = new int[size[i]];
                for (int j = 0; j < size[i]; j++)
                {
                    number[i] = r.Next(1, size[i]);
                }
                //correr aqui
                for (int k = 0; k < 10; k++)
                {
                    Stopwatch sw = new Stopwatch();
                    sw.Start();
                    List<int> list = RandomList(size[i]);
                    //DumpList(list);
                    MyQuickSort(list, 0, list.Count);
                    //DumpList(list);
                    sw.Stop();

                    File.AppendAllText(path, sw.Elapsed.ToString() + ",");
                    Console.WriteLine("Tiempo: " + sw.Elapsed);
                }
                File.AppendAllText(path, Environment.NewLine);
            }
        }
        public static void RunHeapSort()
        {
            int[] size = { 10, 100, 1000, 10000, 100000, 1000000 };
            string path = "C:\\Users\\Ithamar\\Desktop\\Clases\\Analisis de Algoritmos\\Results\\heap.csv";
            int[] number;
            Random r = new Random();
            for (int i = 0; i < 6; i++)
            {
                Console.WriteLine("Heap sort con: " + size[i]);
                //declarar array de int
                number = new int[size[i]];
                for (int j = 0; j < size[i]; j++)
                {
                    number[i] = r.Next(1, size[i]);
                }
                //correr aqui
                for (int k = 0; k < 10; k++)
                {
                    Stopwatch sw = new Stopwatch();
                    sw.Start();
                    HeapSort(number);
                    sw.Stop();
                    
                    File.AppendAllText(path, sw.Elapsed.ToString() + ",");
                    Console.WriteLine("Tiempo: " + sw.Elapsed);
                }
                File.AppendAllText(path, Environment.NewLine);
            }
        }
        
        public static void RunRadixSort()
        {
            int[] size = { 10, 100, 1000, 10000, 100000, 1000000 };
            string path = "C:\\Users\\Ithamar\\Desktop\\Clases\\Analisis de Algoritmos\\Results\\radix.csv";
            int[] number;
            int[] res;
            Random r = new Random();
            for (int i = 0; i < 6; i++)
            {
                Console.WriteLine("Radix sort con: " + size[i]);
                //declarar array de int
                number = new int[size[i]];
                for (int j = 0; j < size[i]; j++)
                {
                    number[i] = r.Next(1, size[i]);
                }
                //correr aqui
                for (int k = 0; k < 10; k++)
                {
                    Stopwatch sw = new Stopwatch();
                    sw.Start();
                    RadixSort( number);
                    sw.Stop();

                    File.AppendAllText(path, sw.Elapsed.ToString() + ",");
                    Console.WriteLine("Tiempo: " + sw.Elapsed);
                }
                File.AppendAllText(path, Environment.NewLine);
            }
        }
        public static void RadixSort(int[] a)
        {
            // our helper array 
            int[] t = new int[a.Length];

            // number of bits our group will be long 
            int r = 4; // try to set this also to 2, 8 or 16 to see if it is quicker or not 

            // number of bits of a C# int 
            int b = 32;

            // counting and prefix arrays
            // (note dimensions 2^r which is the number of all possible values of a r-bit number) 
            int[] count = new int[1 << r];
            int[] pref = new int[1 << r];

            // number of groups 
            int groups = (int)Math.Ceiling((double)b / (double)r);

            // the mask to identify groups 
            int mask = (1 << r) - 1;

            // the algorithm: 
            for (int c = 0, shift = 0; c < groups; c++, shift += r)
            {
                // reset count array 
                for (int j = 0; j < count.Length; j++)
                    count[j] = 0;

                // counting elements of the c-th group 
                for (int i = 0; i < a.Length; i++)
                    count[(a[i] >> shift) & mask]++;

                // calculating prefixes 
                pref[0] = 0;
                for (int i = 1; i < count.Length; i++)
                    pref[i] = pref[i - 1] + count[i - 1];

                // from a[] to t[] elements ordered by c-th group 
                for (int i = 0; i < a.Length; i++)
                    t[pref[(a[i] >> shift) & mask]++] = a[i];

                // a[]=t[] and start again until the last group 
                t.CopyTo(a, 0);
            }
           
                //for (int i = 0; i < 1; i++)
                //{
                    //Console.WriteLine("Ejecución: " + size[i]);
                   /* for (int j = 0; j < 8; j++)
                    {
                       // SelectionSort(1000000);
                    }
                    */
            //}
            //selection sort
            Thread thread1 = new Thread(ExecSelection);
            thread1.Start();
            //Insertion
            Thread thread2 = new Thread(ExecInsertion);
            thread2.Start();

           

                    
            //Console.ReadKey();
            
        }

        public static void ExecSelection()
        {
            int[] size = { 10, 100, 1000, 10000, 100000, 1000000 };
            for (int j = 0; j < 6; j++)
            {
                Console.WriteLine("Selection sort with: " + size[j]);
                for (int i = 0; i < 10; i++)
                {
                    SelectionSort(size[j]);
                }
                string path = "C:\\Users\\wmejia\\Documents\\Visual Studio 2012\\Projects\\analisis-algoritmos-proyecto1\\Analisis_Algoritmos_Proyecto1\\Results\\selection.csv";
                File.AppendAllText(path, Environment.NewLine);
            }
        }

        public static void ExecInsertion()
        {
            int[] size = { 10, 100, 1000, 10000, 100000, 1000000 };
            for (int j = 0; j < 6; j++)
            {
                Console.WriteLine("Insertion sort with: " + size[j]);
                for (int i = 0; i < 10; i++)
                {
                    InsertionSort(size[j]);
                }
                string path = "C:\\Users\\wmejia\\Documents\\Visual Studio 2012\\Projects\\analisis-algoritmos-proyecto1\\Analisis_Algoritmos_Proyecto1\\Results\\insertion.csv";
                File.AppendAllText(path, Environment.NewLine);
            }
        }

        public static void bubble_sort(int size)
        {

            int[] number = new int[size];
            Random r = new Random();
            for (int i = 0; i < size; i++)
            {
                number[i] = r.Next(1,size);
            }
            bool flag = true;
            int temp;
            int numLength = number.Length;

            Stopwatch sw = new Stopwatch();
            sw.Start();
            //sorting an array
            for (int i = 1; (i <= (numLength - 1)) && flag; i++)
            {
                flag = false;
                for (int j = 0; j < (numLength - 1); j++)
                {
                    if (number[j + 1] > number[j])
                    {
                        temp = number[j];
                        number[j] = number[j + 1];
                        number[j + 1] = temp;
                        flag = true;
                    }
                }
            }
            sw.Stop();
            string path = "C:\\Users\\Ithamar\\Desktop\\Clases\\Analisis de Algoritmos\\Results\\bubble2.csv";
            File.AppendAllText(path, sw.Elapsed.ToString() + ",");
            
            Console.WriteLine("Tiempo: " + sw.Elapsed);
        }
        
        public static void InsertionSort(int size)
        {    
            int length = size;

                int[] number = new int[size];
                Random r = new Random();
                for (int i = 0; i < size; i++)
                {
                    number[i] = r.Next(1, size);
                }
                
                Stopwatch sw = new Stopwatch();
                sw.Start();

                for (int i = 1; i < length; i++)
                {
                    int j = i;

                    while ((j > 0) && (number[j] < number[j - 1]))
                    {
                        int k = j - 1;
                        int temp = number[k];
                        number[k] = number[j];
                        number[j] = temp;

                        j--;
                    }
                }
                sw.Stop();

               string path = "C:\\Users\\wmejia\\Documents\\Visual Studio 2012\\Projects\\analisis-algoritmos-proyecto1\\Analisis_Algoritmos_Proyecto1\\Results\\insertion.csv";

               File.AppendAllText(path, sw.Elapsed.ToString() + ",");

                Console.WriteLine("Tiempo: " + sw.Elapsed);

            
        }
        
        static public void DoMerge(int[] numbers, int left, int mid, int right)
        {
            int[] temp = new int[numbers.Length];
            int i, left_end, num_elements, tmp_pos;

            left_end = (mid - 1);
            tmp_pos = left;
            num_elements = (right - left + 1);

            while ((left <= left_end) && (mid <= right))
            {
                if (numbers[left] <= numbers[mid])
                    temp[tmp_pos++] = numbers[left++];
                else
                    temp[tmp_pos++] = numbers[mid++];
            }

            while (left <= left_end)
                temp[tmp_pos++] = numbers[left++];

            while (mid <= right)
                temp[tmp_pos++] = numbers[mid++];

            for (i = 0; i < num_elements; i++)
            {
                numbers[right] = temp[right];
                right--;
            }
        }

        static public void MergeSort_Recursive(int[] numbers, int left, int right)
        {
            int mid;

            if (right > left)
            {
                mid = (right + left) / 2;
                MergeSort_Recursive(numbers, left, mid);
                MergeSort_Recursive(numbers, (mid + 1), right);

                DoMerge(numbers, left, (mid + 1), right);
            }
        }

        public static void HeapSort(int[] input)
        {
            //Build-Max-Heap
            int heapSize = input.Length;
            for (int p = (heapSize - 1) / 2; p >= 0; p--)
                MaxHeapify(input, heapSize, p);

            for (int i = input.Length - 1; i > 0; i--)
            {
                //Swap
                int temp = input[i];
                input[i] = input[0];
                input[0] = temp;

                heapSize--;
                MaxHeapify(input, heapSize, 0);
            }
        }

        private static void MaxHeapify(int[] input, int heapSize, int index)
        {
            int left = (index + 1) * 2 - 1;
            int right = (index + 1) * 2;
            int largest = 0;

            if (left < heapSize && input[left] > input[index])
                largest = left;
            else
                largest = index;

            if (right < heapSize && input[right] > input[largest])
                largest = right;

            if (largest != index)
            {
                int temp = input[index];
                input[index] = input[largest];
                input[largest] = temp;

                MaxHeapify(input, heapSize, largest);
            }
        }


        static List<int> RandomList(int size)
        {
            List<int> ret = new List<int>(size);
            Random rand = new Random(1);
            for (int i = 0; i < size; i++)
            {
                ret.Add(rand.Next(size));
            }
            return ret;
        }

        static int MyPartition(List<int> list, int left, int right)
        {
            int start = left;
            int pivot = list[start];
            left++;
            right--;

            while (true)
            {
                while (left <= right && list[left] <= pivot)
                    left++;

                while (left <= right && list[right] > pivot)
                    right--;

                if (left > right)
                {
                    list[start] = list[left - 1];
                    list[left - 1] = pivot;

                    return left;
                }


                int temp = list[left];
                list[left] = list[right];
                list[right] = temp;

            }
        }

        static void MyQuickSort(List<int> list, int left, int right)
        {
            if (list == null || list.Count <= 1)
                return;

            if (left < right)
            {
                int pivotIdx = MyPartition(list, left, right);
                //Console.WriteLine("MQS " + left + " " + right);
                //DumpList(list);
                MyQuickSort(list, left, pivotIdx - 1);
                MyQuickSort(list, pivotIdx, right);
            }
        }

        static void DumpList(List<int> list)
        {
            list.ForEach(delegate (int val)
            {
                Console.Write(val);
                Console.Write(",");
            });
            Console.WriteLine();
        }


        public static void SelectionSort(int size)
        {
            
            int[] number = new int[size];
            Random r = new Random();
            for (int i = 0; i < size; i++)
            {
                number[i] = r.Next(1, size);
            }

            //pos_min is short for position of min
            
            int pos_min, temp;
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < number.Length - 1; i++)
            {
                pos_min = i;//set pos_min to the current index of array

                for (int j = i + 1; j < number.Length; j++)
                {
                    if (number[j] < number[pos_min])
                    {
                        pos_min = j;
                    }
                }
                if (pos_min != i)
                {
                    temp = number[i];
                    number[i] = number[pos_min];
                    number[pos_min] = temp;
                }
            }
            sw.Stop();

            string path = "C:\\Users\\wmejia\\Documents\\Visual Studio 2012\\Projects\\analisis-algoritmos-proyecto1\\Analisis_Algoritmos_Proyecto1\\Results\\selection.csv";
            File.AppendAllText(path, sw.Elapsed + ",");
            Console.WriteLine("Tiempo: " + sw.Elapsed);
        }
        
    }
}
