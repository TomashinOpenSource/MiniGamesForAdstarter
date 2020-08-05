using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    public static BoardManager instance;     // Синглтон, чтобы обращаться к методу из других мест
    public List<Sprite> characters = new List<Sprite>();     // лист спрайтов - картинок для выбора
    public GameObject tile;      // префаб сетки
    public int xSize, ySize;     // размеры поля

    private GameObject[,] tiles;      // приватный массив элементов сетки

    public bool IsShifting { get; set; }     // инкапсулированная bool для проверки пустот

    Vector2 offset;

    void Start()
    {
        instance = GetComponent<BoardManager>();     // ссылка на класс
        offset = tile.transform.localScale; // размер спрайта
        CreateBoard(offset.x, offset.y);     // метод создания доски
    }

    private void CreateBoard(float xOffset, float yOffset)
    {
        tiles = new GameObject[xSize, ySize];     // инициализация массива сетки

        float startX = transform.position.x;     // старт сетки
        float startY = transform.position.y;

        for (int x = 0; x < xSize; x++)
        {
            for (int y = 0; y < ySize; y++)
            {
                GameObject newTile = Instantiate(tile, new Vector3(startX + (xOffset * x), startY + (yOffset * y), 0), tile.transform.rotation);
                tiles[x, y] = newTile;
                newTile.transform.parent = transform;
                Sprite newSprite = characters[Random.Range(0, characters.Count)];
                newTile.GetComponent<SpriteRenderer>().sprite = newSprite;

            }
        }
        SetCamera();
    }

    private void SetCamera()
    {
        Camera cam = Camera.main;
        float size = tile.transform.localScale.x;
        float xMove = size * (xSize / 2f);
        float yMove = size * (ySize / 2f);
        cam.transform.position = new Vector3(xMove, yMove, cam.transform.position.z);
    }

}
