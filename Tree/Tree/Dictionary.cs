using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree
{
    public class Dictionary
    {
        public List<string> result { get; set; }
        public List<string> FinalResult { get; set; }

        public void FindStrings(TreeNode node, string value)
        {
            FinalResult = new List<string>();
            FindOneHopStrings(node, "", value, 1);
        }
        internal void FindOneHopStrings(TreeNode rootNode, string prefix, string inputWord, int noOfHopsPermitted)
        {
            if (null == rootNode)
                return;
            Console.WriteLine("Searching word: {0}, prefix: {1}, on Node:{2}", inputWord, prefix, rootNode.Value);
            if (inputWord.Length < 1)
            {
                if (rootNode.isTerminal)
                {
                    FinalResult.Add(prefix);
                }
                return;
            }

            string firstChar = inputWord.Substring(0, 1);
            string remainingString = inputWord.Substring(1);
            string fullPrefix = string.Concat(prefix, firstChar);

            //if (rootNode.HasChild(firstChar))
            //{
            //    TreeNode node = rootNode.getChild(firstChar);
            //    FindOneHopStrings(node, fullPrefix, remainingString, noOfHopsPermitted);
            //}

            var matchingSiblings = rootNode.siblings.Where(n => n.Value == firstChar);
            foreach (var child in matchingSiblings)
            {
                FindOneHopStrings(child, fullPrefix, remainingString, noOfHopsPermitted);
            }

            if (noOfHopsPermitted > 0)
            {
                var unmatchedSiblings = rootNode.siblings.Where(node => node.Value != firstChar);
                foreach (var child in unmatchedSiblings) { 
                    FindOneHopStrings(child, String.Concat(prefix, child.Value), remainingString, noOfHopsPermitted - 1);
                }
                //foreach (TreeNode OtherNode in rootNode.siblings)
                //{
                //    if (rootNode.Value == firstChar)
                //        continue;
                //    result.AddRange(FindOneHopStrings(OtherNode, String.Concat(prefix,n.Value), remainingString, noOfHopsPermitted - 1));
                //}
            }
        }
    }
}
