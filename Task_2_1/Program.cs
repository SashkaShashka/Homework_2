using System;

namespace Task_2_1
{
    class Program
    {
        static void PrintIn(int[] AZS, int[] volume, decimal[] price, int[][] pricePathAZS)
        {
            Console.WriteLine("┌────────────┬────────────┬─────────┬───────────────────────────────┐");
            Console.WriteLine("│            │  Максимум  │  Цена   │   Стоимость доставки на АЗС   │");
            Console.WriteLine("│            │   объема   │ закупки ├───────┬───────┬───────┬───────┤");
            Console.WriteLine("│ Поставщики │   закупки  │ за ед.  │   А   │   Б   │   В   │   Г   │");
            Console.WriteLine("├────────────┼────────────┼─────────┼───────┼───────┼───────┼───────┤");

            for (int i = 0; i < volume.Length; i++)
            {
                for (int j = 0; j < volume.Length + 1; j++)
                {
                    if (j == 0)
                        Console.Write($"│{i + 1,12}│");
                    if (j == 1)
                        Console.Write($"{volume[i],12}│");
                    if (j == 2)
                        Console.Write($"{price[i],9}│");
                    if (j > 2)
                        Console.Write($"{pricePathAZS[i][j - 3],7}|");

                }
                Console.WriteLine();
            }
            Console.WriteLine("└────────────┴────────────┴─────────┴───────┴───────┴───────┴───────┘");
        }
        static bool ChechEnd(int[] AZS)
        {
            for (int i = 0; i < AZS.Length; i++)
            {
                if (AZS[i] > 0.1)
                    return false;
            }
            return true;
        }
        static int GetIndexForMinValue(int[] arr)
        {
            int index = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] < arr[index])
                    index = i;
            }
            return index;
        }
        static int GetIndexForMinValue(decimal[] arr)
        {
            int index = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] < arr[index])
                    index = i;
            }
            return index;
        }
        static void PrintResult(decimal[,] result,decimal[] petroleumCost, decimal[] fullCost)
        {
            decimal resultCost = 0;
            Console.WriteLine("┌──────────┬───────┬───────┬───────┬───────┬───────────┬────────────┐");
            Console.WriteLine("│          │       │       │       │       │ Стоимость │  С учетом  │");
            Console.WriteLine("│Поставщики│ АЗС А │ АЗС Б │ АЗС В │ АЗС Г │  закупки  │  доставки  │");
            Console.WriteLine("├──────────┼───────┼───────┼───────┼───────┼───────────┼────────────┤");
            for (int i = 0; i < result.GetUpperBound(0) + 1; i++)
            {
                Console.Write($"│{i + 1,10}│");
                for (int j = 0; j < result.GetUpperBound(0) + 1; j++)
                {
                    if (j < 4)
                        Console.Write($"{result[i, j],7}|");
                   if (j == 4)
                        Console.Write($"{String.Format("{0:F2}", petroleumCost[i]),11}|");
                   if (j==5)
                   {
                        Console.Write($"{String.Format("{0:F2}", fullCost[i]),12}|");
                        resultCost += fullCost[i];
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine("└──────────┴───────┴───────┴───────┴───────┴───────────┴────────────┘");
            Console.WriteLine("ИТОГ: " + String.Format("{0:#,##0.00}", resultCost));
        }
        static int ReadInt(string name, int min, int max)
        {
            Console.Write("Введите " + name + ": ");
            int value;
            while (!int.TryParse(Console.ReadLine(), out value) || value < min || value > max)
            {
                Console.WriteLine("Неверный ввод!");
                Console.Write("Введите " + name + ": ");
            }
            return value;
        }
        static void Algoritm(int[] AZS, int[] volume, decimal[] price, int[][] pricePathAZS)
        {
            decimal[,] resultPrice = new decimal[6, 4];
            decimal[] petroleumCost = new decimal[6];
            decimal[] fullCost = new decimal[6];
            while (!ChechEnd(AZS))
            {
                int minIndex = GetIndexForMinValue(price);

                while (volume[minIndex] != 0 && !ChechEnd(AZS))
                {
                    int minPriceIndex = GetIndexForMinValue(pricePathAZS[minIndex]);

                    int minValueAZSandVolume = Math.Min(AZS[minPriceIndex], volume[minIndex]);
                    AZS[minPriceIndex] = AZS[minPriceIndex] - minValueAZSandVolume;
                    volume[minIndex] = volume[minIndex] - minValueAZSandVolume;
                    resultPrice[minIndex, minPriceIndex] = minValueAZSandVolume;
                    petroleumCost[minIndex] += minValueAZSandVolume * price[minIndex];
                    fullCost[minIndex] += minValueAZSandVolume * price[minIndex] + pricePathAZS[minIndex][minPriceIndex];

                    if (volume[minIndex] == 0)
                    {
                        price[minIndex] = int.MaxValue;
                        pricePathAZS[minIndex][minPriceIndex] = int.MaxValue;
                    }

                    if (AZS[minPriceIndex] == 0)
                    {
                        for (int i = 0; i < pricePathAZS.GetUpperBound(0) + 1; i++)
                        {
                            pricePathAZS[i][minPriceIndex] = int.MaxValue;
                        }
                    }
                }
            }
            PrintResult(resultPrice, petroleumCost, fullCost);
        }
        static void Main(string[] args)
        {
            int[][] pricePathAZS = new int[6][];
            pricePathAZS[0] = new int[] { 803, 952, 997, 931 };
            pricePathAZS[1] = new int[] { 967, 1012, 848, 1200 };
            pricePathAZS[2] = new int[] { 825, 945, 777, 848 };
            pricePathAZS[3] = new int[] { 1024, 1800, 931, 999 };
            pricePathAZS[4] = new int[] { 754, 817, 531, 628 };
            pricePathAZS[5] = new int[] { 911, 668, 865, 1526 };

            decimal[] price = new decimal[] { (decimal)5.2, (decimal)4.5, (decimal)6.1, (decimal)3.8, (decimal)6.4, (decimal)5.6 };

            int[] volume = new int[] { 600, 420, 360, 250, 700, 390 };

            int[] AZS = new int[4];
            for (int i = 0; i < 4; i++)
            {
                AZS[i] = ReadInt($"необходимое количество топлива на АЗС {(char)('А' + i)}", 0, int.MaxValue);
            }

            PrintIn(AZS, volume, price, pricePathAZS);

            Algoritm(AZS, volume, price, pricePathAZS);


        }
    }
}
