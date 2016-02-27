using System;
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
            //insert sort
            //selection sort
            //merge sort
            //heap sort en un mismo arreglo
            //quick sort en un mismo arreglo
            //radix sort
            int[] size = { 10, 100, 1000, 10000, 100000, 1000000 };

            /**
              for (int i = 0; i < 6; i++)
                {
                for (int j = 0; j < 10; j++)
                {
                    bubble_sort(1000000);
                }
                string path = "C:\\Users\\Ithamar\\Desktop\\Clases\\Analisis de Algoritmos\\Results\\bubble.csv";
                File.AppendAllText(path, Environment.NewLine);
            }
            
            
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    InsertionSort(size[i]);
                }
                string path = "C:\\Users\\Ithamar\\Desktop\\Clases\\Analisis de Algoritmos\\Results\\insertion.csv";
                File.AppendAllText(path, Environment.NewLine);
            }*/

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

            string path = "C:\\Users\\Ithamar\\Desktop\\Clases\\Analisis de Algoritmos\\Results\\bubble.csv";
            
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
