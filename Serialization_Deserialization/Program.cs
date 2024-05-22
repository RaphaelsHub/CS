using System.Xml.Linq;
using System.Xml.Serialization;

namespace Serialization_Deserialization;

public struct Worker
{
    public string Name;
    public string Surname;
    public string MidName;
    public string PostJob;
    public string Corpotation;
    public int Salary;
}

class Program
{
    static void Main(string[] args)
    {
        string path = @"D:\Repositories\C_Sharp_Reminder\Serialization_Deserialization\AlexData.xml";

        Worker a = new Worker()
        {
            Name = "Alex", Surname = "Pekel", MidName = "Alexei", PostJob = "GameDev", Corpotation = "Frank",
            Salary = 15000
        };

        Serialize(path, a);
        DeSerialize(path, ref a);

        Console.WriteLine(
            $"Name: {a.Name}, Surname: {a.Surname}, MidName: {a.MidName}, PostJob: {a.PostJob}, Corpotation: {a.Corpotation}, Salary: {a.Salary}");


        //Работа с листами
        string pathForListOfWorkers = @"D:\Repositories\C_Sharp_Reminder\Serialization_Deserialization\ListData.xml";

        List<Worker> list = new List<Worker>() { a, a, a, a, a };

        SerializeList(pathForListOfWorkers, list);
        DeSerializeList(pathForListOfWorkers, list);

        foreach (var obj in list)
        {
            Console.WriteLine($"Name: {obj.Name}, Surname: {obj.Surname}, MidName: {obj.MidName}, PostJob: {obj.PostJob}, Corpotation: {obj.Corpotation}, Salary: {obj.Salary}");
        }

        //AddAttributes(pathForListOfWorkers);

        CreatCustom();
    }

    private static void CreatCustom()
    {
        string path = @"D:\Repositories\C_Sharp_Reminder\Serialization_Deserialization\Custom.xml";

        XElement a = new XElement("Country");
        XElement b = new XElement("City");
        XElement c = new XElement("Adress");

        XElement adress = new XElement("Adress", "Pushkin");
        c = adress;
        
        XAttribute city = new XAttribute("City", "Chisinau");
        b.Add(city);

        b.Add(c);

        XAttribute country = new XAttribute("Country", "Moldova");
        a.Add(country);

        a.Add(b);
        a.Add(b);
        a.Add(b);

        a.Save(path);
    }


    private static void AddAttributes(string pathForListOfWorkers)
    {
        XDocument doc = XDocument.Load(pathForListOfWorkers);

        List<XElement> list = doc
            .Descendants("ArrayOfWorker")
            .Descendants("Worker")
            .ToList();
        
        XAttribute min = new XAttribute("Min", 10000);
        XAttribute max = new XAttribute("Max", 30000);
        
        foreach (var obj in list)
            obj.Element("Salary")?.Add(min,max);

        doc.Save(pathForListOfWorkers);
    }

    private static void DeSerialize(string path, ref Worker worker)
    {
        if (!File.Exists(path))
            throw new Exception("File Dont Exists!");

        using FileStream fs = File.Open(path, FileMode.Open, FileAccess.Read);
        worker = (Worker)(new XmlSerializer(typeof(Worker)).Deserialize(fs) ??
                          throw new InvalidOperationException("Is null Worker!"));
    }

    private static void Serialize(string path, Worker b)
    {
        using (FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write))
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Worker));
            xmlSerializer.Serialize(fs, b);
        }
    }

    private static void DeSerializeList(string path, List<Worker> list)
    {
        if (!File.Exists(path))
            throw new Exception("File Dont Exists!");

        using FileStream fs = File.Open(path, FileMode.Open, FileAccess.Read);
        list = (List<Worker>)(new XmlSerializer(typeof(List<Worker>)).Deserialize(fs) ??
                          throw new InvalidOperationException("Is null Worker!"));
    }

    private static void SerializeList(string path, List<Worker> list)
    {
        using FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write);
        new XmlSerializer(typeof(List<Worker>)).Serialize(fs, list);
    }
}