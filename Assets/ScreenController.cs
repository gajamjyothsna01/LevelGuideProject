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
       //StartCoroutine(GetRequest());
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

   
}
