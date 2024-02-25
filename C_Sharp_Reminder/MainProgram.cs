namespace C_Sharp_Reminder;

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
    }

    private static void Parsing()
    {
        double num = 10.5;
        int roundedNum = (int)Math.Round(num, MidpointRounding.ToZero);
        Console.WriteLine(roundedNum);
        roundedNum = (int)Math.Round(num, MidpointRounding.AwayFromZero);
        Console.WriteLine(roundedNum);
    }

    private static void CreatingArray()
    {
        int[] arr = new int[5];
        int[] arr1 = new int[5] {2,4,6,2,5};
        //int[] arr2 = {2,4,6,2,5};
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