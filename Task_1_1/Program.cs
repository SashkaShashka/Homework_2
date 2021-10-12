using System;

namespace Task_1_1
{
    class Program
    {
        static string GetUnicode(ConsoleKeyInfo ch)
        {
            String number = Convert.ToString((int)ch.KeyChar, 16);
            return ch.KeyChar + "\t0x" + String.Format("{0:X4}", (int)ch.KeyChar);
        }
        static void Main(string[] args)
        {
            ConsoleKeyInfo cki;

            Console.OutputEncoding = System.Text.Encoding.Unicode;

            while (true)
            {
                Console.WriteLine("Чтобы закончить введите Enter");
                Console.Write("Введите символ: ");
                cki = Console.ReadKey(true);
                if (cki.Key == ConsoleKey.Enter)
                    return;
                else
                    Console.WriteLine(GetUnicode(cki));
            }
        }
    }
}