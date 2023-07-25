using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadialMenuFunctions : MonoBehaviour
{/*
    public RadialMenu homeMenu;
    public RadialMenu filterMenu; */
    /*public List<GameObject> airspaceContainer;
    string objectName = "AP";*/
    public GameObject airspaceContainer;
    public GameObject[] waypoints;
    /*
    public void SetFilter()
    {
        homeMenu.ChangeActive();
        filterMenu.ChangeActive();
    }*/
    /*
    private void Start()
    {
        airspaceContainer = GameObject.Find(objectName);
        Debug.Log(airspaceContainer.name);
    }*/

    public void airSpaceChange() {
        Debug.Log("Sind wir drin?");
        if (airspaceContainer.transform.GetChild(0).gameObject.activeSelf == true) 
        { for (int i = 0; i < airspaceContainer.transform.childCount; i++) 
            { airspaceContainer.transform.GetChild(i).gameObject.SetActive(false); 
            } 
        } 

        else 
        { for (int i = 0; i < airspaceContainer.transform.childCount; i++) 
            { airspaceContainer.transform.GetChild(i).gameObject.SetActive(true); 
            } 
        }
        /*
        print("Sind in der Methode");
        Debug.Log("Sind in der Methode");
        if (airspaceContainer.activeSelf == true){
            airspaceContainer.SetActive(false);
            print("Setz False");
            Debug.Log("Setz False");
        }
        else if (airspaceContainer.activeSelf != true)
        {
            airspaceContainer.SetActive(true);
            print("Setz True");
            Debug.Log("Setz True");*/
    }
    public void waypointChange() {
        waypoints = GameObject.FindGameObjectsWithTag("waypoint");
        if (waypoints[0].activeSelf == true) 
        {
            foreach (GameObject waypoint in waypoints) 
            {
                waypoint.SetActive(false);
            }
        }
        else {
            foreach (GameObject waypoint in waypoints) 
            {
                waypoint.SetActive(true);
            }
        }
        
    }

}
//}
