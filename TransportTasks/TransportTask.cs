using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathematicalModeling.TransportTasks
{
    /*Родительский класс для решения транспортных задач, содержащий основные методы,
     *поля, нужные для решения каждого вида решения транспортных задач*/
    internal class TransportTask
    {
        protected int countRowMatrix, countColumnMatrix; //кол-во строк и столбцов в матрице
        protected int[] mVector, nVector; //для значений M и N векторов
        protected int[,] exitMatrix, inputMatrix; //для значений исходной и ценовой матриц
        protected int cost = 0; //стоимость перевозки
        protected Random randomCount = new Random();

        /*Свойства для публичности матриц*/
        public int[,] ExitMatrix { get => exitMatrix; set => exitMatrix = value; }
        public int[,] InputMatrix { get => inputMatrix; set => inputMatrix = value; }

        public TransportTask(int countRowMatrix, int cointColumnMatrix)
        {
            this.countRowMatrix = countRowMatrix;
            this.countColumnMatrix = cointColumnMatrix;
            this.mVector = new int[this.countRowMatrix];
            this.nVector = new int[this.countColumnMatrix];
            this.inputMatrix = new int[this.countRowMatrix, this.countColumnMatrix];
            this.exitMatrix = new int[this.countRowMatrix, this.countColumnMatrix];
        }

        /*для заполнения значений вектора*/
        public void DoItemInVector()
        {
            Console.WriteLine("Введите значения М вектора");
            for (int i = 0; i < mVector.Length; i++)
            {
                Console.Write($"{i+1}: ");
                mVector[i] = Convert.ToInt32(Console.ReadLine());
            }
            Console.WriteLine("Введите значения N вектора");
            for (int i = 0; i < nVector.Length; i++)
            {
                Console.Write($"{i+1}: ");
                nVector[i] = Convert.ToInt32(Console.ReadLine());
            }
        }

        /*Проверка, чтобы сумма элементов векторов бвли равны*/
        public bool TestVector()
        {
            return (mVector.Sum() == nVector.Sum());
        }

        public void DoItemMatrix(int startRange, int stopRange) //для генерации значений исходной матрицы 
        {
            for (int i = 0; i < inputMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < inputMatrix.GetLength(1); j++)
                {
                    inputMatrix[i, j] = randomCount.Next(startRange, stopRange); //здесь задаются границы генерации
                }
            }
        }

        public void ShowMatrix(int[,] matrix) //для вывода матрицы
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write($"{matrix[i, j]} ");
                }
                Console.WriteLine();
            }
        }

        /*подсчет стоимости перевозки*/
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

        /*Вывод стоимости*/
        public void ShowCost()
        {
            Console.WriteLine("Стоимость перевозки = {0}", cost);
        }


    }
}
