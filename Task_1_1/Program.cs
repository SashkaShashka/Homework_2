using System;

namespace Task_1_1
{
    class Program
    {
        static string GetUnicode(ConsoleKeyInfo ch)
        {
            String number = Convert.ToString((int)ch.KeyChar, 16);
            switch (number.Length)
            {
                case 0:
                    return ch.KeyChar + "\t0x0000";
                case 1:
                    return (ch.KeyChar + "\t0x000" + number);
                case 2:
                    return (ch.KeyChar + "\t0x00" + number);
                case 3:
                    return (ch.KeyChar + "\t0x0" + number);
                default:
                    return (ch.KeyChar + "\t0x" + number);
            }
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