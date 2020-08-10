using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;

public class Board : MonoBehaviour
{
    public int width, height, borderSize;
    public List<GameObject> characters;

    Tile[,] m_allTiles;

    void Start()
    {
        width = Random.Range(2, 10);
        height = Random.Range(2, 10);
        borderSize = Random.Range(0, 3);
        m_allTiles = new Tile[width, height];
        SetupTiles();
        SetupCamera();
    }

    void SetupTiles()
    {
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                GameObject tile = Instantiate(characters[Random.Range(0, characters.Count)], new Vector3(i, j, 0), Quaternion.identity) as GameObject;
                tile.name = "Tile (" + i + "," + j + ")";
                m_allTiles[i, j] = tile.GetComponent<Tile>();
                tile.transform.parent = transform;
            }
        }
    }

    void SetupCamera()
    {
        Camera.main.transform.position = new Vector3((float)(width - 1) / 2f, (float)(height - 1) / 2f, -10f);

        float aspectRatio = (float)Screen.width / (float)Screen.height;
        float verticalSize = (float)height / 2f + (float)borderSize;
        float horizontalSize = ((float)width / 2f + (float)borderSize) / aspectRatio;
        Camera.main.orthographicSize = (verticalSize > horizontalSize) ? verticalSize : horizontalSize;
    }

    public void Restart()
    {
        SceneManager.LoadScene("GameScene");
    }
}
