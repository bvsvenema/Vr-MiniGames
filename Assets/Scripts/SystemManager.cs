using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemManager : MonoBehaviour
{
    //scripts
    public HitBowling HB;
    //private Pawn P;

    //In game adds
    public GameObject strike;
    public GameObject miss;
    public GameObject doubleMiss;
    public GameObject spare;
    public GameObject score;

    //private checks
    private bool strikeMp4 = false;
    private int strikeStreak = 0;

    //wait for second script
    public IEnumerator Wfs5()
    {
        if (strikeMp4 == true)
        {
            yield return new WaitForSeconds(10f);
        }
        else
        {
            yield return new WaitForSeconds(5);
            score.SetActive(true);
        }
    }

    //what happens when you hit the pins
    public void TvScreenBowling()
    {
        Debug.Log("Amount of pawn dat has fallen " + Pawn.pawnsFallen);
        //strike
        if (Pawn.pawnsFallen == 10 && HB.ballsHasEnterCollider == 1)
        {
            strikeMp4 = true;
            Debug.Log("Strike");
            strike.SetActive(true);
            strikeStreak++;
            //switch to see if you hit how many strike. with more strikes you get more points
            switch (strikeStreak)
            {
                case 1:

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
            Wfs5();
        }
        //Miss
        else if (Pawn.pawnsFallen == 0 && HB.ballsHasEnterCollider == 1)
        {
            Debug.Log("Miss");
            score.SetActive(false);
            miss.SetActive(true);
            strikeStreak = 0;
            Wfs5();
        }
        //Double Miss
        else if (Pawn.pawnsFallen == 0 && HB.ballsHasEnterCollider == 2)
        {
            Debug.Log("Double Miss");
            score.SetActive(false);
            doubleMiss.SetActive(true);
            strikeStreak = 0;
            Wfs5();
        }
        //just hit the pins nothin special
        else
        {
            Debug.Log("Big Banana's");
            strikeStreak = 0;
            foreach (var pawn in HB.pawns)
            {
                if (pawn.mRend.enabled == false)
                {
                    score.SetActive(false);
                    pawn.tvScreenPawn.SetActive(true);
                    Wfs5();
                }
            }
        }
    }
}
