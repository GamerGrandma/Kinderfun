using UnityEngine;

[CreateAssetMenu(fileName = "soundCardData",menuName = "SoundCard")]
public class SoundGameSO : ScriptableObject
{
    public Sprite soundPicture;
    public Sprite pictureWithText;
    public AudioClip pictureName;
    public AudioClip pictureName2;
    public string pictureTag;
    public int alphabetNumber;
    public int cardSet;
}
