using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp.Algorithm.Custom
{
    /// <summary>
    /// 
    /// </summary>
    class FibonacciSequence:IRunAlgorithm
    {
        int[] _list;

        public FibonacciSequence()
        {
            _list = new int[] {0, 1, 1, 2, 3, 5, 8 };
        }
        
        public int GetIndexNumber(int index)
        {
            if (index<=3)
            {
                return _list[index];
            }
            return GetIndexNumber(index-1) + GetIndexNumber(index - 2);
        }

        public void Run()
        {
            GetIndexNumber(7);
        }
    }
}
