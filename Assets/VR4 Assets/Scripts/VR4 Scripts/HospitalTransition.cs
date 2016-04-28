using UnityEngine;
using System.Collections;

public class HospitalTransition : MonoBehaviour {

    public float delayTime = 30;
    public string lvlIndex;
    MainSceneAudio sceneMgr;


    // Use this for initialization
    void Start()
    {
        sceneMgr = GameObject.Find("SceneMgr").GetComponent<MainSceneAudio>();
        if (PlayerPrefs.GetInt("Go") == 0 && PlayerPrefs.GetInt("IsDrunk") == 1)
            delayTime = 31;                                                                                  //remember to add introDelay time from Start Scene Trigger Object to correctly fade out
        else
            delayTime = 17;
        Invoke("LoadCutScene", delayTime);
    }

    void LoadCutScene()
    {
        PlayerPrefs.DeleteAll();
        StartCoroutine(sceneMgr.LoadCutScene(lvlIndex));                                                    //needs to be loaded in Inspector
    }
    // Update is called once per frame
 
}
