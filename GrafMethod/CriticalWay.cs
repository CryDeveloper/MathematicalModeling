using MathematicalModeling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathematicalModeling.GrafMethod
{
    //{{ 0, 0, 3, 0, 0 },
    //                    { 0, 0, 1, 3, 2 },
    //                    { 0, 0, 0, 3, 3 },
    //                    { 0, 0, 0, 0, 3 },
    //                    { 0, 0, 0, 0, 0}};
internal class CriticalWay
    {
        int[,] table = {{ 0, 1, 3, 0},
                        { 0, 0, 1, 3},
                        { 0, 0, 0, 3},
                        { 0, 0, 0, 0}};
        int countDot;
        Random random = new Random();
        List<List<int>> listWay = new List<List<int>>();

        public CriticalWay(int countDot)
        {
            this.countDot = countDot;
            //table = DoRandomTable();
        }

        public int[,] Table { get => table; set => table = value; }
        /// <summary>
        /// Генерация матрицы для метода критического пути
        /// </summary>
        /// <returns>int[,]</returns>
        public int[,] DoRandomTable()
        {
            int[,] matrix = new int[countDot, countDot-1];
            for (int i = 0; i < matrix.GetLength(0)-1; i++)
            {
                for (int j = 1+i; j < matrix.GetLength(1); j++) 
                {
                    if (i == j) continue;
                    matrix[i,j] = random.Next(0, 5);
                }
            }
            return matrix;
        }

        int CountNotNullElemetInRow(int numberRow)
        {
            int count = 0;
            for (int j = 1; j < table.GetLength(1); j++)
            {
                if (table[numberRow, j] != 0)
                {
                    count++;
                }
            }
            return count;
        }
        //List<int> CountNotNullElemetInRow(int numberRow)
        //{
        //    List<int> count = new List<int>();
        //    for (int j = 1; j < table.GetLength(1); j++)
        //    {
        //        if (table[numberRow, j] != 0)
        //        {
        //            count.Add(j);
        //        }
        //    }
        //    return count;
        //}

        public void FindWays()
        {
            int countDotInRow = 1;
            for (int g = 0; g <= countDotInRow; g++)
            {
                for (int k = 1; k < countDot; k++)
                {
                    countDotInRow = CountNotNullElemetInRow(k + 1);
                    List<int> way = new List<int>();
                    way.Add(0);
                    for (int i = 0; i < table.GetLength(0) - 1; i++)
                    {
                        for (int j = 0; i < table.GetLength(1); i++)
                        {
                            if (!way.Contains(j) && table[i, j] != 0)
                            {
                                way.Add(j);
                                break;
                            }
                        }
                        
                    }
                    CommonClass<int>.ShowCollect(way);
                }
            }
        }

        public void FindWays1()
        {
            if (table == null)
            {
                table = DoRandomTable();
            }

            //ввести k цикл, который будет содержать начальное значение j из 0 строки
            //определить сколько путей из 0 точки 
            
            for (int k = 1; k < table.GetLength(0); k++)
            {
                int g = 0;
                do
                {
                    int a = CountNotNullElemetInRow(k);
                    List<int> way = new List<int>();
                    way.Add(0);
                    for (int i = 0; i < table.GetLength(0)-1; i++)
                    {
                        for (int j = k; j < table.GetLength(1); j++)
                        {
                            bool flag = true;
                            if(listWay.Count > 0)
                            {
                                foreach (List<int> item in listWay)
                                {
                                    List<int> b = item;
                                    if (j > k && j == item[j])
                                    {
                                        flag = false;
                                        break;
                                    }
                                    //for (int f = j; f < countDot; f++)
                                    //{
                                    //    if (f > k && item[f] == j)
                                    //    {
                                    //        flag = false;
                                    //    }
                                    //}
                                }
                                
                            }                            
                            if (flag && !way.Contains(j) && table[i, j] != 0 )
                            {
                                way.Add(j);
                                break;
                            }
                        }
                    }
                    listWay.Add(way);
                    CommonClass<int>.ShowCollect(way);
                    g++;
                } while (g <= CountNotNullElemetInRow(k));
            }
           
            
        }
    }
}

//int countDotInRow = 1;
//for (int g = 0; g <= countDotInRow; g++)
//{
//    for (int k = 1; k < countDot; k++)
//    {
//        countDotInRow = CountNotNullElemetInRow(k + 1);
//        List<int> way = new List<int>();
//        way.Add(0);
//        for (int i = 0; i < table.GetLength(0) - 1; i++)
//        {
//            if (!way.Contains(j) && table[i, j] != 0)
                //{
                //    way.Add(j);
                //    break;
                //}
//        }
//        CommonClass<int>.ShowCollect(way);
//    }
//}