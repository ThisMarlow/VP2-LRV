using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Xml;

// was ist mir AngleIndication???
/*<message:hasMember>
		<aixm:DesignatedPoint gml:id="id.cda2f728-000a-4603-819e-381feac62076">
			<gml:identifier codeSpace="urn:uuid:">cda2f728-000a-4603-819e-381feac62076</gml:identifier>
			<aixm:timeSlice>
				<aixm:DesignatedPointTimeSlice gml:id="it.ts.cda2f728-000a-4603-819e-381feac62076">
					<gml:validTime>
						<gml:TimeInstant gml:id="id.vt.cda2f728-000a-4603-819e-381feac62076">
							<gml:timePosition>2023-06-15T00:00:00</gml:timePosition>
						</gml:TimeInstant>
					</gml:validTime>
					<aixm:interpretation>SNAPSHOT</aixm:interpretation>
					<aixm:featureLifetime>
						<gml:TimePeriod gml:id="is.ts.flt.cda2f728-000a-4603-819e-381feac62076">
							<gml:beginPosition>2015-05-01T00:00:00</gml:beginPosition>
							<gml:endPosition indeterminatePosition="unknown"/>
						</gml:TimePeriod>
					</aixm:featureLifetime>
					<aixm:designator>INDOK</aixm:designator> //designator
					<aixm:type>ICAO</aixm:type>
					<aixm:name>INDOK</aixm:name>
					<aixm:location>
						<aixm:Point gml:id="id.ts.pt.cda2f728-000a-4603-819e-381feac62076" srsName="urn:ogc:def:crs:EPSG::4326">
							<gml:pos>52.951505556 12.132191667</gml:pos>
							<aixm:horizontalAccuracy xsi:nil="true" nilReason="inapplicable"/>
						</aixm:Point>
					</aixm:location>
				</aixm:DesignatedPointTimeSlice>
			</aixm:timeSlice>
		</aixm:DesignatedPoint>
	</message:hasMember>*/

[System.Serializable]
public class Waypoint
{
    public string designator;
    public string waypointName;
    public string type;
    public int srid = 4326;
    public float latitude;
    public float longitude;
    //Todo: wenn wir es brauchen
    public string associatedAirport; 
    public string remark; 
}



public class Waypoints : MonoBehaviour
{
    public static Waypoints instanz;
    public List<Waypoint> waypointList;

    void Start()
    {
        instanz = this;
        //action if XML exists
        string filePath = Path.Combine(Application.dataPath, "Data/waypoints.xml");
        if (File.Exists(filePath))
        {
            ReadXML(filePath);
            print("Found Waypoints");
        }
        else
        {
            Debug.LogError("XML file waypoints not found!");
        }
    }

    private void ReadXML(string filePath)
    {
        //new List of Waypoints
        waypointList = new List<Waypoint>();
        
        //loads XML
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load(filePath);
        XmlNamespaceManager namespaceManager = new XmlNamespaceManager(xmlDoc.NameTable);
        namespaceManager.AddNamespace("aixm", "http://www.aixm.aero/schema/5.1.1");
        namespaceManager.AddNamespace("gml", "http://www.opengis.net/gml/3.2");

        //Get List of Designated Points
        XmlNodeList designatedPointNodes = xmlDoc.SelectNodes("//aixm:DesignatedPointTimeSlice", namespaceManager);

        //Transforms each Waypoint
        foreach (XmlNode node in designatedPointNodes)
        {
            Waypoint waypoint = new Waypoint();
            //type
            XmlNode typeNode = node.SelectSingleNode("aixm:type", namespaceManager);
            if (typeNode != null)
            {
                string type = typeNode.InnerText;
                waypoint.type = type;
            }
            else
            {
                Debug.LogWarning("Type node not found for DesignatedPoint node.");
            }
            //designator
            XmlNode designatorNode = node.SelectSingleNode("aixm:designator", namespaceManager);
            if (designatorNode != null)
            {
                string designator = designatorNode.InnerText;
                waypoint.designator = designator;
            }
            else
            {
                Debug.LogWarning("Designator node not found for DesignatedPoint node.");
            }
            //name
            XmlNode nameNode = node.SelectSingleNode("aixm:name", namespaceManager);
            if (nameNode != null)
            {
                string theNamne = nameNode.InnerText;
                waypoint.waypointName = theNamne;
            }
            else
            {
                Debug.LogWarning("Designator node not found for DesignatedPoint node.");
            }
            //position
            XmlNode positionNode = node.SelectSingleNode("aixm:location/aixm:Point/gml:pos", namespaceManager);
            if (positionNode != null)
            {
                string pos = positionNode.InnerText;
                string[] posParts = pos.Split(' ');

                if (posParts.Length == 2)
                {
                    waypoint.latitude = float.Parse(posParts[0]);
                    waypoint.longitude = float.Parse(posParts[1]);
                }
                else
                {
                    Debug.LogWarning("Invalid position format.");
                }
            }
            else
            {
                Debug.LogWarning("Designator node not found for DesignatedPoint node.");
            }


            waypointList.Add(waypoint);
        }
    }
}
