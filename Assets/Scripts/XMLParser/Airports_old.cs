using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Xml;

/*<message:hasMember>
		<aixm:AirportHeliport gml:id="ID_1fc07b0e-7c09-4784-b5a4-1e61280992dc-0">
			<gml:identifier codeSpace="urn:uuid:">1fc07b0e-7c09-4784-b5a4-1e61280992dc</gml:identifier>
			<aixm:timeSlice>
				<aixm:AirportHeliportTimeSlice gml:id="ID_TS_1fc07b0e-7c09-4784-b5a4-1e61280992dc-0">
					<gml:validTime>
						<gml:TimeInstant gml:id="ID_TS_VT_TI_1fc07b0e-7c09-4784-b5a4-1e61280992dc-0">
							<gml:timePosition>2023-06-15T00:00:00Z</gml:timePosition>
						</gml:TimeInstant>
					</gml:validTime>
					<aixm:interpretation>SNAPSHOT</aixm:interpretation>
					<aixm:featureLifetime>
						<gml:TimePeriod gml:id="ID_TS_FL_TP_1fc07b0e-7c09-4784-b5a4-1e61280992dc">
							<gml:beginPosition>2015-05-01T00:00:00Z</gml:beginPosition>
							<gml:endPosition indeterminatePosition="unknown"/>
						</gml:TimePeriod>
					</aixm:featureLifetime>
					<aixm:name>OSNABRUECK-ATTERHEIDE</aixm:name>
					<aixm:locationIndicatorICAO>EDWO</aixm:locationIndicatorICAO>
					<aixm:designatorIATA xsi:nil="true" nilReason="unknown"/>
					<aixm:type>AD</aixm:type>
					<aixm:controlType>CIVIL</aixm:controlType>
					<aixm:fieldElevation xsi:nil="true" uom="FT" nilReason="unknown"/>
					<aixm:verticalDatum>OTHER</aixm:verticalDatum>
					<aixm:magneticVariation>2</aixm:magneticVariation>
					<aixm:magneticVariationAccuracy xsi:nil="true" nilReason="unknown"/>
					<aixm:dateMagneticVariation>2014</aixm:dateMagneticVariation>
					<aixm:magneticVariationChange xsi:nil="true" nilReason="unknown"/>
					<aixm:referenceTemperature xsi:nil="true" uom="C" nilReason="unknown"/>
					<aixm:transitionAltitude xsi:nil="true" nilReason="unknown"/>
					<aixm:transitionLevel xsi:nil="true" nilReason="unknown"/>
					<aixm:lowestTemperature xsi:nil="true" nilReason="unknown"/>
					<aixm:abandoned>NO</aixm:abandoned>
					<aixm:certificationDate xsi:nil="true" nilReason="unknown"/>
					<aixm:certificationExpirationDate xsi:nil="true" nilReason="unknown"/>
					<aixm:servedCity>
						<aixm:City gml:id="ID_TS_C_1fc07b0e-7c09-4784-b5a4-1e61280992dc-0">
							<aixm:name>OSNABRUECK</aixm:name>
						</aixm:City>
					</aixm:servedCity>
					<aixm:responsibleOrganisation nilReason="unknown" xsi:nil="true"/>
					<aixm:ARP>
						<aixm:ElevatedPoint gml:id="ID_TS_1fc07b0e-7c09-4784-b5a4-1e61280992dc-0-0" srsName="urn:ogc:def:crs:EPSG::4326">
							<gml:pos>52.286373999 7.973257849</gml:pos>
							<aixm:horizontalAccuracy xsi:nil="true" nilReason="unknown"/>
							<aixm:elevation uom="FT">287.0</aixm:elevation>
							<aixm:geoidUndulation xsi:nil="true" nilReason="unknown"/>
							<aixm:verticalDatum>EGM_96</aixm:verticalDatum>
							<aixm:verticalAccuracy xsi:nil="true" nilReason="unknown"/>
						</aixm:ElevatedPoint>
					</aixm:ARP>
					<aixm:contact>
						<aixm:ContactInformation gml:id="ID_TS_C_1fc07b0e-7c09-4784-b5a4-1e61280992dc">
							<aixm:name>AERO-CLUB OSNABRUECK E.V.</aixm:name>
							<aixm:address>
								<aixm:PostalAddress gml:id="ID_TS_C_A_1fc07b0e-7c09-4784-b5a4-1e61280992dc-10">
									<aixm:deliveryPoint>Zum Flugplaz 83, 49076 Osnabrück</aixm:deliveryPoint>
									<aixm:city xsi:nil="true" nilReason="unknown"/>
									<aixm:postalCode xsi:nil="true" nilReason="unknown"/>
									<aixm:country xsi:nil="true" nilReason="unknown"/>
								</aixm:PostalAddress>
							</aixm:address>
							<aixm:phoneFax>
								<aixm:TelephoneContact gml:id="ID_TS_C_TC_1fc07b0e-7c09-4784-b5a4-1e61280992dc">
									<aixm:annotation>
										<aixm:Note gml:id="ID_TS_C_TC_N_1fc07b0e-7c09-4784-b5a4-1e61280992dc-0">
											<aixm:propertyName>voice</aixm:propertyName>
											<aixm:purpose>REMARK</aixm:purpose>
											<aixm:translatedNote>
												<aixm:LinguisticNote gml:id="ID_TS_C_TC_N_LN_1fc07b0e-7c09-4784-b5a4-1e61280992dc-0">
													<aixm:note>+49 541 125240 
+49 541 125240 OPS 
+49 541 128999 OPS
+49 171 4153768 OPS (PPR)
</aixm:note>
												</aixm:LinguisticNote>
											</aixm:translatedNote>
										</aixm:Note>
									</aixm:annotation>
									<aixm:annotation>
										<aixm:Note gml:id="ID_TS_C_TC_N_1fc07b0e-7c09-4784-b5a4-1e61280992dc-1">
											<aixm:propertyName>facsimile</aixm:propertyName>
											<aixm:purpose>REMARK</aixm:purpose>
											<aixm:translatedNote>
												<aixm:LinguisticNote gml:id="ID_TS_C_TC_N_LN_1fc07b0e-7c09-4784-b5a4-1e61280992dc-1">
													<aixm:note>+49 541 128909 OPS
</aixm:note>
												</aixm:LinguisticNote>
											</aixm:translatedNote>
										</aixm:Note>
									</aixm:annotation>
								</aixm:TelephoneContact>
							</aixm:phoneFax>
						</aixm:ContactInformation>
					</aixm:contact>
					<aixm:availability>
						<aixm:AirportHeliportAvailability gml:id="ID_TS_AHA_1fc07b0e-7c09-4784-b5a4-1e61280992dc-0">
							<aixm:timeInterval>
								<aixm:Timesheet gml:id="ID_TS_AHA_TS_1fc07b0e-7c09-4784-b5a4-1e61280992dc-0-0">
									<aixm:timeReference>UTC</aixm:timeReference>
									<aixm:startDate>SDLST</aixm:startDate>
									<aixm:endDate>EDLST</aixm:endDate>
									<aixm:day>ANY</aixm:day>
									<aixm:dayTil xsi:nil="true" nilReason="unknown"/>
									<aixm:startTime>07:00</aixm:startTime>
									<aixm:startEvent xsi:nil="true" nilReason="unknown"/>
									<aixm:startTimeRelativeEvent xsi:nil="true" uom="MIN" nilReason="unknown"/>
									<aixm:startEventInterpretation xsi:nil="true" nilReason="unknown"/>
									<aixm:endTime>18:00</aixm:endTime>
									<aixm:endEvent>SS</aixm:endEvent>
									<aixm:endTimeRelativeEvent xsi:nil="true" uom="MIN" nilReason="unknown"/>
									<aixm:endEventInterpretation>EARLIEST</aixm:endEventInterpretation>
									<aixm:daylightSavingAdjust xsi:nil="true" nilReason="unknown"/>
									<aixm:excluded xsi:nil="true" nilReason="unknown"/>
									<aixm:annotation>
										<aixm:Note gml:id="ID_TS_TMS_N_257-3123">
											<aixm:purpose>REMARK</aixm:purpose>
											<aixm:translatedNote>
												<aixm:LinguisticNote gml:id="ID_TS_TMS_N_LN_257-3123">
													<aixm:note>O/T PPR</aixm:note>
												</aixm:LinguisticNote>
											</aixm:translatedNote>
										</aixm:Note>
									</aixm:annotation>
								</aixm:Timesheet>
							</aixm:timeInterval>
							<aixm:timeInterval>
								<aixm:Timesheet gml:id="ID_TS_AHA_TS_1fc07b0e-7c09-4784-b5a4-1e61280992dc-0-1">
									<aixm:timeReference>UTC</aixm:timeReference>
									<aixm:startDate>EDLST</aixm:startDate>
									<aixm:endDate>SDLST</aixm:endDate>
									<aixm:day>ANY</aixm:day>
									<aixm:dayTil xsi:nil="true" nilReason="unknown"/>
									<aixm:startTime>09:00</aixm:startTime>
									<aixm:startEvent xsi:nil="true" nilReason="unknown"/>
									<aixm:startTimeRelativeEvent xsi:nil="true" uom="MIN" nilReason="unknown"/>
									<aixm:startEventInterpretation xsi:nil="true" nilReason="unknown"/>
									<aixm:endTime xsi:nil="true" nilReason="unknown"/>
									<aixm:endEvent>SS</aixm:endEvent>
									<aixm:endTimeRelativeEvent xsi:nil="true" uom="MIN" nilReason="unknown"/>
									<aixm:endEventInterpretation xsi:nil="true" nilReason="unknown"/>
									<aixm:daylightSavingAdjust xsi:nil="true" nilReason="unknown"/>
									<aixm:excluded xsi:nil="true" nilReason="unknown"/>
									<aixm:annotation>
										<aixm:Note gml:id="ID_TS_TMS_N_257-3124">
											<aixm:purpose>REMARK</aixm:purpose>
											<aixm:translatedNote>
												<aixm:LinguisticNote gml:id="ID_TS_TMS_N_LN_257-3124">
													<aixm:note>O/T PPR</aixm:note>
												</aixm:LinguisticNote>
											</aixm:translatedNote>
										</aixm:Note>
									</aixm:annotation>
								</aixm:Timesheet>
							</aixm:timeInterval>
							<aixm:annotation>
								<aixm:Note gml:id="ID_TS_AHA_N_1fc07b0e-7c09-4784-b5a4-1e61280992dc-0-0">
									<aixm:propertyName>usage</aixm:propertyName>
									<aixm:purpose>REMARK</aixm:purpose>
									<aixm:translatedNote>
										<aixm:LinguisticNote gml:id="ID_TS_AHA_N_LN_1fc07b0e-7c09-4784-b5a4-1e61280992dc-0-0">
											<aixm:note>5700 kg, HEL 5700 kg, GLD (P), UL PPR</aixm:note>
										</aixm:LinguisticNote>
									</aixm:translatedNote>
								</aixm:Note>
							</aixm:annotation>
							<aixm:operationalStatus>NORMAL</aixm:operationalStatus>
							<aixm:warning xsi:nil="true" nilReason="unknown"/>
							<aixm:usage>
								<aixm:AirportHeliportUsage gml:id="ID_TS_AHA_AHU_1fc07b0e-7c09-4784-b5a4-1e61280992dc-0-417">
									<aixm:type>PERMIT</aixm:type>
									<aixm:selection>
										<aixm:ConditionCombination gml:id="ID_TS_AHA_AHU_CC_1fc07b0e-7c09-4784-b5a4-1e61280992dc-0-417-510">
											<aixm:logicalOperator>NONE</aixm:logicalOperator>
											<aixm:flight>
												<aixm:FlightCharacteristic gml:id="ID_TS_AHA_AHU_CC_FC_1fc07b0e-7c09-4784-b5a4-1e61280992dc-0-417-510-43">
													<aixm:type>OTHER</aixm:type>
													<aixm:rule>VFR</aixm:rule>
													<aixm:status>OTHER</aixm:status>
													<aixm:military>CIVIL</aixm:military>
													<aixm:origin xsi:nil="true" nilReason="unknown"/>
													<aixm:purpose xsi:nil="true" nilReason="unknown"/>
												</aixm:FlightCharacteristic>
											</aixm:flight>
										</aixm:ConditionCombination>
									</aixm:selection>
								</aixm:AirportHeliportUsage>
							</aixm:usage>
							<aixm:usage>
								<aixm:AirportHeliportUsage gml:id="ID_TS_AHA_AHU_1fc07b0e-7c09-4784-b5a4-1e61280992dc-0-920">
									<aixm:type>OTHER</aixm:type>
									<aixm:selection>
										<aixm:ConditionCombination gml:id="ID_TS_AHA_AHU_CC_1fc07b0e-7c09-4784-b5a4-1e61280992dc-0-920-1077">
											<aixm:logicalOperator>NONE</aixm:logicalOperator>
											<aixm:flight>
												<aixm:FlightCharacteristic gml:id="ID_TS_AHA_AHU_CC_FC_1fc07b0e-7c09-4784-b5a4-1e61280992dc-0-920-1077-427">
													<aixm:type>OTHER</aixm:type>
													<aixm:rule>OTHER:NVFR</aixm:rule>
													<aixm:status>OTHER</aixm:status>
													<aixm:military>CIVIL</aixm:military>
													<aixm:origin xsi:nil="true" nilReason="unknown"/>
													<aixm:purpose xsi:nil="true" nilReason="unknown"/>
												</aixm:FlightCharacteristic>
											</aixm:flight>
										</aixm:ConditionCombination>
									</aixm:selection>
								</aixm:AirportHeliportUsage>
							</aixm:usage>
						</aixm:AirportHeliportAvailability>
					</aixm:availability>
					<aixm:annotation>
						<aixm:Note gml:id="ID_TS_N_1fc07b0e-7c09-4784-b5a4-1e61280992dc-1">
							<aixm:propertyName>ARP</aixm:propertyName>
							<aixm:purpose>REMARK</aixm:purpose>
							<aixm:translatedNote>
								<aixm:LinguisticNote gml:id="ID_TS_N_LN_1fc07b0e-7c09-4784-b5a4-1e61280992dc-1">
									<aixm:note>ARP site at AD: no data, Direction and distance from (city): 2.7 NM W Osnabrück</aixm:note>
								</aixm:LinguisticNote>
							</aixm:translatedNote>
						</aixm:Note>
					</aixm:annotation>
					<aixm:annotation>
						<aixm:Note gml:id="ID_TS_N_1fc07b0e-7c09-4784-b5a4-1e61280992dc-2">
							<aixm:propertyName>type</aixm:propertyName>
							<aixm:purpose>REMARK</aixm:purpose>
							<aixm:translatedNote>
								<aixm:LinguisticNote gml:id="ID_TS_N_LN_1fc07b0e-7c09-4784-b5a4-1e61280992dc-2">
									<aixm:note>Airfield Civil</aixm:note>
								</aixm:LinguisticNote>
							</aixm:translatedNote>
						</aixm:Note>
					</aixm:annotation>
					<aixm:annotation>
						<aixm:Note gml:id="ID_TS_N_1fc07b0e-7c09-4784-b5a4-1e61280992dc-3">
							<aixm:propertyName>ARP</aixm:propertyName>
							<aixm:purpose>REMARK</aixm:purpose>
							<aixm:translatedNote>
								<aixm:LinguisticNote gml:id="ID_TS_N_LN_1fc07b0e-7c09-4784-b5a4-1e61280992dc-3">
									<aixm:note>State of the Airport/Heliport based on the ARP: Niedersachsen</aixm:note>
								</aixm:LinguisticNote>
							</aixm:translatedNote>
						</aixm:Note>
					</aixm:annotation>
				</aixm:AirportHeliportTimeSlice>
			</aixm:timeSlice>
		</aixm:AirportHeliport>
	</message:hasMember>*/

[System.Serializable]
//public class Airport
//{
//    public string airport;
//    public string city;
//    //public string state; //wenn wir es brauchen, kann ich es hinzufügen
//    //public string airportType;
//    public string icaoCode;
//    public string iataCode;
//    public string flightRule;
//    public string controlType;
//    public string longitude;
//    public string latitude;
//}

public class Airports_old : MonoBehaviour
{
    //public static Airports instanz;
    //public List<Airport> airportList;

    //void Start()
    //{
    //    instanz = this;
    //    //action if XML exists
    //    string filePath = Path.Combine(Application.dataPath, "Data/airports.xml");
    //    if (File.Exists(filePath))
    //    {
    //        ReadXML(filePath);
    //        print("Found Airports");
    //    }
    //    else
    //    {
    //        Debug.LogError("XML file airports not found!");
    //    }
    //}
    //private void ReadXML(string filePath)
    //{
    //    //new List of Waypoints
    //    airportList = new List<Airport>();

    //    //loads XML
    //    XmlDocument xmlDoc = new XmlDocument();
    //    xmlDoc.Load(filePath);
    //    XmlNamespaceManager namespaceManager = new XmlNamespaceManager(xmlDoc.NameTable);
    //    namespaceManager.AddNamespace("aixm", "http://www.aixm.aero/schema/5.1.1");
    //    namespaceManager.AddNamespace("gml", "http://www.opengis.net/gml/3.2");

    //    //Get List of Designated Points
    //    XmlNodeList aiportNodes = xmlDoc.SelectNodes("//aixm:AirportHeliport", namespaceManager);

    //    //Transforms each Waypoint
    //    foreach (XmlNode node in aiportNodes)
    //    {
    //        Airport airport = new Airport();
    //        //Name
    //        XmlNode nameNode = node.SelectSingleNode("aixm:timeSlice/aixm:AirportHeliportTimeSlice/aixm:name", namespaceManager);
    //        if (nameNode != null)
    //        {
    //            string type = nameNode.InnerText;
    //            airport.airport = type;
    //        }
    //        else
    //        {
    //            Debug.LogWarning("Airport Name not found in Airport node.");
    //        }
    //        //ICAO
    //        XmlNode icaoNode = node.SelectSingleNode("aixm:timeSlice/aixm:AirportHeliportTimeSlice/aixm:locationIndicatorICAO", namespaceManager);
    //        if (icaoNode != null)
    //        {
    //            string type = icaoNode.InnerText;
    //            airport.icaoCode = type;
    //        }
    //        else
    //        {
    //            Debug.LogWarning("Airport ICAO not found in Airport node.");
    //        }
    //        //IATA
    //        XmlNode iataNode = node.SelectSingleNode("aixm:timeSlice/aixm:AirportHeliportTimeSlice/aixm:designatorIATA", namespaceManager);
    //        if (iataNode != null)
    //        {
    //            string type = iataNode.InnerText;
    //            airport.iataCode = type;
    //        }
    //        else
    //        {
    //            Debug.LogWarning("Airport IATA not found in Airport node.");
    //        }
    //        //Control Type
    //        XmlNode controlNode = node.SelectSingleNode("aixm:timeSlice/aixm:AirportHeliportTimeSlice/aixm:controlType", namespaceManager);
    //        if (controlNode != null)
    //        {
    //            string type = controlNode.InnerText;
    //            airport.controlType = type;
    //        }
    //        else
    //        {
    //            Debug.LogWarning("Airport Control Type not found in Airport node.");
    //        }
    //        //City
    //        XmlNode cityNode = node.SelectSingleNode("aixm:timeSlice/aixm:AirportHeliportTimeSlice/aixm:servedCity/aixm:City/aixm:name", namespaceManager);
    //        if (cityNode != null)
    //        {
    //            string type = cityNode.InnerText;
    //            airport.city = type;
    //        }
    //        else
    //        {
    //            Debug.LogWarning("Airport City not found in Airport node.");
    //        }
    //        //Position
    //        XmlNode positionNode = node.SelectSingleNode("aixm:timeSlice/aixm:AirportHeliportTimeSlice/aixm:ARP/aixm:ElevatedPoint/gml:pos", namespaceManager);
    //        if (positionNode != null)
    //        {
    //            string pos = positionNode.InnerText;
    //            string[] posParts = pos.Split(' ');

    //            if (posParts.Length == 2)
    //            {
    //                airport.latitude = posParts[0];
    //                airport.longitude = posParts[1];
    //            }
    //            else
    //            {
    //                Debug.LogWarning("Invalid position format in Airports.");
    //            }
    //        }
    //        else
    //        {
    //            Debug.LogWarning("Airport Position not found in Airport node.");
    //        }
    //        //FlightRule
    //        XmlNode ruleNode = node.SelectSingleNode("aixm:timeSlice/aixm:AirportHeliportTimeSlice/aixm:availability/aixm:AirportHeliportAvailability/aixm:usage/aixm:AirportHeliportUsage/aixm:selection/aixm:ConditionCombination/aixm:flight/aixm:FlightCharacteristic/aixm:rule", namespaceManager);
    //        if (ruleNode != null)
    //        {
    //            string type = ruleNode.InnerText;
    //            airport.flightRule = type;
    //        }
    //        else
    //        {
    //            Debug.LogWarning("Airport Rule not found in Airport node. (this usually happens since not every Airport seems to have a flight rule)");
    //        }
          

    //        airportList.Add(airport);
    //    }
    //}

}
