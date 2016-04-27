using UnityEngine;
using System.Collections;

public class BeginningDialog : MonoBehaviour
{
    public AudioSource localSound;
    public AudioClip introDialog;
    public float introDelay = 1.5f;
    public AudioClip idleDialog;
    public float idleDelay = 3;
    public 
	// Use this for initialization
	void Start () 
    {
        localSound = this.GetComponent<AudioSource>();
        Invoke("StartSound", introDelay);
	}
	
    void StartSound()
    {
        localSound.PlayOneShot(introDialog);
        Invoke("IdleSound", idleDelay);
    }

    void IdleSound()
    {
        if (!ItemSelection.isObjectSelected && !ItemSelection.isAnythingGazed)
        {
            localSound.PlayOneShot(idleDialog);
        }
    }
	// Update is called once per frame
	void Update () {
	
	}
}
