using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveGround : MonoBehaviour
{
    public float speed;
    public List<Transform> grounds;
    private Transform first, second;

    private void Start()
    {
        first = grounds[0];
        second = grounds[1];
    }

    private void Update()
    {
        for (int i = 0; i < grounds.Count; i++)
        {
            grounds[i].Translate(-speed * Time.deltaTime, 0f, 0f);

        }
    }

    public void ChangePos()
    {
        grounds[0] = second;
        grounds[1] = first;
    }
    public void ResetButtonPressed()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
