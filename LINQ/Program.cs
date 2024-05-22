namespace LINQ;

public static class LinqExtensions
{
    public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
    {
        if (source == null) return;

        foreach (var variable in source)
            action(variable);
    }

    public static void ForEach<T>(this IEnumerable<T> source, Func<T, FileInfo> getFileInfo)
    {
        if (source == null) return;

        foreach (var item in source)
        {
            FileInfo a = getFileInfo(item);

            Console.WriteLine($"{a.Name} {a.Length}");
        }
    }


    public static void ForEach<T>(this IEnumerable<T> source, Func<T, long> getLenght, Func<T, string> getName)
    {
        if (source == null) return;

        foreach (var item in source)
        {
            long a = getLenght(item);
            string b = getName(item);

            Console.WriteLine($"{b} {a}");
        }
    }
}

class Data
{
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public long Id { get; set; }
    public string? Country { get; set; }
    public string? Addres { get; set; }

    public override string ToString()
    {
        return $"Name: {Name} Surname: {Surname} Id: {Id} Country: {Country} Addres: {Addres}";
    }

    public static Data GetData(string str)
    {
        string[] lines = str.Split(";");
        Console.WriteLine(lines.Length);
        return new Data()
        {
            Name = lines[0],
            Surname = lines[1],
            Id = int.Parse(lines[2]),
            Country = lines[3],
            Addres = lines[4],
        };
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        MinMaxName("TopPlayers.csv");
    }

    // sorting file on lenght
    /*
    private static void LargestLinq()
    {
        GetLargest(@"D:\Repositories\C_Sharp_Reminder");
        GetLargestLinq(@"D:\Repositories\C_Sharp_Reminder");
        GetLargestLinq1(@"D:\Repositories\C_Sharp_Reminder");
        GetLargestLinq2(@"D:\Repositories\C_Sharp_Reminder");
        GetLargestLinq3(@"D:\Repositories\C_Sharp_Reminder");
    }

    // Первый вариант без линк
    private static void GetLargest(string path)
    {
        var info = new DirectoryInfo(path);

        FileInfo[] files = info.GetFiles();

        Array.Sort(files, Comp);

        foreach (var variable in files)
        {
            Console.WriteLine($"{variable.Name} {variable.Length}");
        }
    }

    private static int Comp(FileInfo a, FileInfo b)
    {
        if (a.Length == b.Length) return 0;
        return a.Length > b.Length ? -1 : 1;
    }

    //Второй вариант с линк
    private static void GetLargestLinq(string path)
    {
        IEnumerable<FileInfo> files = new DirectoryInfo(path)
            .GetFiles()
            .OrderByDescending(KeySelect)
            .Take(5);

        foreach (var variable in files)
        {
            Console.WriteLine($"{variable.Name} {variable.Length}");
        }
    }

    private static long KeySelect(FileInfo a) => a.Length;

    //Третий вариант линк
    private static void GetLargestLinq1(string path)
    {
        new DirectoryInfo(path)
            .GetFiles()
            .OrderByDescending(a => a.Length)
            .Take(5)
            .ForEach(elem => elem.Length,
                elem => elem.Name);
    }

    //Четвертый вариант линк с расширением - суть в том передать action, а потом вызвать его
    private static void GetLargestLinq2(string path)
    {
        new DirectoryInfo(path)
            .GetFiles()
            .OrderByDescending(a => a.Length)
            .Take(5)
            .ForEach(elem => Console.WriteLine($"{elem.Name} {elem.Length}"));
    }

    //Пятый вариант - суть в том чтобы передать делегат, который будет возвращать объект
    private static void GetLargestLinq3(string path)
    {
        new DirectoryInfo(path).GetFiles().OrderByDescending(file=>file.Length).Take(10).ForEach(file=>file.Length,file=>file.Name);
        new DirectoryInfo(path)
            .GetFiles()
            .OrderByDescending(file => file.Length)
            .Take(10)
            .ForEach(elem => elem);
    }
    */

    //sending to func by using anonym func
    private static void MinMaxName(string fileName)
    {
        try
        {
            List<Data> varsa = File.ReadAllLines(fileName)
                .Skip(1)
                .Select(s => Data.GetData(s))
                .Where(data => data.Name != null && data.Name.Length > 5)
                .OrderByDescending(data => data.Name)
                .ThenBy(data => data.Id)
                .Take(10)
                .ToList();

            foreach (var obj in varsa) //пробегается по финальной колеции
            {
                Console.WriteLine(obj);
            }

            if (varsa.Any())
            {
                Console.WriteLine($"The lowest name is in top 10: {varsa.Min(x => x.Name)}");
                Console.WriteLine($"The highest name is in top 10: {varsa.Max(x => x.Name)}");
                Console.WriteLine($"The average ID in top 10: {varsa.Average(x => x.Id)}");
                Console.WriteLine(
                    $"The average ID in top 10: {varsa.Average(x => x.Id)} {varsa.First(x => x.Name == "Isabel")}");
                Console.WriteLine(
                    $"The average ID in top 10: {varsa.Average(x => x.Id)} {varsa.Last(x => x.Name == "Isabel")}");
                Console.WriteLine(
                    $"The average ID in top 10: {varsa.Average(x => x.Id)} {varsa.FirstOrDefault(x => x.Name == "IIsabel")}");
                Console.WriteLine(
                    $"The average ID in top 10: {varsa.Average(x => x.Id)} {varsa.LastOrDefault(x => x.Name == "IIsabel")}");
            }
            else
            {
                Console.WriteLine("No data available.");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error occurred: {e.Message}");
        }
    }

    private static void DeleteFromColl()
    {
        var list = new List<int>(){1,2,3,4,5};
        list.RemoveAll(num => num % 2==0);
    }

}