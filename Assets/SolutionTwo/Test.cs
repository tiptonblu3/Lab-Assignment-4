using UnityEngine;

public class Test : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Create Character Class
    public class Character
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public string Race { get; set; }
        public string Class { get; set; }
        public int Health { get; set; }
        

        public Character(string name, int health)
        {
            Name = name;
            Level = Level;
            Race = Race;
            Class = Class;
            Health = health;
            
        }

    }
}
