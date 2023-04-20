using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeAudio : MonoBehaviour
{
    public AudioClip driveBus;
    public AudioSource audioS;
    public AudioClip useSpace;

    IEnumerator playSoundAfterSeconds()
    {
        yield return new WaitForSeconds(1);
        audioS.PlayOneShot(useSpace);
    }
    void SpaceBar()
    {
        StartCoroutine(playSoundAfterSeconds());
    }
    void HowToDrive()
    {
        audioS.PlayOneShot(driveBus);
    }
}
