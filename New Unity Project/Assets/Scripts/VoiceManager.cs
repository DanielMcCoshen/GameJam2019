using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceManager : MonoBehaviour {

    [Header("Tanner")]
    public AudioClip co2Begone;
    public AudioClip friendlyVoice;
    public AudioClip stickingAround;

    [Header("Lisa")]
    public AudioClip iDid;
    public AudioClip theOdds;

    private bool scene = false;

    private AudioSource src;
    void Start()
    {
        src = gameObject.GetComponent<AudioSource>();
    }

	public void co2Sequence()
    {
        StartCoroutine(co2SequenceHelper());
    }
    private IEnumerator co2SequenceHelper()
    {
        yield return new WaitWhile(() => scene);
        scene = true;
        src.clip = co2Begone;
        src.Play();
        yield return new WaitWhile(() => src.isPlaying);
        src.clip = iDid;
        src.Play();
        yield return new WaitWhile(() => src.isPlaying);
        src.clip = friendlyVoice;
        src.Play();
        yield return new WaitWhile(() => src.isPlaying);
        src.clip = theOdds;
        src.Play();
        yield return new WaitWhile(() => src.isPlaying);
        src.clip = stickingAround;
        src.Play();
        yield return new WaitWhile(() => src.isPlaying);
        scene = false;
    }
}
