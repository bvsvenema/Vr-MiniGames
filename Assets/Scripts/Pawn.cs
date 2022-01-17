using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ParticleSystemJobs;

public class Pawn : MonoBehaviour
{
    private Rigidbody rb;
    private HitBowling hit;

    public static int pawnsFallen = 0;
    private float trustFroce = 5000f;

    public ParticleSystem[] psPawn;
    public GameObject pawnName;
    //public GameObject wholePawnEmpty;
    public GameObject tvScreenPawn;
    public MeshRenderer mRend;
    
    //ParticleSystem ps;

    public void Start()
    {
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
        if (pawnName.activeInHierarchy == true)
        {
            rb.velocity = Vector3.up * trustFroce * Time.deltaTime;
            yield return new WaitForSeconds(2);
            rb.constraints = RigidbodyConstraints.FreezeAll;
            Boom();
            yield return new WaitForSeconds(0.5f);
            mRend.enabled = false;
        }
    }

    public void Boom()
    {
        foreach (var ps in psPawn)
        {
            ps.Play();
        }
    }





}
