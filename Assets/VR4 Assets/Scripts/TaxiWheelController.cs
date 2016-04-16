using UnityEngine;
using System.Collections;

public class TaxiWheelController : MonoBehaviour 
{
	public GameObject car;
	public int speed;
	public float maxRot;

	private float lastRot;

	// Use this for initialization
	void Start () 
	{
		lastRot = car.transform.rotation.eulerAngles.y;
	}

	// Update is called once per frame
	void Update () 
	{
		Vector3 wheelRot = transform.rotation.eulerAngles;
		float nowRot = car.transform.rotation.eulerAngles.y;
		wheelRot.z = ((nowRot-lastRot)/maxRot) * -90;
		lastRot = nowRot;
		transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(wheelRot), Time.deltaTime * speed);
	}
}
