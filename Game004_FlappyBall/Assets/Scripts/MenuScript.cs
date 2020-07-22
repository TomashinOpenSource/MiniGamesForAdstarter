﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public bool isWeb;

    private void Start()
    {
        
    }

    public void PlayButtonPressed()
    {
        if (Application.systemLanguage == SystemLanguage.Russian && isWeb == true) SceneManager.LoadScene("WebViewScene");
        else SceneManager.LoadScene("GameScene");
    }

    public void ResetButtonPressed()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
