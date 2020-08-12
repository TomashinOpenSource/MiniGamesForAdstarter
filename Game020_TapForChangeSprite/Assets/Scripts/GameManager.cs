using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject GameObject;
    public Transform Field;
    public List<Sprite> Sprites;


    void Start()
    {
        SpawnTiles();
    }


    void Update()
    {

    }

    public void SpawnTiles()
    {
        for (int i = 0; i < 32; i++)
        {
            GameObject _g = Instantiate(GameObject, Field);
            _g.GetComponent<Image>().sprite = Sprites[Random.Range(0, Sprites.Count)];
        }
    }

}
