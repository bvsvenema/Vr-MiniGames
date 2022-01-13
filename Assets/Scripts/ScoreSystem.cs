using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreSystem : MonoBehaviour
{
    private int scoreBowling;
    public TextMeshProUGUI text;

    public  int ScoreBowling
    {
        get { return scoreBowling; }
        set { scoreBowling = value;
              UpdateBowlingScore();
        }
    }

    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();

        text.text = "" + scoreBowling;
    }

    public void UpdateBowlingScore()
    {
        text.text = "" + scoreBowling;
    }
}
