using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace To_Do_List
{
    internal class Program
    {
            static public DateTime time = DateTime.Now;
            public static int DN = 0;
            static int MonthMem = time.AddDays(DN).Month;
            static int DayMem = time.Day;
            static public string day = "";
            static public string month = "";
            /// <summary>
            /// Выбор задачи по номеру в списке
            /// </summary>
            static public int CursorSelection = 2;
            public static bool InMemo;

        public static void Main(string[] args)
        {
          
            if (DayMem < 10)
            {
                day = $"0{DayMem}";
            }
            else
            {
                day = $"{DayMem}";
            }
            if (MonthMem < 10)
            {
                month = $"0{MonthMem}";
            }
            else
            {
                month = $"{MonthMem}";
            }


            Console.SetCursorPosition(1, 1);
            Console.CursorVisible = false;
            Console.WriteLine($"Выбрана дата {day}.{month}.{time.Year}");

            if (Memo.AllMemos.Count == 0)
            {
                Console.WriteLine("   На сегодня нет записей\n " +
                    " CTRL+ для создания задачи, V для просмотра");
            }
            while (true)
            {
                ConsoleKeyInfo consoleKeyInfo = Console.ReadKey(true);
                if (consoleKeyInfo.Key == ConsoleKey.OemPlus)
                {
                    Console.CursorVisible = true;
                    DataFix(ref day, ref month);
                    Memo.AllMemos.Add(new Memo()
                    {
                        Name = Memo.InputMemoName(),
                        Description = Memo.InputMemoDescription(),
                        Day = time.AddDays(DN).Day,
                        Mouth = time.AddDays(DN).Month,
                        Year = time.AddDays(DN).Year,
                    });  
                    Memo.AllMemos[Memo.AllMemos.Count-1].Id = Memo.AllMemos.Where(i => i.Day == time.AddDays(DN).Day).ToList().Count;
                    Console.Clear();
                    Console.WriteLine($"\n Выбрана дата {day}.{month}.{time.Year}");
                    Memo.Check(Memo.AllMemos);
                }
                if (consoleKeyInfo.Modifiers.HasFlag(ConsoleModifiers.Control) && consoleKeyInfo.Key == ConsoleKey.OemMinus)
                {
                    //Console.WriteLine("-");
                }
                if (consoleKeyInfo.Modifiers.HasFlag(ConsoleModifiers.Control) && consoleKeyInfo.Key == ConsoleKey.R)
                {
                    //Console.WriteLine("R");
                }

                switch (consoleKeyInfo.Key)
                {
                    //Обнова
                    case ConsoleKey.V:
                        Console.Clear();
                        Console.SetCursorPosition(1, 1);
                        Console.WriteLine($"Выбрана дата {day}.{month}.{time.Year}");
                        Page(Memo.AllMemos, day, month);
                        Memo.Check(Memo.AllMemos);
                        break;

                    case ConsoleKey.DownArrow:
                        CursorSelection++;
                        Memo.Check(Memo.AllMemos);
                        break;

                    case ConsoleKey.Enter:

                        Memo.Open();
                        // Enter
                        break;

                    case ConsoleKey.UpArrow:
                        CursorSelection--;
                        Memo.Check(Memo.AllMemos);
                        //Console.Write("^");
                        break;

                    case ConsoleKey.LeftArrow:
                        DN--;
                        CursorSelection=1;
                        Page(Memo.AllMemos, day, month);
                        Memo.Check(Memo.AllMemos);
                        break;

                    case ConsoleKey.RightArrow:
                        CursorSelection=1;
                        InMemo = !InMemo;
                        DN++;
                        Page(Memo.AllMemos, day, month);
                        Memo.Check(Memo.AllMemos);
                        break;
                }
            }
        }

        public static void DataFix(ref string day, ref string month)
        {
            if (time.AddDays(DN).Day < 10)
            {
                day = $"0{time.AddDays(DN).Day}";
            }
            else
            {
                day = $"{time.AddDays(DN).Day}";
            }


            if (time.AddDays(DN).Month < 10)
            {
                month = $"0{time.AddDays(DN).Month}";
            }
            else
            {
                month = $"{time.AddDays(DN).Month}";
            }

        }

        /// <summary>
        /// Красивый вывод шапки
        /// </summary>
        /// <param name="MemoObj"></param>
        /// <param name="day"></param>
        /// <param name="month"></param>
        public static void Page(List<Memo> MemoObj, string day, string month)
        {
            DataFix(ref day, ref month);
            Console.Clear();
            Console.SetCursorPosition(1, 1);
            Console.CursorVisible = false;
            Console.Write($"Выбрана дата {day}.{month}.{time.AddDays(DN).Year}\n");
        }
    }
}
