namespace SharpReminder;

public struct PointVal
{
    public int Y { get; set; }
    public int X { get; set; }
    
    public void Print()
    {
        Console.WriteLine(X + " " + Y);
    }
}