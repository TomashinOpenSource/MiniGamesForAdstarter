using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeGravity : MonoBehaviour
{
    public Rigidbody2D rigidbody;
    public int gravityScale;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.gravityScale = gravityScale;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            rigidbody.gravityScale *= -1;
        }
    }
}
