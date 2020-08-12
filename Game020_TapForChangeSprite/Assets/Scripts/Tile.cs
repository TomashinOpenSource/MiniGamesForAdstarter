using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tile : MonoBehaviour
{
    private GameManager GameManager;

    private void Awake()
    {
        GameManager = GameObject.FindObjectOfType<GameManager>();
    }

    public void Pressed()
    {
        this.GetComponent<Image>().sprite = GameManager.Sprites[Random.Range(0, GameManager.Sprites.Count)];
    }
}
