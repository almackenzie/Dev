using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePlayground.LinkedLists
{
    public class LinkedListTests
    {
        [Test]
        public void FindStartOfLoop()
        {
            int nodeCount = 100;
            Node<long>[] nodes = new Node<long>[nodeCount];

            for (int i = 0; i < nodeCount; i++)
            {
                nodes[i] = new Node<long>() { Data = i };
                if(i > 0)
                {
                    nodes[i - 1].Next = nodes[i];
                }
            }

            nodes[98].Next = nodes[21];

            // we now have a loop

            var hare = nodes[0];
            var tortoise = nodes[0];

            do
            {
                hare = hare.Next.Next;
                tortoise = tortoise.Next;
            } while (hare != tortoise);

            // hare and tortoise have met - so there is deffo a loop

            var top = nodes[0];
            var bottom = hare;

            do
            {
                top = top.Next;
                bottom = bottom.Next;
            } while (top != bottom);




        }

    }
}
