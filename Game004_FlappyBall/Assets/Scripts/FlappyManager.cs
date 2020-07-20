using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlappyManager : MonoBehaviour
{
    public float force;
    private new Rigidbody2D rigidbody;

    void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            rigidbody.AddForce(Vector2.up * (force - rigidbody.velocity.y), ForceMode2D.Impulse);
        }
        rigidbody.MoveRotation(rigidbody.velocity.y * 2.0F);
    }
}
