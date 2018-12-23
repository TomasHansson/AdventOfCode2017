using System;
using System.Collections.Generic;
using System.IO;

namespace AdventOfCode2017
{
    class Day07
    {
        public static string FindNameOfRootNode()
        {
            Dictionary<string, TreeNode> treeNodes = new Dictionary<string, TreeNode>();
            HashSet<string> hasBeenSeen = new HashSet<string>();
            using (StreamReader streamReader = new StreamReader(@"C:/Temp/input_2017_day7.txt"))
            {
                string row;
                while ((row = streamReader.ReadLine()) != null)
                {
                    string name;
                    string weigth;
                    int weigthNumber;
                    string childrenString;
                    string[] children;
                    if (row.Contains("->"))
                    {
                        name = row.Split(' ')[0];
                        weigth = row.Split(' ')[1];
                        weigth = weigth.Substring(1, weigth.Length - 2);
                        weigthNumber = Convert.ToInt32(weigth);
                        childrenString = row.Split('>')[1];
                        children = childrenString.Split(',');
                        for (int i = 0; i < children.Length; i++)
                        {
                            children[i] = children[i].Trim();
                        }
                        treeNodes.Add(name, new TreeNode(name, weigthNumber, children));
                    }
                    else
                    {
                        name = row.Split(' ')[0];
                        weigth = row.Split(' ')[1];
                        weigth = weigth.Substring(1, weigth.Length - 2);
                        weigthNumber = Convert.ToInt32(weigth);
                        treeNodes.Add(name, new TreeNode(name, weigthNumber, new string[0], true));
                    }
                }
            }
            foreach (var treeNode in treeNodes)
            {
                for (int i = 0; i < treeNode.Value.children.Length; i++)
                {
                    treeNodes[treeNode.Value.children[i]].hasParent = true;
                }
            }
            string rootNodeName = "";
            foreach (var item in treeNodes)
            {
                if (item.Value.hasParent == false)
                    rootNodeName = item.Key;
            }
            return rootNodeName;
        }
    }

    public class TreeNode
    {
        public string name;
        public int weigth;
        public string[] children;
        public bool hasParent;

        public TreeNode(string _name, int _weight, string[] _children, bool _hasParent)
        {
            name = _name;
            weigth = _weight;
            children = _children;
            hasParent = _hasParent;
        }

        public TreeNode(string _name, int _weight, string[] _children)
        {
            name = _name;
            weigth = _weight;
            children = _children;
        }

        public TreeNode(string _name, bool _hasParent)
        {
            name = _name;
            hasParent = _hasParent;
        }
    }
}
