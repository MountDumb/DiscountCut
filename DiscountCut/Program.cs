using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountCut
{
    class Program
    {
        public static void Main(string[] args)
        {
            HairThreader ht = new HairThreader();
            ht.MakeThreads();
            ht.Runthreads();
            Console.ReadKey();
        }
    }
}
