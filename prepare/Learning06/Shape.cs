using System;

public class Shape  // This shape class is to represent the base shape with color and GetArea method

{
    public string Color { get; }      // Constructor


    public Shape(string color)
    {
        Color = color;
    }
    
        // Calculate area, override in derived classes

    public virtual double GetArea()
    {
        return 0;  // The default
    }
}