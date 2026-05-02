using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit : MonoBehaviour, IButton
{
    [NonSerialized] public bool startOfGame = true;
    public Button_Click stand;
    public DealCard Player;
    public DealCard Dealer;
    public void Click()
    {
        if (startOfGame)
        {
            Player.StartGame();
            Dealer.StartGame();
            startOfGame = false;
            gameObject.GetComponent<Button_Click>().enabled = false;
        }
        else if (Player.GetComponent<DealCard>().Deal())
        {
            GameObject.Find("EndGame").GetComponent<EndGame>().ShowWinner();
            gameObject.GetComponent<Button_Click>().enabled = false;
            stand.enabled = false;
        }
    }
}
