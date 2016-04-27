using UnityEngine;
using System.Collections;

public class BedroomPhone : PhoneVibrate
{
    public float dialogDelay; //how long we wait to change to the ending scene
    public string lvlIndex;
    public AudioClip drunkAngry;
    public AudioClip soberAngry;
    MainSceneAudio sceneMgr;
    void Awake()
    {
        sceneMgr = GameObject.Find("SceneMgr").GetComponent<MainSceneAudio>();
    }

	// Update is called once per frame
	public override void Update () 
    {
        if (ItemSelection.isObjectSelected && !ItemSelection.isAnythingGazed)
        {
            localSound.Stop();
            localSound.loop = false;
            if (PlayerPrefs.HasKey("Answered"))
            {
                if (PlayerPrefs.GetInt("Answered") == 1)
                {
                    dialogMgr.PlayOneShot(drunkAngry);
                    dialogDelay = 5;                                                        ///needs to be coded in laterS
                }
                else
                {
                    dialogMgr.PlayOneShot(soberAngry);
                    dialogDelay = 5;
                }

                PlayerPrefs.DeleteAll();
                StartCoroutine(sceneMgr.LoadCutScene(lvlIndex));  
            }
            else
                print("Remember to set up the Answered Key");
            
        }
	}
}
