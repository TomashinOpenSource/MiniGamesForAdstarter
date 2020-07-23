using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Net;

public class MainManager : MonoBehaviour
{
    public string country;
    public Text text;
    public IPManager IPManager;
    const string noCountry = "us";

    void Start()
    {
        if (Application.systemLanguage == SystemLanguage.Russian)
        {
            GoWeb();
        }
        else GoToGame();

        //IPManager.GetCountry((callbackText) =>
        //{
        //    country = callbackText;
        //    if (country == noCountry) GoToGame();
        //    else GoWeb();
        //});
    }
    
    private void GoToGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    private void GoWeb()
    {
        SceneManager.LoadScene("WebViewScene");
    }
}
