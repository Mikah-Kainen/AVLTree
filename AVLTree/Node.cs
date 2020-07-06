using System;
using System.Collections.Generic;
using System.Text;

namespace AVLTree
{
    public class Node<T> where T : IComparable<T>
    {
        public Node<T> RightChild;
        public Node<T> LeftChild;

        public T Value { get; private set; }

        public Node (T value)
        {
            Value = value;
            RightChild = null;
            LeftChild = null;
        }

        public int Height()
        {
            if(RightChild == null && LeftChild == null)
            {
                return 1;
            }

            else if(RightChild == null)
            {
                return LeftChild.Height() + 1;
            }
            else if(LeftChild == null)
            {
                return RightChild.Height() + 1;
            }

            else if(RightChild.Height() > LeftChild.Height())
            {
                return RightChild.Height() + 1;
            }
            else
            {
                return LeftChild.Height() + 1;
            }
        }

        public int Balance()
        {
            if(RightChild == null)
            {
                if(LeftChild == null)
                {
                    return 0;
                }
                return -LeftChild.Height();
            }
            else if(LeftChild == null)
            {
                return RightChild.Height();
            }
            return RightChild.Height() - LeftChild.Height();
        }

        public bool IsLessThan(Node<T> targetNode)
        {
            if(Value.CompareTo(targetNode.Value) < 0)
            {
                return true;
            }
            return false;
        }
    }
}
