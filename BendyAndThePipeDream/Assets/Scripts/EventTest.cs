using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventTest : MonoBehaviour
{

    public string game;
    public Animator anim;
    public GameObject TransitionCanvas;
    private bool AnimationEnded = false;

    public void Test()
    {
        Debug.Log("Event Happened");
    }

	void Update()
	{
        StartLoad();
	}

	public void PlayAnimation()
	{
        TransitionCanvas.SetActive(!TransitionCanvas.activeSelf);
        anim.SetInteger("anim", 1);
	}

    public void AnimationEnd()
	{
        AnimationEnded = true;
	}

    public void StartLoad()
    {
		if (AnimationEnded)
		{
            SceneManager.LoadScene("SampleScene");
        }
    }

    public void Quit()
    {
        Application.Quit();
    }
}
