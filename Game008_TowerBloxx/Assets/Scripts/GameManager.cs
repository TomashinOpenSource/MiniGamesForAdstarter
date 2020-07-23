using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Transform Holder;
    public float amplitude;
    public float speedRotate;

    public Transform HouseHolder;

    public GameObject floorPrefab;

    public GameObject lookAtObject;

    private void Start()
    {
        Holder = null ?? GameObject.Find("Holder").transform;
        HouseHolder = null ?? GameObject.Find("HouseHolder").transform;
        lookAtObject = Camera.main.gameObject;
    }

    private void Update()
    {
        RotateObject(Holder, speedRotate, amplitude);
        if (Input.GetMouseButtonDown(0))
        {
            ThrowFloor();
        }
    }

    private void RotateObject(Transform t, float s, float a)
    {
        t.eulerAngles = new Vector3(0, 0, Mathf.Sin(Time.time * s) * a);
    }

    private void ThrowFloor()
    {
        Transform c = HouseHolder.GetChild(0);
        c.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        c.gameObject.transform.parent = null;
        lookAtObject = c.gameObject;

        GameObject floor = Instantiate(floorPrefab, HouseHolder);
        floor.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;

    }
    
}
