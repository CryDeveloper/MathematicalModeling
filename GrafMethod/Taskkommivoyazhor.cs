using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathematicalModeling.GrafMethod
{

    internal class Taskkommivoyazhor
    {

        int[,] inputMatrix;
        int[] valueFunction;
        Random randomCount = new Random();

        public Taskkommivoyazhor(int countRowMatrix, int countColumnMatrix)
        {
            this.inputMatrix = new int[countRowMatrix, countColumnMatrix]; ;
        }

        int[] DoRowwMatrix(int stopRange)
        {
            int[] rowMatrix = new int[inputMatrix.GetLength(1)];
            for (int i = 0; i < inputMatrix.GetLength(1); i++)
            {
                int count = randomCount.Next(1, stopRange);
                while(rowMatrix.Contains(count))
                {
                    count = randomCount.Next(1, stopRange);
                }
                rowMatrix[i] = count;
            }
            return rowMatrix;
        } //костылек, чтобы генерировать строку и проверять совпадения с помощью conteins

        public void DoItemMatrix(int stopRange) //для генерации значений исходной матрицы 
        {
            for (int i = 0; i < inputMatrix.GetLength(0); i++)
            {
                int[] rowMatrix = DoRowwMatrix(25);
                for (int j = 0; j < inputMatrix.GetLength(1); j++)
                {
                    if (i == j) continue;
                    inputMatrix[i, j] = rowMatrix[j];
                }
            }
        }

        public void ShowMatrix() //для вывода матрицы
        {
            for (int i = 0; i < inputMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < inputMatrix.GetLength(1); j++)
                {
                    Console.Write($"{inputMatrix[i, j]} ");
                }
                Console.WriteLine();
            }
        }

        int?[] FindRoute(int numRow)
        {
            int?[] route = new int?[inputMatrix.GetLength(1)+1];
            route[0] = numRow;
            //int idMinimalTime = 0;
            for (int k = 1; k < route.Length-1; k++)
            {
                int idMinimalTime = 0;
                while (route.Contains(idMinimalTime))
                {
                    idMinimalTime++;
                }
                if (idMinimalTime == numRow)
                {
                    if (idMinimalTime < inputMatrix.GetLength(1))
                    {
                        idMinimalTime++;
                    }
                    else idMinimalTime--;
                }
                for (int j = 0; j < inputMatrix.GetLength(1); j++)
                {
                    /*если просмотренный элемент больше выбранного
                     И массив пути не содержит выбранное
                    и просмотренный элемент > 0*/
                    if ((inputMatrix[numRow, idMinimalTime] > inputMatrix[numRow, j]) && 
                        !(route.Contains(j)) && (inputMatrix[numRow, j] != 0))
                    {
                        idMinimalTime = j;
                    }
                }
                route[k] = idMinimalTime;
                numRow = idMinimalTime;
            }
            route[route.Length - 1] = route[0];
            return route;
        }

        int CountFunctionOnRoute(int numRow)
        {
            int?[] route = FindRoute(numRow);
            int value = 0;
            for (int j = 1; j < route.Length; j++)
            {
                value +=inputMatrix[(int)route[j-1], (int)route[j]];
            }
            return value;
        }

        public void DoTask()
        {
            Console.Write("Значения целевых функций: ");
            for (int i = 0; i < inputMatrix.GetLength(0); i++)
            {
                Array.Resize(ref valueFunction, i+1);
                valueFunction[i] = CountFunctionOnRoute(i);
                Console.Write($"{valueFunction[i]} ");
            }
            Console.WriteLine();
            int optimal = valueFunction.Min();
            Console.WriteLine("Оптимальное значение = {0}", optimal);
            for (int i = Array.IndexOf(valueFunction, optimal); i < valueFunction.Length; i++)
            {
                if(valueFunction[i] == optimal)
                {
                    Console.Write("Путь: ");
                    int?[] route = FindRoute(i);
                    for (int j = 0; j < route.Length; j++)
                    {
                        Console.Write($"{route[j]} ");
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
