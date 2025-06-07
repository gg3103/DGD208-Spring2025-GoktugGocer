using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;

public static class SaveSystem
{
    private static string saveFilePath = "save.json";

    public static void SaveGame()
    {
        var saveData = new SaveData
        {
            Pets = PetEkrani.GetAllPets(),
            InventoryItems = Inventory.GetItems()
        };

        string json = JsonConvert.SerializeObject(saveData, Newtonsoft.Json.Formatting.Indented);
        File.WriteAllText(saveFilePath, json);
    }

    public static void LoadGame()
    {
        if (File.Exists(saveFilePath))
        {
            string json = File.ReadAllText(saveFilePath);
            var saveData = JsonConvert.DeserializeObject<SaveData>(json);

            if (saveData != null)
            {
                PetEkrani.SetPets(saveData.Pets);
                Inventory.SetItems(saveData.InventoryItems);
            }
        }
    }
}

public class SaveData
{
    public List<Pet> Pets { get; set; }
    public Dictionary<string, int> InventoryItems { get; set; }
}
