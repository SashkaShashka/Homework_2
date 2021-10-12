using System;
using System.Text;

class Program
{
    static string textWithRegister ="\tОднажды гуляла я по лесу. Наступила осень, листва на деревьях окрасилась в яркие цвета. Тревожно гудели птицы на озере: скоро наступят холода, пора бы уже улететь, чтобы в следующем году вернуться сюда вновь.\n\tТишину в лесу прерывали только редкие птичьи голоса и шелест ветра по сухим листам.Внезапно, я остановилась, услышав “тук-тук”. Я пошла на звук, но, как только я дошла до дерева, по котором стучал невидимый лесной барабанщик, звук раздался уже на другом стволе, словно неведимка решил поиграть со мной в догонялки.\n\tЯ обошла дерево по кругу, недоумевая, кто же стал причиной шума? Запрокинув голову, я увидела, как на толстой кленовой ветке сидит дятел.Я сразу поняла, что именно он стал причиной шума и, словно по мановению волшебной палочки он застучал твердым черным клювом по коре, оглашая лес редким “тук-тук”.\n\t Мы пошли гулять с ребятами.Нам было очень весело.Мальчишки гоняли мяч. Девочки рассказывали интересные истории, читали книги и собирали цветы.ять";
    static string textNoRegister;

    static void PrintText(string substring, ConsoleColor color)
    {
        Console.BackgroundColor = color;
        Console.Write(substring);
        Console.ResetColor();
    }

    static int Replace(string find, string replacement, bool findWithRegister)
    {
        if (find.Length == 0)
        {
            PrintText(textWithRegister, ConsoleColor.Black);
            Console.WriteLine();
            return 0;
        }
        int count = 0;
        int prePos = -1;
        int pos = -1;
        if (!findWithRegister)
            find = find.ToLower();
        do
        {
            pos++;
            prePos = pos;
            if (findWithRegister)
                pos = textWithRegister.IndexOf(find, pos);
            else
                pos = textNoRegister.IndexOf(find, pos);
            if (pos != -1)
            {
                PrintText(textWithRegister.Substring(prePos,pos-prePos), ConsoleColor.Black);
                count++;
                PrintText(replacement, ConsoleColor.DarkYellow);
                pos = pos + find.Length - 1;

            }
        } while (pos != -1);
        PrintText(textWithRegister.Substring(prePos, textWithRegister.Length - prePos), ConsoleColor.Black);
        Console.WriteLine();
        return count;
    }
    static int Find(string find, bool findWithRegister)
    {
        if (find.Length == 0)
        {
            PrintText(textWithRegister, ConsoleColor.Black);
            Console.WriteLine();
            return 0;
        }
        else
        {
            int count = 0;
            int prePos = -1;
            int pos = -1;
            if (!findWithRegister)
                find = find.ToLower();
            do
            {
                pos++;
                prePos = pos;
                if (findWithRegister)
                    pos = textWithRegister.IndexOf(find, pos);
                else
                    pos = textNoRegister.IndexOf(find, pos);
                if (pos != -1)
                {
                    PrintText(textWithRegister.Substring(prePos, pos - prePos), ConsoleColor.Black);
                    count++;
                    PrintText(textWithRegister.Substring(pos, find.Length),ConsoleColor.Green);
                    pos = pos + find.Length - 1;
                }
            } while (pos != -1);
            PrintText(textWithRegister.Substring(prePos, textWithRegister.Length - prePos), ConsoleColor.Black);
            Console.WriteLine();
            return count;
        }


    }
    static void FindOrRelace()
    {
        bool find = true;
        bool withRegister = true;

        for (; ; )
        {
            Console.Clear();
            ShowMenu(find, withRegister);
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.Q:
                    return;
                case ConsoleKey.F2:
                    withRegister = !withRegister;
                    break;
                case ConsoleKey.F3:
                    find = !find;
                    break;
                case ConsoleKey.Enter:
                    Console.Clear();
                    if (find)
                    {

                        ConsoleKeyInfo key;
                        StringBuilder findString = new StringBuilder("");

                        do
                        {
                            Console.Clear();
                            Console.CursorLeft = 0;
                            Console.WriteLine("Найдено совпадений: " + Find(findString.ToString(), withRegister));
                            Console.WriteLine();
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.Write("Введите подстроку для поиска:");
                            Console.ResetColor();
                            Console.WriteLine(" ");
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.Write("Чтобы закончить поиск нажмите Enter:");
                            Console.ResetColor();
                            Console.Write(" ");
                            Console.CursorTop = Console.CursorTop - 1;
                            Console.CursorLeft = "Введите подстроку для поиска:".Length + 1;
                            Console.WriteLine(findString.ToString());

                            key = Console.ReadKey(true);

                            if (key.Key == ConsoleKey.Backspace && findString.Length > 0)
                            {
                                findString.Remove(findString.Length - 1, 1);
                            }
                            else if (key.Key != ConsoleKey.Enter && key.Key != ConsoleKey.Backspace)
                            {
                                findString.Append(key.KeyChar);
                            }


                        } while (key.Key != ConsoleKey.Enter);
                    }
                    else
                    {
                        Console.WriteLine(textWithRegister);
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.Write("Введите ЧТО нужно заменить:");
                        Console.ResetColor();
                        Console.Write(" ");
                        string findStr = Console.ReadLine();
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.Write("Введите НА ЧТО нужно заменить:");
                        Console.ResetColor();
                        Console.Write(" ");
                        string replaceStr = Console.ReadLine();
                        Console.WriteLine("Произведено замен: " + Replace(findStr, replaceStr, withRegister));
                        Console.ResetColor();
                    }
                    return;
            }
        }
    }



    public static void Main()
    {
        textNoRegister = textWithRegister.ToLower();
        FindOrRelace();

    }
    static void ShowMenu(bool find, bool withRegister)
    {
        Console.BackgroundColor = ConsoleColor.Green;
        Console.ForegroundColor = ConsoleColor.Black;
        for (int i = 0; i < Console.WindowWidth; i++)
            Console.Write(" ");
        Console.CursorLeft = 1;
        Console.Write("Выбрынный режим: ");
        if (find)
            Console.Write("Поиск ");
        else
            Console.Write("Замена ");
        if (withRegister)
            Console.WriteLine("с учетом регистра");
        else
            Console.WriteLine("без учета регистра");
        Console.BackgroundColor = ConsoleColor.DarkCyan;
        for (int i = 0; i < Console.WindowWidth; i++)
            Console.Write(" ");
        Console.CursorLeft = 1;
        PrintMenuCommand("Q", "Выход");
        PrintMenuCommand("F2", "С учетом регистра/Без учета регистра");
        PrintMenuCommand("F3", "Заменить/Найти");
        PrintMenuCommand("Enter", "Начать операцию");
        Console.WriteLine();
        Console.ResetColor();
        Console.CursorLeft = 0;
    }

    static void PrintMenuCommand(string key, string action)
    {
        Console.ForegroundColor = ConsoleColor.Black;
        Console.Write(key);
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write(" " + action + " ");
    }
}
