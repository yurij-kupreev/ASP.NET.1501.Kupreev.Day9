using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1BinaryTree;
using Task3_BookService;
using ComparatorsForBinaryTreeTask;

namespace Task1UI
{
    class Program
    {
        struct Point2D
        {
            public int x;
            public int y;

            public Point2D(int x, int y)
            {
                this.x = x;
                this.y = y;
            }

            
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Cheking for int:");
            int[] array = new int[] { 3, 4, 5, 1, 12, 52, 11, 2 };
            BinaryTree<int> tree = new BinaryTree<int>(array);
            foreach (var a in tree.Inorder())
            {
                Console.Write(a + " ");
            }
            Console.WriteLine();
            tree = new BinaryTree<int>(array, new IntReverse());
            foreach (var a in tree.Inorder())
            {
                Console.Write(a + " ");
            }
            Console.WriteLine();

            Console.WriteLine("\nCheking for string:");
            String[] stringArray = { "Ben", "Ann", "Chack", "Peter", "Meg" };
            BinaryTree<String> tree2 = new BinaryTree<String>(stringArray);
            foreach (var a in tree2.Inorder())
            {
                Console.Write(a + " ");
            }
            Console.WriteLine();
            tree2 = new BinaryTree<String>(stringArray, new StringReverse());
            foreach (var a in tree2.Inorder())
            {
                Console.Write(a + " ");
            }
            Console.WriteLine();

            Console.WriteLine("\nCheking for book:");
            List<Book> bookList = new List<Book>(){ new Book("Tolstoy", "War and Peace", 1865, "St.Petersburg"),
                                                    new Book("Lermontov", "Hero of Our Time", 1840, "St.Petersburg"),
                                                    new Book("Lermontov", "Daemon", 1842, "Moscow")};
            BinaryTree<Book> tree3 = new BinaryTree<Book>(bookList);
            foreach (var a in tree3.Inorder())
            {
                Console.WriteLine(a);
            }
            Console.WriteLine();
            Console.WriteLine();
            tree3 = new BinaryTree<Book>(bookList, new YearDecrease());
            foreach (var a in tree3.Inorder())
            {
                Console.WriteLine(a);
            }
            Console.WriteLine();

            List<Point2D> pointList = new List<Point2D>() { new Point2D(1, 3), new Point2D(3, 2), new Point2D(2, 4) };
            try
            {
                BinaryTree<Point2D> tree4 = new BinaryTree<Point2D>(pointList);
                foreach (var a in tree4.Inorder())
                {
                    Console.Write(a + " ");
                }
            }
            catch (Exception e) { Console.WriteLine(e.Message); }

        }
    }
}
