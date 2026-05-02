using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewGame : MonoBehaviour, IButton
{
    public Score dealerScore;
    public Score playerScore;
    public DealCard player;
    public DealCard dealer;
    public TextMesh endGameText;
    public TextMesh winningsText;
    public void Click()
    {
        dealerScore.ResetScore();
        playerScore.ResetScore();

        gameObject.GetComponent<Button_Click>().enabled = false;
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
        endGameText.text = "";
        winningsText.text = "";

        player.ClearCards();
        player.StartGame();

        dealer.ClearCards();
        dealer.StartGame();
    }
}
