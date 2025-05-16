using System.Collections.Generic;

public static class ItemDatabase
{
    public static List<Item> AllItems = new List<Item>
    {
        // Yemek
        new Item {
            Name = "Ot",
            Type = ItemType.Food,
            CompatibleWith = new List<PetType> { PetType.Cow, PetType.Sheep, PetType.Goat },
            AffectedStat = PetStat.Hunger,
            EffectAmount = 10,
            Duration = 1.0f
        },
        new Item {
            Name = "Ekmek Kırıntısı",
            Type = ItemType.Food,
            CompatibleWith = new List<PetType> { PetType.Chicken },
            AffectedStat = PetStat.Hunger,
            EffectAmount = 10,
            Duration = 1.0f
        },
        new Item {
            Name = "Tavuk Yemi",
            Type = ItemType.Food,
            CompatibleWith = new List<PetType> { PetType.Chicken },
            AffectedStat = PetStat.Hunger,
            EffectAmount = 30,
            Duration = 2.0f
        },
        new Item {
            Name = "Saman",
            Type = ItemType.Food,
            CompatibleWith = new List<PetType> { PetType.Cow },
            AffectedStat = PetStat.Hunger,
            EffectAmount = 30,
            Duration = 2.0f
        },
        new Item {
            Name = "Mısır",
            Type = ItemType.Food,
            CompatibleWith = new List<PetType> { PetType.Sheep, PetType.Goat },
            AffectedStat = PetStat.Hunger,
            EffectAmount = 30,
            Duration = 2.0f
        },

        // Uyku
        new Item {
            Name = "Ahır",
            Type = ItemType.Toy,
            CompatibleWith = new List<PetType> { PetType.Cow, PetType.Sheep, PetType.Goat },
            AffectedStat = PetStat.Sleep,
            EffectAmount = 35,
            Duration = 2.0f
        },
        new Item {
            Name = "Kümes",
            Type = ItemType.Toy,
            CompatibleWith = new List<PetType> { PetType.Chicken },
            AffectedStat = PetStat.Sleep,
            EffectAmount = 35,
            Duration = 2.0f
        },

        // Fun
        new Item {
            Name = "Zil",
            Type = ItemType.Toy,
            CompatibleWith = new List<PetType> { PetType.Cow, PetType.Sheep, PetType.Goat },
            AffectedStat = PetStat.Fun,
            EffectAmount = 20,
            Duration = 1.5f
        },
        new Item {
            Name = "Fırça",
            Type = ItemType.Toy,
            CompatibleWith = new List<PetType> { PetType.Cow },
            AffectedStat = PetStat.Fun,
            EffectAmount = 30,
            Duration = 2.0f
        },
        new Item {
            Name = "Tarak",
            Type = ItemType.Toy,
            CompatibleWith = new List<PetType> { PetType.Sheep },
            AffectedStat = PetStat.Fun,
            EffectAmount = 30,
            Duration = 2.0f
        },
        new Item {
            Name = "Parkur",
            Type = ItemType.Toy,
            CompatibleWith = new List<PetType> { PetType.Goat },
            AffectedStat = PetStat.Fun,
            EffectAmount = 30,
            Duration = 2.0f
        },
        new Item {
            Name = "Horoz",
            Type = ItemType.Toy,
            CompatibleWith = new List<PetType> { PetType.Chicken },
            AffectedStat = PetStat.Fun,
            EffectAmount = 50,
            Duration = 4.0f
        },
        new Item {
            Name = "Top",
            Type = ItemType.Toy,
            CompatibleWith = new List<PetType> { PetType.Chicken },
            AffectedStat = PetStat.Fun,
            EffectAmount = 20,
            Duration = 1.5f
        }
    };
}
