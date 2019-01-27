using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceManager : MonoBehaviour {

    [Header("Tanner")]
    public AudioClip co2Begone;
    public AudioClip friendlyVoice;
    public AudioClip stickingAround;

    public AudioClip tannerBreathingStartOfGame;
    public AudioClip tannerHelloAnyone;
    public AudioClip tannerHelloRequestingAid;
   
    public AudioClip tannerBeginningExposition;
    public AudioClip tannerLightHeaded;

    public AudioClip tannerMadeItOff;
    public AudioClip tannerMomResponse;
    public AudioClip tannerStopPlayback;

    [Header("Lisa")]
    public AudioClip iDid;
    public AudioClip theOdds;

    [Header("Saros")]
    public AudioClip sarosTransmission;
    [Header("Karen")]
    public AudioClip karenTransmission;
    [Header("Arnold")]
    public AudioClip arnoldSonOutThere;
    public AudioClip arnoldEverythingGoingToBeOk;


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

    public void firstSequence()
    {
        StartCoroutine(firstSequenceHelper());
    }
    private IEnumerator firstSequenceHelper()
    {
        yield return new WaitWhile(() => scene);
        scene = true;
        src.clip = tannerBreathingStartOfGame;
        src.Play();
        yield return new WaitWhile(() => src.isPlaying);
        src.clip = tannerHelloAnyone;

        /*IF TANNER HITS THE TRANSMITTER BUTTON
         maybe idk*/

        yield return new WaitWhile(() => src.isPlaying);
        src.clip = tannerMadeItOff;
        src.Play();
        scene = false;
    }


    public void receiverSequence()
    {
        StartCoroutine(receiverSequenceHelper());
    }
    private IEnumerator receiverSequenceHelper()
    { 
        yield return new WaitWhile(() => scene);
        scene = true;
        src.clip = karenTransmission;
        src.Play();
        yield return new WaitWhile(() => src.isPlaying);
        src.clip = tannerMomResponse;
        src.Play();
        yield return new WaitWhile(() => src.isPlaying);
        src.clip = sarosTransmission;
        src.Play();
        //TODO: Mix these two somehow;
        yield return new WaitWhile(() => src.isPlaying);
        src.clip = arnoldSonOutThere;
        src.Play();
        yield return new WaitWhile(() => src.isPlaying);
        src.clip = tannerStopPlayback;
    }


}
