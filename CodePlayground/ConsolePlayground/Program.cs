using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsolePlayground.LinkedLists;
using static System.Console;

namespace ConsolePlayground
{
    class Program
    {
        static void Main(string[] args)
        {

            DoubleLinkedNode previous = null;
            DoubleLinkedNode start = null;
            for (int i = 0; i < 10; i++)
            {
                DoubleLinkedNode node = new DoubleLinkedNode() {Data  = i};
                if (previous != null)
                {
                    previous.Next = node;
                    node.Previous = previous;
                }
                else
                {
                    start = node;
                }
                previous = node;

            }

            ReverseLinkedList(start);
            Console.ReadLine();

        }

        private static void ReverseLinkedList(DoubleLinkedNode head)
        {
            DoubleLinkedNode node = head;
            WriteLine("Before reverse");
            WriteLine(head.Previous == null);
            while(node != null)
            {
                WriteLine(node.Data);
                node = node.Next;
            }

            node = head;
            while (node != null)
            {
                var temp = node.Previous;
                node.Previous = node.Next;
                node.Next = temp;

                node = node.Previous;
            }


            WriteLine("Before reverse");
            WriteLine(head.Next == null);
            node = head;
            while (node != null)
            {
                WriteLine(node.Data);
                node = node.Previous;
            }


        }

        public static double FindSquareRoot(double value, double precison)
        {
            // iterative
            if (value == 1) return 1;

            double candidate = value/2;
            double high = value;
            double low = 0;
            
            for(;;)
            {
                double result = candidate * candidate;

                if (Abs(result - value) <= precison)
                {
                    return candidate;
                }
                
                if (result > value)
                {
                    high = candidate;
                    candidate = low + ((candidate - low)/2);
                }
                else
                {
                    low = candidate;
                    candidate = candidate + ((high - candidate) / 2);
                }
            }
        }

        private static double Abs(double value)
        {
            if (value < 0)
            {
                return value * -1;
            }
            return value;
        }

    }






}
