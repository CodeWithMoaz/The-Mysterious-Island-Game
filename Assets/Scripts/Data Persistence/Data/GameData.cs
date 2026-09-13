using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData 
{

    public int currentLevelIndex;
    public string name;

    public SerializableDictionary<string, bool> collectibles;
    //others

    public GameData() 
    {

        this.currentLevelIndex = 0;
        this.name = "";
        collectibles = new SerializableDictionary<string, bool>();
    }
}
