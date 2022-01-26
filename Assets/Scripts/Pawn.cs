using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ParticleSystemJobs;

public class Pawn : MonoBehaviour
{
    Vector3 originalpos;
    public Quaternion originalRot;

    private Rigidbody rb;
    public ScoreSystem SS;

    public static int pawnsFallen = 0;
    private float trustFroce = 5000f;

    public ParticleSystem[] psPawn;
    public GameObject pawnName;
    //public GameObject wholePawnEmpty;
    public GameObject tvScreenPawn;
    public MeshRenderer mRend;
    public bool noMorePoints = false;
    
    //ParticleSystem ps;


    public void Start()
    {
        originalpos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
        originalRot = transform.rotation;
        rb = GetComponent<Rigidbody>();
    }

    public void PawnHasFallen()
    {
        Debug.Log("Calling this script");

        //see of the pawn has moved after the wait in the other script
        if (mRend.enabled == true)
        {
            if (!Mathf.Approximately(Vector3.Angle(Vector3.up, transform.up), 0f))
            {
                StartCoroutine(PawmEnumerator());
                Debug.Log(pawnName.name + " has fallen", this);
                pawnsFallen++;
                SS.ScoreRoundBowling++;
                SS.ScoreTotalBowling++;
                //function
            }
            else
            {
                Debug.Log(pawnName.name + " is still standing", this);
                //TvScreenBowling();
                //fuint
            }
        }
    }


    IEnumerator PawmEnumerator()
    {
        if (mRend.enabled == true)
        {
            rb.velocity = Vector3.up * trustFroce * Time.deltaTime;
            yield return new WaitForSeconds(2);
            rb.constraints = RigidbodyConstraints.FreezeAll;
            Boom();
            yield return new WaitForSeconds(0.5f);
            mRend.enabled = false;
            //if(mRend.enabled = true)
            //{
               // gameObject.transform.position = originalpos;
            //}
        }
    }

    public void Boom()
    {
        foreach (var ps in psPawn)
        {
            ps.Play();
        }
    }

    public void ResetPosistion()
    {
        gameObject.transform.rotation = originalRot;
        gameObject.transform.position = originalpos;
        mRend.enabled = true;
        Debug.Log("Rest posistion");
    }

}
