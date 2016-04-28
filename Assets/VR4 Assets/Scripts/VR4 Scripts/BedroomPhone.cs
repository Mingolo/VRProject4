using UnityEngine;
using System.Collections;

public class BedroomPhone : PhoneVibrate
{
    public float dialogDelay; //how long we wait to change to the ending scene
    public string lvlIndex;
    public AudioClip missedCallAngry;
    public AudioClip ignoredAngry;
    MainSceneAudio sceneMgr;
    bool doOnce = false;
    void Awake()
    {
        sceneMgr = GameObject.Find("SceneMgr").GetComponent<MainSceneAudio>();
    }

	// Update is called once per frame
	public override void Update () 
    {
        if (ItemSelection.isObjectSelected)
        {
            localSound.Stop();
            localSound.loop = false;
        }

        if (ItemSelection.isObjectSelected  && doOnce)
        {
          
            doOnce = true;
            localSound.Stop();
            localSound.loop = false;

                if (PlayerPrefs.GetInt("Answered") == 1)
                {
                 
                    dialogMgr.PlayOneShot(ignoredAngry);                                            //define sounds in inspector
                                                     
                }
                else
                {
                
                    dialogMgr.PlayOneShot(missedCallAngry);                                     
            
                }

                PlayerPrefs.DeleteAll();
                Invoke("LoadScene", dialogDelay);      

            
        }
	}

    void  LoadScene()
    {
        StartCoroutine(sceneMgr.LoadCutScene(lvlIndex));      
    }
}
