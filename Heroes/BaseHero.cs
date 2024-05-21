namespace Heroes;

public class BaseHero
{
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
    protected Speed SpeedParametr { get; set; }
    
    private float _agility; // Ловкость
    protected float Agility
    {
        get => _agility;
        set
        {
            _agility = value;
            _agility = GetAgilityParam();
        }
    }

    protected BaseHero(HeroStateModel? model)
    {
        
        if (model != null)
        {
            Name = model.Name + Index.ToString();
            CurrentLvl = model.CurrentLvl;
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
    public BaseHero() {}


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
    private void LevelUp() { Console.WriteLine("LevelUpLogic"); }
    
    // Получение урона, атака, лечение  - реалиазация какой угодно логики
    public void Treatment(uint hp) { Console.WriteLine("TreatmentLogic"); }
    public void GetDamage(uint damagePoints) { Console.WriteLine("GetDamageLogic"); }
    public void Attack() { Console.WriteLine("AttackLogic"); }
}

public class Archer : BaseHero
{
    public Archer():base(HeroStateLoad.LoadHeroStats(nameof(Archer),10)) { }
    public new void Treatment(uint hp) { Console.WriteLine("NewTreatmentLogic"); }
}