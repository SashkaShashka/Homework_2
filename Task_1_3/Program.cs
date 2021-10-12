using System;
using System.Text;

namespace Tast_1_3
{
    class Program
    {
        static String CopyWord(StringBuilder s, int beg, int count)
        {
            StringBuilder sb = new StringBuilder("");
            for (int i = beg; i < beg + count; i++)
            {
                sb.Append(s[i]);
            }
            return sb.ToString();

        }
        static string[] GetWords(string s, int countWords)
        {
            StringBuilder sb = new StringBuilder(s + " ");
            int posStart = 0;
            string[] arrayWords = new string[countWords];
            int posWord = 0;
            for (int i = 0; i < sb.Length; i++)
            {
                if (sb[i] == ' ')
                {
                    arrayWords[posWord] = CopyWord(sb, posStart, i - posStart).ToUpper();
                    posWord++;
                    posStart = i + 1;
                }
            }
            return arrayWords;
        }
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
            string[] words = new string[countWords];
            words = GetWords(text, countWords);
            Array.Sort(words);
            Console.WriteLine("Результат работы программы:");
            for (int i = 0; i < countWords; i++)
            {
                Console.WriteLine(words[i]);
            }
        }
    }
}
