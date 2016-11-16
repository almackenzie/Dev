using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePlayground.LinkedLists
{
    public class DoubleLinkedNode
    {
        public DoubleLinkedNode Next { get; set; }
        public DoubleLinkedNode Previous { get; set; }
        public object Data { get; set; }
    }
}
