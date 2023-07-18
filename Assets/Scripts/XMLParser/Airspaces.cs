using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Windows;
using System.IO;
using System.Xml;


public class Airspaces : MonoBehaviour
{
    public static Airspaces instanz;
    public List<Airspace> AirspaceList { get; set; }
    

    // Start is called before the first frame update
    void Start()
    {
        instanz = this;

        //action if XML exists
        string filePath = Path.Combine(Application.dataPath, "Data/airspaces.xml");
        if (File.Exists(filePath))
        {
            ReadXML(filePath);
            print("Found Airspaces");
        }
        else
        {
            Debug.LogError("XML file airspaces not found!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ReadXML(string filepath)
    {
        AirspaceList = new List<Airspace>();

        //loads XML
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load(filepath);
        XmlNamespaceManager namespaceManager = new XmlNamespaceManager(xmlDoc.NameTable);
        namespaceManager.AddNamespace("aixm", "http://www.aixm.aero/schema/5.1.1");
        namespaceManager.AddNamespace("gml", "http://www.opengis.net/gml/3.2");

        XmlNodeList airspaceNodes = xmlDoc.SelectNodes("//aixm:AirspaceTimeSlice", namespaceManager);

        foreach (XmlNode node in airspaceNodes)
        {
            Airspace airspace = new Airspace();
            XmlNode searchNode;

            searchNode = node.SelectSingleNode("aixm:type", namespaceManager);
            if (searchNode != null)            
                airspace.Type = searchNode.InnerText;            
            else            
                Debug.LogWarning("Type node not found for Airspace node.");

            searchNode = node.SelectSingleNode("aixm:class", namespaceManager);
            if (searchNode != null)
                airspace.Classification = searchNode.FirstChild.FirstChild.InnerText;
            else
                Debug.LogWarning("Classification node not found for Airspace node.");

            searchNode = node.SelectSingleNode("aixm:designator", namespaceManager);
            if (searchNode != null)
                airspace.Designator = searchNode.InnerText;
            else
                Debug.LogWarning("Designator node not found for Airspace node.");

            searchNode = node.SelectSingleNode("aixm:name", namespaceManager);
            if (searchNode != null)
                airspace.Name = searchNode.InnerText;
            else
                Debug.LogWarning("Name node not found for Airspace node.");

            searchNode = node.SelectSingleNode("aixm:designatorICAO", namespaceManager);
            if (searchNode != null)
            {
                string icaoDes = searchNode.InnerText;
                airspace.ICAOdesignator = icaoDes.Contains("YES");
            }
            else
                Debug.LogWarning("ICAO Designator node not found for Airspace node.");



            AirspaceList.Add(airspace);
        }
    }
}

[System.Serializable]
public class Airspace
{
    public string Type { get; set; }
    public string Classification { get; set; }
    public string Designator { get; set; }
    public string Name { get; set; }
    public bool ICAOdesignator { get; set; }
    public AirspaceGeometry Geometry { get; set; }

}

[System.Serializable]
public class AirspaceGeometry
{
    public int UpperLimit { get; set; }
    public int LowerLimit { get; set; }
    public string UpperLimitRef { get; set; }
    public string LowerLimitRef { get; set; }
    public List<Point> Points { get; set; }
}

//Fuck that shit... i really can't be bothered dealing with this polygon shit!
//public class Segment
//{
//    public List<Point> Position { get; set; }
//}


//public class ArcSegment : Segment
//{
//    public double Radius { get; set; }
//    public double StartAngle { get; set; }
//    public double EndAngle { get; set; }
//}

//public class CircleSegment : Segment
//{
//    public double Radius { get; set; }
//}

public class Point
{
    public double Latitude { get; set; }
    public double Longitude { get; set; }
}