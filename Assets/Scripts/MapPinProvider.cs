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
    private MapPin _airportPinPrefab = null;

    [SerializeField]
    private MapPin _waypointPinPrefab = null;

    //[SerializeField]
    //private TextAsset _mapPinLocationsCsv = null;

    [SerializeField]
    private TextAsset _airportJsonFile = null;

    [SerializeField]
    private TextAsset[] _navaidJsonFiles = null;

    [SerializeField]
    private TextAsset[] _airspacesJsonFiles = null;

    private void Awake()
    {
        Debug.Assert(_mapPinLayer != null);
        Debug.Assert(_airportPinPrefab != null);
        Debug.Assert(_waypointPinPrefab != null);
        Debug.Assert(_airportJsonFile != null);
        //StartCoroutine(LoadMapPinsFromCsv());
        StartCoroutine(LoadAirportPinsFromJson());
        StartCoroutine(LoadWaypointPinsFromJson());
    }

    //IEnumerator LoadAirspacesFromJson()
    //{

    //}

    IEnumerator LoadWaypointPinsFromJson()
    {
        _waypointPinPrefab.gameObject.SetActive(false);

        var mapPinsCreatedThisFrame = new List<MapPin>();

        //If you want to remove certain navaids like every TACAN you can search for it in the array and remove the file from it. Thus only the remaining jsons will be read

        for (int i = 0; i < _navaidJsonFiles.Length; i++)
        {
            Waypoint[] waypoints = JsonHelper.FromJson<Waypoint>(_navaidJsonFiles[i].text);

            for (int j = 0; j < waypoints.Length; j++)
            {
                var mapPin = Instantiate(_waypointPinPrefab);
                mapPin.Location =
                    new LatLon(
                        waypoints[j].geometry.coordinates[1],
                        waypoints[j].geometry.coordinates[0]
                        );
                //multiplied by 10 because i dont know ... they all just lay there on the ground and it makes me sad so i lifted them up to see them fly like little birds who can finally escape this fucking world
                mapPin.Altitude = waypoints[j].elevation.value * 10;
                mapPin.GetComponentInChildren<TextMeshPro>().text = waypoints[j].name;
                mapPinsCreatedThisFrame.Add(mapPin);
            }
            _mapPinLayer.MapPins.AddRange(mapPinsCreatedThisFrame);
            mapPinsCreatedThisFrame.Clear();

        }
        Debug.Log($"MapPin creation for waypoints complete.");
        yield return null;
    }

    IEnumerator LoadAirportPinsFromJson()
    {
        _airportPinPrefab.gameObject.SetActive(false);

        var mapPinsCreatedThisFrame = new List<MapPin>();

        Airport[] airports = JsonHelper.FromJson<Airport>(_airportJsonFile.text);

        for (int i = 0; i < airports.Length; i++)
        {
            var mapPin = Instantiate(_airportPinPrefab);
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

        Debug.Log($"MapPin creation for airports complete.");
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

}
