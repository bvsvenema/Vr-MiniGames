using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreSystem : MonoBehaviour
{
    //in game score
    private int scoreTotalBowling;
    private int scoreRoundBowling;

    //end of game score
    private int scoreTotalStrikes;
    private int scoreTotalSpares;
    private int scoreTotalPinsHit;

    //in game text
    public TextMeshProUGUI textTotalPoints;
    public TextMeshProUGUI textRoundPoints;

    //end of game text
    public TextMeshProUGUI textTotalScore;
    public TextMeshProUGUI textTotalStrikes;
    public TextMeshProUGUI textTotalSpares;
    public TextMeshProUGUI textTotalPinsHit;

    public  int ScoreTotalBowling
    {
        get { return scoreTotalBowling; }
        set {scoreTotalBowling = value;
            UpdateBowlingTotalScore(); }
    }

    public int ScoreRoundBowling
    {
        get{ return scoreRoundBowling; }
        set{ scoreRoundBowling = value;
            UpdateBowlingRoundScore(); }
    }

    public int ScoreTotalStrikes
    {
        get { return scoreTotalStrikes; }
        set { scoreTotalStrikes = value;
            UpdateStrikeScore(); }
    }

    public int ScoreTotalSpares {
        get { return scoreTotalSpares; }
        set { scoreTotalSpares = value;
            UpdateSpareScore(); }
    }

    public int ScoreTotalPinsHit
    {
        get { return scoreTotalPinsHit; }
        set { scoreTotalSpares = value;
            UpdatePinsHitScore(); }
    }


    void Start()
    {
        //text in game update
        textTotalPoints.text = "" + scoreTotalBowling;
        textRoundPoints.text = "" + scoreRoundBowling;

        //text end game update
        textTotalScore.text = "" + scoreTotalBowling;
        textTotalStrikes.text = "Strikes: " + scoreTotalStrikes;
        textTotalSpares.text = "Spares: " + scoreTotalSpares;
        textTotalPinsHit.text = "Pins Hit: " + scoreTotalPinsHit; 
    }

    public void UpdateBowlingTotalScore()
    {
        textTotalPoints.text = "" + scoreTotalBowling;
        textTotalScore.text = "" + scoreTotalBowling;
    }

    public void UpdateBowlingRoundScore()
    {
        textRoundPoints.text = "" + scoreRoundBowling;
    }

    public void UpdateStrikeScore()
    {
        textTotalStrikes.text = "Strikes: " + scoreTotalStrikes;
    }

    public void UpdateSpareScore()
    {
        textTotalSpares.text = "Spares: " + scoreTotalSpares;
    }

    public void UpdatePinsHitScore()
    {
        textTotalPinsHit.text = "Pins Hit: " + scoreTotalPinsHit;
    }
}
