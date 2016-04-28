using UnityEngine;
using System.Collections;

public class NearMissTrigger : MonoBehaviour 
{
    public AudioSource localSound;
    public AudioClip s_NearMiss;
    private bool active;


	// Use this for initialization
	void Start () 
    {
        active = true;
        localSound = this.GetComponent<AudioSource>();
	
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Trigger")
        {
            active = false;
            localSound.Play();
        }
           
    }
}
