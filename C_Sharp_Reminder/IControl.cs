namespace C_Sharp_Reminder;
//почему интерфейс а не абстракт класс, если насследуемый класс должен реализовать более несколько классов, есть смысл испольщовать интервейс, дает пвозможност множ наследованию, а обыкновенный класс так не может.
//абстракт  - i am //интерфейс - i can
//интерфкйс нельзя расширять - не клиета, это мнгновенное требование все насследуемым класс, опредилить методы которые ты добавил, потому что без этого контракт не будет отрабатывать
public interface IControl
{
    //тут расмотрим методы расширения интерфейсов
    void Add(int a);
    void Add2();
}

public static class Control
{
    public static void AddRange(this IControl collection, IEnumerable<int> numbers)
    {
        foreach (var vas in numbers)
        {
            collection.Add(vas);
        }
    }
}


public interface IControl1
{
    void Add(int a);
    void Add2();
}

public class Stack : IControl, IControl1
{
    public void Add(int a)
    {
        Console.WriteLine("PumPum");
    }

    public void Add2()
    {
        Console.WriteLine("TicTIc");
    }
}