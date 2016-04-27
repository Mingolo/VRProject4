using UnityEngine;
using System.Collections;
[RequireComponent(typeof(AudioSource))]
public class PhoneVibrate : MonoBehaviour 
{
    public AudioSource dialogMgr;
    public AudioSource localSound;
    public float ringVolume = .8f;
    public AudioClip ring;
    public float ringDelay = 1.5f;
    public AudioClip idleDialog;
    public float idleDelay = 3;
    
	// Use this for initialization
	void Start () 
    {
        GameObject dialog = GameObject.Find("DialogMgr");
        dialogMgr = dialog.GetComponent<AudioSource>();
        localSound = this.GetComponent<AudioSource>();

        localSound.loop = true;
        Invoke("VibratePhone", 1.5f);
	
	}

     void VibratePhone()
    {
        localSound.Play();
        Invoke("IdleSound", idleDelay);
    }

     void IdleSound()
    {
        if (!ItemSelection.isObjectSelected && !ItemSelection.isAnythingGazed)
        {
            
            dialogMgr.PlayOneShot(idleDialog, 1);
        }
    }
	
	// Update is called once per frame
	public virtual void Update () 
    {
        if (ItemSelection.isObjectSelected)
        {
            localSound.Stop();
            localSound.loop = false;
        }
	
	}
}
