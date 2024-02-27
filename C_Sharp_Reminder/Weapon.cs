using System.Formats.Asn1;

namespace C_Sharp_Reminder;

public abstract class Car
{
    private string numClass;

    public Car(string a)
    {
        Console.WriteLine(a);
    }
    public abstract void Move();
    public abstract void RotateWheels();
    public abstract void RotateRuli();
}

class Tracks:Car
{
    private readonly int speed;
    private readonly int acceleration;

    public Tracks(int a, int b):base(nameof(Tracks))
    {
        Console.WriteLine("Track created");
        speed = a;
        acceleration = b;
    }
    public override void Move()
    {
        Console.WriteLine("IsJustMooving");
    }

    public override void RotateWheels()
    {
        Console.WriteLine("IsWorkingWheels");
    }

    public override void RotateRuli()
    {
        Console.WriteLine("IsWorkingRuli");
    }
}