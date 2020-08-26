using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Synonymous.Models
{
    public class Node
    {
        public Node(string value, bool visited = false)
        {
            Value = value;
            Visited = visited;
        }
        public string Value { get; set; }
        public bool Visited { get; set; }
    }
}
