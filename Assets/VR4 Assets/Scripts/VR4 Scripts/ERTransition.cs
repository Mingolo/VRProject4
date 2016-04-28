using UnityEngine;
using System.Collections;

public class ERTransition : MonoBehaviour 
{
    public float delayTime = 30;
    public string lvlIndex;
    MainSceneAudio sceneMgr;


    // Use this for initialization
    void Start()
    {
        sceneMgr = GameObject.Find("SceneMgr").GetComponent<MainSceneAudio>();
        if ( PlayerPrefs.GetInt("IsDrunk") == 1)
            delayTime = 77;                                                                     //remember to add introDelay time from Start Scene Trigger Object to correctly fade out
        else
            delayTime = 27;
        Invoke("LoadCutScene", delayTime);
    }

    void LoadCutScene()
    {
        StartCoroutine(sceneMgr.LoadCutScene(lvlIndex));                                                    //needs to be loaded in Inspector
    }
}
