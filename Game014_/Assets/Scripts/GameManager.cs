using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject monkey;
    public List<GameObject> objectsToCollect;

    void Start()
    {
        StartCoroutine(StartSpawn());
    }

    void Update()
    {
        monkey.transform.position = Vector2.Lerp(monkey.transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition), Time.deltaTime * 5f);
    }

    private IEnumerator StartSpawn()
    {
        GameObject curObject = Instantiate(objectsToCollect[Random.Range(0, objectsToCollect.Count)]);
        curObject.transform.position = new Vector2(Random.Range(-2f, 2f), Random.Range(-4f, 4f));
        curObject.GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)) * 10f;

        yield return new WaitForSeconds(Random.Range(0.1f, 1f));

        StartCoroutine(StartSpawn());
    }
}
