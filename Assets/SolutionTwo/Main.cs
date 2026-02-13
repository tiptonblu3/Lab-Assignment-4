using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{

    public string CharacterName; 

    [Header("Stats")]
    public string className; // Type "Fighter", "Wizard", etc. here
    public string Race;
    public int Level;
    public int ConScore;
    public int HitPoints;
    public bool Tough = false;
    public bool Stout = false;
    [SerializeField] private int hitDieResult;
    [SerializeField] private int ConMod;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //class name for pulling hitdice out of class dictionary
        hitDieResult = GameData.GetHitDie(className);
        //calculate con mod and apply any modifiers to con score
        ConModCalc();




        Debug.Log($"My Character {CharacterName} is a {className} with a Hitdie of {hitDieResult}. The con score is {ConMod}");


        // Level, Class. Conscore, Race, Feats, Hit Points

        //Debug.Log($"My Character {CharacterName} is a level {Level} {Class} with a CON score of {ConScore} and is the 
        //{Race} race {FeatT} {FeatS} and has a Health Value of {HitPoints}");
    }

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










}
