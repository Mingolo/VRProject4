using UnityEngine;
using System.Collections;

public class BeforeCrashSoundTrigger : MonoBehaviour 
{
	public AudioSource audio;
	private bool active;

	void Start()
	{
		active = true;
	}

	void OnTriggerEnter(Collider other)
	{
		if (active && other.gameObject.tag != "Trigger") 
		{
			active = false;
			audio.Play ();
		}
	}
}
