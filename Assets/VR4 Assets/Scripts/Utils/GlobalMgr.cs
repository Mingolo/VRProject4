using UnityEngine;
using System.Collections;

public class GlobalMgr : MonoBehaviour
{
    public ItemSelection selector;
    public int sceneIndex;                                          //set in Inspector to identify the scene
	// Use this for initialization
	void Start () 
    {
        selector = this.gameObject.GetComponent<ItemSelection>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (selector.isTriggered)
        {
            switch (sceneIndex)
            {
                case 1:
                    if (this.gameObject.tag == "Beer")
                    {
                        print("drunk");
                        PlayerPrefs.SetInt("IsDrunk", 1);
                    }
                        
                    else
                        PlayerPrefs.SetInt("IsDrunk", 0);
                        
                    break;
                case 2:
                    if (this.gameObject.tag == "Beer" || this.gameObject.tag == "Water")
                        PlayerPrefs.SetInt("Answered", 0);
                    else
                        PlayerPrefs.SetInt("Answered", 1);
                    break;
                case 3:
                    if (this.gameObject.tag == "Phone")
                        PlayerPrefs.SetInt("Go", 1);
                    else if (this.gameObject.tag == "Beer" || this.gameObject.tag == "Water")
                        PlayerPrefs.SetInt("Go", 2);
                    else if (this.gameObject.tag == "Keys")
                        PlayerPrefs.SetInt("Go", 0);
                    break;
            }
        }
	
	}
}
