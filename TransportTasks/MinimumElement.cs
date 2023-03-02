using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathematicalModeling.TransportTasks
{
    internal class MinimumElement : TransportTask
    {
        public MinimumElement(int countRowMatrix, int cointColumnMatrix) : base(countRowMatrix, cointColumnMatrix)
        {
        }

        public void TaskSolution()
        {
            int row, column;
            while (nVector.Sum()!=0 && mVector.Sum() != 0)
            {
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
                ////inputMatrix[row, column] = 0;
                //Console.WriteLine("Исходная матрица");
                //ShowMatrix(inputMatrix);
                //Console.WriteLine("Матрица с ценой: ");
                //ShowMatrix(exitMatrix);
            }
        }

        int FindMaximumInMatrix(int[,] matrix )
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

        public void FindMinimumInInputMatrix(out int row, out int column)
        {
            row = 0; column = 0;
            int minimum = FindMaximumInMatrix(inputMatrix);
            for (int i = 0; i < inputMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < inputMatrix.GetLength(1); j++)
                {
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
