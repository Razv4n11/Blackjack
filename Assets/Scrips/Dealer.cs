using System.Collections;
using System.Collections.Generic;
using System.Timers;
using System.Xml.Serialization;
using UnityEngine;

public class Dealer : MonoBehaviour
{
    private float time;
    public GameObject endGame;
    public void Activate()
    {
        enabled = true;
    }
    private void Start()
    {
        enabled = false;
    }
    private void Update()
    {
        if (time > 0)
        {
            time -= Time.deltaTime;
        }
        else
        {
            time = 1.3f;
            if (gameObject.GetComponent<DealCard>().Deal())
            {
                enabled = false;
                time = 0;
                endGame.GetComponent<EndGame>().ShowWinner();
            }
        } 
    }
}
