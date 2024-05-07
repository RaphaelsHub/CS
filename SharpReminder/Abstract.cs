namespace SharpReminder;

public abstract class Car
{
    private string _numClass;

    protected Car(string a)
    {
        _numClass = a;
    }
    public abstract void Move();
    public abstract void RotateWheels();
    public abstract void RotateRul();
}

class Tracks:Car
{
    private readonly int _speed=10;
    private readonly int _acceleration=50;

    public Tracks(int a, int b):base(nameof(Tracks))
    {
        Console.WriteLine("Track created");
    }
    public override void Move()
    {
        Console.WriteLine("IsJustMooving");
    }

    public override void RotateWheels()
    {
        Console.WriteLine("IsWorkingWheels");
    }

    public override void RotateRul()
    {
        Console.WriteLine("IsWorkingRuli");
    }
}