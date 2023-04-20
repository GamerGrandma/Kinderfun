using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public string sceneName;
    public AudioSource audioPlayer;
    public AudioClip sceneAudio;

    private void Awake()
    {
        audioPlayer.PlayOneShot(sceneAudio);
    }
    void Start()
    {
        StartCoroutine(LoadNextScene());
    }
   
    IEnumerator LoadNextScene()
    {
        yield return new WaitForSecondsRealtime(10);
        SceneManager.LoadScene(sceneName);
    }
}