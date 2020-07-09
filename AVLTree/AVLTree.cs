using System;
using System.Collections.Generic;
using System.Text;


namespace AVLTree
{
    public class AVLTree<T> where T : IComparable<T>
    {
        Node<T> RootNode;
        public int Count;

        public AVLTree ()
        {
            RootNode = null;
            Count = 0;
        }

        public Node<T> FindParent(Node<T> targetNode)
        {
            Node<T> previousNode = null;
            Node<T> currentNode = RootNode;

            while(currentNode != null)
            {
                if(currentNode.Equals(targetNode))
                {
                    return previousNode;
                }
                else if(targetNode.Value.CompareTo(currentNode.Value) > 0)
                {
                    previousNode = currentNode;
                    currentNode = currentNode.RightChild;
                }
                else
                {
                    previousNode = currentNode;
                    currentNode = currentNode.LeftChild;
                }
            }

            return null;
        }


        public void Add(T targetValue)
        {
            if(RootNode == null)
            {
                RootNode = new Node<T>(targetValue);
                return;
            }
            Count ++;
            Add(targetValue, RootNode);
        }

        private void Add(T targetValue, Node<T> currentNode)
        { 
            bool shouldAdd = false;
            if(targetValue.Value.CompareTo(currentNode.Value) < 0)
            {
                if(currentNode.LeftChild != null)
                {
                    Add(targetValue, currentNode.LeftChild);
                }
                else
                {
                    shouldAdd = true;
                }
            }
            else
            {
                if(currentNode.LeftChild != null)
                {
                    Add(targetValue, currentNode.RightChild);
                }
                else
                {
                    shouldAdd = true;
                }
            }   

            if(wasFound)
            {
                if(currentNode.Value.CompareTo(targetValue) < 0)
                {
                    currentNode.leftChild = new Node<T>(targetValue);
                }
                else
                {
                    currentNode.RightChild = new Node<T>(targetValue);
                }
                shouldAdd = false;
            }

            while(abs(currrentNode.Balance) > 1)
            {
                if(currentNode.Balance() > 1)
                {
                    LeftRotation(FindParent(FindParent(currentNode)));
                }
                else if(currentNode.Balance() < 1)
                {
                    RightRotation(FindParent(FindParent(currentNode)));
                }   
            }
        }
    

        private void LeftRotation(Node<T> targetNode)
        {
            if(targetNode.RightChild.RightChild == null)
            {
                RightRotation(targetNode.RightChild);
            }

            Node<T> parentNode = FindParent(targetNode);
            Node<T> tempHolder;

            parentNode.RightChild = parentNode.RightChild.RightChild;
            tempHolder = parentNode.RightChild.LeftChild;

            parentNode.RightChild.LeftChild = targetNode;
            targetNode.RightChild = tempHolder;
        }

        private void RightRotation(Node<T> targetNode)
        {
            if(targetNode.LeftChild.LeftChild == null)
            {
                LeftRotation(targetNode.LeftChild);
            }

            Node<T> parentNode = FindParent(targetNode);
            Node<T> tempHolder;

            parentNode.LeftChild = parentNode.LeftChild.LeftChild;
            tempHolder = parentNode.LeftChild.RightChild;

            parentNode.LeftChild.RightChild = targetNode;
            targetNode.LeftChild = tempHolder;
        }
    }
}
