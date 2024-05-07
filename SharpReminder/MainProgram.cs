namespace SharpReminder
{

    internal class MainProgram
    {
        private static void Main()
        {
            var a = 10;
            var b = 5;
            Swap(ref a, ref b);
            MakeArray(1, 2, 3, 4, 5);
            PointVal? obj = null;
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
        }

        private static void Concatenation()
        {
            var surname = "Pekel";
            var name = "Alexandr";

            var type1 = name + " " + surname;
            var type2 = string.Concat(name, " ", surname);
            // ReSharper disable once UnusedVariable
            var type3 = string.Format("{0} {1}", name, surname);
            var type4 = $"{name} {surname}";
        }

        private static void StringInternalMethods()
        {
            var str = string.Concat("Alex ", "Pekel"); //Сделает конкатенацию
            str = string.Join(" ", "Alex", "Pekel", "Is A King"); //Добавит в конец
            str = str.Insert(0, "By the way, "); //Вставит текст вначале указателя
            str = str.Remove(10); //Удалит начиная с 10 символа
            str = str.Replace('a', 'E'); //Заменит
            str = str.ToLower(); //Привидет к маленьким
            string[] strings = str.Split(';'); //Разделит на под массивы и вернет массивы
        }

        private static void Parsing()
        {
            int firstNum = (int)Math.Round(10.5, MidpointRounding.ToZero); //10
            int secondNum = (int)Math.Round(10.5, MidpointRounding.AwayFromZero); //11
        }

        private static void CheckOnOverFlow()
        {
            checked //проверка за выход за пределы, если произойдет какое-то исключение нам это выбьет
            {
                var number = uint.MaxValue;
                number--;
            }
        }

        private static int OptionalParamet(int i, bool b = false)
        {
            return b ? i * i : i * i * i; //Отправили опциональный параметр, можем заполнять можем нет
        }

        private static void StackQueue()
        {
            Stack<int> orders = new Stack<int>(10);
            Queue<int> queue = new Queue<int>(10);

            orders.Push(1);
            orders.Push(2);
            orders.Pop();

            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Dequeue();
        }

        private static void LinkedList()
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

        private static void Dictionary()
        {
            var dictionary = new Dictionary<int, string>
            {
                { 1, "Alex" },
                { 2, "Dima" },
                { 3, "German" }
            };

            dictionary.Add(1, "Anton");

            string name = dictionary[1]; //вернет Anton
        }

        private static void List()
        {
            var vector = new List<int> { 1, 5, 3, 7, 5, 8 };
            vector.Sort();
        }

        private static void MakeArray(params int[] array)
        {
            foreach (var it in array)
                Console.Write(it + " ");
        }

        private static void CreatingArray()
        {
            int[] array = new int[] { 2, 4, 6, 8, 10 };
            int[] array1 = new int[5];

            Array.Copy(array, array1, array1.Length);
            int number = array[(Array.BinarySearch(array, 2))];
        }

        private static void CreatingDoubleArray()
        {
            int[,] doubleArray = new int[,] { { 1, 3, 5 }, { 4, 6, 8 }, { 2, 1, 0 } };

            for (int i = 0; i < doubleArray.GetLength(0); i++)
            {
                for (int j = 0; j < doubleArray.GetLength(1); j++)
                    Console.Write(doubleArray[i, j] + " ");
                Console.WriteLine();
            }
        }

        private static void StructClass()
        {
            PointVal a = new PointVal
            {
                X = 10,
                Y = 15
            };

            PointRef b = new PointRef
            {
                X = 11,
                Y = 16
            };

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

        private static void Swap(ref int i, ref int y)
        {
            int tmp = i;
            i = y;
            y = i;
        }

        private static void BoxingAndUnboxing()
        {
            object obj = 1; // Создали объект ссылочного типа, где значение 1 будет упаковано и выделено на куче
            ref object a = ref obj; // Присвоили ссылку объекта ссылочному типу
            int y = (int)obj; // Значение было извлечено из упакованного объекта и приведено к типу int
        }

        private static void HlfAbst()
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

        private static void EnumWork()
        {
            LightControl a = new LightControl();
            a.SwitchLight(TrafficLights.Green);
        }

        private static void CheckCustomStack()
        {
            CustomStack<int> a = new CustomStack<int>();
            
            a.Push(1);
            a.Push(1);
            a.Push(1);
            a.Push(1);
            foreach (var vas in a)
            {
                Console.WriteLine(vas);
            }
            Console.WriteLine(a.Peek());
            a.Pop();
            Console.WriteLine(a.Peek());
            a.Pop();
            Console.WriteLine(a.Peek());
            a.Pop();
            Console.WriteLine(a.Peek());
            a.Pop();
        }

        private static void CheckMyInt()
        {
            IUse b = new Stack();
            b.Add(4);
            
            IControl a = new Stack();
            a.Add(2);
            a.Add2();
            
            List<int> list = new List<int>(){1,3,5,7,9};
            IControl z = new Stack();
            z.AddRange(list);
        }
    }

}

// private static void ExceptionRead()
// {
//         
//     //bad way
//     // string res = Console.ReadLine();
//     //
//     // int a = int.Parse(res);
//     //
//     // Console.WriteLine(a);
//
//     FileStream file = null;
//     try
//     {
//         file = File.Open("temp.txt", FileMode.Open);
//     }
//     catch (IOException e)
//     {
//         Console.WriteLine(e);
//     }
//     finally
//     {
//         if (file != null)
//         {
//             file.Dispose();
//         }
//     }
//
//     string res = Console.ReadLine();
//     try
//     {
//         int a = int.Parse(res);
//     }
//     catch (OverflowException e)
//     {
//         Console.WriteLine(e.ToString());
//     }
//     catch (FormatException e)
//     {
//         Console.WriteLine(e.ToString());
//         throw;
//     }
//     //отработает базоыый тип, если не отработают исключения выше
//     catch (Exception ex)
//     {
//              
//     }
//
//     int x = 10;
//     if (x != 0)
//         throw new ArgumentException("ISnot equal 0");//выбрасывает исключенрия сообственное если что-то не совпаадает 
//
//     if (x != 0)
//         throw new DrawException("Error!");
// }
//
//
//     
//     
//
//
// public class DrawException : Exception
// {
//     public DrawException(string a):base(a) //вызывыет конструктор   
//     {
//         Console.WriteLine(a);
//     }
// }