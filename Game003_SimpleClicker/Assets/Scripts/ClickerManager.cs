using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ClickerManager : MonoBehaviour
{
    public TMP_Text countText;
    public int count;

    void Start()
    {
        count = 0;
    }

    void Update()
    {
        
    }

    public void Clicked()
    {
        count++;
        countText.text = count.ToString();
    }

    public void ResetButtonPressed()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
