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
    public Transform target;

    private void Start()
    {
        Holder = null ?? GameObject.Find("Holder").transform;
        HouseHolder = null ?? GameObject.Find("HouseHolder").transform;
    }

    private void Update()
    {
        RotateObject(Holder, speedRotate, amplitude);
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(ThrowFloor());
        }
    }

    private void RotateObject(Transform t, float s, float a)
    {
        t.eulerAngles = new Vector3(0, 0, Mathf.Sin(Time.time * s) * a);
    }

    private IEnumerator ThrowFloor()
    {
        Transform c = HouseHolder.GetChild(0);
        c.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        c.gameObject.transform.parent = null;
        c.position -= Vector3.up * floorPrefab.transform.localScale.y / 2;
        GameObject floor = Instantiate(floorPrefab, HouseHolder);
        floor.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
        yield return new WaitForSeconds(1);
        Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, c.transform.position.y + c.localScale.y, Camera.main.transform.position.z);
    }

    
}
