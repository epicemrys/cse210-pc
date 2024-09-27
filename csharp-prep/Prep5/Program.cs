using System;

class Program
{
    static void Main(string[] args)
    {
       string userName = PromptUserName();
       int userNumber = PromptUserNumber();
       int squaredNumber = SquareNumber(userNumber);
       
       DisplayWelcome();
       DisplayResult(userName, squaredNumber);
   }

   static void DisplayWelcome()
   {
       Console.WriteLine("Welcome to the program!"); // Display Welcome
   }

   static string PromptUserName()
   {
       Console.Write("Please enter your name: "); // Ask user for name
       return Console.ReadLine();
   }

   static int PromptUserNumber()
   {
       Console.Write("Please enter your favorite number: "); // Ask user for favorite number
       return Convert.ToInt32(Console.ReadLine());
   }

   static int SquareNumber(int num)
   {
       return num * num;
   }

   static void DisplayResult(string name, int squaredNum)
   {
       Console.WriteLine($"{name}, the square of your number is {squaredNum}");
   }
}