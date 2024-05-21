namespace Heroes
{
    public class HeroStateModel
    {
        public string? Name { get; set; }
        public uint CurrentLvl { get; set; }
        public uint CurrentHealth { get; set; }
        public uint CurrentStamina { get; set; }
        public uint CurrentExp { get; set; }
        public uint ExpLvl { get; set; } 
        public float TimeRegeneratingStamina { get; set; }
        public uint CurrentArmor { get; set; }
        public uint AttackDamage { get; set; }
        public float AttackRange { get; set; }
        public float AttackDeltaTime { get; set; }
        public float CriticalHitChance { get; set; }
        public Speed SpeedParametr { get; set; }
    }
}

