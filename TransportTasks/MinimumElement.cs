using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//MinimumElement minimumElement = new MinimumElement(3, 3);
//do
//{
//    minimumElement.DoItemInVector();
//} while (!minimumElement.TestVector());
//minimumElement.DoItemMatrix(1,10);
//Console.WriteLine("Исходная матрица");
//minimumElement.ShowMatrix(minimumElement.InputMatrix);
//minimumElement.TaskSolution();
//Console.WriteLine("Матрица с ценой: ");
//minimumElement.ShowMatrix(minimumElement.ExitMatrix);
//minimumElement.CountCost();
//minimumElement.ShowCost();

namespace MathematicalModeling.TransportTasks
{
    internal class MinimumElement : TransportTask
    {
        public MinimumElement(int countRowMatrix, int cointColumnMatrix) : base(countRowMatrix, cointColumnMatrix)
        {
        }

        /*Функция для создания ценовой матрицы*/
        public void TaskSolution()
        {
            int row, column;
            /*Условие пробежки по исходной матрице
             *Задача решается, пока значения в обоих векторых не приравниваются к 0*/
            while (nVector.Sum()!=0 && mVector.Sum() != 0)
            {
                //сперва ищем минимальное значение в исходнике
                FindMinimumInInputMatrix(out row, out column);
                if (nVector[column] > mVector[row] && mVector[row] != 0)
                {
                    exitMatrix[row, column] = mVector[row];
                    nVector[column] -= mVector[row];
                    mVector[row] = 0;
                }
                else if (nVector[column] < mVector[row] && nVector[column] != 0)
                {
                    exitMatrix[row, column] = nVector[column];
                    mVector[row] -= nVector[column];
                    nVector[column] = 0;
                }
                else if (nVector[column] == mVector[row])
                {
                    exitMatrix[row, column] = nVector[column];
                    nVector[column] = 0;
                    mVector[row] = 0;
                }
            }
        }

        int FindMaximumInMatrix(int[,] matrix ) //нахождение максимального элемента матрицы
        {
            int maximum = matrix[0,0];
            foreach (int element in matrix)
            {
                if(maximum < element)
                {
                    maximum = element;
                }
            }
            return maximum;
        }

        //нахождение минимального нужного значения из исходной матрицы
        public void FindMinimumInInputMatrix(out int row, out int column)
        {
            row = 0; column = 0; //костыль шоб не ругалось на out
            /*присваиваем для первого минимума самое большое значение в матрице 
             *нужно чтобы условие выполнялось корректно и значения, которые будут равны заранее установленному минимуму
             *проверялись также, как и остальные*/
            int minimum = FindMaximumInMatrix(inputMatrix);
            for (int i = 0; i < inputMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < inputMatrix.GetLength(1); j++)
                {
                    /*Нужный минимальный элемент должен быть:
                    1: меньше известного до этого минимума
                    2: в матрице с ценой там, где значения исходной матрицы не использвовались должен быть 0
                    3: значения векторов на этом элементе исходника должны быть > 0*/
                    if (minimum >= inputMatrix[i, j] && exitMatrix[i, j] == 0 && !(mVector[i] == 0 || nVector[j] == 0))
                    {
                        minimum = inputMatrix[i, j];
                        row = i;
                        column = j;
                    }
                }
            }
        }
    }

}
