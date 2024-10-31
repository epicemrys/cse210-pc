using System;
using System.Collections.Generic;

// This Base class will represent a generic Activity
public abstract class Activity
{
    // Private member variables for shared attributes
    private DateTime date;
    private int minutes;

    // Constructor to initialize common attributes
    public Activity(DateTime date, int minutes)
    {
        this.date = date;             // Date of the activity
        this.minutes = minutes;       // Length of the activity in minutes
    }

    // Protected property to access teh minutes from derived classes
    protected int Minutes => minutes;

    // Virtual methods for distance, speed, and the pace
    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();

    // The ethod to get a summary of the activity
    public virtual string GetSummary()
    {
        return $"{date.ToString("dd MMM yyyy")} - {GetType().Name} ({minutes} min) - Distance: {GetDistance():0.0}, Speed: {GetSpeed():0.0}, Pace: {GetPace():0.0} min per unit.";
    }
}

// Derived class for Running activities
public class Running : Activity
{
    private double distance; // in miles

    // Constructor with distance parameter
    public Running(DateTime date, int minutes, double distance) : base(date, minutes)
    {
        this.distance = distance; // Distance run in miles
    }

    // Calculate distance (already in stored)
    public override double GetDistance()
    {
        return distance;
    }

    // Calculate speed in mph
    public override double GetSpeed()
    {
        return (distance / Minutes) * 60;
    }

    // Calculate the pace in minutes per mile
    public override double GetPace()
    {
        return Minutes / distance;
    }
}

// Derived class for Cycling activities
public class Cycling : Activity
{
    private double speed; // in mph

    // Constructor with speed parameter
    public Cycling(DateTime date, int minutes, double speed) : base(date, minutes)
    {
        this.speed = speed; // Speed in mph
    }

    // Calculate distance based on speed
    public override double GetDistance()
    {
        return (speed * Minutes) / 60; // Distance = (speed*minutes)/60
    }

    // Return the speed (stored directly)
    public override double GetSpeed()
    {
        return speed; // Return the speed in mph
    }

    // Calculate pace in minutes per mile
    public override double GetPace()
    {
        return 60 / speed; // Pace = 60/speed
    }
}

// Derived class for Swimming activities
public class Swimming : Activity
{
    private int laps; // Number of laps swum

    // Constructor with laps parameter
    public Swimming(DateTime date, int minutes, int laps) : base(date, minutes)
    {
        this.laps = laps; // Laps swum
    }

    // Calculate distance swum in km
    public override double GetDistance()
    {
        double distanceInMeters = laps * 50; // Laps of 50 meters each
        return distanceInMeters / 1000; // Convert to kilometers
    }

    // Calculate speed in kph
    public override double GetSpeed()
    {
        return (GetDistance() / Minutes) * 60; // Speed = (distance/minutes)*60
    }

    // Calculate pace in minutes per kilometer
    public override double GetPace()
    {
        return Minutes / GetDistance(); // Pace = minutes/distance
    }
}

// Main program class
class Program
{
    static void Main(string[] args)
    {
        // Create a list to hold different activities
        List<Activity> activities = new List<Activity>();

        // Instances of each activity type and add to the list
        activities.Add(new Running(new DateTime(2024, 10, 24), 30, 3.0)); // 3 miles in 30 min
        activities.Add(new Cycling(new DateTime(2024, 10, 26), 30, 15.0)); // 15 mph in 30 min
        activities.Add(new Swimming(new DateTime(2024, 10, 27), 30, 20)); // 20 laps in 30 min

       // Loop through each activity and print the summary
        foreach (var activity in activities)
        {
            Console.WriteLine();
            Console.WriteLine(activity.GetSummary());
            Console.WriteLine();
        }
    }
}