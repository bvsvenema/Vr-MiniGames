using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KeyDetector : MonoBehaviour
{
    public SystemManager SM; 
    


    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {

        var key = other.GetComponentInChildren<TextMeshProUGUI>();
        if (key != null)
        {
            var keyFeedBack = other.gameObject.GetComponent<KeyFeedBack>();

            if (keyFeedBack.keyCanHitAgain)
            {

                if (other.gameObject.GetComponent<KeyFeedBack>().keyCanHitAgain)
                {
                    if (key.text == "SPACEBARE" /*&& KeyFeedBack.keyHitted != 10*/)
                    {
                        SM.CappedString += " ";
                    }
                    else if (key.text == "<--")
                    {
                        SM.CappedString = SM.CappedString.Substring(0, SM.CappedString.Length - 1);
                        KeyFeedBack.keyHitted--;
                    }else if (key.text == "Submit" )
                    {
                        SM.StartBowlingMiniGame();                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                 
                    }
                    else /*if (KeyFeedBack.keyHitted != 10)*/
                    {
                        SM.CappedString += key.text;
                    }
                    keyFeedBack.keyHit = true;
                }
            }
        }
    }
}
