using System.Collections.Generic;

public static class Inventory
{
    private static Dictionary<string, int> items = new Dictionary<string, int>();

    public static void AddItem(string itemName, int amount)
    {
        if (items.ContainsKey(itemName))
            items[itemName] += amount;
        else
            items[itemName] = amount;
    }

    public static Dictionary<string, int> GetItems()
    {
        return items;
    }

    public static void SetItems(Dictionary<string, int> loadedItems)
    {
        items = loadedItems;
    }

    public static void Clear()
    {
        items.Clear();
    }
}
