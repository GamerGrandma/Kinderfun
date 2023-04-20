using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class LetterCollected : MonoBehaviour
{
    private bool triggerEntered = false;
   
    public MazeController mazeScript;

    public void OnPickUp(InputValue pushed)
    {
        if (pushed != null)
        {
            if (triggerEntered == true)
            {
                mazeScript.AddHappyFace();
                //Destroy(gameObject);
                this.gameObject.SetActive(false);
                triggerEntered = false;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
            if (other.tag == "bus")
            {
            triggerEntered = true;
            }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "bus")
        {
            triggerEntered = false;
        }
    }
}
