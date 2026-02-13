using System;

[System.Serializable] // This allows it to show up in the Inspector if needed
public class CharacterData
{
    public string Name;
    public string Class;
    public string Race;
    public int Level;
    public int HP;
    public int Constitution;
    public bool HasTough;
    public bool HasStout;

    // A constructor makes it easy to "fill" the object when you create it
    public CharacterData(string name, string className, string race, int level, int hp, int con, bool tough, bool stout)
    {
        Name = name;
        Class = className;
        Race = race;
        Level = level;
        HP = hp;
        Constitution = con;
        HasTough = tough;
        HasStout = stout;
    }

    // You can move the Print logic here to keep the ControlScript clean
    public void DisplayInfo()
    {
        string featText = (HasTough && HasStout) ? "both Stout and Tough feats" : 
                          (HasTough) ? "the Tough feat" : 
                          (HasStout) ? "the Stout feat" : "no feats";

        UnityEngine.Debug.Log($"Character: {Name}, a Level {Level} {Class} ({Race}) with {HP} HP and {featText}.");
    }
}