// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Geospatial;
using Microsoft.Maps.Unity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using UnityEngine;
using System.IO;
using System.Xml;

/// <summary>
/// Adds <see cref="MapPin"/>s to the <see cref="MapPinLayer"/> based on the CSV file. Expected CSV file format is "Lat,Lon,Name,Type".
/// </summary>
public class MapPinProvider : MonoBehaviour
{
    [SerializeField]
    private MapPinLayer _mapPinLayer = null;

    [SerializeField]
    private MapPin _mapPinPrefab = null;

    //[SerializeField]
    //private TextAsset _mapPinLocationsCsv = null;

    [SerializeField]
    private TextAsset _airportJsonFile = null;

    private void Awake()
    {
        Debug.Assert(_mapPinLayer != null);
        Debug.Assert(_mapPinPrefab != null);
        Debug.Assert(_airportJsonFile != null);
        //StartCoroutine(LoadMapPinsFromCsv());
        StartCoroutine(LoadAirportPinsFromJson());
    }

    IEnumerator LoadAirportPinsFromJson()
    {
        _mapPinPrefab.gameObject.SetActive(false);

        var mapPinsCreatedThisFrame = new List<MapPin>();

        Airport[] airports = JsonHelper.FromJson<Airport>(_airportJsonFile.text);

        for (int i = 0; i < airports.Length; i++)
        {
            var mapPin = Instantiate(_mapPinPrefab);
            mapPin.Location =
                new LatLon(
                    airports[i].geometry.coordinates[1],
                    airports[i].geometry.coordinates[0]
                    );
            mapPin.GetComponentInChildren<TextMeshPro>().text = airports[i].name;
            mapPinsCreatedThisFrame.Add(mapPin);
        }

        _mapPinLayer.MapPins.AddRange(mapPinsCreatedThisFrame);
        mapPinsCreatedThisFrame.Clear();

        Debug.Log($"MapPin creation complete.");
        yield return null;
    }

    public static class JsonHelper
    {
        public static T[] FromJson<T>(string json)
        {
            Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(json);
            return wrapper.Items;
        }

        public static string ToJson<T>(T[] array)
        {
            Wrapper<T> wrapper = new Wrapper<T>();
            wrapper.Items = array;
            return JsonUtility.ToJson(wrapper);
        }

        public static string ToJson<T>(T[] array, bool prettyPrint)
        {
            Wrapper<T> wrapper = new Wrapper<T>();
            wrapper.Items = array;
            return JsonUtility.ToJson(wrapper, prettyPrint);
        }

        [Serializable]
        private class Wrapper<T>
        {
            public T[] Items;
        }
    }

    string fixJson(string value)
    {
        value = "{\"Items\":" + value + "}";
        return value;
    }

    //IEnumerator LoadMapPinsFromCsv()
    //{
    //    var startTime = Time.realtimeSinceStartup;
    //    var frameStartTime = startTime;

    //    var lines = _mapPinLocationsCsv.text.Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

    //    _mapPinPrefab.gameObject.SetActive(false);

    //    Debug.Log($"Creating MapPins ({lines.Length}) from {_mapPinLocationsCsv.name}...");

    //    // Generate a MapPin for each of the locations and add it to the layer.
    //    var numCreated = 0;
    //    var mapPinsCreatedThisFrame = new List<MapPin>(lines.Length);
    //    foreach (var csvLine in lines)
    //    {
    //        var csvEntries = csvLine.Split(',');

    //        var mapPin = Instantiate(_mapPinPrefab);
    //        mapPin.Location =
    //            new LatLon(
    //                double.Parse(csvEntries[0], NumberStyles.Number, CultureInfo.InvariantCulture),
    //                double.Parse(csvEntries[1], NumberStyles.Number, CultureInfo.InvariantCulture));

    //        mapPin.GetComponentInChildren<TextMeshPro>().text = csvEntries[2].ToLower() == "null" ? "" : csvEntries[2];
    //        mapPinsCreatedThisFrame.Add(mapPin);

    //        // yield occasionally to not block rendering.
    //        if (Time.realtimeSinceStartup - frameStartTime > 0.015f)
    //        {
    //            numCreated += mapPinsCreatedThisFrame.Count;

    //            _mapPinLayer.MapPins.AddRange(mapPinsCreatedThisFrame);
    //            mapPinsCreatedThisFrame.Clear();

    //            Debug.Log($"{numCreated}/{lines.Length} MapPins created.");

    //            yield return null;

    //            frameStartTime = Time.realtimeSinceStartup;
    //        }
    //    }

    //    _mapPinLayer.MapPins.AddRange(mapPinsCreatedThisFrame);
    //    mapPinsCreatedThisFrame.Clear();

    //    Debug.Log($"MapPin creation complete. ({Time.realtimeSinceStartup - startTime:F2}s)");
    //}

    //IEnumerator LoadAirportPinsFromXML()
    //{
    //    var startTime = Time.realtimeSinceStartup;
    //    var frameStartTime = startTime;

    //    _mapPinPrefab.gameObject.SetActive(false);

    //    ReadXML();

    //    // Generate a MapPin for each of the locations and add it to the layer.
    //    var numCreated = 0;
    //    var mapPinsCreatedThisFrame = new List<MapPin>(airportList.Count);


    //    foreach (Airport airport in airportList)
    //    {
    //        var mapPin = Instantiate(_mapPinPrefab);
    //        mapPin.Location =
    //            new LatLon(
    //                double.Parse(airport.latitude, NumberStyles.Number, CultureInfo.InvariantCulture),
    //                double.Parse(airport.longitude, NumberStyles.Number, CultureInfo.InvariantCulture));


    //        mapPin.GetComponentInChildren<TextMeshPro>().text = airport.city;
    //        mapPinsCreatedThisFrame.Add(mapPin);

    //        // yield occasionally to not block rendering.
    //        if (Time.realtimeSinceStartup - frameStartTime > 0.015f)
    //        {
    //            numCreated += mapPinsCreatedThisFrame.Count;

    //            _mapPinLayer.MapPins.AddRange(mapPinsCreatedThisFrame);
    //            mapPinsCreatedThisFrame.Clear();

    //            Debug.Log($"{numCreated}/{airportList.Count} MapPins created.");

    //            yield return null;

    //            frameStartTime = Time.realtimeSinceStartup;
    //        }
    //    }
    //}

    //private void ReadXML()
    //{
    //    //new List of Waypoints
    //    airportList = new List<Airport>();

    //    //loads XML
    //    XmlDocument xmlDoc = new XmlDocument();
    //    xmlDoc.Load(Path.Combine(Application.dataPath, "Data/airports.xml"));
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
