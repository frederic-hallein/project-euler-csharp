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

    class CoinPartitions
    {

        static ulong P_nr(int n, int r)
        {
            
            if      (n < r)      { return 0; }
            else if (n == r)     { return 1; }
            else if (n == r + 1) { return 1; }
            else if (r == 1)     { return 1; }
            else if (r == 2) {
                if (n % 2 == 0)  { return (ulong)(n / 2); }
                else             { return (ulong)((n - 1) / 2); }
            }
            
            else {               
                ulong p_nr = 0;
                for (int k = 1; k <= r; k++) { p_nr += P_nr(n - r, k); }
                return p_nr;
            }
        
        }




        static ulong P(long n)
        {

            if      (n == 0) { return 1; }
            else if (n < 0)  { return 0; }
            
            ulong p = 0;
            double lowerBound = - (Math.Sqrt(24 * n + 1) - 1) / 6;
            double upperBound =   (Math.Sqrt(24 * n + 1) + 1) / 6;



            for (long k = (long)Math.Ceiling(lowerBound); k <= upperBound; k++) {
                if (k != 0) {
                    long nPar = n - k * (3 * k - 1) / 2;
                    p += (ulong)(Math.Pow(-1, k + 1) * P(nPar));
                }
            }
            return p;
            
        }
        


        static void Main(string[] args)
        {
            /*
            int n = 0;
            ulong p_n = 0;

            // TODO : use Pentagonal number theorem to speed up calculations
            bool leastValueIsFound = false;
            while (!leastValueIsFound) {
                if (n == 0) { p_n++; }
                for (int r = 1; r <= n; r++) {
                    ulong p_nr = 0;
                    for (int k = 1; k <= r; k++) { p_nr += P_nr(n - r, k); }
                    if (n == r) { p_nr++;}
                    p_n += p_nr;
                } 

                Console.WriteLine($"p({n}) = {p_n}");
                if (p_n % 1000000 == 0) { leastValueIsFound = true; } 
                else { n++; p_n = 0; }
                
            }
            */
            

            ulong n = 0;
            ulong p;

            bool leastValueIsFound = false;
            while (!leastValueIsFound) {
                p = P((long)n); 
                Console.WriteLine($"p({n}) = {p}");
                if (p % 1000000 == 0) { leastValueIsFound = true; } 
                else { n++; }
                
            }
            
        }
    }
}