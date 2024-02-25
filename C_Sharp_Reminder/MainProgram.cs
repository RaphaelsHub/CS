namespace C_Sharp_Reminder;

// Using "internal" with vars, methods, classes - doesn't give permission to use them in other programs, projects, assemblies.
internal class MainProgram
{
    private static void Main() //Main function
    {
        CheckOnOverFlow();
        Concatenation();
        ConsoleView();
    }

    private static void ConsoleView()
    {
        Console.ForegroundColor = ConsoleColor.White; //sets the color text
        Console.BackgroundColor = ConsoleColor.Black; //sets the color backGround
        
        Console.WriteLine("Hello World!");
        Console.Write("What's your name: ");

        var sequenceOfCharacters = Console.ReadLine()!;
        
        Console.WriteLine($"{sequenceOfCharacters}, nice to meet you!");

        var number = Console.Read();
        Console.WriteLine($"You entered: {(char)number}, Its code is: {number}");
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
        string name = "Alex";
        string surname = "Pekel";
        string fullName1 = name + " " + surname;
        string fullName2 = string.Concat(name, " ", surname);
        string fullName3 = string.Format("{0} {1}", name, surname);
        string fullName4 = $"{name} {surname}";
        
        Console.WriteLine(fullName1);
        Console.WriteLine(fullName2);
        Console.WriteLine(fullName3);
        Console.WriteLine(fullName4);
    }
}