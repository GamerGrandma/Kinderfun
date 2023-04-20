using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class SoundGame : MonoBehaviour
{
    [Header("Picture Info")]
    public string letterTag;
    public Image pictureHolder;
    public SoundGameSO[] soundPictures;
    public Image[] matchSlots;
    public Image[] noMatchSlots;
    private int nextMatchSlot;
    private int nextNoMatchSlot;
    [Header ("Sound Files")]
    public AudioSource playSound;
    public AudioClip goodJob;
    public AudioClip arrow;
    public AudioClip tryagain;
    private int nextPictureA = 0;
    private int currentPictureA = 0;
    private bool resetGame = false;

    void Awake()
    {
        ShuffleDeck();
    }
    void Start()
    {
        StartCoroutine(Waiting());
    }
    private void Update()
    {
        //checking if game can be reset, running reset functions, and restarting action.
            if(resetGame == true)
            {
                ResetSlots();
                ShuffleDeck();
                StartCoroutine(Waiting());
                resetGame = false;//make sure reset doesn't keep happening.
            }
    }
    void ShuffleDeck()
    {
        //rearranges order of card deck.
        int replacements = Random.Range(20, 1000);//for how many times the switching loop will run.
        for (int i = 0; i < replacements; i++)
        {
            //picks 2 different cards from deck to switch places.
            int A = Random.Range(0, soundPictures.Length);
            int B = Random.Range(0, soundPictures.Length);
            SoundGameSO a = soundPictures[A];
            SoundGameSO b = soundPictures[B];
            SoundGameSO c = soundPictures[A];//need 3rd holder to remember 1st card when switching.
            a = b;//1st random card becomes the 2nd random one.
            b = c;//2nd random card becomes 1st one as remembered by 3rd holder.
            soundPictures[A] = a;
            soundPictures[B] = b;
        }
        resetGame = false;
    }
    IEnumerator Waiting()
        {
            yield return new WaitForSeconds(20);
            PlacePicture();
            currentPictureA = nextPictureA;
        resetGame = false;
        }
        IEnumerator PictureNoMatchRight()
        {
            yield return new WaitForSeconds(2);
            AddNotAMatch();
            nextPictureA = nextPictureA + 1;
        }
        IEnumerator PictureMatchesLeft()
        {
            yield return new WaitForSeconds(2);
            AddAMatch();
            nextPictureA = nextPictureA + 1;
            
        }
        IEnumerator NewPicture()
        {
            if (nextPictureA <= soundPictures.Length)
                {
                yield return new WaitForSeconds(6);
                PlacePicture();
                }
            else if (nextPictureA >= soundPictures.Length)
            {
                yield return new WaitForSeconds(6);
                playSound.PlayOneShot(goodJob);
                yield return new WaitForSeconds(4);
                playSound.PlayOneShot(arrow);
            }
        }
    public void CheckmarkClicked()
        {
            Debug.Log("checkmark clicked");

            if (letterTag == soundPictures[nextPictureA].pictureTag)
            {
                Debug.Log("matches");
                StartCoroutine(PictureMatchesLeft());
                StartCoroutine(NewPicture());
            }
            else if (letterTag != soundPictures[nextPictureA].pictureTag)
            {
                Debug.Log("wrong button");
                playSound.PlayOneShot(tryagain);
            }
        }
     public void ExClicked()
     {
         Debug.Log("ex clicked");
         if (letterTag != soundPictures[nextPictureA].pictureTag)
         {
             Debug.Log("no match");
             StartCoroutine(PictureNoMatchRight());
             StartCoroutine(NewPicture());

         }
         else if (letterTag == soundPictures[nextPictureA].pictureTag)
         {
             Debug.Log("wrong button");
             playSound.PlayOneShot(tryagain);
         }
     }
    public void PlacePicture()
    {
        if(nextPictureA < soundPictures.Length)
        {
            pictureHolder.sprite = soundPictures[nextPictureA].soundPicture;
            playSound.PlayOneShot(soundPictures[nextPictureA].pictureName);
        }
        else
        {
            pictureHolder.sprite = null;
        }
    }
    public void AddAMatch()
    {
        if (nextMatchSlot <= matchSlots.Length)
        {
            matchSlots[nextMatchSlot].color = new Color(255, 255, 255, 255);
            matchSlots[nextMatchSlot].sprite = soundPictures[nextPictureA].pictureWithText;
            playSound.PlayOneShot(soundPictures[nextPictureA].pictureName2);
            nextMatchSlot++;
        }
    }
    public void AddNotAMatch()
    {
        if (nextNoMatchSlot <= noMatchSlots.Length)
        {
            noMatchSlots[nextNoMatchSlot].color = new Color(255, 255, 255, 255);
            noMatchSlots[nextNoMatchSlot].sprite = soundPictures[nextPictureA].pictureWithText;
            playSound.PlayOneShot(soundPictures[nextPictureA].pictureName2);
            nextNoMatchSlot++;
        }
    }
    public void ReplaySound()
    {
        playSound.PlayOneShot(soundPictures[nextPictureA].pictureName);
    }
    private void ResetSlots()
    {
        //if game is being reset, previous data is cleared.
        for (int i = 0; i < noMatchSlots.Length; i++)
        {
            noMatchSlots[i].sprite = null;
            noMatchSlots[i].color = new Color(255, 255, 255, 100);
        }
        for (int i = 0; i < matchSlots.Length; i++)
        {
            matchSlots[i].sprite = null;
            matchSlots[i].color = new Color(255, 255, 255, 100);
        }
        nextMatchSlot = 0;
        currentPictureA = 0;
        nextPictureA = 0;
        nextNoMatchSlot = 0;
        resetGame = false;
    }
    public void ResetGame()
    {
        //bool to change if game can be reset.
        resetGame = true;
    }
}
