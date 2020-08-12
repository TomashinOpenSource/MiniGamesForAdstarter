using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Move : MonoBehaviour
{
    public TMP_Text countText;
    public int count = 0;
    void Start()
    {
        countText.text = count.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.Lerp(transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition), Time.deltaTime * 5);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision);
        count++;
        countText.text = count.ToString();
    }
}
