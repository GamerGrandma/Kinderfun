using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="memoryCardData",menuName = "Memory Card")]
public class MemoryCardSO : ScriptableObject
{
    public string letterTag;
    public int caseId;//not sure if needed
    public Sprite letter;
    public Color color;
}
