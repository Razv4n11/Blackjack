using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    [NonSerialized] public bool gameOver = false;
    public Score playerScore;
    public Score dealerScore;
    public Sprite square;
    public GameObject NewGame;
    public BetUp betUp;
    public TextMesh winningsText;

    public void ShowWinner()
    {
        if (playerScore.score > 21)
            DealerWin();
        else if (dealerScore.score > 21)
            PlayerWin();
        else if (playerScore.score < dealerScore.score)
            DealerWin();
        else if (playerScore.score > dealerScore.score)
            PlayerWin();
        else
            Draw();
        if (!gameOver)
        {
            NewGame.GetComponent<Button_Click>().enabled = true;
            NewGame.GetComponent<BoxCollider2D>().enabled = true;
            NewGame.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
        }
        else
            gameObject.GetComponent<TextMesh>().text += "\n\n\n\n\n\nGame\nOver!";
    }
    public void Blackjack()
    {
        gameObject.transform.position = new Vector3(-2.3f, -1);
        gameObject.GetComponent<TextMesh>().text = "Player\nwins!\nBlack\njack";

        NewGame.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
        NewGame.GetComponent<Button_Click>().enabled = true;
        NewGame.GetComponent<BoxCollider2D>().enabled = true;
        gameOver = betUp.RecieveWinnings(2 * betUp.bet);
        winningsText.text = "+$" + Convert.ToString(2 * betUp.bet);
    }
    void DealerWin()
    {
        gameObject.transform.position = new Vector3(-2.3f, 3);
        gameObject.GetComponent<TextMesh>().text = "Dealer\nwins!";
        gameOver = betUp.RecieveWinnings(-betUp.bet);
        winningsText.text = "-$" + Convert.ToString(betUp.bet);
    }
    void PlayerWin()
    {
        gameObject.transform.position = new Vector3(-2.3f, -1.5f);
        gameObject.GetComponent<TextMesh>().text = "Player\nwins!";
        gameOver = betUp.RecieveWinnings(betUp.bet);
        winningsText.text = "+$" + Convert.ToString(betUp.bet);
    }
    void Draw()
    {
        gameObject.transform.position = new Vector3(-2.3f, 2.5f);
        gameObject.GetComponent<TextMesh>().text = "Draw!";
        gameOver = betUp.RecieveWinnings(0);
        winningsText.text = "+$0";
    }
}
