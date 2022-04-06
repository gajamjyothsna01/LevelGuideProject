using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
//using Newtonsoft.Json.Converters;



public class ListTheContent : MonoBehaviour
{
    public string prefabName;

    // Start is called before the first frame update
    void Start()
    {
        if (ScreenController.keyword != null)
        {
            StartCoroutine(GetRequest());
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator GetRequest()
    {
        string uri = "https://bit.ly/3iPzhoD";
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            Debug.Log("Incoroutine Function");
            yield return webRequest.SendWebRequest();
            Debug.Log("Sent Request Done");

            string[] pages = uri.Split('/');
            int page = pages.Length - 1;

            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError(pages[page] + ": Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.ProtocolError:
                    Debug.LogError(pages[page] + ": HTTP Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.Success:
                    Debug.Log(pages[page] + ":\nReceived: " + webRequest.downloadHandler.text);
                    break;
            }
            CreateList(webRequest.downloadHandler.text);
        }
    }

    public void CreateList(string jsonString)
    {
        if (jsonString != null)
        {
            Root theContent = new Root();
            JsonConvert.PopulateObject(jsonString, theContent);
            if (theContent.results.Count != 0)
            {
                string Keyword = ScreenController.keyword;
                switch (Keyword)
                {
                    case "Park":
                        prefabName = "ParkDataList";
                        break;
                    case "School":
                        prefabName = "SchoolDataList";
                        break;
                    case "Hotel":
                        prefabName = "HotelDataList";
                        break;
                    case "Hospital":
                        prefabName = "HospitalDataList";
                        break;
                    default:
                        break;


                }

                for (int i = 0; i < theContent.results.Count; i++)
                {
                    GameObject thePrefab = Instantiate(Resources.Load("Assests/Prefabs/" + prefabName)) as GameObject;
                    GameObject contentHolder = GameObject.FindGameObjectWithTag("Content");
                    thePrefab.transform.parent = contentHolder.transform;
                    Text theText = thePrefab.GetComponentInChildren<Text>();
                    theText.text = theContent.results[i].name;
                    // GameObject contentHolder = GameObject.FindGameObjectsWithTag("Content");
                    //thePrefab.transform.parent = contentHolder.transform;
                    //Text theText = thePrefab

                    Debug.Log(theContent.results[i].name);
                }
            }
        }


        /*
        Debug.Log(theContent.results[0].name);
        Debug.Log(theContent.results[0].geometry.location.lat);
        Debug.Log(theContent.results[0].geometry.location.lng);*/
    }
}


// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
public class Location
{
    public double lat { get; set; }
    public double lng { get; set; }
}

public class Northeast
{
    public double lat { get; set; }
    public double lng { get; set; }
}

public class Southwest
{
    public double lat { get; set; }
    public double lng { get; set; }
}

public class Viewport
{
    public Northeast northeast { get; set; }
    public Southwest southwest { get; set; }
}

public class Geometry
{
    public Location location { get; set; }
    public Viewport viewport { get; set; }
}

public class OpeningHours
{
    public bool open_now { get; set; }
}

public class Photo
{
    public int height { get; set; }
    public List<string> html_attributions { get; set; }
    public string photo_reference { get; set; }
    public int width { get; set; }
}

public class PlusCode
{
    public string compound_code { get; set; }
    public string global_code { get; set; }
}

public class Result
{
    public Geometry geometry { get; set; }
    public string icon { get; set; }
    public string id { get; set; }
    public string name { get; set; }
    public OpeningHours opening_hours { get; set; }
    public List<Photo> photos { get; set; }
    public string place_id { get; set; }
    public PlusCode plus_code { get; set; }
    public double rating { get; set; }
    public string reference { get; set; }
    public string scope { get; set; }
    public List<string> types { get; set; }
    public string vicinity { get; set; }
}

public class Root
{
    public List<object> html_attributions { get; set; }
    public List<Result> results { get; set; }
    public string status { get; set; }
}


