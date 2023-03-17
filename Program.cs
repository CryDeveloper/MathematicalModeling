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
            
            int row = 5;
            int collumn = 7;
            Console.WriteLine("Введите первую матрицу симплекс-метода");
            SimplexMethod zad = new SimplexMethod(row, collumn);

            Console.ReadKey();
        }
    }
}
