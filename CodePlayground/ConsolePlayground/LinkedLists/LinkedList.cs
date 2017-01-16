using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePlayground.LinkedLists
{
    public class Node<T>
    {
        public Node<T> Next { get; set; }
        public T Data { get; set; } 
    }

    public class LinkedList<T>
    {
        public Node<T> Head { get; set; }
    }
}
