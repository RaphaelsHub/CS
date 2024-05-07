namespace SharpReminder;

public class PointRef
{
    public int Y { get; set; }
    public int X { get; set; }
    
    public void Print()
    {
        Console.WriteLine(X + " " +  Y);
    }

    public PointRef()
    {
        
    }
}