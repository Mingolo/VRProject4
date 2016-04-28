using UnityEngine;
using System.Collections;

public class SoundTriggerAlt : MonoBehaviour 
{
	public AudioSource localSound;
    public AudioClip introDialog;
    public AudioClip introDrunk;
    public float introDelay = 3;
    public int sceneIndex = 0;


	void Start()
	{
        localSound = this.GetComponent<AudioSource>();
        Invoke("IntroDialog", introDelay);
	}

    void IntroDialog()
    {
        if (sceneIndex == 1)                                                 //this is the taxi driver scene AND the Bedroom 2 Scene
        {
            if (PlayerPrefs.GetInt("IsDrunk") == 1)
                localSound.PlayOneShot(introDrunk);
            else
                localSound.PlayOneShot(introDialog);
        }
        else if (sceneIndex == 2)                                           //this is the hospital Arrival scene
        {
            if (PlayerPrefs.GetInt("Go") == 0 && PlayerPrefs.GetInt("IsDrunk") == 1)
                localSound.PlayOneShot(introDrunk);
            else
                localSound.PlayOneShot(introDialog);
        }
        else
            localSound.PlayOneShot(introDialog, 1);
    }


}
