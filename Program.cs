using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathematicalModeling.TransportTasks;
using MathematicalModeling.GrafMethod;
using MathematicalModeling.Practice_UP_;
using System.IO;

namespace MathematicalModeling
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Prufer codeTask = new Prufer("ResourceFile/inputCode.txt");
            codeTask.DoCodeTask();
            codeTask.DoCodePruferOutputFile("ResourceFile/resultCode.txt");

            Prufer decodeTask = new Prufer("ResourceFile/resultCode.txt");
            decodeTask.DoDecodeTask();
            decodeTask.DoWoodOutputFile("ResourceFile/resultDecode.txt");

            Console.WriteLine("Ready.");
            Console.ReadKey();
        }
    }
}