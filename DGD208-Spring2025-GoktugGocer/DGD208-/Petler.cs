using System;

public class Pet
{
    private const int maxStat = 100;

    public string Name { get; set; }
    public PetType Type { get; set; }
    public int Hunger { get; private set; } = 50;
    public int Sleep { get; private set; } = 50;
    public int Fun { get; private set; } = 50;

    public Pet(string name, PetType type)
    {
        Name = name;
        Type = type;
    }

    public void IncreaseStat(PetStat stat, int amount)
    {
        switch (stat)
        {
            case PetStat.Hunger:
                Hunger = Math.Min(Hunger + amount, maxStat);
                break;
            case PetStat.Sleep:
                Sleep = Math.Min(Sleep + amount, maxStat);
                break;
            case PetStat.Fun:
                Fun = Math.Min(Fun + amount, maxStat);
                break;
        }
    }

    public void DecreaseStat(PetStat stat, int amount)
    {
        switch (stat)
        {
            case PetStat.Hunger:
                Hunger = Math.Max(Hunger - amount, 0);
                break;
            case PetStat.Sleep:
                Sleep = Math.Max(Sleep - amount, 0);
                break;
            case PetStat.Fun:
                Fun = Math.Max(Fun - amount, 0);
                break;
        }
    }

    public override string ToString()
    {
        return $"- Name: {Name}, Type: {Type}, Hunger: {Hunger}, Sleep: {Sleep}, Fun: {Fun}";
    }
}
