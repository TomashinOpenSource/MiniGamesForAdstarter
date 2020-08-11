using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject Fruit;
    public List<Sprite> FruitSprites;
    public TMP_Text CountText;
    private int Count = 0;


    void Start()
    {
        CountText.text = Count.ToString();
        StartCoroutine(SpawnFruits());
    }

    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);
            if (hit.collider != null)
            {
                if (hit.collider.name.Contains("Fruit"))
                {
                    Destroy(hit.collider.gameObject);
                    Count++;
                    CountText.text = Count.ToString();
                }
            }
        }
    }

    private IEnumerator SpawnFruits()
    {
        GameObject _object = Instantiate(Fruit);

        Vector2 SpawnPos = new Vector2(Random.Range(-2.5f, 2.5f), Random.Range(0f, 5f));
        _object.transform.position = SpawnPos;

        Sprite _sprite = FruitSprites[Random.Range(0, FruitSprites.Count)];
        SpriteRenderer _sr = _object.GetComponent<SpriteRenderer>();
        _sr.sortingOrder = Random.Range(0, 100);
        _sr.sprite = _sprite;

        yield return new WaitForSeconds(Random.Range(0f, 3f));

        StartCoroutine(SpawnFruits());

        yield return new WaitForSeconds(100f);
        Destroy(_object);
    }


}
