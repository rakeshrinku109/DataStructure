using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListImplementation
{
    class Program
    {
        static void Main(string[] args)
        {

            BinaryTree<int> bt = new BinaryTree<int>();
            Stopwatch watch = new Stopwatch();
            watch.Start();
            for (int i = 0; i < 10000; i++)
            {
                bt.AddRecursion(i);
            }
           
            Console.WriteLine(watch.Elapsed);
            Console.ReadKey();
            

        }

  
        }
    }
