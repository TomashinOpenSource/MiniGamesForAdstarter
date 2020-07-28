using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject gameObject;
    private void Start()
    {
        StartCoroutine(SpawnObject());
    }
    private void Update()
    {
        transform.position = new Vector2(Random.Range(-2.5f, 2.5f), transform.position.y);
    }
    private IEnumerator SpawnObject()
    {
        GameObject go =  Instantiate(gameObject, transform);
        go.transform.parent = null;
        go.GetComponent<Rigidbody2D>().gravityScale = Random.Range(1f, 5f);
        yield return new WaitForSeconds(Random.Range(0.01f, 2f));
        StartCoroutine(SpawnObject());
    }
}
