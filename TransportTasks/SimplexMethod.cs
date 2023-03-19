using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathematicalModeling.TransportTasks
{
    internal class SimplexMethod
    {
        /*{ { 4, 1, 1, 0, 8 }, { 1, -1, 0, -1, -3 }, { 3, 4, 0, 0, 0 } }*/
        //{ 
        //                        { 10,3,-1,0,0,0,30 },
        //                        { -1,1,01,1,0,0,5 },
        //                        { 0,1,0,0,-1,0,2 },
        //                        { 1,1,0,0,0,1,10 },
        //                        { 1,3,0,0,0,0,0 }};
        double[,] inputMatrix;
        int countRow, countColumn, permissiveColumn, permissiveRow;
        double valueFunction;
        double[] scanf(string stroke, int lenght) //чтение строки в массив
        {
            string[] listCount = stroke.Split(' ');
            double[] array = new double[lenght];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = Convert.ToDouble(listCount[i]);
            }
            return array;
        }

        public SimplexMethod(int row, int column)
        {
            countRow = row;
            countColumn = column;
            GenerateMatrix();
        }
        void GenerateMatrix() //для ввода матрицы пользователем
        {
            inputMatrix = new double[countRow, countColumn];
            for (int i = 0; i < inputMatrix.GetLength(0); i++)
            {
                string inputString = Console.ReadLine();
                double[] stroke = scanf(inputString, countColumn);
                for (int j = 0; j < inputMatrix.GetLength(1); j++)
                {
                    inputMatrix[i, j] = stroke[j];
                }
            }
        }

        bool ItOptimalSolution ()
        {
            bool itOptimalSolution = true;
            for (int j = 0; j < inputMatrix.GetLength(1); j++)
            {
                if (inputMatrix[countRow-1, j] > 0)
                {
                    itOptimalSolution = false;
                    break;
                }
            }
            return itOptimalSolution;
        }
        void FindPermissiveElement()
        {
            permissiveColumn = 0;
            /*Нахождение в каком столбце будет разрешающий элемент*/
            for (int i = 0; i < inputMatrix.GetLength(1) - 1; i++)
            {
                if (inputMatrix[countRow - 1, i] > inputMatrix[countRow - 1, permissiveColumn])
                {
                    permissiveColumn = i;
                }
            }
            permissiveRow = 0;
            /*Нахождение в какой строке разрешающий элемент*/
            for (int i = 0; i < inputMatrix.GetLength(0) - 1; i++)
            {
                double count = inputMatrix[i, countColumn - 1] / inputMatrix[i, permissiveColumn];
                if (count < (inputMatrix[permissiveRow, countColumn - 1] / inputMatrix[permissiveRow, permissiveColumn]) && count > 0)
                {
                    permissiveRow = i;
                }
            }
        }

        void ChangeMatrixByGaus ()
        {
            FindPermissiveElement();
            /*Приведение строки с разрешающим элементом к значению = 1*/
            double permissiveElement = inputMatrix[permissiveRow, permissiveColumn];
            for (int j = 0; j < inputMatrix.GetLength(1); j++)
            {
                inputMatrix[permissiveRow, j] /= permissiveElement;
            }

            /*Преобразование матрицы*/
            for (int i = 0; i < inputMatrix.GetLength(0); i++)
            {
                if (i == permissiveRow) continue;
                double divider;
                if (inputMatrix[i, permissiveColumn] < 0)
                {
                    divider = inputMatrix[i, permissiveColumn];
                }
                else
                {
                    divider = inputMatrix[i, permissiveColumn] * (-1);
                }
                for (int j = 0; j < inputMatrix.GetLength(1); j++)
                {
                    double a = inputMatrix[permissiveRow, j];
                    inputMatrix[i, j] = inputMatrix[permissiveRow, j] * divider + inputMatrix[i, j];
                }
            }
        }
        public void DoTask()
        {
            if(!ItOptimalSolution())
            {
                do
                {
                    ChangeMatrixByGaus();
                } while (!ItOptimalSolution());
            }
            valueFunction = inputMatrix[countRow - 1, countColumn - 1];
            Console.WriteLine("Значение целевой функции = {0}", valueFunction*(-1));
            
            
        }
    }
}
