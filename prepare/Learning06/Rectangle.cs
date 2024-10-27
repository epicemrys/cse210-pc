public class Rectangle : Shape  // Rectangle
{
    private double Length { get; }  
    private double Width { get; }   

    // Constructor
    public Rectangle(string color, double length, double width) : base(color)
    {
        Length = length;
        Width = width;
    }

    // Override GetArea
    public override double GetArea()
    {
        return Length * Width;  // Area calculation for rectangle
    }
}