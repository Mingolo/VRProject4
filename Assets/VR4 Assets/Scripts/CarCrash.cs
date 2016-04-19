using UnityEngine;
using System.Collections;

public class CarCrash : MonoBehaviour 
{
	public int collisionSpeed;

	// Use this for initialization
	void Start () 
	{		
		PlayerPrefs.SetInt("Crash", 0);
	}
	
	void OnCollisionEnter(Collision col)
	{
		if (col.relativeVelocity.magnitude >= collisionSpeed) 
		{
			PlayerPrefs.SetInt("Crash", 1);
			Debug.Log ("Crashed!");
		}
	}
}
