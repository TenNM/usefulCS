using System;
using StringService;

namespace usefulCS
{
    class Program
    {      
        static void Main(string[] args)
        {
            //Console.WriteLine(MaTen.IsPowOf2(0));
            string s = "1,23";

            Console.WriteLine(s);
            Console.WriteLine(s.DotsToCommas());
            Console.WriteLine(s.StringIsNumber());
            Console.WriteLine(s.Reverse());
            Console.WriteLine(s.ReplaceFirst("23", "45"));

            Console.ReadKey();
        }//m
    }//c
}
