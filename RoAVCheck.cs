using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7
{
    internal static class RoAVCheck
    {
        public static void Continue()
        {
            Console.WriteLine("Нажмите любую клавишу, чтобы продолжить...");
            Console.ReadLine();
        }
        public static int Input()
        {
            int c;
            while (!int.TryParse(Console.ReadLine(), out c))
            {
                Console.WriteLine($"Ошибка! введите число заново: ");
            }
            return c;
        }
        public static int InputA()
        {
            int A = 0;
            bool isNumber = false;
            while (isNumber == false)
            {
                Console.Write("Введите А: ");
                string a = Console.ReadLine();
                isNumber = int.TryParse(a, out A);
                if (isNumber == false)
                {
                    Console.WriteLine("Введите A: ");
                    while (!int.TryParse(Console.ReadLine(), out A))
                    {
                        Console.WriteLine("Введите A: ");
                    }
                }
                if (Math.Cos(A) == 1)
                {
                    Console.WriteLine("Ошибка! Деление на ноль!");
                    Continue();
                    break;
                }
            }
            return A;
        }
        public static int InputB()
        {
            int B = 0;
            bool isNumber2 = false;
            while (isNumber2 == false)
            {
                Console.Write("Введите B: ");
                string b = Console.ReadLine();
                isNumber2 = int.TryParse(b, out B);
                if (isNumber2 == false)
                {
                    Console.WriteLine("Введите B: ");
                    while (!int.TryParse(Console.ReadLine(), out B))
                    {
                        Console.WriteLine("Введите B: ");
                    }
                }
                if (B <= 0)
                {
                    Console.WriteLine("Ошибка! Действие не может выполняться за пределами области допустимых значенимй");
                    Continue();
                    break;
                }
            }
            return B;
        }
    }
}
