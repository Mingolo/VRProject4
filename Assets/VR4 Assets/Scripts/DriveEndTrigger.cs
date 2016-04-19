using UnityEngine;
using System.Collections;

public class DriveEndTrigger : MonoBehaviour 
{
	private bool triggered;

	void Start()
	{
		triggered = false;
	}


	void OnTriggerEnter()
	{
		if (!triggered) 
		{
			triggered = true;
			int crash = PlayerPrefs.GetInt ("Crash");

			if (crash == 0)
				Debug.Log ("Change to didn't crash scene.");
			else if (crash == 1)
				Debug.Log ("Change to CRASHED scene.");
			else
				Debug.Log ("Unknown scene!");
		}
	}
}
