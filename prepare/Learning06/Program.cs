using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Creating list of shapes
        List<Shape> shapes = new List<Shape>();

        // Add shapes t list
        shapes.Add(new Square("Red", 4));
        shapes.Add(new Rectangle("Blue", 3, 5));
        shapes.Add(new Circle("Green", 2.5));

        // Iterate through the list of shapes provided
        foreach (var shape in shapes)
        {
            Console.WriteLine($"Shape: {shape.GetType().Name}, Color: {shape.Color}, Area: {shape.GetArea()}");
            Console.WriteLine();
        }
    }
}