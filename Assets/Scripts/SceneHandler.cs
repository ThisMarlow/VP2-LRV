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
    public Material selected_airport_mat;
    public Material default_airport_mat;

    public Material selected_waypoint_mat;
    public Material default_waypoint_mat;

    public SteamVR_LaserPointer laserPointer;
    private string airport = "";
    private GameObject airportchosen;
    private GameObject prev_airportchosen;
    private string waypoint = "";
    private GameObject waypointchosen;
    private GameObject prev_waypointchosen;

    void Awake()
    {
        laserPointer.PointerIn += PointerInside;
        laserPointer.PointerOut += PointerOutside;
        laserPointer.PointerClick += PointerClick;
    }

    public void PointerClick(object sender, PointerEventArgs e)
    {
        if(prev_airportchosen != null && prev_airportchosen != e.target.gameObject)
        {
            prev_airportchosen.GetComponent<MeshRenderer>().material = default_airport_mat;
        }
        if(prev_waypointchosen != null && prev_waypointchosen != waypointchosen)
        {
            prev_waypointchosen.GetComponent<MeshRenderer>().material = default_waypoint_mat;
        }

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
                    airportchosen = e.target.gameObject;
                    e.target.transform.parent.transform.GetChild(0).GetComponent<TextMeshPro>().text = "SCHOENHAGEN, Längengrad: 52.203888888889, Breitengrad: 13.16, Art: VFR- und IFR-Flughafen, Landebahnen: 6";
                    e.target.transform.localScale += new Vector3(0.5f, 0.5f, 0.5f);
                    airport = "SCHOENHAGEN";
                }
                if (e.target.transform.parent.transform.GetChild(0).GetComponent<TextMeshPro>().text == "MAGDEBURG-CITY")
                {
                    airportchosen = e.target.gameObject;
                    e.target.transform.parent.transform.GetChild(0).GetComponent<TextMeshPro>().text = "MAGDEBURG-CITY, Längengrad: 52.0736, Breitengrad: 11.6264, Art: VFR- und IFR-Flughafen, Landebahnen: 4";
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
                    airportchosen = e.target.gameObject;
                    e.target.transform.parent.transform.GetChild(0).GetComponent<TextMeshPro>().text = "MAGDEBURG-CITY, Längengrad: 52.0736, Breitengrad: 11.6264, Art: VFR- und IFR-Flughafen, Landebahnen: 4";
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
                    airportchosen = e.target.gameObject;
                    e.target.transform.parent.transform.GetChild(0).GetComponent<TextMeshPro>().text = "SCHOENHAGEN, Längengrad: 52.203888888889, Breitengrad: 13.16, Art: VFR- und IFR-Flughafen, Landebahnen: 6";
                    e.target.transform.localScale += new Vector3(0.5f, 0.5f, 0.5f);
                    airport = "SCHOENHAGEN";
                }
            }

            airportchosen.GetComponent<MeshRenderer>().material = selected_airport_mat;

            // e.target.transform.parent.GetChild(0).text
            Debug.Log("Target:" + e.target.transform.parent.transform.GetChild(0).GetComponent<TextMeshPro>().text);
            Debug.Log("Target:" + e.target);
            Debug.Log("Parent:" + e.target.transform.parent);
            Debug.Log("Airport was clicked");
            prev_airportchosen = airportchosen;
        }

        else if (e.target.name == "Sphere")
        {
            if (waypoint == "")
            {
                if (e.target.transform.parent.transform.GetChild(1).GetComponent<TextMeshPro>().text == "HEHLINGEN")
                {
                    waypointchosen = e.target.gameObject;
                    e.target.transform.parent.transform.GetChild(1).GetComponent<TextMeshPro>().text = "HEHLINGEN, Längengrad: 52.3633346558, Breitengrad: 10.7952775955, Typ: DVOR-DME, Distanz: 80 NM";
                    e.target.transform.localScale += new Vector3(0.5f, 0.5f, 0.5f);
                    waypoint = "HEHLINGEN";
                }
                if (e.target.transform.parent.transform.GetChild(1).GetComponent<TextMeshPro>().text == "MAGDEBURG")
                {
                    waypointchosen = e.target.gameObject;
                    e.target.transform.parent.transform.GetChild(1).GetComponent<TextMeshPro>().text = "MAGDEBURG, Längengrad: 51.9949989319, Breitengrad: 11.7944440842, Typ: VOR-DME, Distanz: 80 NM";
                    e.target.transform.localScale += new Vector3(0.5f, 0.5f, 0.5f);
                    waypoint = "MAGDEBURG";
                }
                if (e.target.transform.parent.transform.GetChild(1).GetComponent<TextMeshPro>().text == "GOTEM")
                {
                    waypointchosen = e.target.gameObject;
                    e.target.transform.parent.transform.GetChild(1).GetComponent<TextMeshPro>().text = "GOTEM, Längengrad: 51.3430557251, Breitengrad: 11.5974998474, Typ: DVOR-DME, Distanz: 60 NM";
                    e.target.transform.localScale += new Vector3(0.5f, 0.5f, 0.5f);
                    waypoint = "GOTEM";
                }
                if (e.target.transform.parent.transform.GetChild(1).GetComponent<TextMeshPro>().text == "LEIPZIG")
                {
                    waypointchosen = e.target.gameObject;
                    e.target.transform.parent.transform.GetChild(1).GetComponent<TextMeshPro>().text = "LEIPZIG, Längengrad: 51.436111111111, Breitengrad: 12.473611111111, Typ: DVOR-DME, Distanz: 80 NM";
                    e.target.transform.localScale += new Vector3(0.5f, 0.5f, 0.5f);
                    waypoint = "LEIPZIG";
                }
                if (e.target.transform.parent.transform.GetChild(1).GetComponent<TextMeshPro>().text == "HOLZDORF")
                {
                    waypointchosen = e.target.gameObject;
                    e.target.transform.parent.transform.GetChild(1).GetComponent<TextMeshPro>().text = "HOLZDORF, Längengrad: 51.766666666667, Breitengrad: 13.198333333333, Typ: TACAN, Distanz: N/A";
                    e.target.transform.localScale += new Vector3(0.5f, 0.5f, 0.5f);
                    waypoint = "HOLZDORF";
                }
            }
            else if (waypoint == "HEHLINGEN")
            {
                waypointchosen.transform.parent.transform.GetChild(1).GetComponent<TextMeshPro>().text = "HEHLINGEN";
                waypointchosen.transform.localScale -= new Vector3(0.5f, 0.5f, 0.5f);
                waypoint = "";
                if (e.target.transform.parent.transform.GetChild(1).GetComponent<TextMeshPro>().text == "MAGDEBURG")
                {
                    waypointchosen = e.target.gameObject;
                    e.target.transform.parent.transform.GetChild(1).GetComponent<TextMeshPro>().text = "MAGDEBURG, Längengrad: 51.9949989319, Breitengrad: 11.7944440842, Typ: VOR-DME, Distanz: 80 NM";
                    e.target.transform.localScale += new Vector3(0.5f, 0.5f, 0.5f);
                    waypoint = "MAGDEBURG";
                }
                if (e.target.transform.parent.transform.GetChild(1).GetComponent<TextMeshPro>().text == "GOTEM")
                {
                    waypointchosen = e.target.gameObject;
                    e.target.transform.parent.transform.GetChild(1).GetComponent<TextMeshPro>().text = "GOTEM, Längengrad: 51.3430557251, Breitengrad: 11.5974998474, Typ: DVOR-DME, Distanz: 60 NM";
                    e.target.transform.localScale += new Vector3(0.5f, 0.5f, 0.5f);
                    waypoint = "GOTEM";
                }
                if (e.target.transform.parent.transform.GetChild(1).GetComponent<TextMeshPro>().text == "LEIPZIG")
                {
                    waypointchosen = e.target.gameObject;
                    e.target.transform.parent.transform.GetChild(1).GetComponent<TextMeshPro>().text = "LEIPZIG, Längengrad: 51.436111111111, Breitengrad: 12.473611111111, Typ: DVOR-DME, Distanz: 80 NM";
                    e.target.transform.localScale += new Vector3(0.5f, 0.5f, 0.5f);
                    waypoint = "LEIPZIG";
                }
                if (e.target.transform.parent.transform.GetChild(1).GetComponent<TextMeshPro>().text == "HOLZDORF")
                {
                    waypointchosen = e.target.gameObject;
                    e.target.transform.parent.transform.GetChild(1).GetComponent<TextMeshPro>().text = "HOLZDORF, Längengrad: 51.766666666667, Breitengrad: 13.198333333333, Typ: TACAN, Distanz: N/A";
                    e.target.transform.localScale += new Vector3(0.5f, 0.5f, 0.5f);
                    waypoint = "HOLZDORF";
                }
            }
            else if (waypoint == "MAGDEBURG")
            {
                waypointchosen.transform.parent.transform.GetChild(1).GetComponent<TextMeshPro>().text = "MAGDEBURG";
                waypointchosen.transform.localScale -= new Vector3(0.5f, 0.5f, 0.5f);
                waypoint = "";
                if (e.target.transform.parent.transform.GetChild(1).GetComponent<TextMeshPro>().text == "HEHLINGEN")
                {
                    waypointchosen = e.target.gameObject;
                    e.target.transform.parent.transform.GetChild(1).GetComponent<TextMeshPro>().text = "HEHLINGEN, Längengrad: 52.3633346558, Breitengrad: 10.7952775955, Typ: DVOR-DME, Distanz: 80 NM";
                    e.target.transform.localScale += new Vector3(0.5f, 0.5f, 0.5f);
                    waypoint = "HEHLINGEN";
                }
                if (e.target.transform.parent.transform.GetChild(1).GetComponent<TextMeshPro>().text == "GOTEM")
                {
                    waypointchosen = e.target.gameObject;
                    e.target.transform.parent.transform.GetChild(1).GetComponent<TextMeshPro>().text = "GOTEM, Längengrad: 51.3430557251, Breitengrad: 11.5974998474, Typ: DVOR-DME, Distanz: 60 NM";
                    e.target.transform.localScale += new Vector3(0.5f, 0.5f, 0.5f);
                    waypoint = "GOTEM";
                }
                if (e.target.transform.parent.transform.GetChild(1).GetComponent<TextMeshPro>().text == "LEIPZIG")
                {
                    waypointchosen = e.target.gameObject;
                    e.target.transform.parent.transform.GetChild(1).GetComponent<TextMeshPro>().text = "LEIPZIG, Längengrad: 51.436111111111, Breitengrad: 12.473611111111, Typ: DVOR-DME, Distanz: 80 NM";
                    e.target.transform.localScale += new Vector3(0.5f, 0.5f, 0.5f);
                    waypoint = "LEIPZIG";
                }
                if (e.target.transform.parent.transform.GetChild(1).GetComponent<TextMeshPro>().text == "HOLZDORF")
                {
                    waypointchosen = e.target.gameObject;
                    e.target.transform.parent.transform.GetChild(1).GetComponent<TextMeshPro>().text = "HOLZDORF, Längengrad: 51.766666666667, Breitengrad: 13.198333333333, Typ: TACAN, Distanz: N/A";
                    e.target.transform.localScale += new Vector3(0.5f, 0.5f, 0.5f);
                    waypoint = "HOLZDORF";
                }
            }
            else if (waypoint == "GOTEM")
            {
                waypointchosen.transform.parent.transform.GetChild(1).GetComponent<TextMeshPro>().text = "GOTEM";
                waypointchosen.transform.localScale -= new Vector3(0.5f, 0.5f, 0.5f);
                waypoint = "";
                if (e.target.transform.parent.transform.GetChild(1).GetComponent<TextMeshPro>().text == "HEHLINGEN")
                {
                    waypointchosen = e.target.gameObject;
                    e.target.transform.parent.transform.GetChild(1).GetComponent<TextMeshPro>().text = "HEHLINGEN, Längengrad: 52.3633346558, Breitengrad: 10.7952775955, Typ: DVOR-DME, Distanz: 80 NM";
                    e.target.transform.localScale += new Vector3(0.5f, 0.5f, 0.5f);
                    waypoint = "HEHLINGEN";
                }
                if (e.target.transform.parent.transform.GetChild(1).GetComponent<TextMeshPro>().text == "MAGDEBURG")
                {
                    waypointchosen = e.target.gameObject;
                    e.target.transform.parent.transform.GetChild(1).GetComponent<TextMeshPro>().text = "MAGDEBURG, Längengrad: 51.9949989319, Breitengrad: 11.7944440842, Typ: VOR-DME, Distanz: 80 NM";
                    e.target.transform.localScale += new Vector3(0.5f, 0.5f, 0.5f);
                    waypoint = "MAGDEBURG";
                }
                if (e.target.transform.parent.transform.GetChild(1).GetComponent<TextMeshPro>().text == "LEIPZIG")
                {
                    waypointchosen = e.target.gameObject;
                    e.target.transform.parent.transform.GetChild(1).GetComponent<TextMeshPro>().text = "LEIPZIG, Längengrad: 51.436111111111, Breitengrad: 12.473611111111, Typ: DVOR-DME, Distanz: 80 NM";
                    e.target.transform.localScale += new Vector3(0.5f, 0.5f, 0.5f);
                    waypoint = "LEIPZIG";
                }
                if (e.target.transform.parent.transform.GetChild(1).GetComponent<TextMeshPro>().text == "HOLZDORF")
                {
                    waypointchosen = e.target.gameObject;
                    e.target.transform.parent.transform.GetChild(1).GetComponent<TextMeshPro>().text = "HOLZDORF, Längengrad: 51.766666666667, Breitengrad: 13.198333333333, Typ: TACAN, Distanz: N/A";
                    e.target.transform.localScale += new Vector3(0.5f, 0.5f, 0.5f);
                    waypoint = "HOLZDORF";
                }
            }
            else if (waypoint == "LEIPZIG")
            {
                waypointchosen.transform.parent.transform.GetChild(1).GetComponent<TextMeshPro>().text = "LEIPZIG";
                waypointchosen.transform.localScale -= new Vector3(0.5f, 0.5f, 0.5f);
                waypoint = "";
                if (e.target.transform.parent.transform.GetChild(1).GetComponent<TextMeshPro>().text == "HEHLINGEN")
                {
                    waypointchosen = e.target.gameObject;
                    e.target.transform.parent.transform.GetChild(1).GetComponent<TextMeshPro>().text = "HEHLINGEN, Längengrad: 52.3633346558, Breitengrad: 10.7952775955, Typ: DVOR-DME, Distanz: 80 NM";
                    e.target.transform.localScale += new Vector3(0.5f, 0.5f, 0.5f);
                    waypoint = "HEHLINGEN";
                }
                if (e.target.transform.parent.transform.GetChild(1).GetComponent<TextMeshPro>().text == "GOTEM")
                {
                    waypointchosen = e.target.gameObject;
                    e.target.transform.parent.transform.GetChild(1).GetComponent<TextMeshPro>().text = "GOTEM, Längengrad: 51.3430557251, Breitengrad: 11.5974998474, Typ: DVOR-DME, Distanz: 60 NM";
                    e.target.transform.localScale += new Vector3(0.5f, 0.5f, 0.5f);
                    waypoint = "GOTEM";
                }
                if (e.target.transform.parent.transform.GetChild(1).GetComponent<TextMeshPro>().text == "MAGDEBURG")
                {
                    waypointchosen = e.target.gameObject;
                    e.target.transform.parent.transform.GetChild(1).GetComponent<TextMeshPro>().text = "MAGDEBURG, Längengrad: 51.9949989319, Breitengrad: 11.7944440842, Typ: VOR-DME, Distanz: 80 NM";
                    e.target.transform.localScale += new Vector3(0.5f, 0.5f, 0.5f);
                    waypoint = "MAGDEBURG";
                }
                if (e.target.transform.parent.transform.GetChild(1).GetComponent<TextMeshPro>().text == "HOLZDORF")
                {
                    waypointchosen = e.target.gameObject;
                    e.target.transform.parent.transform.GetChild(1).GetComponent<TextMeshPro>().text = "HOLZDORF, Längengrad: 51.766666666667, Breitengrad: 13.198333333333, Typ: TACAN, Distanz: N/A";
                    e.target.transform.localScale += new Vector3(0.5f, 0.5f, 0.5f);
                    waypoint = "HOLZDORF";
                }
            }
            else if (waypoint == "HOLZDORF")
            {
                waypointchosen.transform.parent.transform.GetChild(1).GetComponent<TextMeshPro>().text = "HOLZDORF";
                waypointchosen.transform.localScale -= new Vector3(0.5f, 0.5f, 0.5f);
                waypoint = "";
                if (e.target.transform.parent.transform.GetChild(1).GetComponent<TextMeshPro>().text == "HEHLINGEN")
                {
                    waypointchosen = e.target.gameObject;
                    e.target.transform.parent.transform.GetChild(1).GetComponent<TextMeshPro>().text = "HEHLINGEN, Längengrad: 52.3633346558, Breitengrad: 10.7952775955, Typ: DVOR-DME, Distanz: 80 NM";
                    e.target.transform.localScale += new Vector3(0.5f, 0.5f, 0.5f);
                    waypoint = "HEHLINGEN";
                }
                if (e.target.transform.parent.transform.GetChild(1).GetComponent<TextMeshPro>().text == "GOTEM")
                {
                    waypointchosen = e.target.gameObject;
                    e.target.transform.parent.transform.GetChild(1).GetComponent<TextMeshPro>().text = "GOTEM, Längengrad: 51.3430557251, Breitengrad: 11.5974998474, Typ: DVOR-DME, Distanz: 60 NM";
                    e.target.transform.localScale += new Vector3(0.5f, 0.5f, 0.5f);
                    waypoint = "GOTEM";
                }
                if (e.target.transform.parent.transform.GetChild(1).GetComponent<TextMeshPro>().text == "LEIPZIG")
                {
                    waypointchosen = e.target.gameObject;
                    e.target.transform.parent.transform.GetChild(1).GetComponent<TextMeshPro>().text = "LEIPZIG, Längengrad: 51.436111111111, Breitengrad: 12.473611111111, Typ: DVOR-DME, Distanz: 80 NM";
                    e.target.transform.localScale += new Vector3(0.5f, 0.5f, 0.5f);
                    waypoint = "LEIPZIG";
                }
                if (e.target.transform.parent.transform.GetChild(1).GetComponent<TextMeshPro>().text == "MAGDEBURG")
                {
                    waypointchosen = e.target.gameObject;
                    e.target.transform.parent.transform.GetChild(1).GetComponent<TextMeshPro>().text = "MAGDEBURG, Längengrad: 51.9949989319, Breitengrad: 11.7944440842, Typ: VOR-DME, Distanz: 80 NM";
                    e.target.transform.localScale += new Vector3(0.5f, 0.5f, 0.5f);
                    waypoint = "MAGDEBURG";
                }
            }
            waypointchosen.GetComponent<MeshRenderer>().material = selected_waypoint_mat;
            prev_waypointchosen = waypointchosen;
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
        else if (e.target.name == "Sphere")
        {
            Debug.Log("Waypoint was entered");
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
        else if (e.target.name == "Sphere")
        {
            Debug.Log("Waypoint was exited");
        }
    }
}