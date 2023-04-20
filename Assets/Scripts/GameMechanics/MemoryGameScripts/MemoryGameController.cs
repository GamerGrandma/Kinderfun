using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MemoryGameController : MonoBehaviour
{
    public MemoryCardSO[] menoryCards;
    public Image[] memorycardSlots; //to place cards in game.
    public Image slotImage; //to clear sprite to original one.
    public GameObject[] buttonHolders; //to setactive button graphic true or false.
    private GameObject buttonHolder1;
    private GameObject buttonHolder2;
    //public int cardIndex; //to keep track of which cards
    private int nextCard = 0;//which card in array to place.
    public bool matched = false; //keep track of whether or not match is made.
    //track of how many cards are shown.
    public bool firstCard = false;
    public bool secondCard = false;
    //strings to compare for a match.
    private string firstTag = null;
    private string secondTag = null;
    //audio files for sorry and good job and direction
    public AudioSource playSound;
    public AudioClip sorry;
    public AudioClip good;
    public AudioClip directions;
    public AudioClip doneGame;
    private bool resetGame = false;//for resetting game to replay it.

    void Awake()
    {
        ShuffleDeck();
    }
    void Start()
    {
        StartCoroutine(PlayInstructions());
        PlaceCards();
    }
    private void Update()
    {
        if(resetGame == true)
        {
            nextCard = 0;
            ResetSlots();
            ShuffleDeck();
            PlaceCards();
            resetGame = false;
        }
    }
    IEnumerator PlayInstructions()
    {
        //play directions audio
        playSound.PlayOneShot(directions);
        yield return new WaitForSeconds(8);
        playSound.PlayOneShot(doneGame);
    }
    void ShuffleDeck()
    {
        //rearranges order of memory card deck.
        int replacements = Random.Range(20, 1000);//for how many times the switching loop will run.
        for(int i = 0; i < replacements; i++)
        {
            //picks 2 different cards from deck to switch places.
            int A = Random.Range(0, menoryCards.Length);
            int B = Random.Range(0, menoryCards.Length);
            MemoryCardSO a = menoryCards[A];
            MemoryCardSO b = menoryCards[B];
            MemoryCardSO c = menoryCards[A];//need 3rd holder to remember 1st card when switching.
            a = b;//1st random card becomes the 2nd random one.
            b = c;//2nd random card becomes 1st one as remembered by 3rd holder.
            menoryCards[A] = a;
            menoryCards[B] = b;
        }
        resetGame = false;
    }
    void PlaceCards()
    {
        //puts memory card backs in cardSlots.
        for(int i = 0; i< memorycardSlots.Length; i++)
        {
            if(nextCard < menoryCards.Length)
            {
                memorycardSlots[nextCard].sprite = menoryCards[nextCard].letter;
                memorycardSlots[nextCard].color = menoryCards[nextCard].color;
                nextCard++;
            }
        }
        resetGame = false;
    }
    public void CardRevealed(int slotNumber)
    {
        if(!firstCard && !secondCard) //if no cards are revealed.
        {
            Debug.Log("card showing " + slotNumber);
            if (memorycardSlots[slotNumber] != null)
            {
                buttonHolder1 = buttonHolders[slotNumber]; //saves button graphic in case needed again.
                buttonHolders[slotNumber].SetActive(false); //hide button graphic
                memorycardSlots[slotNumber].sprite = menoryCards[slotNumber].letter; //show card letter.
                firstCard = true; //one card is revealed.
                firstTag = menoryCards[slotNumber].letterTag; // get a string to compare.
            }
        }
        else if(firstCard = true && !secondCard) //if one card is showing but not 2nd.
        {
            Debug.Log("card showing " + slotNumber);
            if (memorycardSlots[slotNumber] != null)
            {
                buttonHolder2 = buttonHolders[slotNumber];
                buttonHolders[slotNumber].SetActive(false);
                memorycardSlots[slotNumber].sprite = menoryCards[slotNumber].letter;
                secondCard = true;
                secondTag = menoryCards[slotNumber].letterTag;
                StartCoroutine(CheckIfTagsMatch()); //method that checks strings for a match.
            }
        }
    }
    IEnumerator CheckIfTagsMatch()
    {
        if (firstTag == secondTag) // if string tags match.
        {
            playSound.PlayOneShot(good);
            firstCard = false; //reset bools to enable card reveal with buttons.
            secondCard = false;
        }
        else if (firstTag != secondTag) //if string tags do not match.
        {
            playSound.PlayOneShot(sorry);
            yield return new WaitForSeconds(3f); //need to wait so player can see 2nd card before hiding again.
            firstCard = false; // reset bools to enable card reveal with buttons.
            secondCard = false;
            buttonHolder1.SetActive(true); //show button graphics again so the button can be used again.
            buttonHolder2.SetActive(true);
        }
    }
    private void ResetSlots()
    {
        nextCard = 0;
        for (int i = 0; i < buttonHolders.Length; i++)
        {
            buttonHolders[i].SetActive(true);
            
        }
        for(int i = 0; i< memorycardSlots.Length; i++)
        {
            nextCard = 0;
        }
        resetGame = false;
    }
    public void ResetGame()
    {
        //bool to allow game to be reset.
        resetGame = true;
    }
}
