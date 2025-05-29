using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class Game
{
    private bool _isRunning = true;

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
        Console.WriteLine("4. Show project creator");
        Console.WriteLine("5. Exit the game");
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
                Console.WriteLine("\n[Item Usage] This feature will be added soon.\n");
                break;
            case "4":
                Console.WriteLine("\n Created by Goktug Gocer.\nStudent ID: 225040074\n");
                break;
            case "5":
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
            Console.WriteLine($" { name}the { selectedType} has been adopted!");
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
}
