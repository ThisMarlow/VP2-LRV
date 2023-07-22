using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Geometry
{
    public string type;
    public List<double> coordinates;
}

[System.Serializable]
public class Elevation
{
    public int value;
    public int unit;
}