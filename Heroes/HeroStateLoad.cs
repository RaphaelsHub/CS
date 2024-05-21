using System.Collections;
using Newtonsoft.Json;

namespace Heroes;

public static class HeroStateLoad
{
    public static HeroStateModel? LoadHeroStats(string heroType, uint lvl)
    {
        var json = File.ReadAllText(@"D:\\Repositories\\C_Sharp_Reminder\\Heroes\\heroes.json");
        
        
        // Десериализуем JSON в объект
        dynamic data = JsonConvert.DeserializeObject(json)!;

        // Извлекаем данные о нужном типе героя и уровне
        dynamic? heroData = data?[heroType]["Level" + lvl];

        HeroStateModel heroState = new HeroStateModel
        {
            Name = heroData?.name,
            CurrentLvl = heroData?.currentLvl,
            CurrentHealth = heroData?.currentHealth,
            CurrentStamina = heroData?.currentStamina,
            CurrentExp = heroData?.currentExp,
            ExpLvl = heroData?.expLvl,
            TimeRegeneratingStamina = heroData?.timeRegeneratingStamina,
            CurrentArmor = heroData?.currentArmor,
            AttackDamage = heroData?.attackDamage,
            AttackRange = heroData?.attackRange,
            AttackDeltaTime = heroData?.attackDeltaTime,
            CriticalHitChance = heroData?.criticalHitChance,
            SpeedParametr = Enum.Parse<Speed>(heroData?.speedParametr.ToString())
        };

        return heroState;
    }
    
    public  static HeroStateModel? LoadHeroState(string heroType, uint lvl)
    {
        string filePath = @"D:\Repositories\C_Sharp_Reminder\Heroes\heroes.json";
        string json = File.ReadAllText(filePath);
        var data = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, HeroStateModel>>>(json);

        if (data != null && data.ContainsKey(heroType) && data[heroType].ContainsKey("Level" + lvl))
        {
            var heroData = data[heroType]["Level" + lvl];

            HeroStateModel heroState = new HeroStateModel
            {
                Name = heroData.Name,
                CurrentLvl = heroData.CurrentLvl,
                CurrentHealth = heroData.CurrentHealth,
                CurrentStamina = heroData.CurrentStamina,
                CurrentExp = heroData.CurrentExp,
                ExpLvl = heroData.ExpLvl,
                TimeRegeneratingStamina = heroData.TimeRegeneratingStamina,
                CurrentArmor = heroData.CurrentArmor,
                AttackDamage = heroData.AttackDamage,
                AttackRange = heroData.AttackRange,
                AttackDeltaTime = heroData.AttackDeltaTime,
                CriticalHitChance = heroData.CriticalHitChance,
                SpeedParametr = heroData.SpeedParametr
            };

            return heroState;
        }

        return null;
    }
}



