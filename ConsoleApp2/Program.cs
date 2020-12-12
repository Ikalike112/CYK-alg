using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
            //grammar
            //S->AB
            //A->CD | CF
            //B->c | EB
            //C->a
            //D->b
            //E->c
            //F->AD
            //char[,] M = new char[str.Length,str.Length]; //треугольная матрица n-ого порядка
namespace ConsoleApp2
{
    class Program
    {

        static void Main(string[] args)
        {
            string[,] MyGrammar = { { "S", "AB", "" }, { "A", "CD", "CF" }, { "B", "c", "EB" }, { "C", "a", "" }, { "D", "b", "" }, { "E", "c", "" }, { "F", "AD", "" } };
            PrintGrammar(MyGrammar);
            Console.WriteLine("Введите строку алгоритма");
            string str = Console.ReadLine(); //входная строка
            string[][] s = new string[str.Length][]; // делаю ступенчатую матрицу
            int k = 0;
            for (int i = str.Length; i > 0; i--)
            {
                s[k] = new string[i];
                for (int j=0;j<s[k].Length;j++)
                {
                    s[k][j] = "_";
                }
                k++;
            }
            TheCYKAlgorythm(ref s, str, MyGrammar);
            PrintTable(s);
            Console.ReadLine();
        }

        public static void TheCYKAlgorythm(ref string[][] s, string str, string[,] MyGrammar)
        {
            int x1, y1, x2, y2;
            for (int i = 0; i < s.Length; i++)
            {
                x1 = 0;
                x2 = i - 1;
                for (int j = 0; j < s[i].Length; j++)
                {
                    y1 = j;
                    y2 = j + 1;
                    if (x2==-1)
                    {
                        x1 = 0;
                        x2 = i - 1;
                    }
                    if (i==0)
                    {
                        s[i][j] = CheckSymbol(str[j].ToString(),"",s[i][j],MyGrammar);
                    }
                    else
                    {
                        while (x1!=i)
                        {
                            s[i][j] = CheckSymbol(s[x1][y1], s[x2][y2], s[i][j], MyGrammar);
                            x1++;
                            x2--;
                            y2++;
                        }
                    }
                }
            }
        }

        public static string CheckSymbol(string MySymbol1, string MySymbol2, string endstr, string[,] MyGrammar)
        {
            string MySymbol;
            string[] mysymbols1 =MySymbol1.Split(','); //разбиваю строку, чтобы можно было считать например b,e и b,e как eb
            string[] mysymbols2 =MySymbol2.Split(','); //разбиваю строку, чтобы можно было считать например b,e и b,e как eb
            if (endstr == null || endstr == "_")
            {
                for (int i = 0; i < MyGrammar.GetUpperBound(0) + 1; i++)
                {
                    for (int j = 0; j < MyGrammar.GetUpperBound(1) + 1; j++)
                    {
                        if (j != 0)
                        {
                            foreach (var it1 in mysymbols1)
                                foreach (var it2 in mysymbols2)
                                {
                                    MySymbol = it1 + it2;
                                    if (MySymbol == MyGrammar[i, j] && MySymbol != "" && (endstr == null || endstr == "_"))
                                        endstr = MyGrammar[i, 0];
                                    else if (MySymbol == MyGrammar[i, j] && MySymbol != "" && endstr != null)
                                        endstr += $",{MyGrammar[i, 0]}";

                                }
                        }
                    }
                }
            }
            if (endstr == null)
                endstr = "_";
            return endstr;
        }

        public static void PrintGrammar(string[,] MyGrammar)
        {
            Console.WriteLine("Grammar");
            for (int i = 0; i < MyGrammar.GetUpperBound(0) + 1; i++)
            {
                for (int j = 0; j < MyGrammar.GetUpperBound(1) + 1; j++)
                {
                    Console.Write(MyGrammar[i, j] + " ");
                    if (j == 0)
                        Console.Write("-> ");
                }
                Console.WriteLine();
            }
        }

        public static void PrintTable(string[][] s)
        {
            for (int i = 0; i < s.Length; i++)
            {
                for (int j = 0; j < s[i].Length; j++)
                {
                    Console.Write($"{s[i][j]} \t");
                }
                Console.WriteLine();
            }
        }
    }
}
