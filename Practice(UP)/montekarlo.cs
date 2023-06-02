using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathematicalModeling.Practice_UP_
{
    internal class montekarlo
    {
        public montekarlo()
        {
            Random rand = new Random();
            double x, y, pi;
            int k = 0, n = 10000000;
            for (int i = 0; i < n; i++)
            {
                x = rand.NextDouble() * (2 - 0) + 0;
                y = rand.NextDouble() * (2 - 0) + 0;
                if (Math.Pow((x - 1), 2) + Math.Pow((y - 1), 2) <= 1)
                {
                    k++;
                }
            }
            pi = 4.0 * (double)k / (double)n;
            Console.WriteLine("Вычисленное значение ПИ = " + pi);
            Console.WriteLine("Фактическое значение ПИ = " + Math.PI);
        }
    }
}
