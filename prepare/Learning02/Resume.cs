using System;
using System.Collections.Generic;

public class Resume
{
    public string Name;
    public List<Job> Jobs;

    public void Display()
    {
        Console.WriteLine("Jobs:");
        foreach (Job job in Jobs)
        {
            job.Display();
        }
    }
}