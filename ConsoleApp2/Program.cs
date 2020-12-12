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
            //grammar
            //S->AB
            //A->CD | CF
            //B->c | EB
            //C->a
            //D->b
            //E->c
            //F->AD
            string[,] MyGrammar = { {"S","AB","" },{ "A","CD","CF"}, { "B","c", "EB"},{ "C","a",""},{ "D","b",""}, { "E", "c", "" }, { "F", "AD", "" } };
            string str;
            Console.WriteLine("Grammar");
            for (int i=0; i<MyGrammar.GetUpperBound(0)+1;i++)
            {
                for (int j=0; j<MyGrammar.GetUpperBound(1)+1;j++)
                {
                    Console.Write(MyGrammar[i,j] + " ");
                    if (j == 0)
                        Console.Write("-> ");
                }
                
                Console.WriteLine();
            }
            Console.WriteLine("Вводим строку алгоритма");
            str = Console.ReadLine();//входная строка длинной n
            char[,] M = new char[str.Length,str.Length];//треугольная матрица n-ого порядка
            string[][] s = new string[str.Length][];// делаю ступенчатую матрицу
            int k = 0;
            for (int i = str.Length; i > 0; i--)
            {
                s[k] = new string[i];
                k++;
            }
            for (int i = 0; i < s.Length; i++)
            {
                for (int j = 0; j < s[i].Length; j++)
                {

                    Console.Write($"{s[i][j]} \t");
                }
                Console.WriteLine();
            }
            
            //foreach (var it in s)
            //{
            //    foreach (var it1 in it)
            //        Console.Write(it1+" ");
            //    Console.WriteLine();
            //}
            Console.ReadLine();
        }
        string CheckSymbol(string MySymbol, string endstr, string[,] MyGrammar)
        {
            if (endstr == "")
            {
                for (int i = 0; i < MyGrammar.GetUpperBound(0) + 1; i++)
                {
                    for (int j = 0; j < MyGrammar.GetUpperBound(1) + 1; j++)
                    {
                        if (j != 0)
                            if ()
                    }

                    Console.WriteLine();
                }
            }
            return endstr;
        }
    }
}
