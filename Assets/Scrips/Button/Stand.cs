using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stand : MonoBehaviour, IButton
{
    public Button_Click hit;
    public Dealer dealer;
    public void Click()
    {
        dealer.Activate();
        gameObject.GetComponent<Button_Click>().enabled = false;
        hit.enabled = false;
    }
}
