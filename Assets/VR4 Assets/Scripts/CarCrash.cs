using UnityEngine;
using System.Collections;

public class CarCrash : MonoBehaviour 
{
	public AudioSource crashSound;
	public int collisionSpeed;
	public Light light1;
	public Light light2;
	public Light light3;
	private DriveSceneController scene;

	// Use this for initialization
	void Start () 
	{		
		PlayerPrefs.SetInt("Crash", 0);
		scene = GameObject.Find ("SceneMgr").GetComponent<DriveSceneController>();
	}
	
	void OnCollisionEnter(Collision col)
	{
		if (col.relativeVelocity.magnitude >= collisionSpeed) 
		{
			PlayerPrefs.SetInt("Crash", 1);
			crashSound.Play ();
			light1.enabled = false;
			light2.enabled = false;
			light3.enabled = false;
			scene.changeScene = true;
			Debug.Log ("Crashed!");
		}
	}
}
