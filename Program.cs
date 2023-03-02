using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathematicalModeling.TransportTasks;

namespace MathematicalModeling
{
    internal class Program
    {
        static void Main(string[] args)
        {
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

            MinimumElement minimumElement = new MinimumElement(3, 4);
            do
            {
                minimumElement.DoItemInVector();
            } while (!minimumElement.TestVector());
            minimumElement.DoItemMatrix();
            Console.WriteLine("Исходная матрица");
            minimumElement.ShowMatrix(minimumElement.InputMatrix);
            minimumElement.TaskSolution();
            Console.WriteLine("Матрица с ценой: ");
            minimumElement.ShowMatrix(minimumElement.ExitMatrix);
            minimumElement.CountCost();
            minimumElement.ShowCost();



            Console.ReadKey();
        }
    }
}
