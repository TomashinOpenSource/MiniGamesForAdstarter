using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public RectTransform Ring;
    private float targetRotation;
    Quaternion target;
    public float speed;
    void Start()
    {
        Rotate();
    }

    void Update()
    {
        // The step size is equal to speed times frame time.
        var step = speed * Time.deltaTime;

        // Rotate our transform a step closer to the target's.
        Ring.rotation = Quaternion.RotateTowards(Ring.rotation, target, step);
    }

    public void Rotate()
    {
        targetRotation = Random.Range(-360, 360);
        Debug.Log(targetRotation);
        target = new Quaternion(0, 0, targetRotation, 0);
        Debug.Log(target);
    }
}
