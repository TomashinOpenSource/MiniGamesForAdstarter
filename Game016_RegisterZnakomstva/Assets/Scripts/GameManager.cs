using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject InputZone;
    private void Start()
    {
        InputZone = null ?? GameObject.Find("InputZone");
        InputZone.SetActive(true);
    }

    public void RegisterButtonPressed()
    {
        InputZone.SetActive(false);
    }
}
