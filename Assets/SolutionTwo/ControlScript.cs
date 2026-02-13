using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using UnityEngine;

public class ControlScript : MonoBehaviour
{
    #region Declares
[Header("Stats")]
    public string CharacterName; 
    public string className; // Type "Fighter", "Wizard", etc. here
    public string Race;
    public int Level;
    public int ConScore;
    public int HitPoints;
    public bool Tough = false;
    public bool Stout = false;
    public bool ManuellyCalculatedHitDie = false;
    public bool RolledHitDie = true;
    [SerializeField] private int hitDieResult;
    [SerializeField] private int ConMod;
    private int TotalNum;
    private float AverageNum;
    private float roundedUpHP;
    #endregion

public CharacterData myCreatedCharacter;
    void Start()
    {
        //class name for pulling hitdice out of class dictionary
        hitDieResult = GameData.GetHitDie(className);
        //calculate con mod and apply any modifiers to con score
        ConModCalc();
        HitpointCalc();
//run these before finial message so that the final message can pull the correct hit point total and con mod for the character


myCreatedCharacter = new CharacterData(CharacterName, className, Race, Level, HitPoints, ConScore, Tough, Stout);
myCreatedCharacter.DisplayInfo();
        
        
    }

//calculate con modifiers to apply to hit point calculation and apply any modifiers to con score
    void ConModCalc()
    {
        //Check if there are any modifiers that could change con score
        if (Stout == true)
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
        //check con score modifier after feats and race modifiers are applied
        ConMod = Modifiers.GetModifier(ConScore);

    }

//figure out differing calculations depending on if you want to roll hit die or just use average and round up. Apply con mod and feats to final hit point calculation.
    void HitpointCalc()
    {
        if (ManuellyCalculatedHitDie == true)
        {
        
        AverageNum = (12 / 2) + 0.5f;
        roundedUpHP = (Level * AverageNum) + ConMod;
                Debug.Log(roundedUpHP   );
        HitPoints = (int)Math.Ceiling(roundedUpHP); 
        Debug.Log(AverageNum);

        
        }
        else if (RolledHitDie == true)
        {
                    HitPoints = (Level * hitDieResult) + ConMod;
        }

        else{}


    }

                      


}
 