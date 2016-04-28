using UnityEngine;
using System.Collections;

public class TransitionScene : MonoBehaviour
{
    public float delayTime = 30;
    public string lvlIndex;
    MainSceneAudio sceneMgr;


	// Use this for initialization
	void Start () 
    {
        sceneMgr = GameObject.Find("SceneMgr").GetComponent<MainSceneAudio>();
        Invoke("LoadCutScene", delayTime);
	}

    void LoadCutScene()
    {
        StartCoroutine(sceneMgr.LoadCutScene(lvlIndex));                                                    //needs to be loaded in Inspector
    }
	// Update is called once per frame
	void Update () {
	
	}
}
