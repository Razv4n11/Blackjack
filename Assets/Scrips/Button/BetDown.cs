using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BetDown : MonoBehaviour , IButton
{
    public BetUp betUp;
    public TextMesh betText;
    public int bet;
    public void Click()
    {
        bet -= 100;
        if (bet < 100)
            bet = 100;
        betUp.bet = bet;
        betText.text = "Your bet:\r\n$" + bet;
    }
}
