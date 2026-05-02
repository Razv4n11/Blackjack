using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using System.Threading;
using UnityEditor;
using UnityEngine;


public class DealCard : MonoBehaviour
{
    private static Sprite[] deck = new Sprite[52];
    private static bool[] dealtCards = new bool[52];

    private List<GameObject> cards = new List<GameObject>();
    private float layer;
    private float time;
    public Score score;
    public BetUp betUp;

    void Awake()
    {
        if (deck[0] != null)
            return;
        var objects = new List<Object>(Resources.LoadAll("Cards", typeof(Sprite)));
        int i = 0;
        foreach (var obj in objects)
        {
            deck[i] = (Sprite)obj;
            i++;
        }
    }
    void Update()
    {
        if (time > 0)
        {
            time -= Time.deltaTime;
        }
        else
        {
            Deal();
            if (gameObject.name == "Player")
            {
                if (score.score == 21)
                    GameObject.Find("EndGame").GetComponent<EndGame>().Blackjack();
                else
                {
                    GameObject.Find("Stand").GetComponent<Button_Click>().enabled = true;
                    GameObject.Find("Hit").GetComponent<Button_Click>().enabled = true;
                }
            }
            enabled = false;
        }
    }
    public void StartGame()
    {
        if (gameObject.name == "Dealer")
            time = 1.3f;
        else
        {
            betUp.PlaceBet();
            time = 2.6f;
            Deal();
        }
        GameObject.Find("Stand").GetComponent<Button_Click>().enabled = false;
        GameObject.Find("Hit").GetComponent<Button_Click>().enabled = false;
        enabled = true;
    }
    public bool Deal()
    {
        int cardIndex;
        do
        {
            cardIndex = Random.Range(0, deck.Length);
        }
        while (dealtCards[cardIndex]);

        dealtCards[cardIndex] = true;
        int value = (cardIndex % 13) + 2;
        if (value > 11)
            value = 10;

        Sprite sprite = deck[cardIndex];
        GameObject Card = new GameObject(sprite.name);
        var renderer = Card.AddComponent<SpriteRenderer>();
        renderer.sprite = sprite;
        Card.transform.position = new Vector3(gameObject.transform.position.x + layer * 300, gameObject.transform.position.y + layer * 150, gameObject.transform.position.z - layer);
        Card.transform.localScale = new Vector3(0.11f, 0.108779f, 0.11f);
        cards.Add(Card);
        layer += 0.001f;
        return score.UpdateScore(value);
    }
    public void ClearCards()
    {
        foreach (GameObject card in cards)
        {
            Destroy(card);
        }
        cards.Clear();
        dealtCards = new bool[52];
        layer = 0;
    }
}
