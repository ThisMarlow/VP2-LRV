using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadialMenuFunctions : MonoBehaviour
{/*
    public RadialMenu homeMenu;
    public RadialMenu filterMenu; */
    public GameObject airspaceContainer;
    /*
    public void SetFilter()
    {
        homeMenu.ChangeActive();
        filterMenu.ChangeActive();
    }*/

    public void airSpaceChange() {
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
            Debug.Log("Setz True");
        }
    }
}
