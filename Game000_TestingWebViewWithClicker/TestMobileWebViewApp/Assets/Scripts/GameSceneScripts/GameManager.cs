using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text countText;
    private int count;
    
    
    void Start()
    {
        count = 0;
        PrintCount(count);
    }

    private void PrintCount(int c)
    {
        countText.text = c.ToString();
    }

    public void Pressed()
    {
        count++;
        PrintCount(count);
    }
}
