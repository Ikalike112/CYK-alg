//00:00:05.00445 быстрее предыдущего на 2 сек
using System;
using System.IO;
using System.Collections.Generic;
namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<List<string>> MyGrammar = new List<List<string>>();
            ReadFromFileGrammar(MyGrammar);
            PrintGrammar(MyGrammar);
            Console.WriteLine("Введите строку алгоритма");
            string str = Console.ReadLine(); //входная строка
            string[][] s = new string[str.Length][]; // делаю ступенчатую матрицу
            CreateMatrix(str, s);
            TheCYKAlgorythm(ref s, str, MyGrammar);
            PrintTable(s);
            Console.ReadLine();
        }

        private static void CreateMatrix(string str, string[][] s)
        {
            int k = 0;
            for (int i = str.Length; i > 0; i--)
            {
                s[k] = new string[i];
                for (int j = 0; j < s[k].Length; j++)
                {
                    s[k][j] = "_";
                }
                k++;
            }
        }

        private static void ReadFromFileGrammar(List<List<string>> MyGrammar)
        {
            using (StreamReader sr = new StreamReader("Grammar.txt"))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] tem = line.Split(' ', '-', '>', '|');
                    List<string> temp = new List<string>();
                    foreach (var it in tem)
                        if (it != "")
                            temp.Add(it);
                    MyGrammar.Add(temp);
                }
            }
        }

        public static void TheCYKAlgorythm(ref string[][] s, string str, List<List<string>> MyGrammar)
        {
            int x1, y1, x2, y2;//переменные для выборки элементов, которые будут передоваться входными параметрами в замену на нетерминал
            for (int j = 0; j < s[0].Length; j++)
            {
                s[0][j] = CheckSymbol(str[j].ToString(), "", s[0][j], MyGrammar);
            }//заполнение первой строки ступенчатой матрицы
            for (int i = 1; i < s.Length; i++)
            {
                x1 = 0;
                x2 = i - 1;
                for (int j = 0; j < s[i].Length; j++)
                {
                    y1 = j;
                    y2 = j + 1;
                    if (x2 == -1)
                    {
                        x1 = 0;
                        x2 = i - 1;
                    }
                    while (x1 != i)
                    {
                        s[i][j] = CheckSymbol(s[x1][y1], s[x2][y2], s[i][j], MyGrammar);
                        x1++;
                        x2--;
                        y2++;
                    }
               }
            }
        }
        public static string CheckSymbol(string MySymbol1, string MySymbol2, string endstr, List<List<string>> MyGrammar)
        {
            string MySymbol;
            string[] mysymbols1 = MySymbol1.Split(','); //разбиваю строку, чтобы можно было считать например b,e и b,e как bb,be,eb,ee
            string[] mysymbols2 = MySymbol2.Split(',');
            foreach (var it1 in mysymbols1) // иду по символам строки
                foreach (var it2 in mysymbols2)
                {
                    MySymbol = it1 + it2; //сложение двух символов для проверки соответствия c грамматикой
                    for (int i = 0; i < MyGrammar.Count; i++)
                    {
                        for (int j = 1; j < MyGrammar[i].Count; j++)
                        {
                                if (MySymbol == MyGrammar[i][j] && endstr == "_")
                                    endstr = MyGrammar[i][0];//если соответствие найдено 1 раз
                                else if (MySymbol == MyGrammar[i][j] && endstr != "_")
                                    endstr += $",{MyGrammar[i][0]}"; //если соответствие найдено более одного раза
                        }

                    }
                }
            return endstr;
        }

        public static void PrintGrammar(List<List<string>> MyGrammar)
        {
            Console.WriteLine("Grammar");
            for (int i = 0; i < MyGrammar.Count; i++)
            {
                for (int j = 0; j < MyGrammar[i].Count; j++)
                {
                    Console.Write(MyGrammar[i][j] + " ");
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