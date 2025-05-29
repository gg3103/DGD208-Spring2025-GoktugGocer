using System;
using System.Threading.Tasks;
using System.Collections.Generic;

public static class StatKontrol
{
    private static Dictionary<Pet, Task> runningTasks = new Dictionary<Pet, Task>();

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
                        Console.WriteLine($"> {pet.Name} has died due to a stat reaching 0.");
                        break;
                    }
                }
            });

            runningTasks[pet] = task;
        }
    }
}
