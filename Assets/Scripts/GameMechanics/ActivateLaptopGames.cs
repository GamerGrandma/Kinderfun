using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ActivateLaptopGames : MonoBehaviour
{
    [Header("Main Scene")]
    public Transform decor;
    public GameObject exitDoor;
    public GameObject nPc;
    [Header("Canvas Objects")]
    public GameObject[] gameButtons;
    public GameObject[] gamePanels;
    public GameObject letterSprite;
    public AudioSource playSound;
    public AudioClip[] playGame;
    public int buttonArray;
    public int nextPanel;
    private int nextSound;

    void Start()
    {
        
    }

    void Update()
    {
        ActivateGameButtons();
    }
    bool buttonIsActive;
    public void ActivateGameButtons()
    {
        //buttons for laptop games will be activated at certain points.
        if(!buttonIsActive && letterSprite.activeInHierarchy == true)
        {
            if (buttonArray < gameButtons.Length)
            {
                gameButtons[buttonArray].SetActive(true);
                //StartCoroutine(PlayFirstSound());
                nextPanel = buttonArray;
                buttonArray = buttonArray + 1;
                buttonIsActive = true;
            }
            else 
            { 
                Debug.Log("all buttons are active"); 
            }
        }
    }
    IEnumerator PlayFirstSound()
    {
        //plays the instruction for the first game button after timeline is done.
        yield return new WaitForSeconds(3);
        playSound.PlayOneShot(playGame[nextSound]);
        nextSound = nextSound + 1;
    }
    public void OpenNextGamePanel(int panelNumber)
    {
        //game panel will open when laptop button is clicked.
        gamePanels[panelNumber].SetActive(true);
        if(nextPanel < gamePanels.Length)
        {
            nextPanel = nextPanel + 1;
        }
        else
        {
            nextPanel = gamePanels.Length;
        }
        //hides classroom elements that might block panel in view.
        foreach (Transform child in decor)
        {
            child.gameObject.SetActive(false);
        } 
        exitDoor.SetActive(false);
        nPc.SetActive(false);
    }
    public void CloseGamePanel(int thisPanel) 
    {
        if (gamePanels[nextPanel -1] != null)
        {
            //sets the next game button active and plays instruction audio.
            if(buttonArray < gameButtons.Length)
            {
                gameButtons[buttonArray].SetActive(true);
                buttonArray = buttonArray + 1;
                playSound.PlayOneShot(playGame[nextSound]);
                if(nextSound < playGame.Length)
                {
                    nextSound = nextSound + 1;
                }
                else
                {
                    nextSound = playGame.Length;
                }
            }
            //panels are reset by each game control when closed.
            gamePanels[thisPanel].SetActive(false);
            //all original classroom elements are set active again.
            foreach (Transform child in decor)
            {
                child.gameObject.SetActive(true);
            }
            exitDoor.SetActive(true);
            nPc.SetActive(true);
        }
    }
    public void ExitDoor()
    {
        SceneManager.LoadScene("GoodbyeScene");
    }
}
