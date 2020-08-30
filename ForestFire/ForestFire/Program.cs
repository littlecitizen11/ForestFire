using System;

namespace ForestFire
{
    class Program
    {
        static void Main(string[] args)
        {
            TreeForest treeForest = new TreeForest(20, 20);
            treeForest.ConnectTrees(70);
            treeForest.Forest[10, 10].Update();
            treeForest.PrintByInterval(1000);
            
            
            

        }
    }
}
