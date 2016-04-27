using UnityEngine;
using System.Collections;

public class SelectionGlow : MonoBehaviour 
{
    public Light baseLight;                     //both lights are set in the inspector
    public Light glowLight;
     public bool isSelected = false;                    //on when over
                     
    public float baseIntensity = 8;
    //public float minGlow = 1.5f;
    //public float maxGlow = 5.5f;                //min glow is 3.5
    public float midGlow = 3.5f;
    public float glowAmplitude = 2;
    public float glowFreq = 1;
    float tween = 0;
    bool doOnce = false;
    bool isFaded = false;     //initiates glowing

    Color selectionColor;
	// Use this for initialization
	void Start () 
    {
        selectionColor = new Color(81, 231, 107, 255);
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (isSelected)
        {
            baseLight.intensity = baseIntensity;
            glowLight.intensity = midGlow + (glowAmplitude * Mathf.Sin(Time.time * glowFreq));

            if (Input.GetButtonDown("Jump"))
                glowLight.color = selectionColor;
        }
        else
        {
            baseLight.intensity = 0;
            glowLight.intensity = 0;
        }

	}

    IEnumerator FadeSelection(int fadeDirection)
    {
        float baseIntensity = 0;
        float glowIntensity = 0;
        bool isValid = true;
        if (fadeDirection >= 0)                     //fade in
        { 

            do
            {
                if (isSelected)
                {

                    tween += .01f;
                    glowIntensity = Mathf.Lerp(0, midGlow, tween);
                    baseIntensity = Mathf.Lerp(0, baseIntensity, tween);
                    baseLight.intensity = baseIntensity;
                    glowLight.intensity = glowIntensity;
                    yield return new WaitForSeconds(.005f);
                }
                else
                    isValid = false;
            }
            while (isValid && tween < 1);

            isFaded = true;
        }
        else if (fadeDirection < 0)                                     //fade back out
        {
            do
            {
                if (isSelected)
                {

                    tween -= .01f;
                    glowIntensity = Mathf.Lerp(0, midGlow, tween);
                    baseIntensity = Mathf.Lerp(0, baseIntensity, tween);
                    yield return new WaitForSeconds(.005f);
                }
                else
                    isValid = false;  
            }
            while (isValid && tween < 1);

            isFaded = false;
        }

   
    }


}
