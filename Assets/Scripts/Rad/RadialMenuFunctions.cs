using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadialMenuFunctions : MonoBehaviour
{
    public RadialMenu homeMenu;
    public RadialMenu filterMenu; 
    public GameObject airspaceContainer;

    public void SetFilter()
    {
        homeMenu.ChangeActive();
        filterMenu.ChangeActive();
    }

    public void airSpaceChange() {
        if (airspaceContainer.activeSelf == true){
            airspaceContainer.SetActive(false);
        }
        else if (airspaceContainer.activeSelf != true)
        {
            airspaceContainer.SetActive(true);
        }
    }
}
