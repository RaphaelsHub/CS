

    private static void ExceptionRead()
    {
        
        //bad way
        // string res = Console.ReadLine();
        //
        // int a = int.Parse(res);
        //
        // Console.WriteLine(a);

        FileStream file = null;
        try
        {
            file = File.Open("temp.txt", FileMode.Open);
        }
        catch (IOException e)
        {
            Console.WriteLine(e);
        }
        finally
        {
            if (file != null)
            {
                file.Dispose();
            }
        }

         string res = Console.ReadLine();
         try
         {
             int a = int.Parse(res);
         }
         catch (OverflowException e)
         {
             Console.WriteLine(e.ToString());
         }
         catch (FormatException e)
         {
             Console.WriteLine(e.ToString());
             throw;
         }
         //отработает базоыый тип, если не отработают исключения выше
         catch (Exception ex)
         {
             
         }

         int x = 10;
         if (x != 0)
             throw new ArgumentException("ISnot equal 0");//выбрасывает исключенрия сообственное если что-то не совпаадает 

         if (x != 0)
             throw new DrawException("Error!");
    }


    
    


public class DrawException : Exception
{
    public DrawException(string a):base(a) //вызывыет конструктор   
    {
        Console.WriteLine(a);
    }
}