using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeteIntro : MonoBehaviour
{
    public AudioClip welcome;
    public AudioSource audioS;
    public AudioClip busMaze;
    public AudioClip letterP;

    void Start()
    {
        
    }

    IEnumerator playSoundAfterSeconds()
    {
        yield return new WaitForSeconds(3);
        audioS.PlayOneShot(busMaze);
    }
    void Welcome()
    {
        audioS.PlayOneShot(welcome);
    }
    void BusMaze()
    {
        StartCoroutine(playSoundAfterSeconds());
    }
    void LetterP()
    {
        audioS.PlayOneShot(letterP);
    }
}
