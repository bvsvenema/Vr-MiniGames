using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBowling : MonoBehaviour
{
    /* public Pawn pawn;
     public GameObject pawnPrefab;*/
    public Pawn[] pawns;
    //public Pawn pawn;
    public int ballsHasEnterCollider = 0;

    public void Start()
    {
        //pawn = GetComponent<Pawn>();
        /*GameObject obj = pawnPrefab;

        pawn = obj.GetComponent<Pawn>();*/
    }
    
    public IEnumerator OnTriggerEnter(Collider collision)
    {
        Debug.Log("Big balls");
        //if the ball hits the end of the bowling ally start this 
        if (collision.gameObject.tag == "Ball")
        {
            ballsHasEnterCollider++;
            Debug.Log("Start de second wait");
            //wait 5 second for starting the fuction
            yield return new WaitForSeconds(5);
            Debug.Log("Ended the waiting");
            //this function sees if the pawn has fallen and then gives you points
            //pawn.PawnHasFallen();
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
            TvScreenBowling();

        }

    }


    public void TvScreenBowling()
    {
        Debug.Log("Amount of pawn dat has fallen " + Pawn.pawnsFallen);
        if (Pawn.pawnsFallen == 10 && ballsHasEnterCollider == 1)
        {
            Debug.Log("Strike");
        }
        else if (Pawn.pawnsFallen == 10 && ballsHasEnterCollider == 2)
        {
            Debug.Log("Spare");
        }
        else if (Pawn.pawnsFallen == 0 && ballsHasEnterCollider == 1)
        {
            Debug.Log("Miss");
        }else if(Pawn.pawnsFallen == 0 && ballsHasEnterCollider == 2)
        {
            Debug.Log("Double Miss");
        }
        else
        {
            Debug.Log("Big Banana's");
            foreach (var pawn in pawns)
            {
                if (pawn.mRend.enabled == false)
                {
                    pawn.tvScreenPawn.SetActive(true);
                }
            }
        }
    }

}
