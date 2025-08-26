using System.Collections.Generic;
using UnityEngine;

public static class ObjectDatabase
{
    public static List<string> foundObjectIDs = new List<string>();
    public static Dictionary<string, (int index, string displayName)> objectInfo = new Dictionary<string, (int, string)>()
    {
        { "book2", (0, "Book") },
        { "car", (1, "Car Toy") },
        { "cat", (2, "Cat") },
        { "clock", (3, "Clock") },
        { "fish", (4, "Goldfish") },
        { "food", (5, "Cat Food") },
        { "jewelry", (6, "Jewelry") },
        { "magnet", (7, "Fridge Magnet") },
        { "mug", (8, "Mug") },
        { "pan", (9, "Pan") },
        { "penguim", (10, "Penguim") },
        { "phone", (11, "Telephone") },
        { "plant", (12, "Plant") },
        { "portrait", (13, "Portrait") },
        { "poster", (14, "Poster") },
        { "radio", (15, "Radio") },
        { "ration", (16, "Ration Pack") },
        { "rubik", (17, "Rubik's Cube") },
        { "sheet", (18, "Sheet") },
        { "watch", (19, "Watch") }
    };
}
