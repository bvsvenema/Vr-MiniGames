using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBowling : MonoBehaviour
{
    public Pawn[] pawns;
    public BowlingBall[] balls;
    public SystemManager systemManager;
    public ScoreSystem SS;
    public GameObject blockBowling;

    public int ballsHasEnterCollider = 0;

    public void Start()
    {
        //SystemManager = GetComponent<SystemManager>();
    }
    
    public IEnumerator OnTriggerEnter(Collider collision)
    {
        Debug.Log("Big balls");
        //if the ball hits the end of the bowling ally start this 
        if (collision.gameObject.tag == "Ball")
        {
            blockBowling.SetActive(true);
            ballsHasEnterCollider++;
            Debug.Log("Start de second wait");
            //wait 5 second for starting the fuction
            yield return new WaitForSeconds(5);
            Debug.Log("Ended the waiting");
            //this function sees if the pawn has fallen and then gives you points
            foreach(var pawn in pawns)
            {
                if (!pawn.gameObject.activeSelf)
                {
                    Debug.Log("do nothing");
                }
                else
                {
                    pawn.PawnHasFallen();
                }

            }
            yield return new WaitForSeconds(5f);
            StartCoroutine(systemManager.TvScreenBowling());
            yield return new WaitForSeconds(15f);
            if(ballsHasEnterCollider == 2)
            {
                systemManager.roundCounter++;
                SS.ScoreRoundBowling = 0;
                yield return new WaitForSeconds(4.8f);
                foreach(var ball in balls)
                {
                    ball.ResetBowlingBall();
                }
                yield return new WaitForSeconds(0.2f);
                foreach(var pawn in pawns)
                {
                   pawn.ResetPosistion();
                }
                ballsHasEnterCollider = 0;
            }
        }

    }


}
