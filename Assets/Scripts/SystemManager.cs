using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SystemManager : MonoBehaviour
{
    //scripts
    public HitBowling HB;
    public HighScoreTable HsT;
    public ScoreSystem SS;
    public ContinuousMovmend xrRig;

    public GameObject blockBowling;
    //public Pawn P;

    //In game adds
    public GameObject strike;
    public GameObject miss;
    public GameObject doubleMiss;
    public GameObject spare;
    public GameObject score;
    public GameObject xRRigBowlingGame;
    public GameObject xRRigBowlingSetName;

    //private checks
    private int strikeSpareStreak;
    public bool strikeBowling = false;
    public int roundCount = 10;

    public TextMeshProUGUI playerTextOutput;
    private const int maxLength = 10;



    public string CappedString
    {
        get { return playerTextOutput.text; }
        set { playerTextOutput.text = value != null && value.Length > maxLength ? value.Substring(0, maxLength) : value; }
    }


    //what happens when you hit the pins
    public IEnumerator TvScreenBowling()
    {
        if (SS.RoundCounter == roundCount)
        {
            HsT.AddHighscoreEntry(SS.ScoreTotalBowling, playerTextOutput.text);
            Debug.Log("End of game");
        }
        else
        {
            Debug.Log("Amount of pawn dat has fallen " + Pawn.pawnsFallen);
            //strike
            if (Pawn.pawnsFallen == 10 && HB.ballsHasEnterCollider == 1)
            {
                Debug.Log("Strike");
                strike.SetActive(true);
                score.SetActive(false);
                strikeBowling = true;
                if (strikeSpareStreak != 3)
                {
                    strikeSpareStreak++;
                }

                switch (strikeSpareStreak)
                {
                    case 1:
                        SS.ScoreRoundBowling += 10;
                        SS.ScoreTotalBowling += 10;
                        break;
                    case 2:
                        SS.ScoreRoundBowling += 20;
                        SS.ScoreTotalBowling += 20;
                        break;
                    case 3:
                        SS.ScoreRoundBowling += 30;
                        SS.ScoreTotalBowling += 30;
                        break;
                }
                yield return new WaitForSecondsRealtime(10f);
                //switch to see if you hit how many strike. with more strikes you get more points
                strike.SetActive(false);
                score.SetActive(true);
                blockBowling.SetActive(false);

            }
            //Spare
            else if (Pawn.pawnsFallen == 10 && HB.ballsHasEnterCollider == 2)
            {
                Debug.Log("Spare");
                score.SetActive(false);
                spare.SetActive(true);
                strikeSpareStreak++;
                switch (strikeSpareStreak)
                {
                    case 1:
                        SS.ScoreRoundBowling += 5;
                        SS.ScoreTotalBowling += 5;
                        break;
                    case 2:
                        SS.ScoreRoundBowling += 15;
                        SS.ScoreTotalBowling += 15;
                        break;
                    case 3:
                        SS.ScoreRoundBowling += 25;
                        SS.ScoreTotalBowling += 25;
                        break;
                }
                yield return new WaitForSecondsRealtime(5f);
                spare.SetActive(false);
                score.SetActive(true);
                blockBowling.SetActive(false);
            }
            //Miss
            else if (Pawn.pawnsFallen == 0 && HB.ballsHasEnterCollider == 1)
            {
                Debug.Log("Miss");
                score.SetActive(false);
                miss.SetActive(true);
                strikeSpareStreak = 0;
                yield return new WaitForSecondsRealtime(5f);
                miss.SetActive(false);
                score.SetActive(true);
                blockBowling.SetActive(false);
            }
            //Double Miss
            else if (Pawn.pawnsFallen == 0 && HB.ballsHasEnterCollider == 2)
            {
                Debug.Log("Double Miss");
                score.SetActive(false);
                doubleMiss.SetActive(true);
                strikeSpareStreak = 0;
                yield return new WaitForSecondsRealtime(5f);
                doubleMiss.SetActive(false);
                score.SetActive(true);
                blockBowling.SetActive(false);
            }
            //just hit the pins nothin special
            else
            {
                Debug.Log("Big Banana's");
                strikeSpareStreak = 0;
                //SS.ScoreRoundBowling = 0;
                foreach (var pawn in HB.pawns)
                {
                    if (pawn.mRend.enabled == false)
                    {
                        Debug.Log("pawns active");
                        score.SetActive(false);
                        pawn.tvScreenPawn.SetActive(true);
                    }

                }
                yield return new WaitForSecondsRealtime(5f);
                Debug.Log("weird");
                foreach (var pawn in HB.pawns)
                {
                    Debug.Log("pawns disable");
                    pawn.tvScreenPawn.SetActive(false);
                }
                score.SetActive(true);
                blockBowling.SetActive(false);
            }
        }
    }

    public void ResetEveryThingBowling ()
    {
        SS.ScoreTotalBowling = 0;
        SS.ScoreRoundBowling = 0;
        SS.ScoreTotalStrikes = 0;
        SS.ScoreTotalSpares = 0;
        SS.ScoreTotalPinsHit = 0;

        HB.ballsHasEnterCollider = 0;
        Pawn.pawnsFallen = 0;

        SS.RoundCounter = 0;
        strikeSpareStreak = 0;
        strikeBowling = false;

        blockBowling.SetActive(false);

        strike.SetActive(false);
        miss.SetActive(false);
        doubleMiss.SetActive(false);
        spare.SetActive(false);
        score.SetActive(true);

        xrRig.ResetXRRig();
        foreach (var pawn in HB.pawns)
        {
            pawn.ResetPosistion();
        }
        foreach(var ball in HB.balls)
        {
            ball.ResetBowlingBall();
        }
    }

    public void StartBowlingMiniGame()
    {
        xRRigBowlingSetName.SetActive(false);
        xRRigBowlingGame.SetActive(true);
    }

}
