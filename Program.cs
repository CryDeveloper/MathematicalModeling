using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathematicalModeling.TransportTasks;
using MathematicalModeling.GrafMethod;

namespace MathematicalModeling
{
    internal class Program
    {
        
static void Main(string[] args)
        {
            Taskkommivoyazhor task = new Taskkommivoyazhor(5, 5);
            task.DoItemMatrix(25);
            task.ShowMatrix();
            task.DoTask();

            Console.ReadKey();
        }
    }
}
