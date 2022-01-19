using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreSystem : MonoBehaviour
{
    private int scoreTotalBowling;
    private int scoreRoundBowling; 
    public TextMeshProUGUI textTotalPoints;
    public TextMeshProUGUI textRoundPoints;

    public  int ScoreTotalBowling
    {
        get { return scoreTotalBowling; }
        set {scoreTotalBowling = value;
            UpdateBowlingTotalScore();
        }
    }

    public int ScoreRoundBowling
    {
        get{ return scoreRoundBowling; }
        set{ scoreRoundBowling = value;
            UpdateBowlingRoundScore();
        }
    }

    void Start()
    {
        //text = GetComponent<TextMeshProUGUI>();

        textTotalPoints.text = "" + scoreTotalBowling;
        textRoundPoints.text = "" + scoreRoundBowling;
    }

    public void UpdateBowlingTotalScore()
    {
        textTotalPoints.text = "" + scoreTotalBowling;
    }

    public void UpdateBowlingRoundScore()
    {
        textRoundPoints.text = "" + scoreRoundBowling;
    }
}
