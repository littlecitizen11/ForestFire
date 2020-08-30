using System;
using System.Collections.Generic;
using System.Text;

namespace ForestFire
{
    public interface ITree
    {
        public event Action UpdateTheTree;
        public int Healthness { get; set; }
        public TreeStatus Status { get; set; }
        public void Update();
        public void Subscribe(ITree sub);

        public void DownHealth();

        public void UnSubscribe(ITree sub);
        public void UpdateTree();
    }
}
