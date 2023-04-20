using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "mazeLetterData", menuName = "Maze LetterSO")]
public class LettersSO : ScriptableObject
{
    public string letterTag;
    public Sprite letter;
    public Color color;
}
