using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class SolutionOne : MonoBehaviour
{
    #region Declares
    public string CharacterName;
    public int Level;
    public int ConScore;
    public string Class;
    public string Race;
    public float HitPoints;
    public bool Tough = false;
    public bool Stout = false;
    private string FeatT;
    private string FeatS;
    public bool HpRoll = false;
    #endregion



// Start is called once before the first execution of Update after the MonoBehaviour is created
void Start()
    {
        //Hit dice depending on class
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
        //modifier depending on constitution score
        var Modifiers = new Dictionary<int, int>()
        {
            {1,-5},
            {2,-4},
            {3,-4},
            {4,-3},
            {5,-3},
            {6,-2},
            {7,-2},
            {8,-1},
            {9,-1},
            {10,0},
            {11,0},
            {12,1},
            {13,1},
            {14,2},
            {15,2},
            {16,3},
            {17,3},
            {18,4},
            {19,4},
            {20,5},
            {21,5},
            {22,6},
            {23,6},
            {24,7},
            {25,7},
            {26,8},
            {27,8},
            {28,9},
            {29,9},
            {30,10}
        };

        //check if race with modifier and if so apply modifier to constutition score
        #region RaceCheck
        if ( Stout == true)
        {
            ConScore = ConScore + 1;
        }
        if (Race == "Dwarf" || Race == "dwarf")
        {
            ConScore = ConScore + 2;
        }
        if (Race == "Orc" || Race == "orc")
        {
            ConScore = ConScore + 1;
        }
        if (Race == "Goliath" || Race == "goliath")
        {
            ConScore = ConScore + 1;
        }
        #endregion

        //check for class and give specific hit die
        int HitDie = Classes[Class];
        Debug.Log($"The Hit Die Value is a d{HitDie}");
        //apply modifier to constutition score
        int ConMod = Modifiers[ConScore];
        Debug.Log($"The Constitution Modifier is {ConMod}");

        if (HpRoll == true)
        {
            //roll dice based on level
            for (int i = 0; i < Level; i++)
            {
                //dice roll added to total hit points
                HitPoints = HitPoints + UnityEngine.Random.Range(1,HitDie);
                // add constution modifier to hit points
                HitPoints = HitPoints + ConMod;
                //if you have tough add hit points to total
                if ( Tough == true)
                {
                    HitPoints = HitPoints + 2;
                }
            }
        }
        if (HpRoll == false)
        {
            //calculate hit points by finding the average roll
            HitPoints = ((HitDie / 2) + 0.5f) * Level + (ConMod * Level);
            if ( Tough == true)
                {
                    HitPoints = HitPoints + (2 * Level);
                }
        }
        Debug.Log($"You have this amount of Hit Points: {HitPoints}");

        //check for feats and output accordingly
        #region Feats Debug
        if ( Tough == true)
        {
            FeatT = "has the Tough Feat";
        }
        else 
        {
            FeatT = "doesn't have the Tough Feat";
        }
        if ( Stout == true)
        {
            FeatS = "has the Stout Feat";
                
        }
        else 
        {
            FeatS = "doesn't have the Stout Feat";
        }
        #endregion
        //output character summary
        Debug.Log($"My Character {CharacterName} is a level {Level} {Class} with a CON score of {ConScore} and is the {Race} race {FeatT} {FeatS} and has a Health Value of {HitPoints}");
    }

}
