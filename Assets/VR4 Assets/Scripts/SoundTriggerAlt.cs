using UnityEngine;
using System.Collections;

public class SoundTriggerAlt : MonoBehaviour 
{
	public AudioSource audio;
	private bool active;

	void Start()
	{
		active = true;
	}

	void OnTriggerEnter()
	{
		if (active) 
		{
			active = false;
			audio.Play ();
		}
	}
}
