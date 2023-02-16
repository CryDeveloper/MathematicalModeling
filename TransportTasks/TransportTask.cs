using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathematicalModeling.TransportTasks
{
    internal class TransportTask
    {
        int countRowMatrix, countColumnMatrix; //кол-во строк и столбцов в матрице
        int[] mVector, nVector; //для значений M и N векторов
        int[,] inputMatrix, exitMatrix; //для значений матрицы
        int cost = 0;
        Random randomCount = new Random();

        public TransportTask(int countRowMatrix, int cointColumnMatrix)
        {
            this.countRowMatrix = countRowMatrix;
            this.countColumnMatrix = cointColumnMatrix;
            this.mVector = new int[this.countRowMatrix];
            this.nVector = new int[this.countColumnMatrix];
            this.inputMatrix = new int[this.countRowMatrix, this.countColumnMatrix];
            this.exitMatrix = new int[this.countRowMatrix, this.countColumnMatrix];
        }

        public void DoItemInVector()
        {
            Console.WriteLine("Введите значения М вектора");
            for (int i = 0; i < mVector.Length; i++)
            {
                Console.Write($"{i}: ");
                mVector[i] = Convert.ToInt32(Console.ReadLine());
            }
            Console.WriteLine("Введите значения N вектора");
            for (int i = 0; i < nVector.Length; i++)
            {
                Console.Write($"{i}: ");
                nVector[i] = Convert.ToInt32(Console.ReadLine());
            }
        }

        public bool TestVector()
        {
            int sumInM = 0, sumInN = 0;
            for (int i = 0; i < mVector.Length; i++)
            {
                sumInM += mVector[i];
            }
            for (int i = 0; i < nVector.Length; i++)
            {
                sumInN += nVector[i];
            }
            return (sumInM == sumInN);
        }

        public void DoItemMatrix() //для генерации
        {
            for (int i = 0; i < inputMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < inputMatrix.GetLength(1); j++)
                {
                    inputMatrix[i, j] = randomCount.Next(1, 10);
                }
            }
        }

        public void ShowInputMatrix() //для вывода
        {
            Console.WriteLine("Ваша матрица");
            for (int i = 0; i < inputMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < inputMatrix.GetLength(1); j++)
                {
                    Console.Write($"{inputMatrix[i, j]} ");
                }
                Console.WriteLine();
            }
        }

        public void ShowExitMatrix() //для вывода
        {
            Console.WriteLine("Ваша матрица с ценой: ");
            for (int i = 0; i < exitMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < exitMatrix.GetLength(1); j++)
                {
                    Console.Write($"{exitMatrix[i, j]} ");
                }
                Console.WriteLine();
            }
        }

        public void TaskSolution()
        {
            for (int i = 0; i < exitMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < exitMatrix.GetLength(1); j++)
                {
                    if (nVector[j] > mVector[i] && mVector[i] != 0)
                    {
                        exitMatrix[i,j] = mVector[i];
                        nVector[j] -= mVector[i];
                        mVector[i] = 0;
                        break;
                    }
                    else if (nVector[j] < mVector[i] && nVector[j] != 0)
                    {
                        exitMatrix[i, j] = nVector[i];
                        mVector[j] -= nVector[i];
                        nVector[i] = 0;
                    }
                    else if (nVector[j] == mVector[i])
                    {
                        exitMatrix[i, j] = nVector[i];
                        nVector[i] = 0;
                        mVector[i] = 0;
                    }
                }
            }
        }

        public void CountCost()
        {
            for (int i = 0; i < exitMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < exitMatrix.GetLength(1); j++)
                {
                    cost += exitMatrix[i, j] * inputMatrix[i, j];
                }
            }
        }

        public void ShowCost()
        {
            Console.WriteLine("Стоимость перевозки = {0}", cost);
        }
    }
}
