using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            string str;
            Console.WriteLine("Вводим строку алгоритма");
            str = Console.ReadLine();//входная строка длинной n
            char[,] M = new char[str.Length,str.Length];//треугольная матрица n-ого порядка
            string[][] s = new string[str.Length][];
            for (int i=str.Length;i>0;i++)
            s[0] = new string[i];
            

        }
    }
}
