using System;
using ClassLibraryFraction;

namespace fractions
{
    class Program
    {
        static void Main(string[] args)
        {
            Fraction a = new Fraction(8, 12);
            Fraction b = new Fraction(2, 6);
            Fraction c = new Fraction(4, 11);
            Fraction d = new Fraction(3, 6);
            Fraction e = new Fraction(2, 6);

            if (a == c)
                Console.WriteLine("Объекты равны");
            else if (a != c)
                Console.WriteLine("Объекты не равны");

            if (a > c)
                Console.WriteLine("a > c");
            else  if (a < c)
                Console.WriteLine("a < c");

            if (a < c)
                Console.WriteLine("a < c");
            else if (a > c)
                Console.WriteLine("a > c");

            if (d <= e)
                Console.WriteLine("d <= e");
            else if (d >= e)
                Console.WriteLine("d >= e");
            Fraction res1 = a * b;
            double res_double = (double)res1;
            Console.WriteLine(res1);
            Console.WriteLine(res_double);

            Fraction res2 = a / !b;
            Console.WriteLine(res2);

            Fraction res3 = a - (-b);
            Console.WriteLine(res3);

            Fraction res4 = ++a;
            Console.WriteLine(res4);

            
        }
    }
}
