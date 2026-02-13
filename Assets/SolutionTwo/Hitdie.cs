using System;
using System.Collections.Generic;
using UnityEngine;

public static class GameData
{
    // 'ReadOnlyDictionary' or just 'IReadOnlyDictionary' prevents external modification
    public static readonly Dictionary<string, int> HitDice = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase)
    {
        {"Artificer", 8},
        {"Barbarian", 12},
        {"Bard", 8},
        {"Cleric", 8},
        {"Druid", 8},
        {"Fighter", 10},
        {"Monk", 8},
        {"Ranger", 10},
        {"Rogue", 8},
        {"Paladin", 10},
        {"Sorcerer", 6},
        {"Wizard", 6},
        {"Warlock", 8}
    };

    //// Optional helper method for cleaner access
    public static int GetHitDie(string className)
    {
        return HitDice.TryGetValue(className, out int die) ? die : 0;
    }
}