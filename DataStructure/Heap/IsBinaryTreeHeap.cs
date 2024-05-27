// https://www.geeksforgeeks.org/problems/is-binary-tree-heap/1?itm_source=geeksforgeeks&itm_medium=article&itm_campaign=bottom_sticky_on_article
using System.ComponentModel.Design.Serialization;
namespace DotNet.DataStructure.Heap
{
    public class IsBinaryTreeHeap
    {
        public IsBinaryTreeHeap() {

        }
        
        class Node {
            public int data;
            public Node left;
            public Node right;
            public Node(int data) {
                this.data = data;
                left = null;
                right = null;
            }
        }

        public void Test() {
            Node root = new Node(10);
            root.left = new Node(9);
            root.right = new Node(8);
            root.left.left = new Node(7);
            root.left.right = new Node(6);
            root.right.left = new Node(5);
            root.right.right = new Node(4);
            root.left.left.left = new Node(3);
            root.left.left.right = new Node(2);
            root.left.right.left = new Node(1);

            if(IsHeap(root) == true) {
                Console.WriteLine("Given binary tree is a heap");
            } else {
                Console.WriteLine("Given binary tree is not a heap");
            }
        }

        bool IsHeap(Node tree) {

            bool result = true;

            if(tree.right != null) {
                if(tree.left == null) {
                    return false;
                }
            }

            if(tree != null
                && ((tree.left != null && (tree.left.data > tree.data))
                     || (tree.right != null && (tree.right.data > tree.data))
                   )
                ) 
            {
                    return false;     
            }

            if(tree.left != null) {
                if((tree.left.left != null || tree.left.right != null) && tree.right == null) {
                    return false;
                }
            }

            if(tree.right != null) {
                if(tree.right.left != null || tree.right.right != null) {
                    if(tree.left != null) {
                        if(tree.left.left == null || tree.left.right == null) {
                            return false;
                        }
                    }
                }
            }

            if(tree != null && tree.left != null) {
                bool  l = IsHeap(tree.left);
                result = result & l;
            }

            if(tree !=null && tree.right != null) {
                bool r = IsHeap(tree.right);
                result = result & r;
            }

            return result;
        }
    }
}