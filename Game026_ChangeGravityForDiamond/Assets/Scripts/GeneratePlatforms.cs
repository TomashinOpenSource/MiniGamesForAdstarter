using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratePlatforms : MonoBehaviour
{
    public GameObject Platform;

    private void Start()
    {
        StartCoroutine(SpawnPlatform());
    }

    public IEnumerator SpawnPlatform()
    {
        GameObject gameObject = Instantiate(Platform);
        bool flip = (Random.Range(0, 2) == 0) ? false : true;
        Debug.Log(flip);
        gameObject.transform.position = (flip) ? new Vector2(5, 4) : new Vector2(5, -4);
        gameObject.GetComponent<SpriteRenderer>().flipX = flip;
        gameObject.GetComponent<Platform>().speed = Random.Range(5, 7);

        yield return new WaitForSeconds(Random.Range(0.1f, 2f));

        StartCoroutine(SpawnPlatform());
    }
}
