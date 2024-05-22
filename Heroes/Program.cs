namespace Heroes;

static class Program
{
    static void Main(string[] args)
    {
        BaseHero a = new Archer();
        List<BaseHero> team = new List<BaseHero>();
        
        for (int i = 0; i < 2; i++)
        {
            team.Add(new Archer());
            if (team[i] is IHitBang archer)
            {
                archer.HitWithBomba(team[i]);
            }
        }
    }
}