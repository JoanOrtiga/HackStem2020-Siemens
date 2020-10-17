using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SimpleDraggeable : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    [SerializeField] private RectTransform dragRectTransform;
    [SerializeField] private GameObject contentPanel;
    [SerializeField] private Canvas canvas;

    private Vector2 cellSize = new Vector2(45, 45);

    private bool collisionDetected;
    private bool checkedOnce;
    private Vector2 lastPos = Vector2.zero;

    private void Awake()
    {
        dragRectTransform = GetComponent<RectTransform>();
        lastPos = dragRectTransform.anchoredPosition;
    }

    public void OnDrag(PointerEventData eventData)
    {
        dragRectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;

   /*     dragRectTransform.anchoredPosition = UIUtility.KeepFullyOnScreen(gameObject, dragRectTransform.anchoredPosition, canvas.GetComponent<RectTransform>());*/
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        transform.SetParent(canvas.gameObject.transform);
        dragRectTransform.SetAsLastSibling();
        transform.localScale = contentPanel.transform.localScale;

        collisionDetected = false;

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(contentPanel.transform);
        transform.localScale = Vector3.one;

        dragRectTransform.anchoredPosition = GridSystem.GetGridPosition(dragRectTransform.anchoredPosition);

        collisionDetected = true;
        checkedOnce = false;
        StartCoroutine(ResetCollision());
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collisionDetected && !checkedOnce)
        {
            if (collision.GetComponent<DraggeableWindow>() != null || collision.GetComponent<SimpleDraggeable>() != null)
            {
                if (lastPos == Vector2.zero)
                {
                    Destroy(gameObject);
                }

                dragRectTransform.anchoredPosition = lastPos;
            }

            checkedOnce = true;
        }
    }

    IEnumerator ResetCollision()
    {
        yield return new WaitForSeconds(0.1f);

        checkedOnce = true;
    }
}
