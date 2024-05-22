namespace Heroes;

public interface IHitUltra
{
    public void HitWithUltraDamage(BaseHero a);
}

public interface IHitBang
{
    public void HitWithBomba(BaseHero a);
}
public abstract class BaseHero: IHitUltra
{
    private static Random _random;
    public static uint Index = 1;

    //Constants
    private const uint MaxLvl = 15;
    private const uint MaxHealth = 150;
    private const uint MaxStamina = 100;
    private const uint MaxArmor = 100;
    private const uint MaxDamagePoint = 1000;

    //Current characteristics
    protected string Name { get; set; } = null!;
    protected uint CurrentLvl { get; set; }
    protected uint CurrentExp { get; set; } //Тякущий опыт
    protected uint ExpLvl { get; set; } //кол опыта для того чтобы перепрыгнуть с нынешнего уровня на следующий
    protected uint CurrentHealth { get; set; }
    protected uint CurrentStamina { get; set; }
    protected float TimeRegeneratingStamina { get; set; }
    protected uint CurrentArmor { get; set; }
    protected uint AttackDamage { get; set; }
    protected float AttackRange { get; set; }
    protected float AttackDeltaTime { get; set; } // Разница времени между концом атаки и началом
    protected float CriticalHitChance { get; set; }

    private Speed _speedParametr;

    protected Speed SpeedParametr
    {
        get { return _speedParametr; }
        set
        {
            _speedParametr = value;
            _agility = GetAgilityParam();
        }
    }

    private float _agility; // Ловкость

    protected float Agility => _agility;

    //CheckLevelUp
    public event Action? CheckOnLevelUp;

    //Constructors
    protected BaseHero(HeroStateModel? model)
    {
        LoadLblConfig(model);
        CheckOnLevelUp += LevelUp;
        _random = new Random();
    }

    protected BaseHero()
    {
    }


    public abstract void CallWarior();

    
    //Метод установление ловкости, скорости, и метод с нереализованной логикой поднятия на новый уровень
    private float GetAgilityParam()
    {
        switch (SpeedParametr)
        {
            case Speed.VeryHigh:
                _agility = 1f;
                break;
            case Speed.High:
                _agility = 0.80f;
                break;
            case Speed.Medium:
                _agility = 0.60f;
                break;
            case Speed.Low:
                _agility = 0.40f;
                break;
            case Speed.VeryLow:
                _agility = 0.30f;
                break;
            default:
                _agility = 0f;
                break;
        }

        return _agility;
    }

    private void LevelUp()
    {
        Console.WriteLine("LevelUpLogic");
        if (CurrentLvl < MaxLvl)
        {
            CurrentLvl++;
            LoadLblConfig(HeroStateLoad.LoadHeroState("Archer", CurrentLvl));
        }
    }

    private void LoadLblConfig(HeroStateModel? model)
    {
        if (model != null)
        {
            Name = model.Name + Index.ToString();
            CurrentExp = model.CurrentExp;
            ExpLvl = model.ExpLvl;
            CurrentLvl = model.CurrentLvl;
            CurrentHealth = model.CurrentHealth;
            CurrentStamina = model.CurrentStamina;
            TimeRegeneratingStamina = model.TimeRegeneratingStamina;
            CurrentArmor = model.CurrentArmor;
            AttackDamage = model.AttackDamage;
            AttackRange = model.AttackRange;
            AttackDeltaTime = model.AttackDeltaTime;
            CriticalHitChance = model.CriticalHitChance;
            SpeedParametr = model.SpeedParametr;
        }
    }


    // Получение урона, атака, лечение  - реалиазация какой угодно логики
    public virtual void Treatment(uint hp)
    {
        CurrentHealth = Math.Min(CurrentHealth + hp, MaxHealth);
        Console.WriteLine($"Healing {hp} HP. Current health: {CurrentHealth}");
    }

    public virtual void GetDamage(uint damagePoints)
    {
        uint actualDamage = Math.Min(damagePoints, CurrentHealth);
        CurrentHealth -= actualDamage;
        Console.WriteLine($"Taking {actualDamage} damage. Current health: {CurrentHealth}");
    }

    public virtual void Attack()
    {
        Console.WriteLine("AttackLogic");


        CurrentExp += (uint)_random.Next(100, 200);

        if (CurrentExp >= ExpLvl)
            CheckOnLevelUp?.Invoke();

        if (CurrentLvl == MaxLvl && CheckOnLevelUp != null)
            CheckOnLevelUp -= LevelUp;
    }


    public virtual void Die()
    {
        //some logic
        if (CheckOnLevelUp != null)
            CheckOnLevelUp -= LevelUp;
    }

    public virtual void HitWithUltraDamage(BaseHero a)
    {
        if (this != a)
            a.GetDamage(20);
    }
}

public class Archer : BaseHero,IHitBang
{
    // прежде временно можно считать данные откуда-то и прогрузить именно те уровни которые нужны нам
    public Archer() : base(HeroStateLoad.LoadHeroStats(nameof(Archer), 1))
    {
        Attack();
    }


    public override void Treatment(uint hp)
    {
        base.Treatment(hp);
        Console.WriteLine("NewTreatmentLogic");
    }

    public override void CallWarior()
    {
        // вызов какого-то списка других кричалок
        Console.WriteLine("HA-HA, I am Elif");
    }

    public void HitWithBomba(BaseHero a)
    {
        if(this!=a)
            a.GetDamage(500);
    }
}