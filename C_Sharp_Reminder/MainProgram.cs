namespace C_Sharp_Reminder;
using System;
using System.Collections.Generic;
// Using "internal" with vars, methods, classes - doesn't give permission to use them in other programs, projects, assemblies.
internal class MainProgram
{
    private static void Main() //Main function
    {
        CheckOnOverFlow();
        Concatenation();
        ConsoleView();
        StringView();
        CreatingArray();
        Parsing();
        CreatingList();
        CreatingVector();
        CreatingQueue();
        CreatingStack();
        CreatingDictionary();
    }

    private static void CreatingDictionary()
    {
        var dictionary = new Dictionary<int, string>();
        dictionary.Add(1,"hELLO");
        dictionary.Add(2,"hELLO");
        dictionary.Add(3,"hELLO");

        dictionary = new Dictionary<int, string>()
        {
            { 1, "john" },
            { 2, "john" },
            { 3, "john" }
        };

        string name = dictionary[2];
        Console.WriteLine(name);
    }

    private static void CreatingStack()
    {
        
    }

    private static void CreatingQueue()
    {
         
    }

    private static void CreatingVector() // Vector in c++ is a list in c#
    {
        var a = new List<int>() { 2, 5, 6, 7, 8, 9 };
        a.Add(3);
        foreach (var vas in a)
        {
            Console.Write(vas+" ");
        }
        Console.WriteLine();
        
        a.Sort();
        
        foreach (var vas in a)
        {
            Console.Write(vas+" ");
        }
    }

    private static void CreatingList()  // 
    {
        //Это позволит вам добавить узел в список в нужное место, а также обеспечит доступ к методам для работы с узлами (например, Next, Previous, Value).
        LinkedList<int> a = new LinkedList<int>();
        a.AddLast(2);
        a.AddLast(2);
        a.AddLast(2);
        a.AddLast(2);
        a.AddLast(2);
        a.AddLast(2);
        a.AddLast(2);
        a.AddLast(2);

        if (a.First != null)
        {
            LinkedListNode<int> firstNode = a.First;
            if (firstNode.Next != null) firstNode.Next.Value = 3;
        } //Работа с нодой


        foreach (var vas in a)
        {
            Console.Write(vas+" ");
        }
        Console.WriteLine();
        
        a.RemoveFirst();
        
        foreach (var vas in a)
        {
            Console.Write(vas+" ");
        }
        Console.WriteLine();
    }

    private static void Parsing()
    {
        double num = 10.5;
        int roundedNum = (int)Math.Round(num, MidpointRounding.ToZero);
        Console.WriteLine("\n"+roundedNum);
        roundedNum = (int)Math.Round(num, MidpointRounding.AwayFromZero);
        Console.WriteLine(roundedNum);
    }

    private static void CreatingArray()
    {
        int[] arr = new int[5];
        int[] arr1 = new int[5] {2,4,6,7,8};
        //int[] arr2 = {2,4,6,2,5};
        foreach (var vas in arr1)
        {
            Console.Write(vas+" ");
        }
        Console.WriteLine();

        int index = Array.BinarySearch(arr1, 4);
        Console.WriteLine(arr1[index] + " Is our num");
        
        Array.Copy(arr1,arr,arr1.Length);
        foreach (var vas in arr)
        {
            Console.Write(vas+" ");
        }
    }

    private static void StringView()
    {
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

    private static void ConsoleView()
    {
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
        checked //проверка за выход за пределы
        {
            var number = uint.MaxValue;

            number--;

            Console.WriteLine(number);
        }
    }

    private static void Concatenation()
    {
        var name = "Alex";
        var surname = "Pekel";
        var fullName1 = name + " " + surname;
        var fullName2 = string.Concat(name, " ", surname);
        var fullName3 = string.Format("{0} {1}", name, surname);
        var fullName4 = $"{name} {surname}";

        var subString = fullName1.Substring(5);

        Console.WriteLine(fullName1);
        Console.WriteLine(fullName2);
        Console.WriteLine(fullName3);
        Console.WriteLine(fullName4);
        Console.WriteLine(subString);
        Console.WriteLine($"{string.IsNullOrEmpty("Ak")} {string.IsNullOrWhiteSpace(null)}");
    }
}