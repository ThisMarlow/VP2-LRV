using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Airspace
{
    public string name;
    public Geometry geometry;
    public Elevation upperLimit;
    public Elevation lowerLimit;
}
