using UnityEngine;
using System.Collections;

public class BedroomSceneController : MonoBehaviour {

	public AudioSource callerMad5Sound;
	public AudioSource callerMad10Sound;
	public AudioSource crashedSound;
	public float waitTime;			//how long the until we fade to black and game ends
	private Fading fade;
	private bool active;

	void Awake()
	{
		fade = GetComponent<Fading>();
		fade.BeginFade (-1);
	}

	// Use this for initialization
	void Start () 
	{
		active = true;
		if (PlayerPrefs.GetInt ("Crash") == 1)
			crashedSound.Play ();
		else if (PlayerPrefs.GetInt ("Answered") == 1)
			callerMad10Sound.Play ();
		else
			callerMad5Sound.Play ();
	}

	// Update is called once per frame
	void Update () 
	{
		if (active) 
		{
			waitTime -= Time.deltaTime;
			if (waitTime < 0) 
			{
				active = false;
				PlayerPrefs.DeleteAll ();
				fade.BeginFade (1);
			}
		}
	}
}
