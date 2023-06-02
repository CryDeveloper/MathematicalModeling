using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathematicalModeling.Practice_UP_
{
    internal class montekarloS
    {
        public montekarloS()
        {
            //7, 28.5, 48, 19.5-20, 17.5-18, 1-1.5 
            //zad0();
            zad1();
            zad2();
            zad3();
            zad4();
            zad5();
            zad6();
        }
        public void zad0()
        {
            Random rand = new Random();
            double x, y, s, a = 5, b = 8.5;
            int k = 0, n = 10000000;
            for (int i = 0; i < n; i++)
            {
                x = rand.NextDouble() * (b);
                y = rand.NextDouble() * (a);
                if ((x / 3) < y && (x * (10 - x) / 5) > y)
                {
                    k++;
                }
            }
            s = a * b * (double)k / (double)n;
            Console.WriteLine("N0. Площадь фигуры = " + s);
        }
        public void zad1() //7
        {
            Random rand = new Random();
            double x, y, s, a = 1, b = 20;
            int k = 0, n = 10000000;
            for (int i = 0; i < n; i++)
            {
                x = rand.NextDouble() * (b) - 5;
                y = rand.NextDouble() * (a) - 0;
                //Console.WriteLine($"{x} {y}");
                if (y > 0 && Math.Sin(x) > y)
                {
                    k++;
                }
            }
            s = a * b * (double)k / (double)n;
            Console.WriteLine("N1. Площадь фигуры = " + s);
        }
        public void zad2() 
        {
            Random rand = new Random();
            double x, y, s, a = 8, b = 7;
            int k = 0, n = 10000000;
            for (int i = 0; i < n; i++)
            {
                x = rand.NextDouble() * (b) - 0;
                y = rand.NextDouble() * (a) - 0;
                //Console.WriteLine($"{x} {y}");
                if ((x / 2) < y && (x * (8 - x) / 2) > y)
                {
                    k++;
                }
            }
            s = a * b * (double)k / (double)n;
            Console.WriteLine("N2. Площадь фигуры = " + s);
        }
        public void zad3() 
        {
            Random rand = new Random();
            double x, y, s, a = 6, b = 12;
            int k = 0, n = 10000000;
            for (int i = 0; i < n; i++)
            {
                x = rand.NextDouble() * (b) - 0;
                y = rand.NextDouble() * (a) - 0;
                //Console.WriteLine($"{x} {y}");
                if (Math.Pow(x - 6,2)/ 6 < y && 6 > y)
                {
                    k++;
                }
            }
            s = a * b * (double)k / (double)n;
            Console.WriteLine("N3. Площадь фигуры = " + s);
        }
        public void zad4()
        {
            Random rand = new Random();
            double x, y, s, a = 4, b = 10.5;
            int k = 0, n = 10000000;
            for (int i = 0; i < n; i++)
            {
                x = rand.NextDouble() * (b) - 0;
                y = rand.NextDouble() * (a) - 0;
                //Console.WriteLine($"{x} {y}");
                if ((x / 5) < y && (x * (12 - x) / 9) > y)
                {
                    k++;
                }
            }
            s = a * b * (double)k / (double)n;
            Console.WriteLine("N4. Площадь фигуры = " + s);
        }
        public void zad5()
        {
            Random rand = new Random();
            double x, y, s, a = 4, b = 8;
            int k = 0, n = 10000000;
            for (int i = 0; i < n; i++)
            {
                x = rand.NextDouble() * (b) - 0;
                y = rand.NextDouble() * (a) - 0;
                //Console.WriteLine($"{x} {y}");
                if ((8 - x)/ 8 < y && (x * (8 - x) / 4) > y)
                {
                    k++;
                }
            }
            s = a * b * (double)k / (double)n;
            Console.WriteLine("N5. Площадь фигуры = " + s);
        }
        public void zad6()
        {
            Random rand = new Random();
            double x, y, s, a = 2, b = 3;
            int k = 0, n = 10000000;
            for (int i = 0; i < n; i++)
            {
                x = rand.NextDouble() * (b);
                y = rand.NextDouble() * (a);
                //Console.WriteLine($"{x} {y}");
                if (Math.Sin(x) > y && Math.Pow(x - 2, 2) / 2 < y)
                {
                    k++;
                }
            }
            s = a * b * (double)k / (double)n;
            Console.WriteLine("N6. Площадь фигуры = " + s);
        }

    }
}
