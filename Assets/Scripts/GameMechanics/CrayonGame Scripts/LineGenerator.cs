using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineGenerator : MonoBehaviour
{
    public GameObject linePrefab;
    Line activeLine;
    Color newColor;
    private GameObject[] lines;

    private void Start()
    {
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject newLine = Instantiate(linePrefab);
            activeLine = newLine.GetComponent<Line>();
            //lineMaterial = newLine.GetComponent<Material>();
        }
        if (Input.GetMouseButtonUp(0))
        {
            activeLine = null;
        }
        if (activeLine != null)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            activeLine.lineRenderer.material.color = newColor;
            activeLine.UpdateLine(mousePos);
        }
    }
    //set colorNum in on button in inspector
    public void GetAColor(int colorNum)
    {
        //converts colorNum ints to color with switch statements.
        //create colors not defined by unity.
        Color brown = new Color(.4f, .25f, .18f, 1f);
        Color orange = new Color(1f, .5f, .15f, 1f);
        Color pink = new Color(.96f, .49f, .65f, 1f);
        Color purple = new Color(.62f, .03f, .78f, 1f);
        switch (colorNum)
        {
            case 1:
                newColor = Color.black;
                break;
            case 2:
                newColor = brown;
                break;
            case 3:
                newColor = Color.blue;
                break;
            case 4:
                newColor = Color.green;
                break;
            case 5:
                newColor = Color.yellow;
                break;
            case 6:
                newColor = orange;
                break;
            case 7:
                newColor = Color.red;
                break;
            case 8:
                newColor = pink;
                break;
            case 9:
                newColor = purple;
                break;
            default:
                newColor = Color.black;
                break;
        }
    }
    public void RemoveLines()
    {
        if (lines == null)
            lines = GameObject.FindGameObjectsWithTag("line");
        foreach (GameObject line in lines)
        {
            Destroy(line);
        }
    }
}
