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
            TransportTask transportTask = new TransportTask(3, 3);
            do
            {
                transportTask.DoItemInVector();
            } while (!transportTask.TestVector());
            transportTask.DoItemMatrix();
            transportTask.ShowInputMatrix();
            transportTask.TaskSolution();
            transportTask.ShowExitMatrix();
            transportTask.CountCost();
            transportTask.ShowCost();
            Console.ReadKey();
        }
    }
}
