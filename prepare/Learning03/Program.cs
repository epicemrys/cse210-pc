using System;

namespace FractionExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Fractions.Fraction fraction1 = new Fractions.Fraction();  // 1/1
            Fractions.Fraction fraction2 = new Fractions.Fraction(5); // 5/1
            Fractions.Fraction fraction3 = new Fractions.Fraction(6, 7); // 6/7

            Console.WriteLine(fraction1.GetFractionString());
            Console.WriteLine(fraction2.GetFractionString());
            Console.WriteLine(fraction3.GetFractionString());

            Console.WriteLine(fraction1.GetDecimalValue());
            Console.WriteLine(fraction2.GetDecimalValue());
            Console.WriteLine(fraction3.GetDecimalValue());
        }
    }
}