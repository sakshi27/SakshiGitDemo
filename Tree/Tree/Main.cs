using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree
{
    public class TreeBuilder
    {

        public void run()
        {
            //int[] inorder = new int[7] { 10, 14, 19, 27, 31, 35, 42 };
            //int[] preorder = new int[7] { 27, 14, 10, 19, 35, 31, 42 };

            int[] inorder = new int[19] { 16, 8, 17, 4, 18, 9, 19, 2, 10, 5, 11, 1, 12, 6, 13, 3, 14, 7, 15 };
            int[] preorder = new int[19] { 1, 2, 4, 8, 16, 17, 9, 18, 19, 5, 10, 11, 3, 6, 12, 13, 7, 14, 15 };

            Queue<int> preorderQueue = getPreorderQueue(preorder);

            ElementNode<int> node = ParseTree(preorderQueue, inorder);

            Console.WriteLine("Post Order Traversal::");
            PostOrderTraversal(node);

            Console.WriteLine("\n Pre Order Traversal::");
            PreOrderTraversal(node);

            Console.WriteLine("\n In Order Traversal::");
            inorderTraversal(node);

            Console.WriteLine("\n BFS traversal :: ");
            BFS(node);

            Console.WriteLine("\n Spiral BFS result ::");
            SpiralBFS(node);

        }

        private void SpiralBFS(ElementNode<int> node)
        {
            if (null == node)
                return;
            Queue<ElementNode<int>> sBfsQueue = new Queue<ElementNode<int>>();
            sBfsQueue.Enqueue(node);
            sBfsQueue.Enqueue(null);

            sBFSSearch(sBfsQueue);
        }
        /// <summary>
        /// Challenge here to print BFS in sprial order is to get level info. Level change I implemented by inserting null node afetr root node, 
        ///     And while dequeuing null node, enqueued another null node.
        /// Second challenge is to print alternate levels in reverse order. So, kept useStack variable which reverses when ever null node is dequeued. 
        ///     UseStack helps in telling that instead of printing we need to add vaues in stack and on every occurance of null node in queue, we need to print the stack elements.
        /// </summary>
        /// <param name="sBfsQueue"></param>
        private void sBFSSearch(Queue<ElementNode<int>> sBfsQueue)
        {
            bool useStack = false;
            Stack<ElementNode<int>> stack = new Stack<ElementNode<int>>();
            while (sBfsQueue.Count > 0)
            {
                ElementNode<int> node = sBfsQueue.Dequeue();
                if (node != null)
                {
                    if (null != node.left)
                        sBfsQueue.Enqueue(node.left);
                    if (null != node.right)
                        sBfsQueue.Enqueue(node.right);
                }
                else
                {
                    sBfsQueue.Enqueue(null);
                    while (stack.Count > 0)
                    {
                        Console.Write(stack.Pop().value + " ");
                    }
                    useStack = !useStack;
                    continue;
                }
                if (!useStack)
                {
                    Console.Write(node.value + " ");
                }
                else
                {
                    stack.Push(node);
                }
            }
        }

        private void BFS(ElementNode<int> node)
        {
            if (null == node)
                return;
            Queue<ElementNode<int>> bfsQueue = new Queue<ElementNode<int>>();
            bfsQueue.Enqueue(node);
            bfsSearch(node, bfsQueue);
        }

        private void bfsSearch(ElementNode<int> node, Queue<ElementNode<int>> bfsQueue)
        {
            ElementNode<int> elementNode = node;
            while (bfsQueue.Count > 0)
            {
                elementNode = bfsQueue.Dequeue();
                Console.Write(elementNode.value + " ");
                if (null != elementNode.left)
                    bfsQueue.Enqueue(elementNode.left);
                if (null != elementNode.right)
                    bfsQueue.Enqueue(elementNode.right);
            }

        }

        public void inorderTraversal(ElementNode<int> node)
        {
            if (null == node)
                return;
            inorderTraversal(node.left);
            Console.Write(node.value + " ");
            inorderTraversal(node.right);
        }

        private void PreOrderTraversal(ElementNode<int> node)
        {
            if (node == null)
                return;
            Console.Write(node.value + " ");
            PreOrderTraversal(node.left);
            PreOrderTraversal(node.right);
        }

        private void PostOrderTraversal(ElementNode<int> node)
        {
            if (null == node)
                return;
            PostOrderTraversal(node.left);
            PostOrderTraversal(node.right);
            Console.Write(node.value + " ");
        }

        private ElementNode<int> ParseTree(Queue<int> preorderQueue, int[] inorder)
        {
            if (inorder.Length == 0)
            {
                return null;
            }

            int rootValue = preorderQueue.Dequeue();
            ElementNode<int> rootNode = new ElementNode<int>(rootValue);
            int indexinInoder = SearchInArray(rootValue, inorder);
            if (indexinInoder == -1)
            {
                //Wrong tree input
                return null;
            }

            int[] leftArray = getLeftArray(inorder, indexinInoder);
            int[] rightArray = getRightArray(inorder, indexinInoder);

            rootNode.left = ParseTree(preorderQueue, leftArray);
            rootNode.right = ParseTree(preorderQueue, rightArray);

            return rootNode;
        }

        private int[] getLeftArray(int[] inorder, int indexinInoder)
        {
            if (indexinInoder == 0)
            {
                return new int[0];
            }
            int[] leftArray = new int[indexinInoder];
            for (int i = 0; i < indexinInoder; i++)
            {
                leftArray[i] = inorder[i];
            }
            return leftArray;
        }

        private int[] getRightArray(int[] inorder, int indexinInoder)
        {
            if (indexinInoder == inorder.Length - 1)
                return new int[0];
            int[] rightArray = new int[inorder.Length - indexinInoder - 1];
            for (int i = indexinInoder + 1, j = 0; i < inorder.Length; i++)
            {
                rightArray[j++] = inorder[i];
            }
            return rightArray;
        }

        private int SearchInArray(int rootValue, int[] inorder)
        {
            int position = 0;
            foreach (int element in inorder)
            {
                if (element == rootValue)
                    return position;
                position++;
            }
            return -1;
        }

        private Queue<int> getPreorderQueue(int[] preorder)
        {
            Queue<int> queue = new Queue<int>();
            foreach (int element in preorder)
            {
                queue.Enqueue(element);
            }
            return queue;
        }

        private bool isBalancedBinary(ElementNode<int> node)
        {
            if (null == node)
                return true;
            bool left, right;
            if (Math.Abs(getHeight(node.left) - getHeight(node.right)) > 1)
                return false;
            else {
                left = isBalancedBinary(node.left);
                right = isBalancedBinary(node.right);
            }
            return left && right;
        }

        private int getHeight(ElementNode<int> node)
        {
            if (null == node)
                return 0;
            return Math.Max(getHeight(node.left), getHeight(node.right)) + 1;
        }

        class ValidateBSTNode
        {
            public int Minimum { get; private set; }
            public int Maximum { get; private set; }

            public bool IsBST { get; private set; }

            public ValidateBSTNode(int min, int max, bool isBST)
            {
                Minimum = min;
                Maximum = max;
                IsBST = isBST;
            }

            private ValidateBSTNode alterNode(ValidateBSTNode node)
            {
                int minValue = Math.Min(Minimum, node.Minimum);
                int maximum = Math.Max(Maximum, node.Maximum);

                return new ValidateBSTNode(minValue, maximum, node.IsBST && IsBST);
            }
        }

        public ElementNode<int> BinaryTree(int[] array, int index = 0)
        {
            return createBinaryTreeThroughArray(array, index);
        }

        private ElementNode<int> createBinaryTreeThroughArray(int[] array, int index)
        {
            if (index >= array.Length)
                return null;

            ElementNode<int> rootNode = new ElementNode<int>(array[index]);
            rootNode.left = createBinaryTreeThroughArray(array, (2 * index) + 1);
            rootNode.right = createBinaryTreeThroughArray(array, (2 * index) + 2);

            return rootNode;
        }

        public ElementNode<int> createCompleteBinaryTreeThroughArrayIteratively(int[] arr)
        {
            Queue<ElementNode<int>> emptyNodes = new Queue<ElementNode<int>>();
            ElementNode<int> root = new ElementNode<int>(arr[0]);
            emptyNodes.Enqueue(root);
            for (int i = 1; i < arr.Length; i++)
            {
                ElementNode<int> node = new ElementNode<int>(arr[i]);
                emptyNodes.Enqueue(node);
                if (null == emptyNodes.Peek().left)
                {
                    emptyNodes.Peek().left = node;
                }
                else
                {
                    emptyNodes.Dequeue().right = node;
                }
            }
            return root;
        }

        public int[] MinHeap(int[] array)
        {
            CreateHeapThroughArray(array, 0);
            return array;
        }

        private void CreateHeapThroughArray(int[] array, int index)
        {
            //Heap is a binary tree
            if (index >= array.Length)
                return;
            int leftIndex = getLeftIndex(array, index);
            CreateHeapThroughArray(array, leftIndex);

            int rightIndex = getRightIndex(array, index);
            CreateHeapThroughArray(array, rightIndex);

            int minIndex = index;
            if ((leftIndex < array.Length))
            {
                if (array[minIndex] > array[leftIndex])
                    minIndex = leftIndex;
            }
            if ((rightIndex < array.Length))
            {
                if (array[minIndex] > array[rightIndex])
                    minIndex = rightIndex;
            }

            if(index!= minIndex)
            {
                Swap(array, index, minIndex);
                CreateHeapThroughArray(array, minIndex);
            }
            

        }

        private void Swap(int[] array, int index, int minIndex)
        {
            if (index != minIndex)
            {
                int data = array[minIndex];
                array[minIndex] = array[index];
                array[index] = data;
            }
        }

        private int getRightIndex(int[] array, int index)
        {
            return (index * 2) + 2;
        }

        private int getLeftIndex(int[] array, int index)
        {
            return (index * 2) + 1;
        }

        public ElementNode<int> RepresentTreeinDoublyLL(ElementNode<int> node)
        {
            if (null == node)
                return null;
            if (IsLeafNode(node))
            {
                return node;
            }
            ElementNode<int> leftHead=  RepresentTreeinDoublyLL(node.left);
            AppendAtLast(leftHead, node);


            ElementNode<int> rightHead = RepresentTreeinDoublyLL(node.right);
            if(rightHead!=null)
                AppendAtLast(leftHead, rightHead);

            return leftHead;
        }

        private void AppendAtLast(ElementNode<int> leftHead, ElementNode<int> node)
        {
            if (null == leftHead)
            {
                leftHead = node;
                return;
            }
                
            ElementNode<int> Head = leftHead;
            while(Head.right!= null)
            {
                Head = Head.right;
            }
            Head.right = node;
            node.left = Head;
        }

        private bool IsLeafNode(ElementNode<int> node)
        {
            if (null == node.left && null == node.right)
                return true;
            return false;
        }
    }
}
