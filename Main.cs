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
 
                    n = 10000;  

                    
                    BigInteger C = 0;
                    Dictionary<int, int> muDict = [];

                    for (int b = 1; b <= n; b++) {
                        int mu = MobiusFunctionAndIntervals.Mu(b);
                        muDict.Add(b, mu);
                        MobiusFunctionAndIntervals.distinctPrimes.Clear();
                        Console.WriteLine(b);
    
                        int P = 0;
                        int N = 0;
                        for (int a = b; a >= 1; a--) {

                            if      (muDict[a] ==  1) { P++; }
                            else if (muDict[a] == -1) { N++; }

                            
                            if (99 * N <= 100 * P && 99 * P <= 100 * N) { C++; }
                        }
                        
                    }
                    
                    
                    
                    
                    /*
                    int[] muArray = new int[n];
                    for (int i = 1; i <= n; i++) {
                        int mu = MobiusFunctionAndIntervals.Mu(i);
                        muArray[i-1] = mu;
                        Console.WriteLine($"{i} : {mu}");
                        MobiusFunctionAndIntervals.distinctPrimes.Clear();
                    }

                    

                    List<ArraySegment<int>> subIntervals = [];
                    for (int a = 1; a <= n; a++) {
                        for (int b = a; b <= n; b++) {
                            var subInterval = new ArraySegment<int>(muArray, a - 1, b - a + 1);
                            //Console.WriteLine($"{a},{b}");
                            subIntervals.Add(subInterval);
                            
                                
                        }
                    } 
                    

                    int C = 0;
                    foreach (ArraySegment<int> subInterval in subIntervals) {
                        int P = 0;
                        int N = 0;

                        var dict = new Dictionary<int, int>() {{-1, 0} , {0, 0}, {1, 0}};
                        foreach(int m in subInterval)
                        {
                            // When the key is not found, "count" will be initialized to 0
                            dict.TryGetValue(m, out int count);
                            dict[m] = count + 1;
                        }

                        P = dict[1];
                        N = dict[-1];

                        //Console.WriteLine($"P({a},{b}) = {P}, N({a},{b}) = {N}");
                        //Console.WriteLine($"P = {P}, N = {N}");
                        if (99 * N <= 100 * P && 99 * P <= 100 * N) { C++; }

                    }     
                    */


                    
                    
                    /*
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
                    */
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