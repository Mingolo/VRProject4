using UnityEngine;
using System.Collections;

public class SteeringWheelController : MonoBehaviour 
{
	public int speed;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		Vector3 wheelRot = transform.rotation.eulerAngles;
		wheelRot.z = Input.GetAxis ("Horizontal") * -90;
		transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(wheelRot), Time.deltaTime * speed);
	}
}
