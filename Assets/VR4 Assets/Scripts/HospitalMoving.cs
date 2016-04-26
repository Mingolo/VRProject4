using UnityEngine;
using System.Collections;

public class HospitalMoving : MonoBehaviour 
{
    public float speed = 3;
    Vector3 moveAmount;
    Vector3 forwardDir;
    Rigidbody body;
    bool isMoving = false;

	// Use this for initialization
	void Start () 
    {
        body = this.GetComponent<Rigidbody>();
        forwardDir = -Vector3.forward;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (isMoving)
        {
            moveAmount = forwardDir * speed;
        }
       
	}
    void FixedUpdate()
    {
        body.MovePosition(this.transform.position + (moveAmount * Time.fixedDeltaTime));
    }
}
