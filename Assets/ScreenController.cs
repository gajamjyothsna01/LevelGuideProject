using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class ScreenController : MonoBehaviour
{
    public static string keyword;


    void Start()
    {
       StartCoroutine(GetRequest());
    }
    // Start is called before the first frame update
   

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void GoNextScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);

    }
    public void KeywordForGoogle(string keywordName)
    {
        keyword = keywordName;
        Debug.Log(keyword);
      //  string url = "https://github.com/OAI/OpenAPI-Specification/blob/main/examples/v3.0/link-example.json";
      // StartCoroutine(GetRequest());
    }
   /*void Start()
    {
        // A correct website page.
        StartCoroutine(GetRequest("https://www.example.com"));

        // A non-existing page.
        StartCoroutine(GetRequest("https://error.html"));
    }*/

    IEnumerator GetRequest()
    {
        string uri = "https://bit.ly/3iPzhoD";
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            Debug.Log("Incoroutine Function");
            yield return webRequest.SendWebRequest();
            Debug.Log("Sent Request Done");

            //string[] pages = uri.Split('/');
            //int page = pages.Length - 1;

            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                   Debug.LogError(/*pages[page] */ ": Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.ProtocolError:
                    Debug.LogError(/*pages[page] */ ": HTTP Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.Success:
                    Debug.Log(/*pages[page] +*/ ":\nReceived: " + webRequest.downloadHandler.text);
                    break;
            }
        }
    }
}
