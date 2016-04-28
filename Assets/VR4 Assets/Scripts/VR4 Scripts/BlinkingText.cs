using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class BlinkingText : MonoBehaviour 
{
    public float midGlow = 127.5f;
     public float glowAmplitude = 50;
    public float glowFreq = 3;
    MainSceneAudio sceneMgr;
    Text txt;
    float currentGlow;
	// Use this for initialization
	void Start () 
    {
        txt = this.GetComponent<Text>();
        sceneMgr = GameObject.Find("SceneMgr").GetComponent<MainSceneAudio>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        currentGlow = midGlow + (glowAmplitude * Mathf.Sin(Time.time * glowFreq));
        txt.color = new Color(currentGlow, currentGlow, currentGlow, currentGlow);

        if (Input.GetButtonDown("Jump"))
        {
            StartCoroutine(sceneMgr.LoadCutScene("Party1"));
        }




	}
}
