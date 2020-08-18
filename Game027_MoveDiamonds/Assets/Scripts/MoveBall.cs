using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveBall : MonoBehaviour
{
    public Slider slider;

    TextAsset file;
    List<Vector3> Directions;
    public bool moving;
    private Vector3 target;

    private void Awake()
    {
        file = Resources.Load("ball_path") as TextAsset;
    }

    void Start()
    {
        Directions = new List<Vector3>();
        ReadJson();

        slider.maxValue = Directions.Count - 1;
        slider.minValue = 0;
        slider.value = slider.minValue;
    }


    void Update()
    {
        target = Directions[(int)slider.value];
        transform.position = Vector3.MoveTowards(transform.position, target, 1);
        Camera.main.transform.position = new Vector3(transform.position.x, transform.position.y, -10f);
    }

    public void ReadJson()
    {
        Points _points = JsonUtility.FromJson<Points>(file.text);
        for (int i = 0; i < _points.x.Count; i++)
        {
            Directions.Add(new Vector3(_points.x[i], _points.y[i], _points.z[i]));
        }

        //StartCoroutine(Moving(Directions));
    }

    public IEnumerator Moving(List<Vector3> d)
    {
        moving = true;
        int i = 0;
        target = (d[i]);
        while (true)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, 3);
            yield return new WaitForEndOfFrame();

            if (transform.position == target)
            {
                Debug.Log("transform.position == target");
                if (i < d.Count - 1)
                {
                    Debug.Log("i <= d.Count");
                    i++;
                    target = (d[i]);
                }
                else
                {
                    Debug.Log("else");
                    i = 0;
                    moving = false;
                    target = transform.position;
                    yield break;
                }
            }
        }

    }
}

public class Points
{
    public List<float> x, y, z;
}
