using System.Text;
using System.Xml.Serialization;
using SharpReminder;
using OOP;
using Stack = OOP.Stack;

namespace SharpReminder
{
    public static class MainProgram
    {
        private static void Main()
        {
            CallSheet();
        }
        private static void CallSheet()
        {
            Collections.CreatingArray();
            Collections.CreatingDoubleArray();
            Collections.List();
            Collections.StackQueue();
            Collections.LinkedList();
            Collections.Dictionary();
            Collections.HashSet();
            Collections.CheckCustomStack();
            VarWorking.Vars();
            VarWorking.TimeVar();
            VarWorking.Parsing();
            VarWorking.OptionalParamet(1);
            VarWorking.CheckOnOverFlow();
            VarWorking.BoxingAndUnboxing();
            String.StringInternalMethods();
            String.Concatenation();
            String.ConsoleView();
            OopWork.EnumWork();
            OopWork.HalfAbstract();
            OopWork.CheckMyInt();
            OopWork.WorkingWithFiles();
            ExceptionWork.ExceptionRead();
            ExceptionWork.FileOpenException();
            ExceptionWork.TrainingOnExcepctions();
        }
    }
}
public static class Collections
{
    public static void CreatingArray(params int[] array)
    {
        foreach (var it in array)
            Console.Write(it + " ");
        Console.WriteLine();
    }
    public static void CreatingArray()
    {
        int[] array = new int[] { 2, 4, 6, 8, 10 };
        int[] array1 = new int[5];

        Array.Copy(array, array1, array1.Length);
        int number = array[(Array.BinarySearch(array, 2))];

        CreatingArray(1, 2, 3, 4, 5);
    }
    public static void CreatingDoubleArray()
    {
        int[,] doubleArray = new int[,] { { 1, 3, 5 }, { 4, 6, 8 }, { 2, 1, 0 } };

        for (int i = 0; i < doubleArray.GetLength(0); i++)
        {
            for (int j = 0; j < doubleArray.GetLength(1); j++)
                Console.Write(doubleArray[i, j] + " ");
            Console.WriteLine();
        }
    }
    public static void List()
    {
        var vector = new List<int> { 1, 5, 3, 7, 5, 8 };
        vector.Sort();
        foreach (var item in vector)
            Console.Write(item + " ");
        Console.WriteLine();
    }
    public static void StackQueue()
    {
        Stack<int> orders = new Stack<int>(10);
        Queue<int> queue = new Queue<int>(10);

        orders.Push(1);
        orders.Pop();

        queue.Enqueue(1);
        queue.Dequeue();
    }
    public static void LinkedList()
    {
        var a = new LinkedList<int>();

        a.AddLast(1);
        a.AddLast(2);
        a.AddLast(3);

        if (a.First != null)
            a.First.Value = 0;

        var currNode = a.First;

        while (currNode != null && currNode.Next != null)
        {
            if (currNode.Next.Value == 1)
            {
                var newNode = new LinkedListNode<int>(3);
                a.AddAfter(currNode, newNode);
            }

            currNode = currNode.Next;
        }
    }
    public static void Dictionary()
    {
        var dictionary = new Dictionary<int, string>
        {
            { 1, "Alex" },
            { 2, "Dima" },
            { 3, "German" }
        };

        dictionary[1] = "Anton";

        string name = dictionary[1]; //вернет Anton
        Console.WriteLine(name);
    }
    public static void HashSet()
    {
        var set = new HashSet<int>(new int[] { 1, 2, 2, 3, 4, 5 });

        foreach (var variable in set)
            Console.WriteLine($"{variable} ");
    }
    public static void CheckCustomStack()
    {
        CustomStack<int> a = new CustomStack<int>();
        
        for (int i = 0; i < 4; i++)
            a.Push(1);

        for (int i = 0; i < 4; i++)
        {
            Console.WriteLine(a.Peek());
            a.Pop();
        }
    }
}
public static class VarWorking
{
    public static void Vars()
    {
        Random random = new Random();
    
        const int speed = 10;
        
        var firstNum = random.Next(1, 6);
        var secondNum = random.Next(1, 6);
        var floatNum = random.NextDouble() * 10;

        Swap(ref firstNum,ref secondNum);
    }
    public static void TimeVar()
    {
        DateTime a = DateTime.Now;
        Console.WriteLine($"Start time: {a}");

        DateTime b = a.AddDays(2);
        Console.WriteLine($"End time: {b}");

        TimeSpan dif = b - a;

        Console.WriteLine($"Difference in days: {dif.Days}");
    }
    public static void BoxingAndUnboxing()
    {
        object obj = 1; // Создали объект ссылочного типа, где значение 1 будет упаковано и выделено на куче
        ref object a = ref obj; // Присвоили ссылку объекта ссылочному типу
        int y = (int)obj; // Значение было извлечено из упакованного объекта и приведено к типу int
    }
    public static void CheckOnOverFlow()
    {
        checked //проверка за выход за пределы, если произойдет какое-то исключение нам это выбьет
        {
            var number = uint.MaxValue;
            number--;
        }
    }
    public static int OptionalParamet(int i, bool b = false)
    {
        return b ? i * i : i * i * i; //Отправили опциональный параметр, можем заполнять можем нет
    }
    public static void Parsing()
    {
        int firstNum = (int)Math.Round(10.5, MidpointRounding.ToZero); //10
        int secondNum = (int)Math.Round(10.5, MidpointRounding.AwayFromZero); //11
    }
    private static void Swap<T>(ref T i, ref T y)
    {
        T tmp = i;
        i = y;
        y = i;
    }
}
public static class String
{
    public static void ConsoleView()
    {
        Console.WriteLine("\n\nConsole");
        Console.ForegroundColor = ConsoleColor.White; //sets the color text
        Console.BackgroundColor = ConsoleColor.Black; //sets the color backGround

        Console.WriteLine("Hello World!");
        Console.Write("What's your name: ");

        var sequenceOfCharacters = Console.ReadLine()!;

        Console.WriteLine($"{sequenceOfCharacters}, nice to meet you!");
    }
    public static void StringInternalMethods()
    {
        var str = string.Concat("Alex ", "Pekel"); //Сделает конкатенацию
        str = string.Join(" ", "Alex", "Pekel", "Is A King"); //Добавит в конец
        str = str.Insert(0, "By the way, "); //Вставит текст вначале указателя
        str = str.Remove(10); //Удалит начиная с 10 символа
        str = str.Replace('a', 'E'); //Заменит
        str = str.ToLower(); //Привидет к маленьким
        string[] strings = str.Split(';'); //Разделит на под массивы и вернет массивы
    }
    public static void Concatenation()
    {
        var surname = "Pekel";
        var name = "Alexandr";

        var type1 = name + " " + surname;
        var type2 = string.Concat(name, " ", surname);
        var type3 = string.Format("{0} {1}", name, surname);
        var type4 = $"{name} {surname}";
    }
}
public static class OopWork
{
    public static void HalfAbstract()
    {
        Car[] a = new Car[2];
        a[0] = new Tracks(1, 4);
        a[1] = new Tracks(1, 4);

        foreach (var vas in a)
        {
            vas.Move();
            vas.RotateRul();
            vas.RotateWheels();
        }
    }
    public static void EnumWork()
    {
        LightControl a = new LightControl();
        a.SwitchLight(TrafficLights.Green);
    }    
    public static void CheckMyInt()
    {
        var b = new Stack();
        b.Add(4);

        IControl a = new Stack();
        a.Add(2);
        a.Add2();

        var list = new List<int>() { 1, 3, 5, 7, 9 };
        IControl z = new Stack();
        z.AddRange(list);
    }
    

    public static void WorkingWithFiles()
    {
        //1 вариант
        Stream? file = null;
        try
        {
            file = new FileStream("Text.txt", FileMode.OpenOrCreate, FileAccess.Write);
            if (file.CanWrite)
            {
                string str = "Alex";
                byte[] strByte = Convert.FromBase64String(str);
                file.Write(strByte, 0, strByte.Length);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error {e.ToString()}");
        }
        finally
        {
            file?.Close();
        }

        
        //2 вариант
        string filePath = "Text.txt"; 
        string[] linesToWrite = ["Строка 1", "Строка 2", "Строка 3"];

        using (FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write))
        {
            foreach (string line in linesToWrite)
            {
                byte[] bytes = Encoding.UTF8.GetBytes(line + Environment.NewLine); // Кодируем строку в байты с добавлением перевода строки
                fs.Write(bytes, 0, bytes.Length); // Записываем байты в файл
            }
        }

        //3 вариант
        using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
        {
            byte[] bytes = new byte[fs.Length];
            var read = fs.Read(bytes, 0, bytes.Length);

            string fileContent = Encoding.UTF8.GetString(bytes);
            string[] linesRead = fileContent.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries); // Разбиваем строку на массив строк

            foreach (string line in linesRead)
            {
                Console.WriteLine(line);
            }
        }

        //4 вариант
        string[] allLines = File.ReadAllLines("Text.txt");
        string allFile = File.ReadAllText("Text.txt");

        string[] initialLines = ["Строка 1", "Строка 2", "Строка 3"];
        string[] linesToAdd = ["Строка 4", "Строка 5", "Строка 6"]; 

        File.WriteAllLines(filePath, initialLines);
        File.AppendAllLines(filePath, linesToAdd);

        allFile = File.ReadAllText(filePath);
        
        //5 вариант
        FileStream fileStream = File.Open("Text.txt", FileMode.OpenOrCreate, FileAccess.Write);

        bool existDir = Directory.Exists("Text.txt");

        if (existDir)
        {
            Console.WriteLine("Exists very good");
            var files = Directory.GetFiles("Text.txt");
            foreach (var vFile in files)
            {
                Console.WriteLine(Path.GetFileName(vFile));
            }
        }

        fileStream.SetLength(0);

        bool isEmpty = fileStream.Length == 0;

        Console.WriteLine($"The file is emptys: {isEmpty}");

        fileStream.Close();
    }
}
public static class ExceptionWork
{
    public static void TrainingOnExcepctions()
    {
        Console.Write("Enter a number: ");
        string? num = Console.ReadLine();

        try
        {
            int a = int.Parse(num ?? string.Empty);
        }
        catch (ArgumentException e)
        {
            Console.WriteLine(e);
        }
        catch (OverflowException e)
        {
            Console.WriteLine(e);
        }
        catch (FormatException e)
        {
            Console.WriteLine(e);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex); //отработает базоыый тип, если не отработают исключения выше
        }
    }
    public static void FileOpenException()
    {
        FileStream? myFile = null;

        try
        {
            myFile = File.Open("Alex", FileMode.Open, FileAccess.Read);
        }
        catch (Exception ex)
        {
            throw new DrawException("File openning error! Couldn't Find!" + ex);
        }
        finally
        {
            myFile?.Dispose();
        }
    }
    public static void ExceptionRead()
    {
        if (false)
            throw new ArgumentException("Is not equal 0!"); // Наше исключение
        else
            throw new DrawException("X is equal 0"); //Кастомный класс под иключение
    }

}

namespace OOP
{
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
    public class Tracks:Car
    {
        private readonly int _speed;
        private readonly int _acceleration;

        public Tracks(int a, int b):base(nameof(Tracks))
        {
            _speed = a;
            _acceleration = b;
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
    public enum TrafficLights
    {
        Green,
        Yellow,
        Red
    }
    public class LightControl
    {
        private TrafficLights _light = TrafficLights.Red;
        public void SwitchLight(TrafficLights light)
        {
            this._light = light;
            ResetLight();
        }
        private void ResetLight(TrafficLights light = TrafficLights.Red)
        {
            Console.WriteLine(this._light);
            this._light = light;
            Console.WriteLine(this._light);
            LightNext();
        }
        private void LightNext()
        {
            _light= (this._light == TrafficLights.Red) ? TrafficLights.Green : (TrafficLights)(((int)_light+1) % 3); 
    
            if (_light != TrafficLights.Red)
            {
                LightNext();
            }
        }
    }
    
    /* Почему интерфейс, а не абстракт класс?
     * Множественное насследование + контракт на реализацию - галочка в пользу интерфейса.
     * Его минус - сложность в расширении, нужно создавать статический класс
    */
    
    public interface IUse
    {
        void Add(int a);
    }
    public interface IControl: IUse
    {
        new void Add(int a);
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
    public class Stack : IControl
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

    public class DrawException : Exception
    {
        public DrawException(string a) : base(a) //вызывыет конструктор   
        {
            Console.WriteLine(a);
        }
    }
}