using System;
using System.Text;

namespace Tast_1_3
{
    class Program
    {
        static int CountWords(string s)
        {

            int countWords = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == ' ')
                    countWords++;
            }
            return countWords + 1;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Введите слова через пробел");
            string text = Console.ReadLine();
            int countWords = CountWords(text);
            string[] words = text.Split(' ');
            Array.Sort(words);
            Console.WriteLine("Результат работы программы:");
            for (int i = 0; i < countWords; i++)
            {
                Console.WriteLine(words[i]);
            }
        }
    }
}
