using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    public AudioClip tannerCarbonDIEoxide;
    public AudioClip tannerSomebodyHelp;

    [Header("Lisa")]
    public AudioClip iDid;
    public AudioClip theOdds;
    public AudioClip solderingIron;
    public AudioClip lisaOnBoard;
    public AudioClip lisaRepairTransmitter;

    [Header("Saros")]
    public AudioClip sarosTransmission;
    [Header("Karen")]
    public AudioClip karenTransmission;
    [Header("Arnold")]
    public AudioClip arnoldSonOutThere;
    public AudioClip arnoldEverythingGoingToBeOk;


    [Header("generic")]
    public AudioClip co2Dangerous;


    private bool scene = false;

    private AudioSource src;
    void Start()
    {
        src = gameObject.GetComponent<AudioSource>();
        firstSequence();
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
        yield return new WaitForSeconds(1);
        src.clip = friendlyVoice;
        src.Play();
        yield return new WaitWhile(() => src.isPlaying);
        src.clip = theOdds;
        src.Play();
        yield return new WaitWhile(() => src.isPlaying);
        src.clip = stickingAround;
        src.Play();
        yield return new WaitWhile(() => src.isPlaying);
        yield return new WaitForSeconds(10);
        src.clip = lisaOnBoard;
        src.Play();
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
        yield return new WaitWhile(() => src.isPlaying);
        src.clip = tannerBeginningExposition;
        src.Play();
        yield return new WaitWhile(() => src.isPlaying);

        scene = false;
    }

    public void repairTransmitter()
    {
        src.clip = lisaRepairTransmitter;
        src.Play();
    }

    public void noToolsSequence()
    {
        src.clip = solderingIron;
        src.Play();
        //scene = false;
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
        scene = false;
    }

    public void powerOnSequence()
    {
        StartCoroutine(powerOnSequenceHelper());
    }
    private IEnumerator powerOnSequenceHelper()
    {
        yield return new WaitWhile(() => scene);
        scene = true;
        src.clip = co2Dangerous;
        src.Play();
        yield return new WaitWhile(() => src.isPlaying);
        src.clip = tannerCarbonDIEoxide;
        src.Play();
        scene = false;
    }

    public void aGoodbye()
    {
        StartCoroutine(finalVoicesHelper());
    }
    private IEnumerator finalVoicesHelper()
    {
        yield return new WaitWhile(() => scene);
        src.clip = tannerSomebodyHelp;
        src.Play();
        SceneManager.LoadScene("Credits");
    }
}
