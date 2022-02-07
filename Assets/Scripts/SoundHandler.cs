using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundHandler : MonoBehaviour
{

    private SoundHandler soundHandler;
    public AudioClip keyClick;
    private AudioSource clickSource;

    // Start is called before the first frame update
    void Start()
    {
        
        clickSource = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayKeyClick()
    {
        clickSource.PlayOneShot(keyClick);
    }
}
