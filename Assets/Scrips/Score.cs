using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    private List<int> values = new List<int>();
    public int score;
    public bool UpdateScore(int value)
    {
        var Text = gameObject.GetComponent<TextMesh>();
        values.Add(value);
        score += value;
        if (score > 21)
        {
            for (int i = 0; i < values.Count; i++)
            {
                if (values[i] == 11)
                {
                    values[i] = 1;
                    score -= 10;
                    Text.text = score.ToString();
                    return false;
                }
            }
            Text.text = score.ToString();
            return true;
        }
        else if (gameObject.name == "DealerScore" && score >= 17)
        {
            Text.text = score.ToString();
            return true;
        }
        Text.text = score.ToString();
        return false;
    }
    public void ResetScore()
    {
        score = 0;
        gameObject.GetComponent<TextMesh>().text = "0";
        values = new List<int>();
    }
}
