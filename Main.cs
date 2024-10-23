using System.Numerics;

namespace project_euler 
{
    public class MainClass 
    {
        static void Main()
        {   
            int n;
            
            int problem = 2;
            switch(problem) {
                case 1:
                    n = 0;
                    BigInteger p;
                    int divisor = 1000000;

                    bool leastValueIsFound = false;
                    while (!leastValueIsFound) {
                        p = CoinPartitions.P(n); 
                        Console.WriteLine($"p({n}) = {p}");
                        if (p % divisor == 0) { 
                            leastValueIsFound = true; 
                            Console.WriteLine($"\nThe least value of n for which p(n) is divisible by {divisor} is n = {n}."); 
                        }
                        else { n++; }
                        
                    }
                    break;
                    
                case 2:
 
                    n = 500;

                    int C = 0;
                    for (int a = 1; a <= n; a++) {
                        for (int b = a; b <= n; b++) {
                            int P = 0;
                            int N = 0;
                            for (int m = a; m <= b; m++) {
                                int mu = MobiusFunctionAndIntervals.Mu(m);
                                if      (mu ==  1) { P++; }
                                else if (mu == -1) { N++; } 
                                MobiusFunctionAndIntervals.distinctPrimes.Clear();
                            }

                            Console.WriteLine($"P({a},{b}) = {P}, N({a},{b}) = {N}");
                            if (99 * N <= 100 * P && 99 * P <= 100 * N) { C++; }

                            
                                
                        }
                    }

                    Console.WriteLine($"\nWe find C({n}) = {C}");
                    break; 

                default:
                    break;

            }    




            
        }

    }

}