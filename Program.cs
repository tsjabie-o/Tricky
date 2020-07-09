using System;
using System.Text;
using System.Collections.Generic;

namespace Opdracht_7
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            string[] results = new string[n];

            for (int i = 0; i < n; i++)
            {
                results[i] = TrickySort(Console.ReadLine());
            }

            foreach (string result in results)
            {
                System.Console.WriteLine(result);
            }
        }

        static string TrickySort(string input)
        {
            // Creating needed datastructures
            Node root = new Node(input, null, null);
            Queue<Node> tocheck = new System.Collections.Generic.Queue<Node>();
            Dictionary<string, Node> found = new Dictionary<string, Node>();

            // The correctly sorted key
            string desired = root.Desired;

            // Add root to found and tocheck
            found.Add(root.Key, root);
            tocheck.Enqueue(root);

            string result = "Not found";

            while (tocheck.Count != 0)
            {
                Node current = tocheck.Dequeue();
                if (current.Key == desired)
                {
                    result = FindPath(found, desired);
                    break;
                }
                Node A_node = current.A();
                if (!found.ContainsKey(A_node.Key))
                {
                    found.Add(A_node.Key, A_node);
                    tocheck.Enqueue(A_node);
                }
                Node B_node = current.B();
                if (!found.ContainsKey(B_node.Key))
                {
                    found.Add(B_node.Key, B_node);
                    tocheck.Enqueue(B_node);
                }
                Node X_node = current.X();
                if (!found.ContainsKey(X_node.Key))
                {
                    found.Add(X_node.Key, X_node);
                    tocheck.Enqueue(X_node);
                }
            }

            return result;
        }

        static string FindPath(Dictionary<string, Node> found, string desired)
        {
            int steps = 0;
            StringBuilder methods = new StringBuilder();
            Node current = found[desired];
            while (current.Parent != null)
            {
                methods.Insert(0, current.Method);
                steps++;
                current = current.Parent;
            }
            string result = string.Format("{0} {1}", steps, methods);
            return result;
        }
    }

    class Node
    {
        string _key;
        string _method;
        Node _parent;

        public Node(string key, Node parent, string method)
        {
            _key = key;
            _parent = parent;
            _method = method;
        }

        public string Desired { get => FindDesired(); }
        public string Method { get => _method; }
        public string Key { get => _key; }
        public Node Parent { get => _parent; }

        public Node A()
        {
            StringBuilder newkey = new StringBuilder();
            newkey.Append(this._key[1]);
            newkey.Append(this._key[0]);
            newkey.Append(this._key.Substring(2, this._key.Length - 2));

            Node newNode = new Node(newkey.ToString(), this, "a");
            return newNode;
        }

        public Node B()
        {
            StringBuilder newkey = new StringBuilder();
            newkey.Append(this._key.Substring(0, this._key.Length - 2));
            newkey.Append(this._key[this._key.Length - 1]);
            newkey.Append(this._key[this._key.Length - 2]);

            Node newNode = new Node(newkey.ToString(), this, "b");
            return newNode;
        }

        public Node X()
        {
            StringBuilder newkey = new StringBuilder();
            newkey.Append(this._key[0]);
            newkey.Append(this._key[this._key.Length - 2]);
            for (int i = 1; i < this._key.Length - 2; i++)
            {
                newkey.Append(this._key[i]);
            }
            newkey.Append(this._key[this._key.Length - 1]);

            Node newNode = new Node(newkey.ToString(), this, "x");
            return newNode;
        }

        public string FindDesired()
        {
            char[] keyaschars = this._key.ToCharArray();
            Array.Sort(keyaschars);
            string desired = new String(keyaschars);
            return desired;
        }

    }


}