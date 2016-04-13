using UnityEngine;
using System.Collections;
/// <summary>
/// 
/// </summary>

public class RayCaster : MonoBehaviour
{
    public Camera cam;
    public GameObject lastObjectHit;
    bool isOff = false;
    public static GameObject currentPlanet;                              //initialized in Gravity2 at startup
    public LayerMask ObjectLayer;
   
    // Use this for initialization
    void Start()
    {

        InvokeRepeating("RayCasting", .1f, 1f / 60);
    }

    // Update is called once per frame
    void RayCasting()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));

        if ( Physics.Raycast(ray, out hit, ObjectLayer))                                //use SphereCast instead
        {
            //print("hit" + hit.transform.gameObject.name);                                                       //prints what the raycaster is hitting
            GameObject objectHit = hit.transform.gameObject;

            ObjectIDAndSelect(objectHit);


        }
        else
        {

            ObjectIDAndSelect(null);
        }
    }

    void ObjectIDAndSelect(GameObject go)
    {
		/*

        if (lastObjectHit == null)                  //when we first see an object, set it up for selection
        {
            // print("space");
            lastObjectHit = go;
            isOff = false;
        }
        else if (go == lastObjectHit)
        {
            if (go.tag == "Phone" || go.tag == "Beer" || go.tag == "Water" || go.tag == "Keys")                                                                  //CHANEG THIS TO WHATEVER TAGS WE ARE USING FOR THE OBJECTS
            {
                // print("Charging");
                go.GetComponentInChildren<Glow>().isOver = true;
            }


            isOff = false;

        }
        else if (lastObjectHit != go)
        {
            //print("missed");
            if (lastObjectHit != null && (lastObjectHit.tag == "Phone" || lastObjectHit.tag == "Beer" || lastObjectHit.tag == "Water" || lastObjectHit.tag == "Keys"))          //CHANGE THIS TO WHATEVER TAGS WE ARE USING FOR THE OBJECTS
                lastObjectHit.GetComponentInChildren<Glow>().isOver = false;

            isOff = true;
            ObjectCheck(go);
        }


        lastObjectHit = go;

		*/




    }

    void ObjectCheck(GameObject go)
    {

		/*
        if (go != null &&
            isOff &&
            lastObjectHit.GetComponent<Glow>() != null &&
            go.GetComponent<Glow>() == null)
        {
            lastObjectHit.GetComponent<Glow>().isOver = false;
        }
        isOff = false;
        */

    }




}
