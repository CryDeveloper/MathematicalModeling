using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathematicalModeling.GrafMethod
{
    internal class MultustepProcces
    {
        int[,] inputTable = { { 0, 3,15,8,0,0,0},
                               { 0,0,0,0,1,4,0},
                               { 0,0,0,0,7,2,0},
                               { 0,0,0,0,11,5,0},
                               { 0,0,0,0,0,0,6},
                               { 0,0,0,0,0,0,9}};
        int[,] workTable;

        public MultustepProcces()
        {
            workTable = new int[inputTable.GetLength(0), inputTable.GetLength(1)];
            Array.Copy(inputTable, workTable, inputTable.Length);
        }
    }
}
