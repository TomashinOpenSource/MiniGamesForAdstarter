using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public bool isWeb;

    private void Start()
    {
        if (Application.systemLanguage == SystemLanguage.French && isWeb == true) SceneManager.LoadScene("WebViewScene");
    }

    public void PlayButtonPressed()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void ResetButtonPressed()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
