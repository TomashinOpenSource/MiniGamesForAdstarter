using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Spawn : MonoBehaviour
{
    public GameObject Money;
    private float y;
    public TMP_Text countText;
    private int count = 0;

    private void Start()
    {
        y = Camera.main.transform.position.y;
        countText.text = count.ToString();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject m = Instantiate(Money);
            m.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            m.transform.position = new Vector3(m.transform.position.x, m.transform.position.y, y);
            count++;
            countText.text = count.ToString();
        }
    }
}
