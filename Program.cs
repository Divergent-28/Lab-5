using System;
using System.Diagnostics;

namespace Lab5
{
    internal class Program
    {
        static void Continue()
        {
            Console.WriteLine("Нажмите любую клавишу, чтобы продолжить...");
            Console.ReadLine();
        }
        static void Welcome()
        {
            Console.Clear();
            Console.WriteLine("Добро пожаловать в главное меню");
            Console.WriteLine("Ниже представлена инструкция по навигации по программе");
            Console.WriteLine("1 - Отгадай ответ с 3 попыток");
            Console.WriteLine("2 - Информация об авторе");
            Console.WriteLine("3 - Сортировка");
            Console.WriteLine("4 - Морской бой");
            Console.WriteLine("5 - Выход из программы");
        }
        static void FAQ()
        {
            Console.WriteLine("Лабораторная работа #5");
            Console.WriteLine("Гуреева Лидия Владимировна");
            Console.WriteLine("Группа: 6101-090301D");
            Console.WriteLine("Нажмите Enter, чтобы вернуться в главное меню...");
            Console.ReadLine();
        }
        static bool Exit()
        {
            bool isRun = false;
            while (!isRun)
            {
                Console.Clear();
                Console.WriteLine("Вы точно желаете выйти из программы?");
                Console.WriteLine("д - Подтвердить выход из программы");
                Console.WriteLine("н - Вернуться в главное меню");
                string decide = Console.ReadLine();
                if (decide == "д" || decide == "Д" || decide == "l" || decide == "L")
                {
                    isRun = false;
                    return isRun;
                }
                else if (decide == "н" || decide == "Н" || decide == "y" || decide == "Y")
                {
                    isRun = true;
                }
            }
            Continue();
            return isRun;
        }
        
        static void OutOfCase()
        {
            Console.WriteLine("Ошибка! Страница не найдена!");
            Continue();
        }
        static void Sortings()
        {
            Console.WriteLine("1. Обработка массива из 10-ти элементов");
            Console.WriteLine("2. Ввести количество элементов массива");
            int choice = 0;
            while ((choice != 1) && (choice != 2))
            {
                choice = RoAVCheck.Input();
                string text1 = "";
                if (choice == 1)
                {
                    ArrSort n = new ArrSort();
                    n.Sortings();
                }
                else if (choice == 2)
                {
                    Console.WriteLine("Введите кол-во элементов");
                    int a = RoAVCheck.Input();
                    ArrSort n = new ArrSort(a);
                    n.Sortings();
                }
                else
                {
                    Console.WriteLine("Введите 1 или 2");
                }
            }
        }
       
        static void Main(string[] args)
        {
            bool flag = true;
            while (flag)
            {
                Welcome();
                string number = Console.ReadLine();
                Console.Clear();
                switch (number)
                {
                    case "1":
                        AnswerGuess.AnsGuess();
                        break;
                    case "2":
                        FAQ();
                        break;

                    case "3":
                        Sortings();
                        break;
                    case "4":
                        MB g = new MB();
                        g.MorskoyBoy();
                        break;
                    case "5":
                        flag = Exit();
                        break;
                    default:
                        OutOfCase();
                        break;
                }
            }
        }
    }
} 