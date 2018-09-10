using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class MyIO
    {
        

        public static void Tulis(int kiri, int atas, string teks, ConsoleColor warnaTeks = ConsoleColor.White, ConsoleColor warnaBg = ConsoleColor.Black)
        {
            Console.ForegroundColor = warnaTeks;
            Console.BackgroundColor = warnaBg;
            Console.SetCursorPosition(kiri, atas);
            Console.WriteLine(teks);
        }

        public static void Tulis(string teks, ConsoleColor warnaTeks = ConsoleColor.White, ConsoleColor warnaBg = ConsoleColor.Black)
        {
            Console.ForegroundColor = warnaTeks;
            Console.BackgroundColor = warnaBg;
            Console.WriteLine(teks);
        }

        public static string InputString(int kiri, int atas)
        {
            string result = "";


            return result;
        }


        public static void BuatKotak(int kiri, int atas, int kanan, int bawah)
        {
            Console.SetCursorPosition(kiri, atas);
            Console.Write("┌");

            for (int i = kiri + 1; i <= kanan - 1; i++)
            {
                Console.SetCursorPosition(i, atas);
                Console.Write("─");
                //System.Threading.Thread.Sleep(50);
            }

            Console.SetCursorPosition(kanan, atas);
            Console.Write("┐");

            for (int i = atas + 1; i <= bawah - 1; i++)
            {
                Console.SetCursorPosition(kanan, i);
                Console.Write("│");
                //System.Threading.Thread.Sleep(50);
            }

            Console.SetCursorPosition(kanan, bawah);
            Console.Write("┘");

            for (int i = kanan - 1; i >= kiri + 1; i--)
            {
                Console.SetCursorPosition(i, bawah);
                Console.Write("─");
            }

            Console.SetCursorPosition(kiri, bawah);
            Console.Write("└");

            for (int i = bawah - 1; i >= atas + 1; i--)
            {
                Console.SetCursorPosition(kiri, i);
                Console.Write("│");
            }
        }
    }
}
