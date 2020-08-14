using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveManager : MonoBehaviour
{
    [SerializeField]
    private float speed;

    void Start()
    {
        speed = Random.Range(3, 10);
        Vector2 position = transform.position;
        position.y = Random.Range(-5F, 5F);
        transform.position = position;
        Destroy(gameObject, 15.0F);
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, transform.position - transform.right, speed * Time.deltaTime);
    }
}
