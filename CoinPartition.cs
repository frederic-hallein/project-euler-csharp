namespace project_euler
{
    class CoinPartition
    {

        static int P_nr(int n, int r)
        {

            if (n < r)           { return 0; }
            else if (n == r)     { return 1; }
            else if (n == r + 1) { return 1; }
            else if (r == 1)     { return 1; }
            else if (r == 2) {
                if (n % 2 == 0)  { return n / 2; }
                else             { return (n - 1) / 2; }
            }
            
            else {               
                int p_nr = 0;
                for (int k = 1; k <= r; k++)
                {
                    p_nr += P_nr(n - r, k);
                }
                return p_nr;
            }
        
        }


        static void Main(string[] args)
        {
            int n = 6;
            int r = 3;

            int p_nr = 0;
            for (int k = 1; k <= r; k++)
            {
                p_nr += P_nr(n - r, k);
            }
        

            Console.WriteLine("p(" + n + ", " + r + ") = " + p_nr);
        }
    }
}