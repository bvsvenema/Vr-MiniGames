using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBowling : MonoBehaviour
{
   /* public Pawn pawn;
    public GameObject pawnPrefab;*/
    public Pawn[] pawns;

    public void Start()
    {
        /*GameObject obj = pawnPrefab;

        pawn = obj.GetComponent<Pawn>();*/
    }
    
    public IEnumerator OnTriggerEnter(Collider collision)
    {
        Debug.Log("Big balls");
        //if the ball hits the end of the bowling ally start this 
        if (collision.gameObject.tag == "Ball")
        {
            Debug.Log("Start de second wait");
            //wait 5 second for starting the fuction
            yield return new WaitForSeconds(5);
            Debug.Log("Ended the waiting");
            //this function sees if the pawn has fallen and then gives you points
            //pawn.PawnHasFallen();
            foreach(var pawn in pawns)
            {
                pawn.PawnHasFallen();
            }

        }

    }

}
