using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TMP_Text playerText, rivalText;
    private int playerCount = 0, rivalCount = 0;

    void Start()
    {
        playerText.text = playerCount.ToString();
        rivalText.text = rivalCount.ToString();
    }
    
    public void NextButtonPressed()
    {
        playerCount += Random.Range(1, 7);
        playerText.text = playerCount.ToString();
        if (playerCount >= 21) StopButtonPressed();
    }
    
    public void StopButtonPressed()
    {
        rivalCount += Random.Range(17, 25);
        rivalText.text = rivalCount.ToString();
        StartCoroutine(Wait());
    }

    public void ResetButtonPressed()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(2);
        ResetButtonPressed();
    }

}
