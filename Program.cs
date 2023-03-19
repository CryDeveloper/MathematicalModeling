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
        //{ 6 6 1 0 0 36 },
        //{ 4 2 0 1 0 20 },
        //{ 4 8 0 0 1 40 },
        //{ 12 15 0 0 0 0 }
//6 6 1 0 0 36
//4 2 0 1 0 20
//4 8 0 0 1 40
//12 15 0 0 0 0
static void Main(string[] args)
        {
            
            int row = 4;
            int collumn = 6;
            Console.WriteLine("Введите первую матрицу симплекс-метода");
            SimplexMethod zad = new SimplexMethod(row, collumn);
            zad.DoTask();

            Console.ReadKey();
        }
    }
}
