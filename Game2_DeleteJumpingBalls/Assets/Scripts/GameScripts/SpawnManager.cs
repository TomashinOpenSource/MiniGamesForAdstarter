using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject objPrefab;
    Vector3 pos;

    void Start()
    {
        StartCoroutine(SpawnObj());
    }

    void Update()
    {
        
    }

    private IEnumerator SpawnObj()
    {
        pos = new Vector3(Random.Range(-5, 5), 1f, Random.Range(-5, 5));
        GameObject obj = Instantiate(objPrefab, pos, Quaternion.identity);

        yield return new WaitForSeconds(Random.Range(0.1f, 5));
        StartCoroutine(SpawnObj());
    }
}
