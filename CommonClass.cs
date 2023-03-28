using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathematicalModeling
{
    /// <summary>
    /// Класс содержащий стандартные методы для работы
    /// </summary>
    /// <typeparam name="T">Тип массива,списка,коллекции</typeparam>
    internal class CommonClass<T>
    {
        /// <summary>
        /// Вывод массивов разных типов на консоль
        /// </summary>
        /// <param name="collect">Массив</param>
        public static void ShowCollect(T[] collect)
        {
            for (int i = 0; i < collect.Length; i++)
            {
                Console.Write($"{collect[i]} ");
            }
            Console.WriteLine();
        }
        /// <summary>
        /// Вывод списков разных типов на консоль
        /// </summary>
        /// <param name="collect">Лист</param>
        public static void ShowCollect(List<T> collect)
        {
            for (int i = 0; i < collect.Count; i++)
            {
                Console.Write($"{collect[i]} ");
            }
            Console.WriteLine();
        }

        public static void ShowTable(T[,] table)
        {
            for (int i = 0; i < table.GetLength(0); i++)
            {
                for (int j = 0; j < table.GetLength(1); j++)
                {
                    Console.Write($"{table[i, j]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
