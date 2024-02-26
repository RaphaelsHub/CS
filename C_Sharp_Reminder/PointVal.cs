using System.Security.Principal;

namespace C_Sharp_Reminder;

public struct PointVal
{
    public int Y { get; set; }
    public int X { get; set; }

    public void Print()
    {
        Console.WriteLine(X + " " + Y);
    }
}

public class PointRef
{
    public int Y { get; set; }
    public int X { get; set; }
    
    public void Print()
    {
        Console.WriteLine(X + " " +  Y);
    }
}