namespace Delegate;

//1 способ делегата!
/*
class Car
{
    private float _curSpeed;
    private float _speed;
    private float _maxSpeed;

    //Delegate
    public delegate void CheckSpeed(float speed);

    //Type of methods
    private CheckSpeed ControlUp { get; set; } = null!;
    private CheckSpeed ControlDown { get; set; } = null!;

    //Constructors
    public Car() {}
    public Car(CheckSpeed controlUp, CheckSpeed controlDown)
    {
        _curSpeed = 0;
        _speed = 10f;
        _maxSpeed = 45f;
        ControlUp += controlUp;
        ControlDown += controlDown;
    }

    //Core methods Start,gaz,tormoz
    public void Start()
    {
        _speed = 10f;
    }
    
    public void Gaz()
    {
        if (_curSpeed < 45)
        {
            ControlUp?.Invoke(_speed);
            // ControlUp(_speed);
            float delta = _maxSpeed - _curSpeed;
            
            if (_speed < delta)
                _curSpeed += _speed;
            else
                _curSpeed += delta;
        }
        else
        {
            Random random = new Random();
            float randomTormozImitation = (float)(random.NextDouble() * (5 - 1) + 1);

            ControlDown?.Invoke(randomTormozImitation);
        }
    }
    public void Stop(float speed)
    {
        _speed = 0;
        _curSpeed -= speed;
    }
    
    public void UnSubscribeOnSpeedUp(CheckSpeed control)
    {
        this.ControlUp -= control;
    }

    public void UnSubcribeOnSpeedDown(CheckSpeed control)
    {
        this.ControlDown -= control;
    }
}

class Program
{
    private static Car? _car;

    private static void Main()
    {
        _car = new Car(HandleOnCheckSpeedUp,HandleOnCheckSpeedDown);
        
        _car.UnSubscribeOnSpeedUp(HandleOnCheckSpeedUp);
        _car.UnSubcribeOnSpeedDown(HandleOnCheckSpeedDown);
        
        for (int i = 0; i < 10; i++)
        {
            _car.Gaz();
        }
    }

    private static void HandleOnCheckSpeedDown(float speed)
    {
        Console.WriteLine("Calling speed down!");
        _car?.Stop(speed);
    }
    private static void HandleOnCheckSpeedUp(float speed)
    {
        Console.WriteLine("Calling speed up!");
        _car?.Start();
    }
}
*/

//2 способ делегата!
/*
class Track
{
    private float _curSpeed;
    private float _speed;
    private float _maxSpeed;

    //Delegate
    public delegate void CheckSpeed(float speed);

    //Type of methods
    public  CheckSpeed ControlUp;
    public  CheckSpeed ControlDown;
    
    //Constructors
    public Track()
    {
        _curSpeed = 0;
        _speed = 10f;
        _maxSpeed = 45f;
    }

    //Core methods Start,gaz,tormoz
    public void Start()
    {
        _speed = 10f;
    }
    
    public void Gaz()
    {
        if (_curSpeed < 45)
        {
            ControlUp?.Invoke(_speed);
            // ControlUp(_speed);
            float delta = _maxSpeed - _curSpeed;
            
            if (_speed < delta)
                _curSpeed += _speed;
            else
                _curSpeed += delta;
        }
        else
        {
            Random random = new Random();
            float randomTormozImitation = (float)(random.NextDouble() * (5 - 1) + 1);

            ControlDown?.Invoke(randomTormozImitation);
        }
    }
    public void Stop(float speed)
    {
        _speed = 0;
        _curSpeed -= speed;
    }
}

class Program
{
    private static Track? _track;

    private static void Main()
    {
        _track = new Track();

        _track.ControlUp += HandleOnCheckSpeedUp;
        _track.ControlDown += HandleOnCheckSpeedDown;
        
        for (int i = 0; i < 10; i++)
        {
            _track.Gaz();
        }
    }

    private static void HandleOnCheckSpeedDown(float speed)
    {
        Console.WriteLine("Calling speed down!");
        _track?.Stop(speed);
    }
    private static void HandleOnCheckSpeedUp(float speed)
    {
        Console.WriteLine("Calling speed up!");
        _track?.Start();
    }
}
*/


//3 способ делегата = action!

class Track
{
    private float _curSpeed;
    private float _speed;
    private float _maxSpeed;

    //Action Func - возвращает значение
    public event Action<object,float> ControlUp; //передаем ссылку, int
    public event Action<object,float> ControlDown;
    
    public event EventHandler<float> ControlUpTheSame;
    public event EventHandler<float> ControlDownTheSame;
    
    public event Func<float,float> ControlUpFunc; //передаем float  и возвращаем переменную типа float
    public event Func<float,float> ControlDownFunc;
    
    

    //Constructors
    public Track()
    {
        _curSpeed = 0;
        _speed = 10f;
        _maxSpeed = 45f;
    }

    //Core methods Start,gaz,tormoz
    public void Start()
    {
        _speed = 10f;
    }
    
    public void Gaz()
    {
        if (_curSpeed < 45)
        {
            ControlUp?.Invoke(this,_speed);
            // ControlUp(_speed);
            float delta = _maxSpeed - _curSpeed;
            
            if (_speed < delta)
                _curSpeed += _speed;
            else
                _curSpeed += delta;
        }
        else
        {
            Random random = new Random();
            float randomTormozImitation = (float)(random.NextDouble() * (5 - 1) + 1);

            ControlDown?.Invoke(this,randomTormozImitation);
        }
    }
    public void Stop(float speed)
    {
        _speed = 0;
        _curSpeed -= speed;
    }
}

class Program
{

    
    private static void Main()
    {
        var track = new Track();

        track.ControlUp += HandleOnCheckSpeedUp;
        track.ControlDown += HandleOnCheckSpeedDown;
        
        for (int i = 0; i < 10; i++)
        {
            track.Gaz();
        }
    }

    private static void HandleOnCheckSpeedDown(object obj,float speed) 
    {
        Console.WriteLine("Calling speed down!");
        var track = (Track)obj;
        track.Start();
    }
    private static void HandleOnCheckSpeedUp(object obj, float speed)
    {
        Console.WriteLine("Calling speed up!");
        var track = (Track)obj;
        track?.Start();
    }
}



