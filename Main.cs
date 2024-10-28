using System.Numerics;

namespace project_euler 
{
    public class MainClass 
    {
        static void Main()
        {   
            int n;
            var watch = new System.Diagnostics.Stopwatch();
            watch.Start();
            
            int problem = 2;
            switch(problem) {
                case 1:
                    n = 0;
                    BigInteger p;
                    int divisor = 1_000_000;

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
 
                    n = 10_000;  
                    BigInteger C = MobiusFunctionAndIntervals.C(n);
                    Console.WriteLine($"\nWe find C({n}) = {C}");
                    break; 

                default:
                    break;

            }    


            watch.Stop();
            Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");

            
        }

    }

}