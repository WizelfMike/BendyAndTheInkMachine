using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventTest : MonoBehaviour
{

    public string game;

    public void Test()
    {
        Debug.Log("Event Happened");
    }

    public void StartLoad()
    {
        SceneManager.LoadScene(game);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
