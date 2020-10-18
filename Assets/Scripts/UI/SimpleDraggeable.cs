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

    //////////////
    //Next Block
    private DraggeableWindow nextBlock;

    private void Awake()
    {
        dragRectTransform = GetComponent<RectTransform>();
        lastPos = dragRectTransform.anchoredPosition;

        dragRectTransform.anchoredPosition = GridSystem.GetGridPosition(dragRectTransform.anchoredPosition);

        
    }

    public void OnDrag(PointerEventData eventData)
    {
        dragRectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;

        /*     dragRectTransform.anchoredPosition = UIUtility.KeepFullyOnScreen(gameObject, dragRectTransform.anchoredPosition, canvas.GetComponent<RectTransform>());*/

        if (nextBlock != null)
        {
            nextBlock.OnDrag(eventData);
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        RaycastHit2D ray = Physics2D.Raycast(transform.position, Vector2.down, (40 * transform.parent.localScale.x));


        transform.SetParent(canvas.gameObject.transform);
        dragRectTransform.SetAsLastSibling();
        transform.localScale = contentPanel.transform.localScale;

        collisionDetected = false;


        if (ray)
        {
            nextBlock = ray.collider.GetComponent<DraggeableWindow>();
            nextBlock.OnBeginDrag(eventData);
        }
        else
        {
            nextBlock = null;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {

        transform.SetParent(contentPanel.transform);
        transform.localScale = Vector3.one;

        dragRectTransform.anchoredPosition = GridSystem.GetGridPosition(dragRectTransform.anchoredPosition);

        collisionDetected = true;
        checkedOnce = false;
        StartCoroutine(ResetCollision());

        if (nextBlock != null)
        {
            nextBlock.OnEndDrag(eventData);
        }
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
