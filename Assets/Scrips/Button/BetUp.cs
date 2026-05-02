using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BetUp : MonoBehaviour, IButton, IDataPersistance
{
    private bool gameOver = false;
    [NonSerialized] public int bet;
    public BetDown betDown;
    public TextMesh betText;
    public TextMesh moneyText;
    private int money;
    public void PlaceBet()
    {
        gameObject.GetComponent<Button_Click>().enabled = false;
        betDown.gameObject.GetComponent<Button_Click>().enabled = false;
    }

    public bool RecieveWinnings(int winnings)
    {
        money += winnings;
        if (bet > money)
            bet = money;
        moneyText.text = "Your money:\r\n$" + money;
        betText.text = "Your bet:\r\n$" + bet;
        gameObject.GetComponent<Button_Click>().enabled = true;
        betDown.gameObject.GetComponent<Button_Click>().enabled = true;
        if (money == 0)
        {
            betDown.gameObject.GetComponent<Button_Click>().enabled = false;
            gameOver = true;
            moneyText.text += "\nGame Over!";
            return true;
        }
        return false;
    }
    public void Click()
    {

        bet += 100;
        if (gameOver)
        {
            money = 100;
            moneyText.text = "Your money:\r\n$" + money;
            betDown.gameObject.GetComponent<Button_Click>().enabled = true;
            var hit = GameObject.Find("Hit").GetComponent<Hit>();
            if (hit.startOfGame)
                hit.GetComponentInParent<Button_Click>().enabled = true;
            else
            {
                var newGame = GameObject.Find("NewGame");
                newGame.GetComponent<Button_Click>().enabled = true;
                newGame.GetComponent<BoxCollider2D>().enabled = true;
                newGame.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
            }
            gameOver = false;
        }
        if (bet > money)
            bet = money;
        betDown.bet = bet;
        betText.text = "Your bet:\r\n$" + bet;
    }

    public void LoadData(GameData data)
    {
        money = data.money;
        bet = data.bet;
        betDown.bet = bet;
        moneyText.text = "Your money:\r\n$" + money;
        betText.text = "Your bet:\r\n$" + bet;
        if (money == 0)
        {
            betDown.gameObject.GetComponent<Button_Click>().enabled = false;
            GameObject.Find("Hit").GetComponent<Button_Click>().enabled = false;
            gameOver = true;
            moneyText.text += "\nGame Over!";
        }
    }
    public void SaveData(ref GameData data)
    {
        data.money = money;
        data.bet = bet;
    }
}
