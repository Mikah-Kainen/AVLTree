using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
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

        public Node<T> FindParent(T targetValue)
        {
            Node<T> previousNode = null;
            Node<T> currentNode = RootNode;

            while (currentNode != null)
            {
                if (currentNode.Value.Equals(targetValue))
                {
                    return previousNode;
                }
                else if (targetValue.CompareTo(currentNode.Value) > 0)
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

        public bool Contains(T targetValue)
        {
            
        }

        private Node<T> FindParent(Node<T> targetNode)
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
                Count++;
                return;
            }
            Count ++;
            Add(targetValue, RootNode);
        }

        private void Add(T targetValue, Node<T> currentNode)
        { 
            bool shouldAdd = false;
            if(targetValue.CompareTo(currentNode.Value) < 0)
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
                if(currentNode.RightChild != null)
                {
                    Add(targetValue, currentNode.RightChild);
                }
                else
                {
                    shouldAdd = true;
                }
            }   

            if(shouldAdd)
            {
                if(targetValue.CompareTo(currentNode.Value) < 0)
                {
                    currentNode.LeftChild = new Node<T>(targetValue);
                }
                else
                {
                    currentNode.RightChild = new Node<T>(targetValue);
                }
                shouldAdd = false;
            }

            while(Math.Abs(currentNode.Balance()) > 1)
            {
                if(currentNode.Balance() > 1)
                {
                    LeftRotation(currentNode);
                }
                else if(currentNode.Balance() < 1)
                {
                    RightRotation(currentNode);
                }   
            }
        }
    

        private void LeftRotation(Node<T> targetNode)
        {
            Node<T> parentNode = FindParent(targetNode);
            Node<T> newHead = targetNode.RightChild;
            Node<T> tempHolder;

            if(newHead.RightChild == null && newHead.LeftChild != null)
            {
                RightRotation(newHead);
                newHead = targetNode.RightChild;
            }

            if (parentNode != null)
            {
                if (parentNode.RightChild == targetNode)
                {
                    parentNode.RightChild = newHead;
                }
                else
                {
                    parentNode.LeftChild = newHead;
                }
            }
            else
            {
                RootNode = newHead;
            }
            tempHolder = newHead.LeftChild;
            
            newHead.LeftChild = targetNode;
            targetNode.RightChild = tempHolder;
        }

        private void RightRotation(Node<T> targetNode)
        {
            Node<T> parentNode = FindParent(targetNode);
            Node<T> newHead = targetNode.LeftChild;
            Node<T> tempHolder;

            if(newHead.LeftChild == null && newHead.RightChild != null)
            {
                LeftRotation(newHead);
                newHead = targetNode.LeftChild;
            }

            if(parentNode != null)
            {
                if (parentNode.LeftChild == targetNode)
                {
                    parentNode.LeftChild = newHead;
                }
                else
                {
                    parentNode.RightChild = newHead;
                }
            }
            else
            {
                RootNode = newHead;
            }
            tempHolder = newHead.RightChild;

            newHead.RightChild = targetNode;
            targetNode.LeftChild = tempHolder;
        }
        
        public bool Remove(T targetValue)
        {
            if(RootNode == null)
            {
                return false;
            }

            return Delete();
        }

        private bool Delete(Node<T> targetNode, Node<T>currentNode)
        {

        }
    }
}
