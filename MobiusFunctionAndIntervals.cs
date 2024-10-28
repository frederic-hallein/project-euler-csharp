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
        public static readonly List<int> distinctPrimes = [];

        
        // check whether n is square-free or not using the algorithm from https://www.geeksforgeeks.org/square-free-number/  
        // and add distinct primes to a list
        static bool IsSquareFree(int n)
        {
            if (n % 2 == 0) { distinctPrimes.Add(2); n /= 2; }
            if (n % 2 == 0) { distinctPrimes.Clear(); return false; }
            int i = 3;
            while (i <= Math.Sqrt(n)) {
                if (n % i == 0) {  
                    distinctPrimes.Add(i);       
                    n /= i;
                    if (n % i == 0) { distinctPrimes.Clear(); return false; }
                }   
                i += 2;
            }
            
            if (n > 1) { distinctPrimes.Add(n); }
            return true;
        }
        


        
        public static int Mu(int n)
        {
            if (IsSquareFree(n)) { 
                int omega = distinctPrimes.Count;
                return (int)Math.Pow(-1, omega); 
            }
            return 0;
        }



    }
}