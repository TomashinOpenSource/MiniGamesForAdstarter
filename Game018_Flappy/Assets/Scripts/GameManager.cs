using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject Ball;
    private new Rigidbody2D rigidbody;
    public float force;
    public List<GameObject> objects;

    private void Awake()
    {
        rigidbody = Ball.GetComponent<Rigidbody2D>();
        StartCoroutine(GeneratePipes());
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            force = Random.Range(5f, 25f);
            Ball.GetComponent<Rigidbody2D>().AddForce(Vector2.up * (force - rigidbody.velocity.y), ForceMode2D.Impulse);
        }
    }
    IEnumerator GeneratePipes()
    {
        Vector2 position;
        while (true)
        {
            position = transform.position;
            position.x += 15.0F;
            Instantiate(objects[Random.Range(0, objects.Count)], position, Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(0.5f, 2f));
        }
    }

    public void ResetButtonPressed()
    {
        SceneManager.LoadScene("GameScene");
    }
}
