using System;
using System.Text;

namespace Task_2_2
{
    class Program
    {
        static char[] LowerL = { 'a', 'b', 'v', 'g', 'd', 'e', 'ž', 'z', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'r', 's', 't', 'u', 'f', 'h', 'c', 'č', 'š', 'ŝ', 'ʺ', 'y', 'ʹ', 'è', 'û', 'â', 'ë' };
        static char[] UpperL = { 'A', 'B', 'V', 'G', 'D', 'E', 'Ž', 'Z', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'R', 'S', 'T', 'U', 'F', 'H', 'C', 'Č', 'Š', 'Ŝ', 'ʺ', 'Y', 'ʹ', 'È', 'Û', 'Â', 'Ë' };
        // static char[,] Letters = new char[,]    {{ 'a', 'b', 'v', 'g', 'd', 'e', 'ž', 'z', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'r', 's', 't', 'u', 'f', 'h', 'c', 'č', 'š', 'ŝ', 'ʺ', 'y', 'ʹ', 'è', 'û', 'â', 'ë' },
        //                                          { 'A', 'B', 'V', 'G', 'D', 'E', 'Ž', 'Z', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'R', 'S', 'T', 'U', 'F', 'H', 'C', 'Č', 'Š', 'Ŝ', 'ʺ', 'Y', 'ʹ', 'È', 'Û', 'Â', 'Ë' }};
        static string Translit(string text)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < text.Length; i++)
            {
                sb.Append(NewLetter(text[i]));
            }
            return sb.ToString();
        }
        static char NewLetter(char ch)
        {
            if (ch >= 'А' && ch <= 'Я')
                return UpperL[ch - 'А'];
            if (ch >= 'а' && ch <= 'я')
                return LowerL[ch - 'а'];
            if (ch == 'Ë')
                return UpperL[UpperL.Length - 1];
            if (ch == 'ë')
                return LowerL[LowerL.Length - 1];
            return ch;

        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.WriteLine("Введите текст для транслитерации:");
            string text = Console.ReadLine();
            Console.WriteLine("Текст после транслитерации:");
            text = Translit(text);
            Console.WriteLine(text);
        }
    }
}
