namespace SharpReminder;

public class HalfAbstract
{
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
}