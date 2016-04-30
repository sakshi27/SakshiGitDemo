using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tree;

namespace TreeBuilder
{
    class Program
    {
        static void Main(string[] args)
        {
            //TreeOperations();
            DictionaryTree();
            Console.ReadKey();
        }

        private static void DictionaryTree()
        {
            TreeNode node = new TreeNode("dummy");
            node = node.getRootNode();

            node.addStringInDictionary("mad");
            node.addStringInDictionary("sad");
            node.addStringInDictionary("mate");
            node.addStringInDictionary("dad");

            node.Traversal();

            node.PrintStrings();

            Dictionary oneHopDictionary = new Dictionary();
            oneHopDictionary.FindStrings(node, "dad");
            foreach(String str in oneHopDictionary.FinalResult)
            {
                Console.WriteLine(str);
            }
        }

        private static void TreeOperations()
        {
            Tree.TreeBuilder treeBuilder = new Tree.TreeBuilder();
            //treeBuilder.run();

            int[] array = new int[] { 5, 2, 15, 3, 9, 1, 0, 20 };
            //int[] newarray= treeBuilder.MinHeap(array);

            Tree.ElementNode<int> node = treeBuilder.BinaryTree(array, 0);
            //Tree.ElementNode<int> node = treeBuilder.createCompleteBinaryTreeThroughArrayIteratively(array);

            treeBuilder.inorderTraversal(node);

            //Console.WriteLine(String.Join(" ", newarray));

            treeBuilder.RepresentTreeinDoublyLL(node);

            while (node.right != null)
                Console.WriteLine(node);
        }
    }
}
