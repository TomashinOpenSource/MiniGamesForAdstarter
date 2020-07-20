using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeManager : MonoBehaviour
{
    public List<Transform> tails;
    [Range(0,3)]
    public float boneDist;
    public GameObject bonePrefab;
    [Range(0,4)]
    public float speed;
    float angle;
    Vector3 target;

    private Transform _transform;

    private void Start()
    {
        _transform = GetComponent<Transform>();
        int rand = Random.Range(5, 100);
        boneDist = rand / 10;
        for (int i = 0; i < rand; i++)
        {
            var bone = Instantiate(bonePrefab).transform;
            tails.Add(bone.transform);
        }
        target = _transform.position;
    }

    private void Update()
    {
        RaycastHit hit = RayFromCamera(Input.mousePosition, 100f);
        target = hit.point;
        target = new Vector3(target.x, 0.5f, target.z);
        MoveSnake(target);
        //MoveSnake(_transform.position + _transform.forward * speed);

        //angle = Input.GetAxis("Horizontal") * 4;
        //_transform.Rotate(0, angle, 0);
    }

    private void OnMouseDrag()
    {
        RaycastHit hit = RayFromCamera(Input.mousePosition, 100f);
            MoveSnake(hit.point);
    }

    private void MoveSnake(Vector3 newPosition)
    {
        float sqrDist = boneDist * boneDist;
        Vector3 prevPos = _transform.position;
        for (int i = 0; i < tails.Count; i++)
        {
            var bone = tails[i];
            if ((bone.position - prevPos).sqrMagnitude > sqrDist)
            {
                var temp = bone.position;
                bone.position = prevPos;
                bone.Rotate(0, angle * (i/tails.Count), 0);
                prevPos = temp;
            }
            else
            {
                break;
            }
        }
        _transform.position = newPosition;

    }

    public void ThrowObjectToTouch(GameObject gameObjectPrefab, Vector3 mousePostion, float speed)
    {
        GameObject gameObject = Instantiate(gameObjectPrefab, Camera.main.transform.position, Quaternion.identity);
        RaycastHit hit = RayFromCamera(mousePostion, 1000f);
        Vector3 direction = hit.point - Camera.main.transform.position;
        gameObject.GetComponent<Rigidbody>().AddForce(direction * speed);
    }
    public RaycastHit RayFromCamera(Vector3 mousePostion, float rayLength)
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(mousePostion);
        Physics.Raycast(ray, out hit, rayLength);
        return hit;
    }
}
