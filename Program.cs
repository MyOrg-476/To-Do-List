﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int act, n;
            bool Stoped = false;
            bool FirstOpen = true;
            Console.WriteLine("         __\r\n _(\\    |@@|\r\n(__/\\__ \\--/ __\r\n   \\___|----|  |   __\r\n       \\ }{ /\\ )_ / _\\\r\n       /\\__/\\ \\__O (__\r\n      (--/\\--)    \\__/\r\n      _)(  )(_\r\n     `---''---`");
            do
            {
                int ActIn()
                {
                    if (FirstOpen)
                    {
                        Console.WriteLine(" Привет, я калькулятор! Я могу сделать:\n\t1. Сложение чисел" +
                            "\n\t2. Вычитание" +
                            "\n\t3. Умножение" +
                            "\n\t4. Деление" +
                            "\n\t5. Возвести в степень n первое число" +
                            "\n\t6. Найти квадратный корень из числа" +
                            "\n\t7. Найти 1%" +
                            "\n\t8. Найти факториал числа" +
                            "\n\t9. Выйти из программы");
                        Console.Write(" Выбери номер операции: ");
                        FirstOpen = false;
                    }
                    else
                    {
                        Console.Write("Выбери операцию ещё разок: ");
                    }
                    return int.Parse(Console.ReadLine());
                }
                act = ActIn();
                int Num1In()
                {
                    
                    Console.Write("Введите первое число: ");
                    return int.Parse(Console.ReadLine());
                }

                int Num2In()
                {
                    Console.Write("Введите второе число: ");
                    return int.Parse(Console.ReadLine());
                }
                switch (act)
                {
                    case 1:
                        Console.WriteLine("Результат " + (Num1In() + Num2In()));
                        break;
                    case 2:
                        Console.WriteLine("Результат " + (Num1In() - Num2In()));
                        break;
                    case 3:
                        Console.WriteLine("Результат " + (Num1In() * Num2In()));
                        break;
                    case 4:
                        Console.WriteLine("Результат " + (Convert.ToSingle(Num1In()) / Num2In()));
                        break;
                    case 5:
                        Console.WriteLine("Результат " + Math.Pow(Num1In(), Num2In()));
                        break;
                    case 6: Console.WriteLine("Результат " + Math.Sqrt(Num1In())); break;
                    case 7:
                        Console.WriteLine("Результат " + (Convert.ToSingle(Num1In())) * 0.01);
                        break;
                    case 8:
                        int anws = 1;
                        n = Num1In();
                        for (int i = 1; i <= n; i++)
                            anws *= i;
                        Console.WriteLine($"Результат {anws}"); break;
                    case 9:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Пока, спасибо что открыли");
                        Stoped = true;
                        break;
                }
            } while (!Stoped);


        }
    }
}