using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class DriveSceneController : MonoBehaviour 
{
	public bool changeScene;
	public float waitTime;
	public string NextScene;
	private Fading fade;
	private bool fadeNow;

	void Awake()
	{
		fade = GetComponent<Fading>();
		fade.BeginFade (-1);
	}

	// Use this for initialization
	void Start () 
	{
		changeScene = false;
		fadeNow = true;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (changeScene) 
		{
			if (fadeNow) 					//fade out the scene, put all fade out code here
			{
				fadeNow = false;
				fade.BeginFade (1);
			} 
			else 
			{
				waitTime -= Time.deltaTime;
				if (waitTime <= 0) 					//change to another scene after timer runs out (we wait for fade out to finish)
				{
					changeScene = false;
					SceneManager.LoadScene (NextScene);
				}
			}
		}
	}
}
