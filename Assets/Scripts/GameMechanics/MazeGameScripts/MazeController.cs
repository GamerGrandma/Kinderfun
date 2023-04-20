using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class MazeController : MonoBehaviour
{
    private float movementX;
    private float movementY;
    public float speed = 5f;
    public GameObject[] lettersToPickUp;
    public GameObject theBus;
    public Transform target; //gets location to return bus to on reset.
    public Image[] happySlots;
    public Sprite happyFace;
    public Sprite slotSprite;
    private int nextSlot;
    public AudioSource audioPlayer;
    public AudioClip instructions;
    public AudioClip instruct2;
    private bool resetGame = false;
    public bool IsMoving { get; private set; }
    Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        StartCoroutine(PlayInstructions());
    }
    private void Update()
    {
        if(resetGame == true)
        {
            ResetSlots();
        }
    }
    void FixedUpdate()
    {
        MoveTheBus();
        RotateTheBus();
    }
    IEnumerator PlayInstructions()
    {
        audioPlayer.PlayOneShot(instructions);
        yield return new WaitForSeconds(5);
        audioPlayer.PlayOneShot(instruct2);
    }
    void MoveTheBus()
    {
        // Moves the bus.
        Vector3 movement = new Vector3(movementX, movementY, 0f);
        rb.velocity = movement*speed;
    }
    public void OnMove(InputValue movementValue)
    {
        //gets vector2 data and seperates into two variables for character movement.
        Vector2 movementVector = movementValue.Get<Vector2>();
        IsMoving = movementVector != Vector2.zero;
        movementX = movementVector.x;
        movementY = movementVector.y;
    }
    void RotateTheBus()
    {
        //need some kind of look direction for rotation.
        if(IsMoving == true)
        {
            Vector2 currentPos = transform.position;
            Vector2 newPosition = new Vector2(movementX, movementY);
            Vector2 positionToLookAt = newPosition + currentPos;
            transform.LookAt(positionToLookAt, Vector3.forward);
        }
    }
    public void AddHappyFace()
    {
        //this method is called in LetterCollected script when a letter is picked up.
        happySlots[nextSlot].sprite = happyFace;
        nextSlot++;
    }
    public void ResetSlots()
    {
        // if game is played again, letters go back on maze and happy faces are cleared from slots.
        nextSlot = 0;
        for(int i = 0; i < happySlots.Length; i++)
        {
            happySlots[i].sprite = slotSprite;
        }
        for(int j = 0; j < lettersToPickUp.Length; j++)
        {
            lettersToPickUp[j].SetActive(true);
        }
        //bus returns to original position.
        theBus.transform.position = target.position;
        resetGame = false;
    }
    public void ResetGame()
    {
        resetGame = true;
    }
}
