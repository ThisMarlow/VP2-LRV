using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadialMenuFunctions : MonoBehaviour
{
    public RadialMenu homeMenu;
    public RadialMenu filterMenu; 
    public void SetFilter()
    {
        homeMenu.ChangeActive();
        filterMenu.ChangeActive();
    }
}
