using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject Pirat;
    public int force;

    void Start()
    {
        
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Pirat.GetComponent<Rigidbody2D>().AddForce(Vector2.up * (force), ForceMode2D.Impulse);
        }
    }

    public void SpawnCristall()
    {

    }
}
