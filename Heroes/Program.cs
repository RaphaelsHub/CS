namespace Heroes;

static class Program
{
    static void Main(string[] args)
    {
        BaseHero a = new Archer();
        IHitBang b = new Archer();
        IHitUltra c = new Archer();
        c.HitWithUltraDamage((BaseHero)b);
    }
}