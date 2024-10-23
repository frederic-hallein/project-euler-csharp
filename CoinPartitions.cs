namespace project_euler
{
    /*
    Problem 78 - Coin Partitions

    Let p(n) represent the number of different ways in which n coins can be separated into piles. 
    For example, five coins can be separated into piles in exactly seven different ways, so p(5) = 7.

    OOOOO
    OOOO O
    OOO OO
    OOO O O
    OO OO O
    OO O O O
    O O O O O

    Find the least value of n for which p(n) is divisible by one million.
    */
    
    using System.Numerics;

    public class CoinPartitions
    {
        static readonly Dictionary<int, BigInteger> pDict = [];

        // calculates the partition function p(n) using the recurrence relations from https://en.wikipedia.org/wiki/Partition_function_(number_theory).
        public static BigInteger P(int n)
        {
            if (pDict.TryGetValue(n, out BigInteger pValue)) { return pValue; }
            else if (n == 0) { return 1; }
            else if (n < 0)  { return 0; }
            
            BigInteger p = 0;
            double lowerBound = - (Math.Sqrt(24 * n + 1) - 1) / 6;
            double upperBound =   (Math.Sqrt(24 * n + 1) + 1) / 6;

            for (int k = (int)Math.Ceiling(lowerBound); k <= upperBound; k++) {
                if (k != 0) {
                    int nPar = n - k * (3 * k - 1) / 2;
                    p += (BigInteger)Math.Pow(-1, k + 1) * P(nPar);
                }
            }

            pDict.Add(n, p);
            return p;   
        }
        
    }
}