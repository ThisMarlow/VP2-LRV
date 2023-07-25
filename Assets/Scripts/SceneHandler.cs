/* SceneHandler.cs*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Valve.VR.Extras;
using TMPro;

public class SceneHandler : MonoBehaviour
{
    public SteamVR_LaserPointer laserPointer;
    private string airport = "";
    private GameObject airportchosen;

    void Awake()
    {
        laserPointer.PointerIn += PointerInside;
        laserPointer.PointerOut += PointerOutside;
        laserPointer.PointerClick += PointerClick;
    }

    public void PointerClick(object sender, PointerEventArgs e)
    {
        if (e.target.name == "CubeNot")
        {
            Debug.Log("Cube was clicked");
        }
        else if (e.target.name == "Button")
        {
            Debug.Log("Button was clicked");
        }
        else if (e.target.name == "Cube")
        {
            if (airport == "") 
            {
                if (e.target.transform.parent.transform.GetChild(0).GetComponent<TextMeshPro>().text == "SCHOENHAGEN")
                {
                    airportchosen = e.target;
                    e.target.transform.parent.transform.GetChild(0).GetComponent<TextMeshPro>().text = "SCHOENHAGEN, L�ngengrad: 100gdmb, Breitengrad: egnkg, Art: IFR-Flughafen";
                    e.target.transform.localScale += new Vector3(0.5f, 0.5f, 0.5f);
                    airport = "SCHOENHAGEN";
                }   
                if (e.target.transform.parent.transform.GetChild(0).GetComponent<TextMeshPro>().text == "MAGDEBURG-CITY")
                {  
                    airportchosen = e.target;
                    e.target.transform.parent.transform.GetChild(0).GetComponent<TextMeshPro>().text = "MAGDEBURG-CITY, L�ngengrad: 100gdmb, Breitengrad: egnkg, Art: IFR-Flughafen";
                    e.target.transform.localScale += new Vector3(0.5f, 0.5f, 0.5f);
                    airport = "MAGDEBURG-CITY";
                }
            }
            else if (airport == "SCHOENHAGEN") 
            {
                airportchosen.transform.parent.transform.GetChild(0).GetComponent<TextMeshPro>().text = "SCHOENHAGEN";
                airportchosen.transform.localScale -= new Vector3(0.5f, 0.5f, 0.5f);
                airport = ""; 
                if (e.target.transform.parent.transform.GetChild(0).GetComponent<TextMeshPro>().text == "MAGDEBURG-CITY")
                {
                    airportchosen = e.target;
                    e.target.transform.parent.transform.GetChild(0).GetComponent<TextMeshPro>().text = "MAGDEBURG-CITY, L�ngengrad: 100gdmb, Breitengrad: egnkg, Art: IFR-Flughafen";
                    e.target.transform.localScale += new Vector3(0.5f, 0.5f, 0.5f);
                    airport = "MAGDEBURG-CITY";
                }
            }
            else if (airport == "MAGDEBURG-CITY") 
            {
                airportchosen.transform.parent.transform.GetChild(0).GetComponent<TextMeshPro>().text = "MAGDEBURG-CITY";
                airportchosen.transform.localScale -= new Vector3(0.5f, 0.5f, 0.5f);
                airport = ""; 
                if (e.target.transform.parent.transform.GetChild(0).GetComponent<TextMeshPro>().text == "SCHOENHAGEN")
                {
                    airportchosen = e.target;
                    e.target.transform.parent.transform.GetChild(0).GetComponent<TextMeshPro>().text = "SCHOENHAGEN, L�ngengrad: 100gdmb, Breitengrad: egnkg, Art: IFR-Flughafen";
                    e.target.transform.localScale += new Vector3(0.5f, 0.5f, 0.5f);
                    airport = "SCHOENHAGEN";
                }
            }
            

            // e.target.transform.parent.GetChild(0).text
            Debug.Log("Target:" + e.target.transform.parent.transform.GetChild(0).GetComponent<TextMeshPro>().text);
            Debug.Log("Target:" + e.target);
            Debug.Log("Parent:" + e.target.transform.parent);
            Debug.Log("Airport was clicked");
        }
    }

    public void PointerInside(object sender, PointerEventArgs e)
    {
        if (e.target.name == "CubeNot")
        {
            Debug.Log("Cube was entered");
        }
        else if (e.target.name == "Button")
        {
            Debug.Log("Button was entered");
        }
        else if (e.target.name == "Cube")
        {
            Debug.Log("Airport was entered");
        }
    }

    public void PointerOutside(object sender, PointerEventArgs e)
    {
        if (e.target.name == "CubeNot")
        {
            Debug.Log("Cube was exited");
        }
        else if (e.target.name == "Button")
        {
            Debug.Log("Button was exited");
        }
        else if (e.target.name == "Cube")
        {
            Debug.Log("Airport was exited");
        }
    }
}