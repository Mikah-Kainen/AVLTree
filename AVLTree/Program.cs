using System;
using System.Collections.Generic;

namespace AVLTree
{
    class Program
    {
        static void Main(string[] args)
        {
            AVLTree<int> tree = new AVLTree<int>();
            
            for(int i = 1; i < 11; i ++)
            {
                tree.Add(i);
            }


            tree.Remove(4);
            tree.Remove(8);
            tree.Remove(5);
            tree.Remove(2);

            List<int> Tree = tree.BreadthFirst();
            ;
        }
    }
}
