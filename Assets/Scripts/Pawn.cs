using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ParticleSystemJobs;

public class Pawn : MonoBehaviour
{

    public ParticleSystem[] psPawn;
    private float trustFroce = 1000f;
    public GameObject pawnName;
    private Rigidbody rb;
    public GameObject wholePawnEmpty;
    
    //ParticleSystem ps;

    public void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void PawnHasFallen()
    {
        Debug.Log("Calling this script");

        //see of the pawn has moved after the wait in the other script
        if (!Mathf.Approximately(Vector3.Angle(Vector3.up, transform.up), 0f))
        {
            StartCoroutine(PawmEnumerator());
            Debug.Log(pawnName.name + " has fallen", this);
            //function
        }
        else
        {
            Debug.Log(pawnName.name + " is still standing", this);
            //fuint
        }

       
    }

    IEnumerator PawmEnumerator()
    {
        
        rb.velocity = Vector3.up * trustFroce * Time.deltaTime;
        yield return new WaitForSeconds(2);
        rb.constraints = RigidbodyConstraints.FreezeAll;
        Boom();
        yield return new WaitForSeconds(0.5f);
        pawnName.gameObject.SetActive(false);
    }

    public void Boom()
    {
        foreach (var ps in psPawn)
        {
            ps.Play();
        }
    }





}
