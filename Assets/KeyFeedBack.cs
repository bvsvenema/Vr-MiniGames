using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyFeedBack : MonoBehaviour
{

    public bool keyHit = false;
    public bool keyCanHitAgain = false;
    public static int keyHitted;
    //private SoundHandler soundHandler;

    private float originalYposistion;
    // Start is called before the first frame update
    void Start()
    {
        originalYposistion = transform.position.y;
        //soundHandler = GameObject.FindGameObjectWithTag("SoundHandler").GetComponent<SoundHandler>();
    }

    // Update is called once per frame
    void Update()
    {

        if (keyHit)
        {

            //soundHandler.PlayKeyClick();
            keyCanHitAgain = false;
            keyHit = false;
            transform.position += new Vector3(0, -0.03f, 0);
        }
        if (transform.position.y < originalYposistion)
        {
            transform.position += new Vector3(0, 0.0005f, 0);
        }
        else
        {


            keyCanHitAgain = true;
        }
    }
    
    
}
