using System;

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
            ;
        }
    }
}
