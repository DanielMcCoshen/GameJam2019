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
    public AudioClip tannerBrotherResponse;
    public AudioClip tannerSam;
    public AudioClip tannerTransmiting;
    public AudioClip tannerGoodEnding;
    public AudioClip tannerBrotherTransmission;

    [Header("Lisa")]
    public AudioClip iDid;
    public AudioClip theOdds;
    public AudioClip solderingIron;
    public AudioClip lisaOnBoard;
    public AudioClip lisaRepairTransmitter;
    public AudioClip lisaStopping;
    public AudioClip lisaCantDoThat;

    [Header("Saros")]
    public AudioClip sarosTransmission;
    public AudioClip sarosCanYouHearMe;
    public AudioClip sarosMom;

    [Header("Karen")]
    public AudioClip karenTransmission;
    public AudioClip karenTanner;
    public AudioClip karenGetToYou;

    [Header("Arnold")]
    public AudioClip arnoldSonOutThere;
    public AudioClip arnoldEverythingGoingToBeOk;


    [Header("generic")]
    public AudioClip co2Dangerous;
    public AudioClip samLastLine;

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
        yield return new WaitForSeconds(1);
        src.clip = tannerMomResponse;
        src.Play();
        yield return new WaitWhile(() => src.isPlaying);
        yield return new WaitForSeconds(10);
        src.clip = sarosTransmission;
        src.Play();
        yield return new WaitWhile(() => src.isPlaying);
        src.clip = tannerBrotherResponse;
        src.Play();
        yield return new WaitWhile(() => src.isPlaying);
        yield return new WaitForSeconds(10);
        src.clip = arnoldSonOutThere;
        src.Play();
        yield return new WaitWhile(() => src.isPlaying);
        src.clip = lisaStopping;
        src.Play();
        yield return new WaitWhile(() => src.isPlaying);
        yield return new WaitForSeconds(10);
        src.clip = samLastLine;
        src.Play();
        yield return new WaitWhile(() => src.isPlaying);
        src.clip = tannerSam;
        src.Play();
        yield return new WaitWhile(() => src.isPlaying);
        src.clip = lisaCantDoThat;
        src.Play();
        yield return new WaitWhile(() => src.isPlaying);
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
        yield return new WaitWhile(() => src.isPlaying);
        src.clip = sarosCanYouHearMe;
        src.Play();
        yield return new WaitWhile(() => src.isPlaying);
        src.clip = tannerBrotherTransmission;
        src.Play();
        yield return new WaitWhile(() => src.isPlaying);
        src.clip = sarosMom;
        src.Play();
        yield return new WaitWhile(() => src.isPlaying);
        src.clip = karenTanner;
        src.Play();
        yield return new WaitWhile(() => src.isPlaying);
        src.clip = tannerTransmiting;
        src.Play();
        yield return new WaitWhile(() => src.isPlaying);
        src.clip = karenGetToYou;
        src.Play();
        yield return new WaitWhile(() => src.isPlaying);
        src.clip = arnoldEverythingGoingToBeOk;
        src.Play();
        yield return new WaitWhile(() => src.isPlaying);
        src.clip = tannerGoodEnding;
        src.Play();
        yield return new WaitWhile(() => src.isPlaying);
        SceneManager.LoadScene("Credits");
    }
}
