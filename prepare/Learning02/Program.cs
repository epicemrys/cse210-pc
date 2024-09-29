using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job()
        {
            JobTitle = "Software Engineer",
            Company = "Microsoft",
            StartYear = 2019,
            EndYear = 2022
        };

        Job job2 = new Job()
        {
            JobTitle = "Manager",
            Company = "Apple",
            StartYear = 2022,
            EndYear = 2023
        };

        Console.WriteLine(job1.Company);
        Console.WriteLine(job2.Company);

        Resume myResume = new Resume()
        {
            Name = "Charles Ukoh",
            Jobs = new List<Job> { job1, job2 }
        };

        Console.WriteLine($"Name: {myResume.Name}");
        myResume.Display();
    }
}