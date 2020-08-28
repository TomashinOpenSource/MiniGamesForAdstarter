using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraToMonkey : MonoBehaviour
{
    public Transform MonkeyTarget;
    float zOffset;
    private void Start()
    {
        zOffset = transform.position.z;
    }

    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, MonkeyTarget.position, Time.deltaTime * 5);
        transform.position = new Vector3(transform.position.x, transform.position.y, zOffset);
    }
}
