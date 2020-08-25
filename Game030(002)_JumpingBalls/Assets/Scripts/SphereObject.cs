using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereObject : MonoBehaviour
{

    void Start()
    {
        StartCoroutine(JumpObj());
    }

    void Update()
    {
        
    }

    private IEnumerator JumpObj()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + Random.Range(1, 5), transform.position.z);
        yield return new WaitForSeconds(Random.Range(1, 2));
        StartCoroutine(JumpObj());
    }
}
