using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform Ring;
    private float targetRotation;
    Vector3 target;
    public float speed;

    public TMP_Text CountText, plusText;

    private int count, plus;
    void Start()
    {
        count = 100;
        Rotate();
    }

    void Update()
    {
        // The step size is equal to speed times frame time.
        var step = speed * Time.deltaTime;

        // Rotate our transform a step closer to the target's.
        Ring.rotation = Quaternion.Lerp(Ring.rotation, Quaternion.Euler(target), step);
    }

    public void Rotate()
    {
        targetRotation = Random.Range(0, 360);
        Debug.Log(targetRotation);
        target = new Vector3(0, 0, targetRotation);
        Debug.Log(target);
        plus = Random.Range(-30, 30);
        count += plus;
        plusText.text = plus.ToString();
        CountText.text = count.ToString();
    }
}
