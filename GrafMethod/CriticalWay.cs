using MathematicalModeling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathematicalModeling.GrafMethod
{
    internal class CriticalWay
    {
        int[,] table = {{ 0, 1, 4, 2, 0 },
                        { 0, 0, 1, 3, 2 },
                        { 0, 0, 0, 3, 3 },
                        { 0, 0, 0, 0, 3 },
                        { 0, 0, 0, 0, 0}};
        int countDot;
        Random random = new Random();
        List<List<int>> listWay = new List<List<int>>();

        public CriticalWay(int countDot)
        {
            this.countDot = countDot;
            //table = DoRandomTable();
        }

        public int[,] Table { get => table; set => table = value; }

        public int[,] DoRandomTable()
        {
            int[,] matrix = new int[countDot, countDot];
            for (int i = 0; i < matrix.GetLength(0)-1; i++)
            {
                for (int j = 1+i; j < matrix.GetLength(1); j++) 
                {
                    if (i == j) continue;
                    //if (matrix[j,i] != 0) continue; //какой должна быть исходная матрица?
                    matrix[i,j] = random.Next(0, 5);
                }
            }
            return matrix;
        }

        int CountNotNullElemetInRow(int numberRow)
        {
            int count = 0;
            for (int i = numberRow; i < table.GetLength(0); i++)
            {
                for (int j = 1; j < table.GetLength(1); j++)
                {
                    if (table[i, j] != 0)
                    {
                        count++;
                    }
                }
            }
            return count;
        }

        public void FindWays()
        {
            if (table == null)
            {
                table = DoRandomTable();
            }

            //ввести k цикл, который будет содержать начальное значение j из 0 строки
            //определить сколько путей из 0 точки 
            do
            {

                g++;
            } while (g <= CountNotNullElemetInRow(1));
            for (int k = 0; k < table.GetLength(0) - 1; k++)
            {
                List<int> way = new List<int>();
                way.Add(0);
                int g = 0;
                

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