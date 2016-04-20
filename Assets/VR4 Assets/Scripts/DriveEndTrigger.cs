using UnityEngine;
using System.Collections;

public class DriveEndTrigger : MonoBehaviour 
{
	private bool triggered;
	private DriveSceneController scene;

	void Start()
	{
		triggered = false;
		scene = GameObject.Find ("SceneMgr").GetComponent<DriveSceneController>();
	}


	void OnTriggerEnter()
	{
		if (!triggered) 
		{
			triggered = true;
			scene.changeScene = true;
		}
	}
}
