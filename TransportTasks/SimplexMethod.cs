using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathematicalModeling.TransportTasks
{
    internal class SimplexMethod
    {
        int[,] inputMatrix = { { 4, 1, 1, 0, 8 }, { 1, -1, 0, -1, -3 }, { 3, 4, 0, 0, 0 } };
        int countRow, countColumn;
        int[] scanf(string stroke, int lenght)
        {
            string[] listCount = stroke.Split(' ');
            int[] array = new int[lenght];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = Convert.ToInt32(listCount[i]);
            }
            return array;
        }

        public SimplexMethod(int row, int column)
        {
            countRow = row;
            countColumn = column;
            //GenerateMatrix();
            DoTask();
        }
        void GenerateMatrix()
        {
            inputMatrix = new int[countRow, countColumn];
            for (int i = 0; i < inputMatrix.GetLength(0); i++)
            {
                string inputString = Console.ReadLine();
                int[] stroke = scanf(inputString, countColumn);
                for (int j = 0; j < inputMatrix.GetLength(1); j++)
                {
                    inputMatrix[i, j] = stroke[j];
                }
            }
        }
        void DoTask()
        {
            int maxElement = 0; //по житому
            for (int i = 0; i < inputMatrix.GetLength(1); i++)
            {
                if (inputMatrix[countRow-1, i] > inputMatrix[countRow-1, maxElement])
                {
                    maxElement = i;
                }
            }

            int minElement = 0;
            for (int i = 0; i < inputMatrix.GetLength(0)-1; i++)
            {
                int count = inputMatrix[i, countColumn - 1] / inputMatrix[i, maxElement];
                if (count < (inputMatrix[minElement, countColumn - 1] / inputMatrix[minElement, maxElement]) && count > 0)
                {
                    minElement = i;
                }
            }

            for (int j = 0; j < inputMatrix.GetLength(1); j++)
            {
                inputMatrix[minElement, j] /= inputMatrix[minElement, maxElement];
            }

        }
    }
}
