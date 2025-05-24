using System;
using System.Collections.Generic;
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
                Console.WriteLine("\n This feature will be added soon.\n");
                break;
            case "2":
                Console.WriteLine("\n This feature will be added soon.\n");
                break;
            case "3":
                Console.WriteLine("\n This feature will be added soon.\n");
                break;
            case "4":
                Console.WriteLine("\n Created by Goktug Gocer\nStudent ID: 225040074\n");
                break;
            case "5":
                _isRunning = false;
                break;
            default:
                Console.WriteLine("\nInvalid selection. Please try again.\n");
                break;
        }

        Console.WriteLine("\nPress any key to return to the menu.");
        Console.ReadKey();
        Console.Clear();
    }
}
