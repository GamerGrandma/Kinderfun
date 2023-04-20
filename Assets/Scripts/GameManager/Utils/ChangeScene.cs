using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ChangeScene : MonoBehaviour
{
    public GameObject crayonPanel;
    public void LoadCrayonGame()
    {
        SceneManager.LoadScene("1CrayonGameP");
    }

    public void LoadClassroom()
    {
        SceneManager.LoadScene("Classroom1");
    }

    public void LoadMazeGame()
    {
        SceneManager.LoadScene("MazeGame1");
    }

    public void LoadSoundGame()
    {
        SceneManager.LoadScene("SoundGame1");
    }
    public void LoadGoodbyeScene()
    {
        SceneManager.LoadScene("GoodbyeScene");
    }
    public void ActivateClassroomScene()
    {
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("Classroom1"));
        crayonPanel.SetActive(true);
    }
}

