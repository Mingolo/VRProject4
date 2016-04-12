using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainSceneAudio : MonoBehaviour 
{
    public AudioSource bgm;
    private float tparam;
    public float fadeOffset = 3; //smooth the fade out
    private int played = 0;
    public static MainSceneAudio S;
	// Use this for initialization
	void Awake () 
    {
        this.GetComponent<Fading>().BeginFade(-1);
        S = this;
	}

    void Start()
    {
        GetComponent<FadeMusic>().AssignTunes();
        if (PlayerPrefs.GetInt("isPlayed") != 0)
        {
            played = PlayerPrefs.GetInt("isPlayed");
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        GetComponent<FadeMusic>().FadeInTunes();
        GetComponent<FadeMusic>().FadeOutTunes(); 
	}

    public void GameOver()
    {
        StartCoroutine(LoadCutScene("GameOver"));
    }
  public  IEnumerator LoadCutScene(string lvlIndex)
    {
        //fade out game and load a new level
        GetComponent<FadeMusic>().fadeInTunes = false;
        GetComponent<FadeMusic>().fadeOutTunes = true;
        float fadeTime = this.GetComponent<Fading>().BeginFade(1);
        yield return new WaitForSeconds(fadeTime * fadeOffset);
        SceneManager.LoadScene(lvlIndex);
           
    }
}
