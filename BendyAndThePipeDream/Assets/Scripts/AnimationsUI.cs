using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationsUI : MonoBehaviour
{
    public Animator animFade;
    public Animator Objective;

    void Start()
    {

    }

	void Update()
	{
/*		if (animFade.GetCurrentAnimatorStateInfo(0).IsName("Crossfade"))
		{
			Objective.SetInteger("Objective", 1);
		}*/
	}

	public void CrossfadeEnd()
	{
		Objective.SetInteger("Objective", 1);
	}
}
