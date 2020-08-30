using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;

namespace ForestFire
{
    public class TreeForest
    {
        public Tree[,] Forest { get; set; }
        public TreeForest(int width, int length)
        {
            Forest = new Tree[20, 20];
            for (int i = 0; i < Forest.GetLength(0); i++)
            {
                for (int j = 0; j < Forest.GetLength(1); j++)
                {
                    Forest[i, j] = new Tree();
                }
            }
        }
        
        public void PrintForest()
        {
            for (int i = 0; i < Forest.GetLength(0); i++)
            {
                for (int j = 0; j < Forest.GetLength(1); j++)
                {
                    
                    switch (Forest[i,j].Status)
                    {
                        case TreeStatus.Live:
                            { Console.Write("o "); break; }
                        case TreeStatus.Burned:
                            { Console.Write("x "); break; }
                        case TreeStatus.Dead:
                            { Console.Write(". "); break; }
                        default:
                            break;
                    }
                    
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine();

        }
        public void SetOnFire()
        {
            List<ITree> allOnFireTress = new List<ITree>();

            for (int i = 0; i < Forest.GetLength(0); i++)
            {
                for (int j = 0; j < Forest.GetLength(1); j++)
                {
                    if (Forest[i, j].Status == TreeStatus.Burned)
                    {
                        allOnFireTress.Add(Forest[i, j]);
                    }
                }
            }

            allOnFireTress.ForEach(t => t.UpdateTree());
            allOnFireTress.ForEach(t => t.DownHealth());

        }

        public void PrintByInterval(int interval)
        {
            while (true)
            {
                PrintForest();
                SetOnFire();
                Thread.Sleep(interval);
            }
        }
        public void ConnectTrees(int? success = null)
        {
            Random _rand = new Random();

            for (int i = 0; i < Forest.GetLength(0); i++)
            {
                for (int j = 0; j < Forest.GetLength(1); j++)
                {
                    int number = _rand.Next(1, 101);

                    if (number <= (success))
                    {
                        if ((i + 1) <= Forest.GetLength(0) - 1)
                        {
                            Forest[i + 1, j].Subscribe(Forest[i, j]);
                        }
                        if ((i - 1) >= 0)
                        {
                            Forest[i - 1, j].Subscribe(Forest[i, j]);
                        }

                        if ((j + 1) <= Forest.GetLength(1) - 1)
                        {
                            Forest[i, j + 1].Subscribe(Forest[i, j]);
                        }
                        if ((j - 1) >= 0)
                        {
                            Forest[i, j - 1].Subscribe(Forest[i, j]);
                        }
                    }
                }
            }
        }

    }
}
