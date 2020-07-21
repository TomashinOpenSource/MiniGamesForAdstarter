using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveGround : MonoBehaviour
{
    public float speed;
    public List<Transform> grounds;

    private void Update()
    {
        for (int i = 0; i < grounds.Count; i++)
        {
            grounds[i].Translate(-speed * Time.deltaTime, 0f, 0f);
        }
    }
}
