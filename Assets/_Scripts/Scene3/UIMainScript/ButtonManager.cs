using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour,IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Transform icon;
    void Start()
    {
        icon.localScale = Vector2.one;
    }
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        icon.DOScale(Vector2.one * 1.5f, 0.2f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        icon.DOScale(Vector2.one * 1, 0.2f).SetEase(Ease.OutBack);
    }
   
    
}
