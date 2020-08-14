using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SpawnerController : MonoBehaviour {

    public GameObject[] Fruits;


    void Start()
    {
        StartCoroutine(SpawnFruits());
    }


    void Update()
    {

    }

    private IEnumerator SpawnFruits()
    {
        GameObject _object = Instantiate(Fruits[Random.Range(0, Fruits.Length)]);

        Vector2 SpawnPos = new Vector2(Random.Range(-2.5f, 2.5f), 6f);
        _object.transform.position = SpawnPos;


        yield return new WaitForSeconds(Random.Range(0f, 3f));

        StartCoroutine(SpawnFruits());

        yield return new WaitForSeconds(100f);
        Destroy(_object);
    }

}
