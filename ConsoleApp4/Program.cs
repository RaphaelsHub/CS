namespace ConsoleApp4
{
    //делаем делегаты
    public class Car
    {
        private int speed = 0;

        public delegate void TooFast();
        
        private TooFast _tooFast;
        public void start()
        {
            speed = 10;
        }
        public void Acceletate()
        {
            speed += 10;
            if (speed > 150)
                _tooFast();
        }

        public void stop()
        {
            speed = 0;
        }

        public void RegisterONToFest(TooFast tooFast)
        {
            this._tooFast = tooFast;
        }
        
        
    }
    class Program
    {
        private static Car car;
        static void Main(string[] args)
        {
            car = new Car();
            car.RegisterONToFest(HandleONTooFast);
            car.start();
            
            car.Acceletate();
            car.Acceletate();
            car.Acceletate();
        }

        private static void HandleONTooFast()
        {
            Console.WriteLine("GOT IT");
            car.stop();
        }
    }

}