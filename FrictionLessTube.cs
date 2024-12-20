using System.Numerics;



namespace project_euler 
{
    /*
    Problem 653 - Frictionless Tube

    Consider a horizontal frictionless tube with length L millimetres, and a diameter of 20 millimetres. The east end of the tube is 
    open, while the west end is sealed. The tube contains N marbles of diameter 20 millimetres at designated starting locations, 
    each one initially moving either westward or eastward with common speed v.

    Since there are marbles moving in opposite directions, there are bound to be some collisions. We assume that the collisions are 
    perfectly elastic, so both marbles involved instantly change direction and continue with speed v away from the collision site. 
    Similarly, if the west-most marble collides with the sealed end of the tube, it instantly changes direction and continues eastward at 
    speed v. On the other hand, once a marble reaches the unsealed east end, it exits the tube and has no further interaction with the 
    remaining marbles.

    To obtain the starting positions and initial directions, we use the pseudo-random sequence r_j defined by:

        r_1 = 6 563 116
        r_{j + 1} = r^2_j mod 32 745 673

    The west-most marble is initially positioned with a gap of (r_1 mod 1000) + 1 millimetres between it and the sealed end of the 
    tube, measured from the west-most point of the surface of the marble. Then, for 2 <= j <= N, counting from the west, the gap 
    between the (j - 1)th and jth marbles, as measured from their closest points, is given by (r_j mod 1000) + 1 millimetres. 
    Furthermore, the jth marble is initially moving eastward if r_j <= 10 000 000, and westward if r_j > 10 000 000.

    For example, with N = 3, the sequence specifies gaps of 117, 432, and 173 millimetres. The marbles' centres are therefore 127, 
    579, and 772 millimetres from the sealed west end of the tube. The west-most marble initially moves eastward, while the other
    two initially move westward.

    Under this setup, and with a five metre tube (L = 5000), it turns out that the middle (second) marble travels 5519 millimetres 
    before its centre reaches the east-most end of the tube.

    Let d(L, N, j) be the distance in millimetres that the jth marble travels before its centre reaches the eastern end of the tube. So 
    d(5000, 3, 2) = 5519. You are also given that d(10 000, 11, 6) = 11 780 and d(100 000, 101, 51) = 114 101.

    Find d(1 000 000 000, 1 000 001, 500 001).
    */

    public class FrictionLessTube
    {

        struct Marble(uint r, int v)
        {
            public uint r = r;
            public int v = v;
        }


        private static uint R(int j)
        {
            if (j == 1) { return 6_563_116; }
            return R(j - 1) * R(j - 1) % 32_745_673;
        }

        private static uint DeltaR(uint r) { return (r % 1000) + 1; }


        public static BigInteger D(uint L, uint N, uint j) 
        {
            Marble[] marbles = new Marble[N+1];
            marbles[0] = new Marble(0, 0); 
            for (int m = 1; m <= N; m++) {
                uint r = R(m);
                int v = 1;
                if (r > 10_000_000) { v = -1; }

                marbles[m] = new Marble(r, v); 
            }

            for (int m = 0; m < N; m++) {
                uint r1 = marbles[m+1].r;
                uint r2 = marbles[m].r;
                uint r = r2 - r1 - 20;
                uint deltaR = DeltaR(r);
                Console.WriteLine($"{deltaR}");
            }

            return 0;
        }


    }
}