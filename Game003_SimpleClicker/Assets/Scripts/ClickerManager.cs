using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
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
}
