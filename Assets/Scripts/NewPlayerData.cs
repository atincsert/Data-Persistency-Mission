using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class NewPlayerData 
{
    public int score;
    public string name;

    public NewPlayerData(NewPlayer player)
    {
        score = player._score;
        name = player._name;
    }
}
