using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DraggeableWindow : MonoBehaviour, IDragHandler, IEndDragHandler
{
    [SerializeField] private RectTransform dragRectTransform;
    [SerializeField] private Canvas canvas;
    [SerializeField] private GameObject panel;

    private Color backgroundColor;

    private bool spawn = false;

    public void OnDrag(PointerEventData eventData)
    {
        if (!spawn)
        {
            Instantiate(gameObject, panel.transform);
            spawn = true;
        }

        dragRectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnPointerDown()
    {
        dragRectTransform.SetAsLastSibling();
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        print("Hola");
    }
}
