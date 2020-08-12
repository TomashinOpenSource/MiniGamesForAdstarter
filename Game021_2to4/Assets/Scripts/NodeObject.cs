using System;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class NodeObject : MonoBehaviour
{
    [NonSerialized] public Node from = null;
    [NonSerialized] public Node target = null; 
    public bool combine = false;
    private int m_value;
    public int value
    {
        get => m_value;
        set
        {
            this.m_value = value;
            this.valueText.text = value.ToString();
        }
    }

    public Image blockImage;
    public TMP_Text valueText;

  
    public void InitializeFirstValue()
    {
        int[] v = new int[] {2, 4}; 
        this.value = v[Random.Range(0, v.Length)];
    }  
    public void MoveToNode(Node from, Node to)
    {
        combine = false;
        this.from = from;
        this.target = to;
    }

    public void CombineToNode(Node from, Node to)
    {
        combine = true;
        this.from = from;
        this.target = to; 
    }
    public void OnEndMove()
    {
        if (target != null)
        {
            if (combine)
            {
                target.realNodeObj.value = value * 2;
                var t = target.realNodeObj.transform.DOPunchScale(new Vector3(.25f, .25f, .25f), 0.15f, 3);
                this.gameObject.SetActive(false);
                t.onComplete += () =>
                {
                    this.needDestroy = true;
                    this.target = null; 
                    this.from = null; 
                }; 
            }
            else
            {  
                this.from = null;
                this.target = null;
            }
        } 
    } 
    public bool needDestroy= false;

    public void StartMoveAnimation()
    {
        if (target != null)
        {
            this.name = target.point.ToString(); 
            var tween = this.blockImage.rectTransform.DOLocalMove(target.position, 0.1f);
            tween.onComplete += () =>
            {
                OnEndMove();  
            };
        }
        
    }
    public void UpdateMoveAnimation()
    {
        if (target != null)
        {
            this.name = target.point.ToString();
            var p = Vector2.Lerp(this.transform.localPosition, target.position, 0.35f);
            this.transform.localPosition = p;
            if (Vector2.Distance(this.transform.localPosition, target.position) < 0.25f)
            {
                OnEndMove();  
            }
        }
    }
}
