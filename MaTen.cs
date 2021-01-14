namespace usefulCS
{
    struct MaTen
    {
        internal static bool IsEven(int n)
        {
            return 0 == (n & 1);
        }
        internal static bool IsOdd(int n)
        {
            return 1 == (n & 1);
        }
        internal static bool IsPowOf2(int n)
        {
            return 0 == (n & (--n));
        }
        internal static int Sum1toN(int n)
        {
            return (n * (n + 1)) >> 1;
        }
        internal static void Swap(ref int a, ref int b)
        {
            a ^= b;
            b ^= a;
            a ^= b;
        }
        internal static int GCD(int a, int b)
        {
            while (a != 0 && b != 0)
            {
                if (a > b) a %= b;
                else b %= a;
            }
            return a+b;
        }
        //----------------------------------------------------------------------
    }//s
}
