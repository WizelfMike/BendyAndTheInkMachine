using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;
using UnityEngine.Experimental.Rendering;

public class DepthOfFieldCamera : MonoBehaviour
{
    Ray raycast;
    RaycastHit hit;
    bool isHit;
    float hitDistance;
	public float hitlimit;

	DepthOfField dof;
	public Volume Postvolume;

	void Start()
	{
		Postvolume.profile.TryGet<DepthOfField>(out dof);
	}

	void Update()
    {
        raycast = new Ray(transform.position, transform.forward * 100);

        isHit = false;

		if (Physics.Raycast(raycast, out hit, 100f))
		{
			isHit = true;
			hitDistance = Vector3.Distance(transform.position, hit.point);
			Debug.Log(dof.focusDistance.value);
		}
		else
		{
			if (hitDistance < hitlimit)
			{
				hitDistance++;
			}
		}

		SetFocus();
	}

	void SetFocus()
	{
		dof.focusDistance.value = hitDistance;
	}

	private void OnDrawGizmos()
	{
		if (isHit)
		{
			Gizmos.DrawSphere(hit.point, 0.1f);

			Debug.DrawRay(transform.position, transform.forward * Vector3.Distance(transform.position, hit.point));
		}
		else
		{
			Debug.DrawRay(transform.position, transform.forward * 100f);
		}
	}
}
