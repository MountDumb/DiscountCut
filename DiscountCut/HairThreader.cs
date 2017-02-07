using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace DiscountCut
{
    public class HairThreader
    {
        #region fields
        Scissor ab;
        Scissor bc;
        Scissor cd;
        Scissor de;
        Scissor ef;
        Scissor fa;

        Chair a;
        Chair b;
        Chair c;
        Chair d;
        Chair e;
        Chair f;

        Thread t1;
        Thread t2;
        Thread t3;
        Thread t4;
        Thread t5;
        Thread t6;
        #endregion


        #region Constructors
        public HairThreader()
        {
            ab = new Scissor("AB");
            bc = new Scissor("BC");
            cd = new Scissor("CD");
            de = new Scissor("DE");
            ef = new Scissor("EF");
            fa = new Scissor("FA");

            a = new Chair("A", fa, ab);
            b = new Chair("B", ab, bc);
            c = new Chair("C", bc, cd);
            d = new Chair("D", cd, de);
            e = new Chair("E", de, ef);
            f = new Chair("F", ef, fa);

            
        }
        #endregion

        #region Methods

        public void RunHair(Chair chair)
        {
            while (chair.SessionsLeft > 0) 
            {
                
                chair.TryGetScissors();
                                
            }
            if (chair.SessionsLeft == 0)
            {
                Console.WriteLine(chair.Designation + " has finished");
            }
              
            
        }

        public void MakeThreads()
        {
            t1 = new Thread(() => RunHair(a));
            t2 = new Thread(() => RunHair(b));
            t3 = new Thread(() => RunHair(c));
            t4 = new Thread(() => RunHair(d));
            t5 = new Thread(() => RunHair(e));
            t6 = new Thread(() => RunHair(f));
            
        }

        public void Runthreads()
        {
            t1.Start();
            //Thread.Sleep(10);
            t2.Start();
            //Thread.Sleep(10);
            t3.Start();
           // Thread.Sleep(10);
            t4.Start();
            //Thread.Sleep(10);
            t5.Start();
            //Thread.Sleep(10);
            t6.Start();
        }
       
        #endregion


    }
}
