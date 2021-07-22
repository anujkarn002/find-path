using System;
using System.Collections.Generic;

namespace FindPath
{
    class Program
    {

        static List<Node> FindPath(List<Node> nodes, Node start, Node target)
        {
            var path = new List<Node>();
            /**
                We don't have enough nodes to find a path.
            */
            if (nodes.Count < 2)
            {
                return path;
            }
            /**
                The start node is not linked to any other node
            */
            if (start.Parent == null) { return path; }
            var parent = (Node)null;
            while (true)
            {
                parent = nodes.Find(x => x.Id == start.Parent);
                /**
                    End of search
                */
                if (parent == null) { break; }
                path.Add(parent);
                /**
                    We found the target node
                */
                if (parent.Id == target.Id) { break; }
                start = parent;
            }
            if (path.Count >= 1)
            {
                /**
                    No path between given nodes
                */
                if (path[path.Count - 1].Id != target.Id) { return new List<Node>(); }
            }
            return path;
        }

        static void Main()
        {
            var nodes = new List<Node>()
        {
            new Node() {Id = 1, Parent = 2},
            new Node() {Id = 2, Parent = null},
            new Node() {Id = 3, Parent = 4},
            new Node() {Id = 4, Parent = 1},
            new Node() {Id = 5, Parent = 3}
        };
            var start = new Node() { Id = 5, Parent = 3 };
            var target = new Node() { Id = 1, Parent = 2 };
            var path = FindPath(nodes, start, target);
            if (path.Count == 0)
            {
                Console.WriteLine("No path found");
            }
            else
            {

                Console.Write(start.Id);
                foreach (Node node in path)
                {
                    Console.Write(" -> " + node.Id);
                }
                if (path.Count == 1)
                {
                    Console.WriteLine("(Direct Link)");
                }
            }
        }

        class Node
        {
            public int Id { get; set; }
            public Nullable<int> Parent { get; set; }
        }
    }
}
