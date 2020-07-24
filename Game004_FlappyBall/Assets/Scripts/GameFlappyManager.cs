using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameFlappyManager : MonoBehaviour
{
    [SerializeField]
    private GameObject pipes;

    void Awake()
    {
        //pipes = Resources.Load<GameObject>("Pipes");
    }

    void Start()
    {
        StartCoroutine(GeneratePipes());
    }

    void Update()
    {
        //scoreText.text = "Score: " + score;
    }

    IEnumerator GeneratePipes()
    {
        Vector2 position;
        while (true)
        {
            position = transform.position;
            position.x += 6.0F;
            Instantiate(pipes, position, Quaternion.identity);
            yield return new WaitForSeconds(2.0F);
        }
    }

    public void ResetButtonPressed()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
