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
            //CriticalWay task = new CriticalWay(5);
            //Console.WriteLine("Исходная таблица: ");
            //CommonClass<int>.ShowTable(task.Table);
            //task.FindWays();
            MultustepProcces task = new MultustepProcces();

            Console.ReadKey();
        }
    }
}
