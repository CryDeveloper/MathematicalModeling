using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Console.WriteLine("Введите размер квадратной матрицы: ");
//int size = Convert.ToInt32(Console.ReadLine());
/*
NorthwestCorner northwestCorner = new NorthwestCorner(3,3);
do
{
    northwestCorner.DoItemInVector();
} while (!northwestCorner.TestVector());
northwestCorner.DoItemMatrix();
northwestCorner.ShowInputMatrix();
northwestCorner.TaskSolution();
northwestCorner.ShowExitMatrix();
northwestCorner.CountCost();
northwestCorner.ShowCost();
*/

namespace MathematicalModeling.TransportTasks
{
    internal class NorthwestCorner:TransportTask
    {
        public NorthwestCorner(int countRowMatrix, int cointColumnMatrix) : base(countRowMatrix, cointColumnMatrix)
        {
        }

        public void TaskSolution()
        {
            for (int i = 0; i < exitMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < exitMatrix.GetLength(1); j++)
                {
                    if (nVector[j] > mVector[i] && mVector[i] != 0)
                    {
                        exitMatrix[i, j] = mVector[i];
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
    }
}
