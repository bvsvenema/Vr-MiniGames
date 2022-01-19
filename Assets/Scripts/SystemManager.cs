using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemManager : MonoBehaviour
{
    //scripts
    public HitBowling HB;
    public ScoreSystem SS;
    //public Pawn P;

    //In game adds
    public GameObject strike;
    public GameObject miss;
    public GameObject doubleMiss;
    public GameObject spare;
    public GameObject score;

    //private checks
    private int strikeStreak = 0;


    //what happens when you hit the pins
    public IEnumerator TvScreenBowling()
    {
        Debug.Log("Amount of pawn dat has fallen " + Pawn.pawnsFallen);
        //strike
        if (Pawn.pawnsFallen == 10 && HB.ballsHasEnterCollider == 1)
        {
            Debug.Log("Strike");
            strike.SetActive(true);
            if(strikeStreak != 3)
            {
                strikeStreak++;
            }
            else
            yield return new WaitForSecondsRealtime(10f);
            //switch to see if you hit how many strike. with more strikes you get more points
            switch (strikeStreak)
            {
                case 1:

                    break;
                case 2:

                    break;
                case 3:

                    break;
            }

        }
        //Spare
        else if (Pawn.pawnsFallen == 10 && HB.ballsHasEnterCollider == 2)
        {
            Debug.Log("Spare");
            score.SetActive(false);
            spare.SetActive(true);
            strikeStreak = 0;
            yield return new WaitForSecondsRealtime(5f);
            spare.SetActive(false);
            score.SetActive(true);
        }
        //Miss
        else if (Pawn.pawnsFallen == 0 && HB.ballsHasEnterCollider == 1)
        {
            Debug.Log("Miss");
            score.SetActive(false);
            miss.SetActive(true);
            strikeStreak = 0;
            yield return new WaitForSecondsRealtime(5f);
            miss.SetActive(false);
            score.SetActive(true);
        }
        //Double Miss
        else if (Pawn.pawnsFallen == 0 && HB.ballsHasEnterCollider == 2)
        {
            Debug.Log("Double Miss");
            score.SetActive(false);
            doubleMiss.SetActive(true);
            strikeStreak = 0;
            yield return new WaitForSecondsRealtime(5f);
            doubleMiss.SetActive(false);
            score.SetActive(true);
        }
        //just hit the pins nothin special
        else
        {
            Debug.Log("Big Banana's");
            strikeStreak = 0;
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
        }
    }

}
