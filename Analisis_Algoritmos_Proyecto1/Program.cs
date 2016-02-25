using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;

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

            // 10000, 100000, 1000000
            Console.WriteLine("Insertion sort: ");
            int [] size = { 10, 10, 100, 10000, 100000, 1000000 };
           // for (int i = 0; i < 6; i++)
           // {
                for (int j = 0; j < 10; j++)
                {
                    bubble_sort(1000000);
                }
                string path = "C:\\Users\\Ithamar\\Desktop\\Clases\\Analisis de Algoritmos\\Results\\bubble.csv";
                File.AppendAllText(path, Environment.NewLine);
           // }
            /*
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    InsertionSort(size[i]);
                }
                string path = "C:\\Users\\Ithamar\\Desktop\\Clases\\Analisis de Algoritmos\\Results\\insertion.csv";
                File.AppendAllText(path, Environment.NewLine);
            }*/

            Console.ReadKey();
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
        {{
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
                
                string path = "C:\\Users\\Ithamar\\Desktop\\Clases\\Analisis de Algoritmos\\Results\\insertion.csv";

                File.AppendAllText(path, sw.Elapsed.ToString() + ",");

               // Console.WriteLine("Tiempo: " + sw.Elapsed);

            }
        }
        
            
    }
}
