public class Circle : Shape  // Circle Class
{
    private double Radius { get; }  // Radius of the circle

    // Constructor
    public Circle(string color, double radius) : base (color)
    {
        Radius = radius;
    }

    // Override GetArea method to calculate area of the circle
    public override double GetArea()
    {
        return Math.PI * Radius * Radius;  //
    }
}