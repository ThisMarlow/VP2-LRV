using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandControllerInput : MonoBehaviour
{

    public Valve.VR.SteamVR_TrackedObject trackedObj;

    // Start is called before the first frame update
    void Start()
    {
        trackedObj = GetComponent<Valve.VR.SteamVR_TrackedObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
