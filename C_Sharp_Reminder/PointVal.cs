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
    
    private const int a = 10;
    private readonly int b = 10; // readonly дает возможность изменять в конструкторе

    public PointRef()
    {
        Y = 0;
        X = 0;
        b = 0;
    }

    public PointRef(int x,int y)
    {
        X = x;
        Y = y;
    }
    public void Print()
    {
        Console.WriteLine(X + " " +  Y);
    }
}

public class Weapon //можно назвать это полуабстрактым классом, мы можем переопределять базовые класс, а можем этого и не делать 
{
    public virtual void Print()
    {
        Console.WriteLine("Hello Daddy");
    }
}

public class Gun : Weapon
{
    public override void Print()
    {
        Console.WriteLine("Hello, I am A gun");
    }
}