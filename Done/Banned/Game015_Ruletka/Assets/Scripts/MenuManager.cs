using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public string CheckCountryUrl;
    public string country;
    
    void Start()
    {
        StartCoroutine(GetRequest(CheckCountryUrl, (callback) =>
        {
            Debug.Log(callback);
            if (callback == country) BoostScene();
        }));
    }

    public void StartButtonPressed()
    {
        GameScene();
    }

    IEnumerator GetRequest(string url, Action<string> callback)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(url))
        {
            yield return webRequest.SendWebRequest();
            callback(webRequest.downloadHandler.text);
        }
    }

    #region SceneManager - MenuScene(), WebViewScene(), GameScene(), BoostScene()
    private void MenuScene()
    {
        SceneManager.LoadScene("MenuScene");
    }

    private void WebViewScene()
    {
        SceneManager.LoadScene("WebViewScene");
    }

    private void GameScene()
    {
        SceneManager.LoadScene("GameScene");
    }
    private void BoostScene()
    {
        SceneManager.LoadScene("BoostScene");
    }
    #endregion
}
