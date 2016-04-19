using UnityEngine;
using System.Collections;
using UnityStandardAssets.Vehicles.Car;

public class TaxiDriver : MonoBehaviour 
{

	public GameObject bunny;
	public float rotSpeed;
	public float secondsBehind;

	private Rigidbody rigid;
	private CarController car;

	// Use this for initialization
	void Start () 
	{
		rigid = GetComponent<Rigidbody>();
		car = GetComponent<CarController>();
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		Vector3 heading = bunny.transform.position - transform.position;
		float distance = heading.magnitude;
		Vector3 bunnyDir = heading / distance;
		transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (bunnyDir), rotSpeed);


		rigid.velocity = transform.forward * distance/secondsBehind;
		car.CalculateRevs ();
	}
}
