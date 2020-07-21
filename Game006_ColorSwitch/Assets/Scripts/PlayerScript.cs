using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    public float jumpForce;
    public Rigidbody2D circle;
    public string currentColor;
    public SpriteRenderer sr;
    public Color blue, yellow, pink, purple;

    private void Start()
    {
        jumpForce = 10f;
        circle = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        SetRandomColor();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            circle.velocity = Vector2.up * jumpForce;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "ColorChanger")
        {
            SetRandomColor();
            Destroy(collision.gameObject);
            return;
        }

        if (collision.tag != currentColor)
        {
            Debug.Log("DIED");
            ReloadScene();
        }
        
    }

    private void OnBecameInvisible()
    {
        ReloadScene();
    }

    private void SetRandomColor()
    {
        int rand = Random.Range(0, 3);
        switch (rand)
        {
            case 0:
                currentColor = "Blue";
                sr.color = blue;
                break;
            case 1:
                currentColor = "Yellow";
                sr.color = yellow;
                break;
            case 2:
                currentColor = "Pink";
                sr.color = pink;
                break;
            case 3:
                currentColor = "Purple";
                sr.color = purple;
                break;
        }
    }
    public static void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
