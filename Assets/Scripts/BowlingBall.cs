using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlingBall : MonoBehaviour
{
    Vector3 originalpos;
    public Quaternion originalRot;

    // Start is called before the first frame update
    void Start()
    {
        originalpos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
        originalRot = transform.rotation;
    }
    

    public void ResetBowlingBall()
    {
        gameObject.transform.rotation = originalRot;
        gameObject.transform.position = originalpos;
        Debug.Log("ResetBowlingBall");
    }
}
