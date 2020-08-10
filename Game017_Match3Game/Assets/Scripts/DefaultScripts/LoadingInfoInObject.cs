using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoadingInfoInObject : MonoBehaviour
{
    public TMP_Text PercentText, LoadText;
    public Slider slider;

    private float _step;

    private void Start()
    {
        slider.minValue = 0;
        slider.maxValue = 100;
        SetPercent(slider.minValue);
        StartCoroutine(FillPercent());
    }

    private IEnumerator FillPercent()
    {
        do
        {
            slider.value += Random.Range(5, 10);
            SetPercent(slider.value);
            yield return new WaitForSeconds(0.1f);
        } while (slider.value <= 100);
    }

    private void SetPercent(float p)
    {
        slider.value = p;
        PercentText.text = p.ToString() + "%";
    }
}
