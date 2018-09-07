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

        public static string InputString(int kiri, int atas)
        {
            string result = "";


            return result;
        }
    }
}
