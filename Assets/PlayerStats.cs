using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int Money; //We can distribute accessible using only the player stats type without aquiring instance any particular object in scene
    public int startMoney = 400; 

    public static int Lives;
    public int startLives = 20; 

    public static int Rounds;

    void Start () {
        Money = startMoney; 
        Lives = startLives;
        Rounds = 0;  
    }
}

