using System;

public class Job
{
    public string Company;
    public string JobTitle;
    public int StartYear;
    public int EndYear;

    public void Display()
    {
        Console.WriteLine($"{JobTitle} ({Company}) {StartYear}-{EndYear}");
    }
}