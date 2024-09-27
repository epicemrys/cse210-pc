using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
   static void Main(string[] args)
   {
       List<int> numbers = new List<int>();
       int num;

       // Ask user for series of numbers
       while (true)
       {
           Console.Write("Enter number: ");
           num = int.Parse(Console.ReadLine());
           if (num == 0)
           {
               break;
           }
           
           numbers.Add(num);
       }

       // Record the sum of the numbers in the list
       int sum = numbers.Sum();

       // Record the average of the numbers in the list
       double average = numbers.Average();

       // Find the maximum number
       int max = numbers.Max();

       // Display the sum, average, and maximum
       Console.WriteLine($"The sum is: {sum}");
       Console.WriteLine($"The average is: {average}");
       Console.WriteLine($"The largest number is: {max}");

       // Stretch Challenge:
       var positiveNumbers = numbers.Where(n => n > 0).ToList();

       if (positiveNumbers.Any())
       {
           // Find the smallest positive number closest to zero
           int smallestPositive = positiveNumbers.Min();

           Console.WriteLine($"The smallest positive number is: {smallestPositive}");

           // Sort list
           numbers.Sort();

           Console.WriteLine("The sorted list is:");
           foreach (var sortedNum in numbers)
           {
               Console.WriteLine(sortedNum);
           }
       }
   }
}