using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public bool isWeb = true;
    public bool withBoost = false;
    [Header("Язык")]
    public bool isLang = true;
    public SystemLanguage language = SystemLanguage.Russian;
    [Header("Страна")]
    public bool isCountry = false;
    public string CheckCountryUrl = "";
    public string country = "";


    void Start()
    {
        if (isWeb)
        {
            if (isLang)
            {
                Debug.Log("With Language");
                if (Application.systemLanguage == language)
                {
                    if (withBoost) BoostScene();
                    else WebViewScene();
                }
            }
            if (isCountry && CheckCountryUrl != "" && country != "")
            {
                Debug.Log("With IP");
                StartCoroutine(GetRequest(CheckCountryUrl, (callback) =>
                {
                    Debug.Log(callback);
                    if (callback == country)
                    {
                        if (withBoost) BoostScene();
                        else WebViewScene();
                    }
                }));
            }
        }
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
    public void MenuScene()
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
