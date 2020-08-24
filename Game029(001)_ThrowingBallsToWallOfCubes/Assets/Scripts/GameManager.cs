using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private GameObject WaterObj;
    private float rad;
    private Vector3 pos1, pos2, target;
    private Transform cubeHolder;
    public GameObject ballPrefab;



    void Start()
    {
        WaterObj = GameObject.Find("Water");
        cubeHolder = WaterObj.transform.GetChild(0);
        rad = 10;
        pos1 = new Vector3(0f, 0.25f, -rad / 2);
        pos2 = new Vector3(0f, 0.25f, rad / 2);
        target = Random.Range(0, 1) == 0 ? pos1 : pos2;
    }

    void Update()
    {
        MoveObject(cubeHolder, Random.Range(3, 7));

        if (Input.GetMouseButtonDown(0))
        {
            ThrowObject(ballPrefab, 7);
        }
    }

    private void MoveObject(Transform obj, float speed)
    {
        if (obj.localPosition == pos1) target = pos2;
        if (obj.localPosition == pos2) target = pos1;
        obj.position = Vector3.MoveTowards(obj.position, target, speed * Time.deltaTime);
    }

    public void ThrowObject(GameObject objPrefab, float speed)
    {
        GameObject obj = Instantiate(objPrefab, Camera.main.transform.position, Quaternion.identity);
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out hit, 1000);
        Vector3 direction = hit.point - Camera.main.transform.position;
        obj.GetComponent<Rigidbody>().AddForce(direction * speed);
    }

}