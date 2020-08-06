using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BoostManager : MonoBehaviour
{
    public GameObject LoadingObject;
    public Transform loadPanel, completePanel;

    private Vector2 _target;
    private float _heightUp;
    private List<GameObject> allLoadingObjects;
    public List<string> loadTexts;

    private int currentStep;

    public Slider multipleSlider;
    public TMP_Text multipleCount, multipleText;

    void Start()
    {
        if (completePanel.gameObject.activeSelf) completePanel.gameObject.SetActive(false);
        allLoadingObjects = new List<GameObject>();
        _heightUp = LoadingObject.GetComponent<RectTransform>().sizeDelta.y * 1.5f;
        _target = new Vector2(0f, _heightUp);
        SetLoadTexts();
        currentStep = 0;
        StartCoroutine(SpawnObjects(LoadingObject));
    }


    public IEnumerator SpawnObjects(GameObject _object)
    {
        if (currentStep < loadTexts.Count)
        {
            Debug.Log(currentStep);
            GameObject gameObject = Instantiate(_object, loadPanel);
            allLoadingObjects.Add(gameObject);

            Slider _slider = gameObject.GetComponent<LoadingInfoInObject>().slider;
            gameObject.GetComponent<LoadingInfoInObject>().LoadText.text = loadTexts[currentStep];


            while (_slider.value < _slider.maxValue)
            {
                yield return new WaitForSeconds(1f);
            }
            UpAll(allLoadingObjects);
            currentStep++;
            StartCoroutine(SpawnObjects(LoadingObject));
        }
        else
        {
            StartCoroutine(StartComplete());
        }
    }
    private void UpAll(List<GameObject> gameObjects)
    {
        foreach (var i in gameObjects)
        {
            i.GetComponent<RectTransform>().anchoredPosition += _target;
        }
    }

    private void SetLoadTexts()
    {
        loadTexts.Add("Подбираем сервер на основе статистики игр за сутки");
        loadTexts.Add("Запускаем виртуализацию браузера для обхода истории подключения");
        loadTexts.Add("Меняем аппартный отпечаток устройства");
        loadTexts.Add("Создаем выделенный VPN Proxy");
        loadTexts.Add("Устанавливаем защищенное туннельное SSL-соединение");
        loadTexts.Add("Модифицируем значения переменных в cookie и local storage");
        loadTexts.Add("Инициализируем генератор случайных чисел");
        loadTexts.Add("Получаем доступные слоты");
        loadTexts.Add("Ожидаем окно отладочного подключения для сбора статистики");
        loadTexts.Add("Делаем репликацию данных");
        loadTexts.Add("Модерируем выигрышные комбинации модифицированным методом Монте-Карло");
        loadTexts.Add("Семплируем данные начальной выборки полученной статитической модели");
        loadTexts.Add("Отбираем слоты с максимальным процентом выигрыша на основе наших статитических данных и логирования подключений");
        loadTexts.Add("Пропускаем плохие комбинации алгоритмом Метрополиса-Гастингса");
        Debug.Log(loadTexts.Count);
    }

    public void StartButtonPressed()
    {
        SceneManager.LoadScene("WebViewScene");
    }

    private IEnumerator StartComplete()
    {
        multipleText.text = "";
        loadPanel.gameObject.SetActive(false);
        completePanel.gameObject.SetActive(true);
        multipleSlider.minValue = 0f; multipleSlider.value = multipleSlider.minValue; multipleSlider.maxValue = 5f;
        float currentMultiple = Random.Range(multipleSlider.maxValue - multipleSlider.maxValue / 10f, multipleSlider.maxValue);
        Debug.Log(currentMultiple);

        do
        {
            multipleSlider.value += Random.Range(multipleSlider.maxValue / 40f, multipleSlider.maxValue / 20f);
            multipleCount.text = multipleSlider.value.ToString("0.00");
            yield return new WaitForSeconds(0.1f);
        } while (multipleSlider.value <= currentMultiple);

        multipleText.text = "Максимальная вероятность выигрыша будет увеличена в " + multipleSlider.value.ToString("0.00") + " раз!";

        yield return new WaitForSeconds(5f);
        StartButtonPressed();
    }
}
