using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Helpers
{
    public class TreeNode<T> : IEnumerable<TreeNode<T>>
    {
        private readonly List<TreeNode<T>> children;

        public TreeNode(T value, TreeNode<T> parent = null)
        {
            this.Value = value;
            this.Parent = parent;

            this.children = new List<TreeNode<T>>();
        }

        public TreeNode<T> this[int index]
        {
            get
            {
                return this.Children[index];
            }
        }

        public T Value { get; }

        public TreeNode<T> Parent { get; }

        public ReadOnlyCollection<TreeNode<T>> Children
        {
            get
            {
                return this.children.AsReadOnly();
            }
        }

        public TreeNode<T> Add(T value)
        {
            var node = new TreeNode<T>(value, this);

            this.children.Add(node);

            return node;
        }

        public bool Remove(TreeNode<T> node)
        {
            return this.children.Remove(node);
        }

        public IEnumerator<TreeNode<T>> GetEnumerator()
        {
            yield return this;

            foreach (var child in this.children)
            {
                yield return child;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
