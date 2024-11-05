using System.Numerics;



namespace project_euler 
{
    /*
    Problem 464 - Möbius Function and Intervals

    The Möbius function, denoted μ(n), is defined as:

        • μ(n) = (-1)^ω(n)      if n is squarefree (where ω(n) is the number of distinct prime factors of n)
        • μ(n) = 0              if n is not squarefree.
    
    Let P(a,b) be the number of integers n in the interval [a,b] such that μ(n) = 1.
    Let N(a,b) be the number of integers n in the interval [a,b] such that μ(n) = -1.
    For example, P(2,10) = 2 and N(2,10) = 4. 

    Let C(n) be the number of integer pairs (a,b) such that:

        • 1 <= a <= b <= n,
        • 99 N(a,b) <= 100 P(a,b), and
        • 99 P(a,b) <= 100 N(a,b).

    For example, C(10) = 13, C(500) = 16676 and C(10 000) = 20155319.
    Find C(20 000 000).
    */

    public class MobiusFunctionAndIntervals
    {
        // TODO : try again saving primes to file




        static readonly Dictionary<int, bool> isPrimeDict = [];

        public static void SieveOfEratosthenes(int n) 
        {
            bool[] isPrime = new bool[n + 1];
            for (int i = 2; i <= n; i++) { isPrime[i] = true; }

            for (int p = 2; p * p <= n; p++) {
                if (isPrime[p]) {
                    for (int i = p * p; i <= n; i += p) { isPrime[i] = false; }
                }
            }

            for (int i = 0; i <= n; i++) {
                isPrimeDict.Add(i, isPrime[i]);
                Console.WriteLine($"{i} : {isPrimeDict[i]}");
            }


        }
        
        // check whether n is square-free or not using the algorithm from https://www.geeksforgeeks.org/square-free-number/  
        static BigInteger Omega(int n) 
        {
            if (isPrimeDict[n]) { return 1; }

            List<int> distinctPrimes = [];
            if (n % 2 == 0) { distinctPrimes.Add(2); n /= 2; }
            if (n % 2 == 0) { distinctPrimes.Clear(); return -1; }
            int i = 3;
            while (i * i <= n) {
                if (n % i == 0) {  
                    distinctPrimes.Add(i);       
                    n /= i;
                    if (n % i == 0) { distinctPrimes.Clear(); return -1; }
                }   
                i += 2;
            }
            
            if (n > 1) { distinctPrimes.Add(n); }
            return distinctPrimes.Count;
        }
        

        static int Mu(int n)
        {
            BigInteger omega = Omega(n);
            if (omega >= 0) { return (int)Math.Pow(-1, (double)omega); }
            return 0;
        }
        
        
        public static BigInteger C(int n) {
            Dictionary<int, int> muDict = [];
            BigInteger C = 0;
            BigInteger CPrev = 0;
            int cnt = 1; 
            for (int b = 1; b <= n; b++) {
                BigInteger CTmp = 0;
                int mu = Mu(b);
                muDict.Add(b, mu);
                Console.WriteLine($"n = {b}");
                
                if (mu == 0) { C += CPrev + cnt; cnt++; }
                else {
                    cnt = 1;
                    int P = 0;
                    int N = 0;
                    for (int a = b; a >= 1; a--) {

                        if      (muDict[a] ==  1) { P++; }
                        else if (muDict[a] == -1) { N++; }
                        //Console.WriteLine($"P({a},{b}) = {P}, N({a},{b}) = {N}");
                        if (99 * N <= 100 * P && 99 * P <= 100 * N) { CTmp++; }
                    }

                    CPrev = CTmp;
                    C += CPrev;

                }
                

                
            }

            return C;

        }
        




    }
}