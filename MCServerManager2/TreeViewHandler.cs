using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace MCServerManager2
{
    internal class TreeViewHandler
    {
        public static List<TreeNode> GetAllChildren(TreeNode node)
        {
            var result = new List<TreeNode>();
            result.Add(node);
            foreach (TreeNode child in node.Nodes)
                result.AddRange(GetAllChildren(child));
            return result;
        }

        public static void Add(TreeView view, IEnumerable<string> paths)
        {
            foreach (string path in paths)
            {
                CreatePath(view.Nodes, path);
            }
        }

        private static void CreatePath(TreeNodeCollection nodeList, string path)
        {
            TreeNode node = null;
            string folder = string.Empty;

            int p = path.IndexOf('/');

            if (p == -1)
            {
                folder = path;
                path = "";
            }
            else
            {
                folder = path.Substring(0, p);
                path = path.Substring(p + 1, path.Length - (p + 1));
            }

            node = null;

            foreach (TreeNode item in nodeList)
            {
                if (item.Text == folder)
                {
                    node = item;
                }
            }

            if (node == null)
            {
                node = new TreeNode(folder);
                nodeList.Add(node);
            }

            if (path != "")
            {
                CreatePath(node.Nodes, path);
            }
        }
    }
    internal static class TreeViewExtensions
    {
        public static TreeNode FindTreeNodeByFullPath(this TreeNodeCollection collection, string fullPath, StringComparison comparison = StringComparison.InvariantCultureIgnoreCase)
        {
            var foundNode = collection.Cast<TreeNode>().FirstOrDefault(tn => string.Equals(tn.FullPath, fullPath, comparison));
            if (null == foundNode)
            {
                foreach (var childNode in collection.Cast<TreeNode>())
                {
                    var foundChildNode = FindTreeNodeByFullPath(childNode.Nodes, fullPath, comparison);
                    if (null != foundChildNode)
                    {
                        return foundChildNode;
                    }
                }
            }

            return foundNode;
        }

        public static List<string> GetExpansionState(this TreeNodeCollection nodes)
        {
            return nodes.Descendants()
                        .Where(n => n.IsExpanded)
                        .Select(n => n.FullPath)
                        .ToList();
        }

        public static void SetExpansionState(this TreeNodeCollection nodes, List<string> savedExpansionState)
        {
            foreach (var node in nodes.Descendants()
                                      .Where(n => savedExpansionState.Contains(n.FullPath)))
            {
                node.Expand();
            }
        }

        public static IEnumerable<TreeNode> Descendants(this TreeNodeCollection c)
        {
            foreach (var node in c.OfType<TreeNode>())
            {
                yield return node;

                foreach (var child in node.Nodes.Descendants())
                {
                    yield return child;
                }
            }
        }

        public static void ExpandParents(this TreeNode node)
        {
            TreeNode parent = node.Parent;
            while(parent != null)
            {
                parent.Expand();
                parent = parent.Parent;
            }
        }

        public static IEnumerable<string> AllParents(this TreeNode node)
        {
            var parent = node.Parent;
            while(parent != null)
            {
                yield return parent.FullPath;
                parent = parent.Parent;
            }
        }

        public static List<TreeNode> GetAllNodes(this TreeView view)
        {
            var result = new List<TreeNode>();
            foreach(TreeNode child in view.Nodes)
            {
                result.AddRange(child.GetAllNodes());
            }
            return result;
        }

        public static List<TreeNode> GetAllNodes(this TreeNode node)
        {
            var result = new List<TreeNode>();
            result.Add(node);
            foreach(TreeNode child in node.Nodes)
            {
                result.AddRange(child.GetAllNodes());
            }
            return result;
        }

        /// <summary>
        /// Don't look inside this function. What it does is self-explanatory, but don't look inside this.
        /// </summary>
        /// <param name="view"></param>
        /// <param name="condition"></param>
        public static void ExpandAllExcept(this TreeView view, Predicate<string> condition)
        {
            foreach(var node in view.GetAllNodes())
            {
                if (node.GetNodeCount(false) > 0 && !condition(node.Nodes[0].FullPath)) node.Expand();
            }
        }
    }
}
