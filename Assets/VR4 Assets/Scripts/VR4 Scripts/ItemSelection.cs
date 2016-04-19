using UnityEngine;
using System.Collections;
[RequireComponent(typeof(AudioSource))]
/// <summary>
///  selection sound from: http://www.freesound.org/people/fins/sounds/191589/
/// </summary>

public class ItemSelection : MonoBehaviour
{
    public string lvlIndex;                   //change this in inspector to the correct scene you want to load up
    public bool isOver = false;
    public bool isSelected = false;
   // public Renderer[] renderers;
    public float chargeGrain = .01f;
    public float minCharge = 0;
    public float maxCharge = .008f;
    public float charge = 0;
    public float chargeTime = .1f;
    public float currentGrain = 0;
    public int dischargeSpeed = 8;
    public bool isFullyCharged = false;
    public GameObject player;
   // public AudioClip sCharging;
    //public AudioClip sFailCharge;
    public AudioClip sSelectionSound; // lock-on sound
    public AudioClip transitionSound;
    public AudioClip gazeDialogue;            //played after staring at something for a few seconds
    public float gazeDialogueDelay = 3;                                                         // SET IN INSPECTOR TO CORRECT VALUE
    public AudioClip selectionDialogue;       //played after actually selecting the item
    public float transitionDelay = 4;                                                           //SET IN INSPECTOR TO CORRECT VALUE
    public AudioSource localSound;
    bool isObserved = false;         
    public float vol = .9f;
    MainSceneAudio sceneMgr;
    bool isTriggered = false;                 //disables all mechanics once an object is selected
    public bool __________________;

  
   protected bool doOnce = true; //used to call the charge corouting only once

    public Color selectionColor = new Color(0, 255, 55, 103);
    public Material m_Selected;                                  //SET IN INSPECTOR
    public Material m_Normal;



    public static float lookDist;
    // Use this for initialization
    public void Awake()
    {
        localSound = this.GetComponent<AudioSource>();
        sceneMgr = GameObject.Find("SceneMgr").GetComponent<MainSceneAudio>();


    }

    void Start()
    {
        
    }

    // Update is called once per frame
    public virtual void Update()
    {
        Selection();

        if (isSelected) //the object is selected and waiting to be fired
        {
            if (Input.GetButtonDown("Jump"))                                                                        //Change button mapping if desired, basically what happens when we select an item
            {

                isTriggered = true;
                FailSelection();

                localSound.PlayOneShot(selectionDialogue, 1);
                
                Invoke("LoadCutScene", transitionDelay);
                
                
             
                
            }
        }

    }

    void LoadCutScene()
    {
        StartCoroutine(sceneMgr.LoadCutScene(lvlIndex));                                                    //needs to be loaded in Inspector
    }

   

    public void  Selection()
    {
        if (!isTriggered && isOver && doOnce)
        {
            isSelected = true;                                                                                  //prevents latency in jump controls, can remove if you want to charge up for a jump
            StartCoroutine("GazeTimer");
            ChargeSelection();
            doOnce = false;
        }
        else if (!isTriggered && !isOver && !doOnce)
        {
            //resets so chargeSelection can be called again
            FailSelection();
         
            doOnce = true;
            
        }

        if (!isTriggered && isFullyCharged)
        {
            ItemSelected(); // makes a sound and changes color of outline
            isFullyCharged = false;
        }

    }

  



         

 

    public void ItemSelected()
    {
            this.GetComponent<Renderer>().material.SetColor("_OutlineColor", selectionColor);
        
        localSound.PlayOneShot(sSelectionSound, 1);
        isSelected = true;
    }


    public void ChargeSelection()
    {
        //localSound.PlayOneShot(sCharging, 1);
        StartCoroutine(ChargeLaser());
    }

    IEnumerator ChargeLaser()
    {
        //constantly checks if is over, so only need to call once
 
            //do
            //{
            //    if (isOver)
            //    {
            //        this.GetComponent<Renderer>().material.SetFloat("_Outline", charge);
            //        currentGrain += chargeGrain;
            //        charge = Mathf.Lerp(minCharge, maxCharge, currentGrain);
            //        yield return new WaitForSeconds(chargeTime);
            //    }
            //    else
            //        break;
            //}
            //while (charge < maxCharge);
        yield return new WaitForSeconds(chargeTime);
        charge = maxCharge;
            if (charge >= maxCharge)
            {
                isFullyCharged = true;
               	this.GetComponent<Renderer>().material = m_Selected;
            }
           // print(this.gameObject.name + " is Selected");                             //print which object we selected

           
       
    }

    public void FailSelection()
    {
           // localSound.Stop();                                                        //might want to put in fail sounds later
           // localSound.PlayOneShot(sFailCharge, 1);
            isSelected = false;
           

        StartCoroutine(DischargeLaser());
    }

    IEnumerator DischargeLaser()
    {
            //do
            //{
            //    if (!isSelected)
            //    {
            //        this.GetComponent<Renderer>().material.SetFloat("_Outline", charge);
            //        currentGrain -= chargeGrain * dischargeSpeed;
            //        charge = Mathf.Lerp(minCharge, maxCharge, currentGrain);
            //        yield return new WaitForSeconds(chargeTime);
            //    }
            //    else
            //        break;
            //}
            //while (charge > minCharge);

            yield return new WaitForSeconds(chargeTime);
            charge = minCharge;
            currentGrain = minCharge;
            this.GetComponent<Renderer>().material = m_Normal;
   }

    //this is  a basic timer script for objects
    IEnumerator GazeTimer()
    {
        print("timer running");

        float gazeTime = 0;

        do
        {
            //getcompoinent<timer>().text = roundlength;
            gazeTime += 1;
            if (gazeTime >= gazeDialogueDelay && !isObserved)
            {
                print("sound Play");
                isObserved = true;
                localSound.PlayOneShot(gazeDialogue, 1);
                break;
            }
            yield return new WaitForSeconds(1);
        }
        while (isOver == true);
    }
}
