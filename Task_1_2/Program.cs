using System;
using System.Text;
using System.Collections.Generic;

namespace ConsoleApp2
{
    class Program
    {
        static int ReadInt()
        {
            int val;
            while (!int.TryParse(Console.ReadLine(), out val))
            {
                Console.Write("Введите длину массива: ");
            }
            return val;
        }
        static int[] GetArrayForLenght(int lenght)
        {
            int[] array = new int[lenght];
            var random = new Random();
            for (int i = 0; i < lenght; i++)
            {
                array[i] = random.Next(1, 4);
            }
            return array;
        }

        static double GetMedian(int[] arr)
        {

            if (arr.Length % 2 == 1)
                return arr[arr.Length / 2];
            else
                return (double)((double)arr[(arr.Length - 1) / 2] + (double)arr[arr.Length / 2]) / 2;
        }

        static String GetMode(int[] arr)
        {
            Dictionary<int, int> valueCounts = new Dictionary<int, int>();
            int maxCount = 0;
            int count = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (valueCounts.ContainsKey(arr[i]))
                {
                    valueCounts[arr[i]]++;
                    count++;
                }
                else
                {
                    valueCounts[arr[i]] = 1;
                    count = 1;
                }
                if (count > maxCount)
                    maxCount = count;
                    
            }
            StringBuilder sb = new StringBuilder("");
            foreach (var valueCount in valueCounts)
            {
                if (valueCount.Value==maxCount)
                    sb.Append(" " + valueCount.Key);
            }
            return sb.ToString();
        }
        static void Main(string[] args)
        {
            Console.Write("Введите длину массива: ");
            int length = ReadInt();
            int[] array = new int[length];
            array = GetArrayForLenght(length);
            Array.Sort(array);
            for (int i = 0; i < length; i++)
            {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine();
            Console.WriteLine("Медиана: " + GetMedian(array));
            Console.WriteLine("Мода или моды: " + GetMode(array));

        }
    }
}
