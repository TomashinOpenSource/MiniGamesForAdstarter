using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public int speed;

    private void Start()
    {
        Destroy(this.gameObject, 5);
    }

    void Update()
    {
        transform.position += Vector3.left * Time.deltaTime * speed;
    }
}
