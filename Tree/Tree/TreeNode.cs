using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree
{
    public class TreeNode
    {
        public string Value { get; set; }

        public static List<string> result { get; set; }
        public bool isTerminal { get; set; }

        private static TreeNode ROOT = new TreeNode("$");

        public List<TreeNode> siblings { get; set; }
        public TreeNode getRootNode()
        {
            return ROOT;
        }
        public TreeNode(string value)
        {
            this.Value = value;
            this.siblings = new List<TreeNode>();
        }

        internal bool HasChild(string firstChar)
        {
            foreach (TreeNode str in siblings)
            {
                if (str.Value == firstChar)
                    return true;
            }
            return false;
        }

        internal TreeNode getChild(string firstChar)
        {
            foreach (TreeNode str in siblings)
            {
                if (str.Value == firstChar)
                    return str;
            }
            return null;
        }

        public void addStringInDictionary(string value)
        {
            TreeNode rootNote = getRootNode();
            if (value == null)
                return;

            string firstChar = value.Substring(0, 1);
            string remaniningString = value.Substring(1);

            rootNote.addString(firstChar, remaniningString);
        }

        private void addString(string firstChar, string remaniningString)
        {
            if (firstChar.Length < 1)
                return;

            bool terminal = (remaniningString.Length == 0);

            TreeNode node;
            if (!this.FirsCharInSiblings(firstChar))
            {
                node = new TreeNode(firstChar);
                this.siblings.Add(node);
            }

            node = this.siblings.Where(n => n.Value == firstChar).First();
            if (remaniningString.Length == 0)
            {
                node.isTerminal = node.isTerminal || terminal;
                return;
            }
            firstChar = remaniningString.Substring(0, 1);
            remaniningString = remaniningString.Substring(1);
            node.addString(firstChar, remaniningString);

            

        }

        private bool FirsCharInSiblings(string firstChar)
        {
            return siblings.Any(n => n.Value == firstChar);
        }

        public void Traversal()
        {
            TreeNode rootNode = getRootNode();
            result = new List<string>();
            rootNode.DFSTraverse("");
        }

        private void DFSTraverse(string prefix)
        {
            prefix = String.Concat(prefix, this.Value);
            if (this.isTerminal)
                result.Add(prefix.Substring(1));
            this.siblings.ForEach(n => n.DFSTraverse(prefix));
        }

        public void PrintStrings()
        {
            Console.WriteLine(String.Join ( " ", result));
        }
    }
}
