using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int money;
    public int bet;

    public GameData()
    {
        money = 3000;
        bet = 100;
    }
}
