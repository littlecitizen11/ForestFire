using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Runtime.CompilerServices;
using System.Text;

namespace ForestFire
{
    public class Tree : ITree
    {
        public int Healthness { get; set; }
        public TreeStatus Status { get; set; }
        public event Action UpdateTheTree;
        public void Update()
        {
            if (Status != TreeStatus.Dead && Status==TreeStatus.Live)
                Status = TreeStatus.Burned;
        }
        public void Subscribe(ITree sub)
        {
            sub.UpdateTheTree += Update;
        }

        public void DownHealth()
        {
            if (Healthness == 0)
                Status = TreeStatus.Dead;

            else if (Status == TreeStatus.Burned)
                Healthness--;

        }
        
        public void UnSubscribe(ITree sub)
        {
            sub.UpdateTheTree -= Update;
        }
        public void UpdateTree()
        {
            UpdateTheTree?.Invoke();
        }
        public Tree()
        {
            Healthness = 2;
            Status = TreeStatus.Live;
        }
    }
}
