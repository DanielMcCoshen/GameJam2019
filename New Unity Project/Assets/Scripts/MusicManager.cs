using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour {

    public AudioClip Danger;
    public AudioClip Ambient1;
    public AudioClip Ambient3;
    public AudioClip Ambient4;


    private AudioSource src;
	// Use this for initialization
	void Start () {
        src = gameObject.GetComponent<AudioSource>();
        src.clip = Danger;
        src.loop = true;
        src.Play();
	}

    private AudioClip findNextClip()
    {
        if (src.clip == Danger)
        {
            return Ambient1;
        }
        else if (src.clip == Ambient1)
        {
            return Ambient3;
        }
        else
        {
            return Ambient4;
        }
    }

    public void advanceMain()
    {
        if (src.clip != Ambient4)
        {
            src.Stop();
            src.clip = findNextClip();
            src.Play();
        }
    }
}
