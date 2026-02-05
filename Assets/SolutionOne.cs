using System;
using System.Collections.Generic;
using UnityEngine;

public class SolutionOne : MonoBehaviour
{
    #region Declares
    public string CharacterName;
    public int Level;
    public int ConScore;
    public string Class;
    public string race;
    #endregion

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        var Classes = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase)
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
        int HitDie = Classes[Class];
        Debug.Log($"The Value is: {HitDie}");
    }

}
