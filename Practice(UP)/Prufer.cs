using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathematicalModeling.Practice_UP_
{
    //Prufer codeTask = new Prufer("ResourceFile/inputCode.txt");
    //codeTask.DoCodeTask();
    //codeTask.DoCodePruferOutputFile("ResourceFile/resultCode.txt");

    //Prufer decodeTask = new Prufer("ResourceFile/resultCode.txt");
    //decodeTask.DoDecodeTask();
    //decodeTask.DoWoodOutputFile("ResourceFile/resultDecode.txt");

    internal class Prufer
    {
        string pathInputFile;
        List<int> codePrufer = new List<int>();
        List<List<int>> wood = new List<List<int>>();
        List<int> exitDot = new List<int>();
        List<int> entryDot = new List<int>();

        /// <summary>
        /// Инициализация объекта.
        /// </summary>
        /// <param name="pathInputFile"></param>
        public Prufer(string pathInputFile)
        {
            this.pathInputFile = pathInputFile;
        }

        /// <summary>
        /// Получение кода прюфера
        /// </summary>
        public void DoCodeTask()
        {
            string[] input = File.ReadAllLines(pathInputFile);
            foreach (string line in input)
            {
                List<string> chars = line.Trim(' ').Split(' ').ToList();
                List<int> ints = chars.ConvertAll(int.Parse);
                wood.Add(ints);
            }
            do
            {
                int minLeaf = wood[1].Where(x => !(wood[0].Contains(x))).ToList().Min(); //нахождение минимального крайнего листа
                int numMin = wood[1].IndexOf(minLeaf);
                codePrufer.Add(wood[0][numMin]);
                wood[0].Remove(wood[0][numMin]);
                wood[1].Remove(minLeaf);
            } while (wood[0].Count > 1);
        }

        /// <summary>
        /// Получение дерева
        /// </summary>
        public void DoDecodeTask()
        {
            string[] input = File.ReadAllLines(pathInputFile);
            List<int> codePrufer = input[0].Trim(' ').Split(' ').ToList().ConvertAll(int.Parse);
            List<int> treeTops = new List<int>(codePrufer.Count + 2);
            
            for (int i = 1; i < codePrufer.Count + 3; i++)
            {
                treeTops.Add(i);
            }

            do
            {
                int minLeaf = treeTops.Except(codePrufer).Min();
                entryDot.Add(minLeaf);
                
                //int parentMinLeaf = codePrufer[0];
                exitDot.Add(codePrufer[0]);

                treeTops.Remove(minLeaf);
                codePrufer.Remove(codePrufer[0]);
            } while (codePrufer.Count > 0);
            exitDot.Add(treeTops[0]);
            entryDot.Add(treeTops[1]);
            wood.Add(exitDot);
            wood.Add(entryDot);
        }

        /// <summary>
        /// Вывод в файл кода прюфера
        /// </summary>
        /// <param name="pathOutputFile">Путь сохранения файла</param>
        public void DoCodePruferOutputFile(string pathOutputFile)
        {
            using (StreamWriter w = new StreamWriter(pathOutputFile))
            {
                codePrufer.ForEach(x => { w.Write(x + " "); });
            }
        }

        /// <summary>
        /// Вывод дерева.
        /// </summary>
        /// <param name="pathOutputFile">Путь сохранения файла</param>
        public void DoWoodOutputFile(string pathOutputFile)
        {
            using (StreamWriter w = new StreamWriter($"{pathOutputFile}")) 
            {
                wood[0].ForEach(x => w.Write(x + " "));
                w.WriteLine();
                wood[1].ForEach(x => w.Write(x + " "));
            }
        }
    }
}
