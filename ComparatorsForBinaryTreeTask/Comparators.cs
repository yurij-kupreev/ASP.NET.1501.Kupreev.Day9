using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task3_BookService;

namespace ComparatorsForBinaryTreeTask
{
    public class IntReverse : IComparer<int>
    {
        public int Compare(int left, int right)
        {
            return right.CompareTo(left);
        }
    }

    public class StringReverse : IComparer<String>
    {
        public int Compare(String left, String right)
        {
            return right.CompareTo(left);
        }
    }
}
