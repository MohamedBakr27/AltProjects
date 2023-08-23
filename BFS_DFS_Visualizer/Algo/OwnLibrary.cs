using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwnLibrary
{
    class Color
    {
        public static void Red() { Console.ForegroundColor = ConsoleColor.Red; }
        public static void Green() { Console.ForegroundColor = ConsoleColor.Green; }
        public static void Blue() { Console.ForegroundColor = ConsoleColor.Blue; }
        public static void Cyan() { Console.ForegroundColor = ConsoleColor.Cyan; }
        public static void White() { Console.ForegroundColor = ConsoleColor.Gray; }
        public static void Yellow() { Console.ForegroundColor = ConsoleColor.Yellow; }
    }
    class Read
    {
        public static string String() { return Console.ReadLine(); }
        public static char Char() { return char.Parse(String()); }
        public static int Int() { return int.Parse(String()); }
        public static long Long() { return long.Parse(String()); }
        public static double Double() { return double.Parse(String()); }
        public static string[] Strings() { return String().Split(' '); }
        public static char[] Chars() { return Array.ConvertAll(String().Split(' '), char.Parse); }
        public static int[] Ints() { return Array.ConvertAll(String().Split(' '), int.Parse); }
        public static long[] Longs() { return Array.ConvertAll(String().Split(' '), long.Parse); }
        public static double[] Doubles() { return Array.ConvertAll(String().Split(' '), double.Parse); }
    }
    class Pair<F, S>
    {
        public F First;
        public S Second;
        public Pair(F f, S s)
        {
            First = f;
            Second = s;
        }
    }
}