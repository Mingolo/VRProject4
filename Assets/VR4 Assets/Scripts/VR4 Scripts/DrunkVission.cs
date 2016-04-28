using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;

public class DrunkVission : MonoBehaviour 
{
    public MotionBlur blur;


	// Use this for initialization
	void Start () 
    {
        blur = this.gameObject.GetComponent<MotionBlur>();

        if (PlayerPrefs.GetInt("IsDrunk") == 1)
            blur.enabled = true;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
