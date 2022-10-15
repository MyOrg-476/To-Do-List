using System;
using System.Collections.Generic;
using System.Linq;

namespace To_Do_List
{

    internal class Memo : Program
    {
        public string Name = String.Empty;
        public string Description = String.Empty;
        public int Day = time.AddDays(DN).Day;
        public int Mouth = time.AddDays(DN).Month;
        public int Year = time.AddDays(DN).Year;
        public int Id = 0;
        static public List<Memo> AllMemos = new List<Memo>();
        private static int x = 4;

        public static string InputMemoName()
        {
            Console.SetCursorPosition(x, CursorSelection+2);
            Console.Write("  Ведите название записки:\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t");
            Console.SetCursorPosition(31, CursorSelection+2);

            return Console.ReadLine();
        }
        public static string InputMemoDescription()
        {
            Console.SetCursorPosition(x, CursorSelection + 3);
            Console.Write("  Ведите описание:\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t");
            Console.SetCursorPosition(0, CursorSelection + 4);
            Console.Write("\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t");
            Console.SetCursorPosition(x+3, CursorSelection + 4);
            return Console.ReadLine();
        }

        /// <summary>
        /// Выбор задачи курсором
        /// </summary>
        /// <param name="AllMemo"></param>
        public static void Select(List<Memo> AllMemo)
        {
            if (CursorSelection <= 1)
            {
                CursorSelection = 1;
            }
            if (CursorSelection > AllMemos.Where(i => i.Day == time.AddDays(DN).Day).ToList().Count)
            {
                CursorSelection--;
                Console.SetCursorPosition(1, CursorSelection + 1);
            }
            Console.SetCursorPosition(1, CursorSelection + 1);
            Console.Write($"->");
        }

        /// <summary>
        /// Вывод задач
        /// </summary>
        /// <param name="AllMemo"></param>
        public static void Check(List<Memo> AllMemo)
        {
            Console.Clear();
            Page(AllMemos, day, month);
            //Console.Write("  Вектор времени: " + DN);
            if (AllMemos.Where(i => i.Year == time.AddDays(DN).Year &&
            i.Mouth == time.AddDays(DN).Month &&
            i.Day == time.AddDays(DN).Day).ToList().Count == 0)
            {
                Console.WriteLine("   На сегодня нет записей\n " +
                        " + для создания задачи, - для удаления, R для редактирования");
            }
            else
            {
                //Console.Write("   Кол-во заданий " + AllMemo.Count + "\n");
                List<Memo> t = new List<Memo>();

                foreach (var memo in AllMemo)
                {
                    if (memo.Year == time.AddDays(DN).Year &&
                    memo.Mouth == time.AddDays(DN).Month &&
                    memo.Day == time.AddDays(DN).Day)
                        Console.WriteLine($"    {memo.Id}. {memo.Name}");
                }
                Console.CursorVisible = false;
                Select(AllMemo);
            }
        }
        /// <summary>
        /// Просмотр с описанием
        /// </summary>
        public static void Open(/*Memo memos*/)
        {
            if (AllMemos.Where(i => i.Year == time.AddDays(DN).Year &&
            i.Mouth == time.AddDays(DN).Month &&
            i.Day == time.AddDays(DN).Day).ToList().Count != 0)
            {
                Console.Clear();
                Page(AllMemos, day, month);
                foreach (var memo in AllMemos)
                {
                    if (memo.Year == time.AddDays(DN).Year &&
                    memo.Mouth == time.AddDays(DN).Month &&
                    memo.Day == time.AddDays(DN).Day && memo.Id < CursorSelection)
                        Console.WriteLine($"    {memo.Id}. {memo.Name}");
                }

                foreach (var memo in AllMemos.Where(i =>
                        i.Year == time.AddDays(DN).Year &&
                        i.Mouth == time.AddDays(DN).Month &&
                        i.Day == time.AddDays(DN).Day
                        && i.Id == CursorSelection).ToList())
                {
                    if (memo.Year == time.AddDays(DN).Year &&
                    memo.Mouth == time.AddDays(DN).Month &&
                    memo.Day == time.AddDays(DN).Day && memo.Id == CursorSelection
                        && AllMemos.Where(i =>
                        i.Year == time.AddDays(DN).Year &&
                        i.Mouth == time.AddDays(DN).Month &&
                        i.Day == time.AddDays(DN).Day
                        && i.Id == CursorSelection).ToList().Count != 0)
                        Console.WriteLine($"    {memo.Id}. {memo.Name}\n   {memo.Description}");
                }
                foreach (var memo in AllMemos)
                {
                    if (memo.Year == time.AddDays(DN).Year &&
                    memo.Mouth == time.AddDays(DN).Month &&
                    memo.Day == time.AddDays(DN).Day && memo.Id > CursorSelection)
                        Console.WriteLine($"    {memo.Id}. {memo.Name}");
                }
            }
        }
    }
}