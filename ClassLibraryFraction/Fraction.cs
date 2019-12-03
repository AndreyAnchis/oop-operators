using System;

namespace ClassLibraryFraction
{
    public class Fraction
    {
        protected long Numerator;
        protected long Denominator;

        public Fraction(long numer, long denom)
        {
            Numerator = numer;
            Denominator = denom;
        }
        public Fraction(long numer)
        {
            Numerator = numer;
            Denominator = 1;
        }
        public void Fix()
        {
            if ((Numerator <= 0 && Denominator <= 0) || (Numerator >= 0 && Denominator <= 0))
            {
                Numerator = -Numerator;
                Denominator = -Denominator;
            }
        }
        public void Simplify()
        {
            long i = 0;
            long lcm = 0;
            if(Numerator < 0 && Denominator > 0)
            {
                Numerator *= -1;
            }
            if (Numerator > Denominator)
            {
                i = Denominator;
            }
            else i = Numerator;

            while (i > 0 && lcm == 0)
            {
                if ((Numerator % i == 0) && (Denominator % i == 0))
                    lcm = i;
                i--;
            }
            Numerator = Numerator / lcm;
            Denominator = Denominator / lcm;

            
        }

        // Перегружаем унарный оператор ++
        public static Fraction operator ++(Fraction a)
        {
            Fraction res = new Fraction(a.Numerator + a.Denominator, a.Denominator);
            return res;
        }

        // Перегружаем унарный оператор --
        public static Fraction operator --(Fraction a)
        {
                Fraction res = new Fraction(a.Numerator - a.Denominator, a.Denominator);
                return res;
        }

        // Перегружаем унарный оператор -
        public static Fraction operator -(Fraction a)
        {
            return new Fraction(-a.Numerator, a.Denominator);
        }

        // Перегружаем унарный оператор !
        public static Fraction operator !(Fraction a)
        {
            Fraction res = new Fraction(a.Denominator, a.Numerator);
            res.Fix();
            return res;
        }

        // Перегружаем бинарный оператор +
        public static Fraction operator +(Fraction a, Fraction b)
        {
            Fraction res = new Fraction(a.Numerator * b.Denominator + a.Denominator * b.Numerator, a.Denominator * b.Denominator);
            res.Simplify();
            return res;
        }
        public static Fraction operator +(Fraction a, long b)
        {
            Fraction res = a + new Fraction(b);
            res.Simplify();
            return res;
        }
        public static Fraction operator +(long a, Fraction b)
        {
            Fraction res = new Fraction(a) + b;
            res.Simplify();
            return res;
        }

        // Перегружаем бинарный оператор -
        public static Fraction operator -(Fraction a, Fraction b)
        {
            Fraction res = new Fraction(a.Numerator * b.Denominator - a.Denominator * b.Numerator, a.Denominator * b.Denominator);
            res.Simplify();
            return res;
        }
        public static Fraction operator -(Fraction a, long b)
        {
            Fraction res = a - new Fraction(b);
            res.Simplify();
            return res;
        }
        public static Fraction operator -(long a, Fraction b)
        {
            Fraction res = new Fraction(a) - b;
            res.Simplify();
            return res;
        }

        // Перегружаем бинарный оператор *
        public static Fraction operator *(Fraction a, Fraction b)
        {
            Fraction res = new Fraction(a.Numerator * b.Numerator, a.Denominator * b.Denominator);
            res.Simplify();
            return res;
        }
        public static Fraction operator *(Fraction a, long b)
        {
            Fraction res = a * new Fraction(b);
            res.Simplify();
            return res;
        }
        public static Fraction operator *(long a, Fraction b)
        {
            Fraction res = new Fraction(a) * b;
            res.Simplify();
            return res;
        }

        // Перегружаем бинарный оператор /
        public static Fraction operator /(Fraction a, Fraction b)
        {
            Fraction res = a * !b;
            res.Simplify();
            return res;
        }
        public static Fraction operator /(Fraction a, long b)
        {
            Fraction res = a * !new Fraction(b);
            res.Simplify();
            return res;
        }
        public static Fraction operator /(long a, Fraction b)
        {
            Fraction res = new Fraction(a) * !b;
            res.Simplify();
            return res;
        }
        // Перегружаем логический оператор ==
        public static bool operator ==(Fraction a, Fraction b)
        {
            if (a.Numerator == b.Numerator && a.Denominator == b.Denominator)
                return true;
            return false;
        }

        // Oбязательно перегрузить логический оператор !=
        public static bool operator !=(Fraction a, Fraction b)
        {
            if (a.Denominator != b.Denominator)
            return true;
                return false;
        }

        // Перегружаем логический оператор >
        public static bool operator >(Fraction a, Fraction b)
        {
            long temp = 0;
            if (a.Denominator != b.Denominator)
             {
                 a.Numerator = a.Numerator * b.Denominator;
                 b.Numerator = b.Numerator * a.Denominator;
                 temp = a.Denominator;
                 a.Denominator = a.Denominator * b.Denominator;                
                 b.Denominator = temp * b.Denominator;
            }
            if (a.Numerator > b.Numerator)
            {
                a.Simplify();
                b.Simplify();
                return true;
            }
            else
            {
                a.Simplify();
                b.Simplify();
                return false;
            }
        }

        // Oбязательно перегрузить логический оператор <
        public static bool operator <(Fraction a, Fraction b)
        {
            long temp = 0;
            if (a.Denominator != b.Denominator)
             {
                 a.Numerator = a.Numerator * b.Denominator;
                 b.Numerator = b.Numerator * a.Denominator;
                 temp = a.Denominator;
                 a.Denominator = a.Denominator * b.Denominator;                
                 b.Denominator = temp * b.Denominator;
            }
             if (a.Numerator < b.Numerator)
             {
                 a.Simplify();
                 b.Simplify();
                 return true;
             }
             else
             {
                 a.Simplify();
                 b.Simplify();
                 return false;
             }
        }
        // Перегружаем логический оператор >
        public static bool operator >=(Fraction a, Fraction b)
        {
            long temp = 0;
            if (a.Denominator != b.Denominator)
            {
                a.Numerator = a.Numerator * b.Denominator;
                b.Numerator = b.Numerator * a.Denominator;
                temp = a.Denominator;
                a.Denominator = a.Denominator * b.Denominator;
                b.Denominator = temp * b.Denominator;
            }
            if (a.Numerator >= b.Numerator)
            {
                a.Simplify();
                b.Simplify();
                return true;
            }
            else
            {
                a.Simplify();
                b.Simplify();
                return false;
            }
        }

        // Oбязательно перегрузить логический оператор <=
        public static bool operator <=(Fraction a, Fraction b)
        {
            long temp = 0;
            if (a.Denominator != b.Denominator)
            {
                a.Numerator = a.Numerator * b.Denominator;
                b.Numerator = b.Numerator * a.Denominator;
                temp = a.Denominator;
                a.Denominator = a.Denominator * b.Denominator;
                b.Denominator = temp * b.Denominator;
            }
            if (a.Numerator <= b.Numerator)
            {
                a.Simplify();
                b.Simplify();
                return true;
            }
            else
            {
                a.Simplify();
                b.Simplify();
                return false;
            }
        }
        // Переопределяем метод ToString()
        public override string ToString()
        {
            return $"{Numerator}/{Denominator}";
        }

        // Использование явного преобразования в тип double
        public static explicit operator double(Fraction a)
        {
            return (double)a.Numerator / a.Denominator;
        }  
    }
}
