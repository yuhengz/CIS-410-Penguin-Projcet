using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScript : MonoBehaviour
{
    public GameObject pickup;

    AudioSource[] audios;
    private bool playing;
    private bool get;

    // Start is called before the first frame update
    void Start()
    {
        audios = GetComponents<AudioSource>();
        audios[0].Play();
        playing = false;
        get = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(pickup.activeInHierarchy == false && playing == false)
        {
            audios[0].Pause();
            audios[1].Play();
            playing = true;
        }

        if(ShinyRockScript.obtained == true && get == false)
        {
            audios[1].Pause();
            get = true;
        }
    }
}
