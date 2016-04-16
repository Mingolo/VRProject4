using UnityEngine;
using System.Collections;

public class TaxiPath : MonoBehaviour 
{
	public int speed;


	// Use this for initialization
	void Start () 
	{
		iTween.MoveTo (gameObject, iTween.Hash ("path", iTweenPath.GetPath ("TaxiPath"), "easetype", iTween.EaseType.linear, "speed", speed));
	}	

}
