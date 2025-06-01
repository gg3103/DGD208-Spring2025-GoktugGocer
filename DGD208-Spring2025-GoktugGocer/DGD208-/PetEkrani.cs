using System.Collections.Generic;

public static class PetEkrani
{
    private static List<Pet> pets = new List<Pet>();

    public static void AddPet(Pet pet)
    {
        pets.Add(pet);
        StatKontrol.StartForPet(pet);
    }

    public static void RemovePet(Pet pet)
    {
        pets.Remove(pet);
    }

    public static List<Pet> GetAllPets()
    {
        return pets;
    }
}
