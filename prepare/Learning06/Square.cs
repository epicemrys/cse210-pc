// Square class to represent a square shape
public class Square : Shape
{
    private double Side { get; }  // Length of the side

    // Constructor
    public Square(string color, double side) : base(color)
    {
        Side = side;
    }

    // Override GetArea method to calculate the area of the square here
    public override double GetArea()
    {
        return Side * Side;  // Area calculation for the squares
    }
}