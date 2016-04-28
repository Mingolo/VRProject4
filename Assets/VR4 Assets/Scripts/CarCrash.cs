using UnityEngine;
using System.Collections;
using UnityStandardAssets.Vehicles.Car;
using UnityStandardAssets.ImageEffects;
public class CarCrash : MonoBehaviour 
{
	public AudioSource crashSound;
    public AudioSource bgm;
    public AudioClip s_Crash;
	public int collisionSpeed;
	public Light light1;
	public Light light2;
	public Light light3;
	private DriveSceneController scene;
    public GameObject blindFold;
    public MotionBlur blur;
	// Use this for initialization
	void Start () 
	{
        bgm = GameObject.Find("SceneMgr").GetComponent<AudioSource>();
        crashSound = this.gameObject.GetComponent<AudioSource>();
		PlayerPrefs.SetInt("Crash", 0);
		scene = GameObject.Find ("SceneMgr").GetComponent<DriveSceneController>();
	}
	
	void OnCollisionEnter(Collision col)
	{
		if (col.relativeVelocity.magnitude >= collisionSpeed) 
		{
			PlayerPrefs.SetInt("Crash", 1);
            this.GetComponent<CarAudio>().StopSound();
            this.GetComponent<CarAudio>().enabled = false;
            crashSound.mute = false;
            crashSound.PlayOneShot(s_Crash, 1);
            Invoke("StopBgm", .5f);
			Debug.Log ("Crashed!");
		}
	}

    void StopBgm()
    {
       
        bgm.Stop();
        blindFold.GetComponent<MeshRenderer>().enabled = true;
        blur.enabled = false;
        light1.enabled = false;
        light2.enabled = false;
        light3.enabled = false;
        scene.changeScene = true;
    }
}
