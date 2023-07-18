using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Airport
{
    public string name;
    public string icaoCode;
    public int type;
    public Geometry geometry;
}

[System.Serializable]
public class Geometry
{
    public string type;
    public List<double> coordinates;
}
