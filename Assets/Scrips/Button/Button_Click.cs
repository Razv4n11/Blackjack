using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Button_Click : MonoBehaviour
{
    private Color defaultColor;

    private void Awake()
    {
        defaultColor = gameObject.GetComponent<SpriteRenderer>().color;
        if (enabled)
            OnEnable();
        else
            OnDisable();
    }
    void Update()
    {
        if (Input.touchCount >= 1 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            Vector3 touchPos = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            touchPos.x += gameObject.transform.localScale.x / 2;
            touchPos.y += gameObject.transform.localScale.y / 2;
            if (gameObject.transform.position.x - 0.1f < touchPos.x && touchPos.x < gameObject.transform.position.x + gameObject.transform.localScale.x + 0.1f &&
                gameObject.transform.position.y - 0.1f < touchPos.y && touchPos.y < gameObject.transform.position.y + gameObject.transform.localScale.y + 0.1f)
            {
                gameObject.GetComponent<IButton>().Click();
            }
        }
    }
    private void OnEnable()
    {
        if (gameObject.name != "NewGame")
            gameObject.GetComponent<SpriteRenderer>().color = defaultColor;
    }
    private void OnDisable()
    {
        if (gameObject.name != "NewGame")
            gameObject.GetComponent<SpriteRenderer>().color = new Color(defaultColor.r, defaultColor.g, defaultColor.b, 0.6f);
    }
}
