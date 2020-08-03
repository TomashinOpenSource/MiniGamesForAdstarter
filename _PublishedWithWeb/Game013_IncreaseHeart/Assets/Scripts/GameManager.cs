using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject heart;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Camera cam = Camera.main;
            Vector3 v = cam.ScreenToWorldPoint(Input.mousePosition);
            Vector2 target = new Vector2(v.x, v.y);
            GameObject h = Instantiate(heart);
            h.transform.position = target;

            h.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            h.GetComponent<Rigidbody2D>().gravityScale = Random.Range(-1f, -0.05f);

            StartCoroutine(SlowScale(h));
            StartCoroutine(DestroyGameObject(h));
        }
    }

    private IEnumerator DestroyGameObject(GameObject g)
    {
        yield return new WaitForSeconds(15f);
        Destroy(g);
    }

    private IEnumerator SlowScale(GameObject g)
    {
        float mastQ = Random.Range(1.1f, 5f);
        float stepQ = Random.Range(0.05f, 1f);
        float waitT = Random.Range(0.025f, 1f);
        for (float q = 1f; q < mastQ; q += stepQ)
        {
            g.transform.localScale = new Vector3(q, q, q);
            yield return new WaitForSeconds(waitT);
        }
    }
}
