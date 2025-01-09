using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7
{
    static class AnswerGuess
    {
        public static double FuncResult()
        {
            Console.WriteLine("F = ((ln(B))^2)/(cos(A)-1)");
            int A = RoAVCheck.InputA();
            int B = RoAVCheck.InputB();
            Console.WriteLine("Чему равно значение функции");
            double result = Math.Log(B) * Math.Log(B) / (Math.Cos(A) - 1);
            return result;
        }
        public static void AnsGuess()
        {
            double result = FuncResult();
            int GuessCount = 0;
            int guess;
            int mark = 3;
            bool LostOfTries = true;
            while (LostOfTries)
            {
                guess = RoAVCheck.Input();
                GuessCount = GuessCount + 1;
                if (guess == Math.Round(result))
                {
                    Console.WriteLine("Вы выиграли");
                    LostOfTries = false;
                }
                else if (GuessCount == 3)
                {
                    Console.WriteLine("Вы проиграли");
                    Console.WriteLine("Ответ: " + Math.Round(result));
                    LostOfTries = false;
                }
                else
                {
                    Console.WriteLine("Оставшиеся попытки: " + (mark - GuessCount));
                    LostOfTries = true;
                }
            }
            RoAVCheck.Continue();
        }
    }
}
