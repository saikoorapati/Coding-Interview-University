
using System;

namespace BinaryTrees
{
    class Program
    {
        static void Main(string[] args)
        {
            Tree BST = new Tree();
            BST.Insert(30);
            BST.Insert(35);
            BST.Insert(57);
            BST.Insert(15);
            BST.Insert(63);
            BST.Insert(49);
            BST.Insert(89);
            BST.Insert(77);
            BST.Insert(67);
            BST.Insert(98);
            BST.Insert(91);
            Console.WriteLine("Inorder Traversal : ");
            BST.InOrder(BST.ReturnRoot());
            Console.WriteLine(" ");
            Console.WriteLine();
            Console.WriteLine("Preorder Traversal : ");
            BST.PreOrder(BST.ReturnRoot());
            Console.WriteLine(" ");
            Console.WriteLine();
            Console.WriteLine("Postorder Traversal : ");
            BST.PostOrder(BST.ReturnRoot());
            Console.WriteLine(" ");
            Console.ReadLine();
        }
    }

    class Node
    {
        public int item;
        public Node right;
        public Node left;
        public void display()
        {
            Console.Write("[");
            Console.Write(item);
            Console.Write("]");
        }
    }

    class Tree
    {
        public Node root;
        public Tree ()
        {
            root = null;
        }

        public Node ReturnRoot()
        {
            return root;
        }

        public void Insert(int id)
        {
            Node newNode = new Node();
            newNode.item = id;
            if (root == null)
                root = newNode;
            else
            {
                Node current = root;
                Node parent;
                while (true)
                {
                    parent = current;
                    if (id < current.item)
                    {
                        current = current.left;
                        if (current == null)
                        {
                            parent.left = newNode;
                            return;
                        }
                    }
                    else
                    {
                        current = current.right;
                        if (current == null)
                        {
                            parent.right = newNode;
                            return;
                        }
                    }
                }
            }
        }

        public void PreOrder(Node root)
        {
            if(root != null)
            {
                Console.WriteLine(root.item + "");
                PreOrder(root.left);
                PreOrder(root.right);
            }
        }

        public void InOrder(Node root)
        {
            if (root != null)
            {
                PreOrder(root.left);
                Console.WriteLine(root.item + "");
                PreOrder(root.right);
            }
        }

        public void PostOrder(Node root)
        {
            if (root != null)
            {
                PreOrder(root.left);
                PreOrder(root.right);
                Console.WriteLine(root.item + "");
            }
        }
    }
}
