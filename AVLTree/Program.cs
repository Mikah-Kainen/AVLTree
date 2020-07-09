using System;

namespace AVLTree
{
    class Program
    {
        static void Main(string[] args)
        {
            AVLTree<int> tree = new AVLTree<int>();

            tree.Add(5);
            tree.Add(3);
            tree.Add(4);

            tree.Add(1);
            ;
        }
    }
}
