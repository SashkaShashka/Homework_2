using System;
using System.Text;

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
                array[i] = random.Next(1, 65536);
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
            int[] helpArray = new int[65536];
            int maxCount = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                helpArray[arr[i]]++;
            }
            for (int i = 0; i < helpArray.Length; i++)
            {
                if (helpArray[i] > maxCount)
                    maxCount = helpArray[i];
            }
            StringBuilder sb = new StringBuilder("");
            for (int i = 0; i < helpArray.Length; i++)
            {
                if (helpArray[i] == maxCount)
                    sb.Append(" " + i);
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
