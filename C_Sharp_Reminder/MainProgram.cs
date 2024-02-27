namespace C_Sharp_Reminder;

// Using "internal" with vars, methods, classes - doesn't give permission to use them in other programs, projects, assemblies.
public class MainProgram
{ 
    private static void Main() //Main function
    {
        // CreatingArray();
        // CreatingDoubleArray();
        // CreatingVector();
        // CreatingQueue();
        // CreatingStack();
        // CreatingList();
        // CreatingDictionary();
        // ConsoleView();
        // CheckOnOverFlow();
        // Concatenation();
        // Parsing();
        // StringView();
        // SendingArray(1,2,3,4,5);
        // OptionalParamet(1, true);
        // StructClass();
        //
        // List<int> nubbers = new List<int>();
        // AddNumbers(nubbers);
        //
        // int a = 10;
        // int b = 5;
        // Swap(ref a, ref b);
        //
        // PointVal? py = null;
        //
        // if (py.HasValue)
        // {
        //     PointVal px = py.Value;
        // }
        //
        // BoxingAndUnboxing();
        //
        // Weapon Pistole = new Gun();
        // Pistole.Print();
    //     Car[] a = new Car[2]; //полиморфиз
    //     a[0] = new Tracks(1, 4);
    //     a[1] = new Tracks(1, 4);
    //
    //     foreach (var vas in a)
    //     {
    //         CallTrack(vas);
    //         vas.Move();
    //         vas.RotateRuli();
    //         vas.RotateWheels();
    //     }
    // //
    // IControl a = new Stack();
    // a.Add();
    // a.Add2();
    List<int> list = new List<int>(){1,3,5,7,9};
    IControl b = new Stack();
    b.AddRange(list);
    }

    private static void CallTrack(Car car)
    {
        car.Move();
    }

    private static void BoxingAndUnboxing()
    {
        object obj = 1;        // создали объект ссылоного типа, где 1 будет выделено на куче
        ref object a = ref obj; //сылку присвоили сылочному типу
        int y = (int)obj; // значение вытащили из указателя
    }

    private static void Swap(ref int i, ref int i1)
    {
        int tmp = i;
        i = i1;
        i1 = i;
    }

    private static void AddNumbers(List<int> numbers)
    {
        numbers.Add(1);
        numbers.Add(2);
        numbers.Add(3);
        
        
        foreach (var a in numbers)
        {
            Console.WriteLine(a + " ");
        }
    }


    private static void StructClass()
    {
        Console.WriteLine();
        
        PointVal a = new PointVal();
        a.X = 10;
        a.Y = 15;

        PointRef b = new PointRef();
        b.X = 11;
        b.Y = 16;
        
        a.Print();
        b.Print();
        
        PointVal aa = a;
        PointRef bb = b;

        a.X = 100;
        a.Y = 150;
        
        b.X = 110;
        b.Y = 160;
        
        a.Print();
        b.Print();
        aa.Print();
        bb.Print();
    }
    
    private static int OptionalParamet(int i, bool b=false) //optional parametrs use in the end of parametrs
    {
        return b ? i * i : i * i * i;
    }
    

    private static void SendingArray(params int[] array)
    {
        Console.WriteLine("\n\n Sending Array");
        foreach (var it in array)
            Console.Write(it + " ");
    }
    
    
    private static void CreatingArray()
    {
        Console.WriteLine("Array");
        
        int[] array = new int[] {2,4,6,8,10};
        int[] array1 = new int[5];
        
        Array.Copy(array,array1,array1.Length);

        for (int i = 0; i < 5; i++)
            Console.Write(array[i] + " ");
        
        Console.WriteLine();
        
        for (int i = 0; i < 5; i++)
            Console.Write(array1[i] + " ");
    
        Console.WriteLine($"\nThe index of the number your search is: {Array.BinarySearch(array,2)} and its number is {array[Array.BinarySearch(array,2)]}");
    }
    
    private static void CreatingDoubleArray()
    {
        Console.WriteLine("\nDouble Array");
        
        int[,]n = new int[,]{{1,3,5},{4,6,8},{2,1,0}};
        
        for (int i = 0; i < n.GetLength(0); i++)
        {
            for (int j = 0; j < n.GetLength(1); j++)
                Console.Write(n[i,j]+" ");
            Console.WriteLine();
        }
    }

    // Vector in c++ is a list in c#
    private static void CreatingVector()
    {
        Console.WriteLine("\nVector");
        
        var vector = new List<int> { 1,5,3,7,5,8 };
        
        foreach (var a in vector)
            Console.Write(a + " ");
        
        Console.WriteLine();
        
        vector.Sort();
        
        foreach (var a in vector)
            Console.Write(a + " ");
    }
    
    private static void CreatingQueue()
    {
        Console.WriteLine("\n\nQueue");
        
        Queue<int> queue = new Queue<int>(10);
        queue.Enqueue(1);
        queue.Enqueue(2);
        queue.Enqueue(5);
        queue.Enqueue(1);
        queue.Enqueue(9);
        
        foreach (var a in queue)
            Console.Write(a + " ");
    }
   
    private static void CreatingStack()
    {
        Console.WriteLine("\n\nStack");
        
        Stack<int> orders = new Stack<int>();
        orders.Push(2);
        orders.Push(3);
        orders.Push(5);
        orders.Push(1);
        orders.Push(7);
        
        foreach (var a in orders)
            Console.Write(a + " ");
    }
    
    private static void CreatingList() 
    {
       Console.WriteLine("\n\nList");
       
        var a = new LinkedList<int>();
        a.AddLast(1);
        a.AddLast(2);
        a.AddLast(3);
        a.AddLast(4);
        a.AddLast(5);
        
        foreach (var obj in a)
            Console.Write(obj + " ");

        if (a.First!=null )
            a.First.Value = 0;

        Console.WriteLine();
        
        foreach (var obj in a)
            Console.Write(obj + " ");
    }
        
    private static void CreatingDictionary()
    {
        Console.WriteLine("\n\nDictionary");
        var dictionary = new Dictionary<int, string>
        {
            { 1, "Alex" },
            { 2, "Dima" },
            { 3, "German" }
        };
        
        string name = dictionary[2];
        Console.WriteLine(name + " - the name you trying to find!");
    }

    private static void ConsoleView()
    {
        Console.WriteLine("\n\nConsole");
        Console.ForegroundColor = ConsoleColor.White; //sets the color text
        Console.BackgroundColor = ConsoleColor.Black; //sets the color backGround

        Console.WriteLine("Hello World!");
        Console.Write("What's your name: ");

        var sequenceOfCharacters = Console.ReadLine()!;

        Console.WriteLine($"{sequenceOfCharacters}, nice to meet you!");

        // var number = Console.Read();
        // Console.WriteLine($"You entered: {(char)number}, Its code is: {number}");
    }
 
    private static void CheckOnOverFlow()
    {
        Console.WriteLine("\n\nCheckOnOverFlow");
        checked //проверка за выход за пределы
        {
            var number = uint.MaxValue;

            number--;

            Console.WriteLine(number);
        }
    }
    
    private static void Concatenation()
    {
        Console.WriteLine("\n\nConcatination");
        var name = " Alex";
        var surname = "Pekel";
        var fullName1 = name + " " + surname;
        var fullName2 = string.Concat(name, " ", surname);
        var fullName3 = string.Format("{0} {1}", name, surname);
        var fullName4 = $"{name} {surname}";

        var subString = fullName1.Substring(5);

        Console.WriteLine(fullName1 + fullName2 + fullName3 + fullName4);
        Console.WriteLine(subString);
        Console.WriteLine($"{string.IsNullOrEmpty("Ak")} {string.IsNullOrWhiteSpace(null)}");
    }
    
    private static void Parsing()
    {
        Console.WriteLine("\n\nRounding nums");
        Console.WriteLine((int)Math.Round(10.5,MidpointRounding.ToZero) + " is rounded.");
        Console.WriteLine((int)Math.Round(10.5,MidpointRounding.AwayFromZero) + " is rounded.");
    }
    
    private static void StringView()
    {
        Console.WriteLine("\n\nString View");
        var str = string.Concat("Alex ", "Pekel");
        Console.WriteLine(str);
        
        str = string.Join(" ","Alex", "Pekel", "Is A King");
        Console.WriteLine(str);
        
        str = str.Insert(0, "By the way, ");
        Console.WriteLine(str);
        
        str = str.Remove(10);
        Console.WriteLine(str);
        
        str = str.Replace('a', 'E');
        Console.WriteLine(str);
        
        string []strings = str.Split(';'); //Разделит на под массивы и вернет массивы
        Console.WriteLine(strings[0]);
        
        str = str.ToLower();
        Console.WriteLine(str);
    }
    
}