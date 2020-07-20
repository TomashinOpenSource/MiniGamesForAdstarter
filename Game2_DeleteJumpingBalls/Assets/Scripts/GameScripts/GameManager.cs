using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{


    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (GetRaycastHit(Input.mousePosition).transform.GetComponent<SphereObject>() != null)
            {
                Destroy(GetRaycastHit(Input.mousePosition).transform.gameObject);
            }
        }
    }

    
    private RaycastHit GetRaycastHit(Vector3 _mousePosition)
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(_mousePosition);
        Physics.Raycast(ray, out hit, 1000);
        return hit;
    }

}
