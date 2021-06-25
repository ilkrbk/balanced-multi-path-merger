using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PA_LR1._2
{
    class Filee
    {
        private int kolvoelem = 0;
        public void PushRandomNum(string pathFile)
        {
            using (StreamWriter sw = new StreamWriter(pathFile, false, System.Text.Encoding.Default))
            {
                Random random = new Random();
                while (new System.IO.FileInfo(pathFile).Length < 1000000000 )
                {
                    sw.WriteLine(random.Next(0, 1000)); 
                    Console.WriteLine(new System.IO.FileInfo(pathFile).Length);
                }
            }
            Console.WriteLine("Запись выполнена");
        }
        public void ReadAndSortToFile(string pathFile)
        {
            int numFile = 1;
            using (StreamReader sr = new StreamReader(pathFile, System.Text.Encoding.Default))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    using (StreamWriter sw = new StreamWriter($"b/b{numFile}.txt", true, System.Text.Encoding.Default))
                    {
                        sw.WriteLine(line);
                    }
                    numFile++;
                    kolvoelem++;
                    if (numFile == 4)
                    {
                        numFile = 1;
                    }
                }
            }
        }
        private string Sort(List<string> seriaString)
        {
            List<int> seriaInt = new List<int>();
            foreach (var item in seriaString)
            {
                string[] step1 = item.Split(' ');
                if (step1.Length > 1)
                    for (int j = 0; j < step1.Length - 1; j++)
                            seriaInt.Add(Convert.ToInt32(step1[j]));
                else
                    for (int j = 0; j < step1.Length; j++)
                        seriaInt.Add(Convert.ToInt32(step1[j]));
            }
            seriaInt.Sort();
            string seriaLine = "";
            foreach (var item in seriaInt)
            {
                seriaLine += Convert.ToString(item);
                seriaLine += " ";
            }
            return seriaLine;
        }
        private void Step(string a, string b, ref int countString, ref List<string> seriaString, ref int numFileC, ref int kolvoElem1, int kolvoElem, int check)
        {
            if (check == 0)
            {
                for (int i = 1; i <= 3; i++)
                    if (new FileInfo($"{a}/{a}{numFileC}.txt").Exists)
                        seriaString.Add(File.ReadLines($"{a}/{a}{i}.txt").Skip(countString).Take(1).First());
            }
            else
                for (int i = 1; i <= kolvoElem%3; i++)
                    if (new FileInfo($"{a}/{a}{numFileC}.txt").Exists)
                        seriaString.Add(File.ReadLines($"{a}/{a}{i}.txt").Skip(countString).Take(1).First());
            countString++;
            string seriaLine = Sort(seriaString);
            using (StreamWriter sw = new StreamWriter($"{b}/{b}{numFileC}.txt", true, System.Text.Encoding.Default))
                sw.WriteLine(seriaLine);
            kolvoElem1++;
            numFileC++;
            if (numFileC == 4)
                numFileC = 1;
            seriaString.Clear();
        }
        public void ReadAndSortToFile2(string a, string b)
        {
            int numFileC = 1;
            int kolvoElem1 = 0;
            int countString = 0;
            List<string> seriaString = new List<string>();
            for (int j = 0; j < kolvoelem/3; j++)
                Step(a, b, ref countString, ref seriaString, ref numFileC, ref kolvoElem1, kolvoelem, 0);
            if (kolvoelem%3 != 0)
                Step(a, b, ref countString, ref seriaString, ref numFileC, ref kolvoElem1, kolvoelem, 1);
            DirectoryInfo dirInfo = new DirectoryInfo($"{a}/");
            foreach (FileInfo file in dirInfo.GetFiles())
                file.Delete();
            kolvoelem = kolvoElem1;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Filee file = new Filee();
            //file.PushRandomNum("index.txt");
            file.ReadAndSortToFile("index.txt");
            int num = 1;
            while (Directory.GetFiles("b").Length != 1)
            {
                if (num % 2 != 0) 
                    file.ReadAndSortToFile2("b", "c");
                else 
                    file.ReadAndSortToFile2("c", "b");
                num++;
            }
            
        }
    }
}