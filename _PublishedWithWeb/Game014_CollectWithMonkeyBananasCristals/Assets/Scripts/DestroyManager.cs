using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DestroyManager : MonoBehaviour
{
    public TMP_Text countText;
    private int count = 0;
    private void Start()
    {
        countText.text = count.ToString();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
        count++;
        countText.text = count.ToString();
    }
}
