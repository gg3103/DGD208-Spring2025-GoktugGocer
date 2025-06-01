using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class Game
{
    private bool _isRunning = true;
    private static Random random = new Random();

    public async Task GameLoop()
    {
        Console.Clear();
        Console.WriteLine(" Welcome to the Pet Simulator \n");

        while (_isRunning)
        {
            string choice = GetUserInput();
            await ProcessUserChoice(choice);
        }

        Console.WriteLine("\nExiting..");
    }

    private string GetUserInput()
    {
        Console.WriteLine(" MAIN MENU ");
        Console.WriteLine("1. Adopt a new pet");
        Console.WriteLine("2. View pet statuses");
        Console.WriteLine("3. Use an item on a pet");
        Console.WriteLine("4. Harvest Animals");
        Console.WriteLine("5. Inventory");
        Console.WriteLine("6. Complete Order");
        Console.WriteLine("7. Show project creator");
        Console.WriteLine("8. Exit the game");
        Console.Write("Your choice: ");
        return Console.ReadLine();
    }

    private async Task ProcessUserChoice(string choice)
    {
        switch (choice)
        {
            case "1":
                await AdoptPet();
                break;
            case "2":
                ShowPetStatuses();
                break;
            case "3":
                await UseItemOnPet();
                break;
            case "4":
                await HarvestAnimal();
                break;
            case "5":
                ShowInventory();
                break;
            case "6":
                await CompleteOrder();
                break;
            case "7":
                Console.WriteLine("\n Created by Goktug Gocer.\nStudent ID: 225040074\n");
                break;
            case "8":
                _isRunning = false;
                break;
            default:
                Console.WriteLine("\nInvalid selection. Please try again.\n");
                break;
        }

        Console.WriteLine("\nPress any key to return to the menu...");
        Console.ReadKey();
        Console.Clear();
    }

    private async Task AdoptPet()
    {
        Console.Clear();
        Console.WriteLine("Choose a pet type:");
        var petTypes = Enum.GetValues(typeof(PetType)).Cast<PetType>().ToList();
        for (int i = 0; i < petTypes.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {petTypes[i]}");
        }
        Console.Write("Your choice: ");
        if (int.TryParse(Console.ReadLine(), out int typeChoice) && typeChoice >= 1 && typeChoice <= petTypes.Count)
        {
            PetType selectedType = petTypes[typeChoice - 1];
            Console.Write("Enter a name for your pet: ");
            string name = Console.ReadLine();
            var newPet = new Pet(name, selectedType);
            PetEkrani.AddPet(newPet);
            Console.WriteLine($" {name} the {selectedType} has been adopted.");
        }
        else
        {
            Console.WriteLine("Invalid selection.");
        }

        await Task.CompletedTask;
    }

    private void ShowPetStatuses()
    {
        Console.Clear();
        var allPets = PetEkrani.GetAllPets();
        if (allPets.Count == 0)
        {
            Console.WriteLine("No pets adopted yet.");
        }
        else
        {
            Console.WriteLine("Your Pets:");
            foreach (var pet in allPets)
            {
                Console.WriteLine(pet.ToString());
            }
        }
    }

    private async Task UseItemOnPet()
    {
        Console.Clear();
        var allPets = PetEkrani.GetAllPets();
        if (allPets.Count == 0)
        {
            Console.WriteLine("No pets available.");
            return;
        }

        Console.WriteLine("Select a pet:");
        for (int i = 0; i < allPets.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {allPets[i].Name} ({allPets[i].Type})");
        }
        Console.Write("Your choice: ");
        if (int.TryParse(Console.ReadLine(), out int petChoice) && petChoice >= 1 && petChoice <= allPets.Count)
        {
            var selectedPet = allPets[petChoice - 1];

            var compatibleItems = ItemDatabase.AllItems
                .Where(item => item.CompatibleWith.Contains(selectedPet.Type))
                .ToList();

            if (compatibleItems.Count == 0)
            {
                Console.WriteLine("No item for this animal");
                return;
            }

            Console.WriteLine("\nAvailable Items:");
            for (int i = 0; i < compatibleItems.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {compatibleItems[i].Name} (+{compatibleItems[i].EffectAmount} {compatibleItems[i].AffectedStat})");
            }
            Console.Write("Your choice: ");
            if (int.TryParse(Console.ReadLine(), out int itemChoice) && itemChoice >= 1 && itemChoice <= compatibleItems.Count)
            {
                var selectedItem = compatibleItems[itemChoice - 1];
                Console.WriteLine($"Using {selectedItem.Name} on {selectedPet.Name}...");

                await Task.Delay((int)(selectedItem.Duration * 1000));

                selectedPet.IncreaseStat(selectedItem.AffectedStat, selectedItem.EffectAmount);
                Console.WriteLine($"{selectedItem.Name} used on {selectedPet.Name}. Stat increased!");
            }
            else
            {
                Console.WriteLine("Invalid item selection.");
            }
        }
        else
        {
            Console.WriteLine("Invalid pet selection.");
        }
    }

    private async Task HarvestAnimal()
    {
        Console.Clear();
        var allPets = PetEkrani.GetAllPets();
        if (allPets.Count == 0)
        {
            Console.WriteLine("No pets available to harvest.");
            return;
        }

        Console.WriteLine("Select a pet to harvest:");
        for (int i = 0; i < allPets.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {allPets[i].Name} ({allPets[i].Type})");
        }
        Console.Write("Your choice: ");
        if (int.TryParse(Console.ReadLine(), out int petChoice) && petChoice >= 1 && petChoice <= allPets.Count)
        {
            var selectedPet = allPets[petChoice - 1];
            var timeSinceLastHarvest = DateTime.Now - selectedPet.LastHarvestTime;
            if (timeSinceLastHarvest.TotalSeconds < 15)
            {
                Console.WriteLine("Enough is enough, there is nothing left for the animal to harvest");
                return;
            }

            Console.WriteLine($"Harvesting {selectedPet.Name}...");
            await Task.Delay(3000); 
            selectedPet.LastHarvestTime = DateTime.Now;

            string productName = selectedPet.Type switch
            {
                PetType.Chicken => "Egg",
                PetType.Cow => "Cow Milk",
                PetType.Goat => "Goat Milk",
                PetType.Sheep => "Wool",
                _ => "Unknown Product"
            };

            int productAmount = (random.NextDouble() < 0.5) ? 1 : 2;
            Inventory.AddItem(productName, productAmount);
            Console.WriteLine($"You harvested {productAmount} {productName}(s) from {selectedPet.Name}!");
        }
        else
        {
            Console.WriteLine("Invalid pet selection.");
        }
    }

    private void ShowInventory()
    {
        Console.Clear();
        var items = Inventory.GetItems();
        if (items.Count == 0)
        {
            Console.WriteLine("Your inventory is empty.");
        }
        else
        {
            Console.WriteLine("Your Inventory:");
            foreach (var item in items)
            {
                Console.WriteLine($"- {item.Key}: {item.Value}");
            }
        }
    }

    private async Task CompleteOrder()
    {
        Console.Clear();
        Console.WriteLine("Order Requirements:");
        Console.WriteLine(" 40 Cow Milk");
        Console.WriteLine(" 30 Egg");
        Console.WriteLine(" 30 Wool");
        Console.WriteLine(" 40 Goat Milk\n");

        var items = Inventory.GetItems();

        bool hasEnough =
            items.ContainsKey("Cow Milk") && items["Cow Milk"] >= 40 &&
            items.ContainsKey("Egg") && items["Egg"] >= 30 &&
            items.ContainsKey("Wool") && items["Wool"] >= 30 &&
            items.ContainsKey("Goat Milk") && items["Goat Milk"] >= 40;

        if (hasEnough)
        {
            Console.WriteLine("You have completed the delivery.Helal Olsun");
            await EndGame();
            _isRunning = false;
        }
        else
        {
            Console.WriteLine("There are not enough products to complete the order.");
        }
    }

    private async Task EndGame()
    {
        Console.Clear();
        Console.WriteLine("The End");
        Console.WriteLine("The game is over and this will be fixed later.");
        Console.WriteLine("The game is over and this will be fixed later.");
        await Task.CompletedTask;
    }
}
