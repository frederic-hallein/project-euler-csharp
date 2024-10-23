using System.Numerics;

namespace project_euler 
{
    public class MainClass 
    {
        static void Main()
        {           
            /*
            int n = 0;
            BigInteger p;
            int divisor = 1000000;

            bool leastValueIsFound = false;
            while (!leastValueIsFound) {
                p = P(n); 
                Console.WriteLine($"p({n}) = {p}");
                if (p % divisor == 0) { 
                    leastValueIsFound = true; 
                    Console.WriteLine($"\nThe least value of n for which p(n) is divisible by {divisor} is n = {n}."); 
                }
                else { n++; }
                
            }
            */


            // In [2,10], squarefree numbers: 2, 3, 5, 6, 7, 10
            // P(2,10) = 2, i.e. 6, 10
            // N(2,10) = 4, i.e. 2, 3, 5, 7 
            int a = 2;
            int b = 10;

            int P = 0;
            int N = 0;
            for (int n = a; n <= b; n++) {
                int mu = MobiusFunctionAndIntervals.Mu(n);
                if (mu == 1) { P++; }
                else if (mu == -1) { N++; } 
                MobiusFunctionAndIntervals.distinctPrimes.Clear();
            }

            Console.WriteLine($"P({a},{b}) = {P}, N({a},{b}) = {N}");


            
        }

    }

}