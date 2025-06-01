using System;
using System.Threading.Tasks;
using System.Collections.Generic;

public static class StatKontrol
{
    private static Dictionary<Pet, Task> runningTasks = new Dictionary<Pet, Task>();
    private static Random random = new Random();

    public static void StartForPet(Pet pet)
    {
        if (!runningTasks.ContainsKey(pet))
        {
            var task = Task.Run(async () =>
            {
                while (true)
                {
                    await Task.Delay(5000);

                    pet.DecreaseStat(PetStat.Hunger, 1);
                    pet.DecreaseStat(PetStat.Sleep, 1);
                    pet.DecreaseStat(PetStat.Fun, 1);

                    if (pet.Hunger == 0 || pet.Sleep == 0 || pet.Fun == 0)
                    {
                        Console.WriteLine($"> {pet.Name} has died.");
                        PetEkrani.RemovePet(pet);
                        ApplyRandomEffectToOtherPets();
                        break;
                    }
                }
            });

            runningTasks[pet] = task;
        }
    }

    private static void ApplyRandomEffectToOtherPets()
    {
        var allPets = PetEkrani.GetAllPets();
        if (allPets.Count > 0 && random.NextDouble() < 0.15) 
        {
            Console.WriteLine("One animal died. Other animals were badly affected and caught the disease.");
            foreach (var pet in allPets)
            {
                pet.DecreaseStat(PetStat.Hunger, 15);
                pet.DecreaseStat(PetStat.Sleep, 15);
                pet.DecreaseStat(PetStat.Fun, 15);
            }
        }
    }
}
