using System;

class Program
{
    static void Main(string[] args)
    {
        // Test the Assignment class
        Console.WriteLine();
        Assignment assignment = new Assignment("Samuel Bennett", "Multiplication");
        Console.WriteLine(assignment.GetSummary()); // Samuel Bennett - Multiplication

        // Test the MathAssignment class
        MathAssignment mathAssignment = new MathAssignment("Roberto Rodriguez", "Fractions", "7.3", "8-19");
        Console.WriteLine(mathAssignment.GetSummary()); //  Roberto Rodriguez - Fractions
        Console.WriteLine(mathAssignment.GetHomeworkList()); // Section 7.3 Problems 8-19

        // Test the WritingAssignment class
        WritingAssignment writingAssignment = new WritingAssignment("Mary Waters", "European History", "The Causes of World War II");
        Console.WriteLine(writingAssignment.GetSummary()); // Mary Waters - European History
        Console.WriteLine(writingAssignment.GetWritingInformation()); //  The Causes of World War II by Mary Waters
        Console.WriteLine();
    }
}