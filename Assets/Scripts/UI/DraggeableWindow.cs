using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DraggeableWindow : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler
{
    [SerializeField] private RectTransform dragRectTransform;
    [SerializeField] private Canvas canvas;
    [SerializeField] private GameObject panel;
    [SerializeField] private GameObject contentPanel;

    private Color backgroundColor;

    private bool spawn = false;

    public RectTransform paperBin;
    public RectTransform blocksPanel;

    private Vector2 cellSize = new Vector2(45,45);

    private Vector2 lastPos = Vector2.zero;

    private bool collisionDetected;
    private bool checkedOnce;

    /// Next Block
    private DraggeableWindow nextBlock;

    private Color blockColor;

    private void Awake()
    {
        dragRectTransform = GetComponent<RectTransform>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        dragRectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;

        if (nextBlock != null)
        {
            nextBlock.OnDrag(eventData);
        }
    }


    public void OnBeginDrag(PointerEventData eventData)
    {
        if (!spawn)
        {
            Instantiate(gameObject, panel.transform);
            spawn = true;

            transform.GetComponent<CodeBlock>().EditChildParameters();
        }
        else
        {
            lastPos = dragRectTransform.anchoredPosition;
        }

        RaycastHit2D ray = Physics2D.Raycast(transform.position, Vector2.down, (40 * transform.parent.localScale.x));


        blockColor = transform.GetChild(0).GetComponent<Image>().color;
        blockColor.a = 0.6f;
        transform.GetChild(0).GetComponent<Image>().color = blockColor;

        transform.SetParent(canvas.gameObject.transform);
        dragRectTransform.SetAsLastSibling();
        transform.localScale = contentPanel.transform.localScale;

        collisionDetected = false;

        if (ray)
        {
            if (ray.collider.GetComponent<DraggeableWindow>() != null)
            {
                nextBlock = ray.collider.GetComponent<DraggeableWindow>();
                nextBlock.OnBeginDrag(eventData);
            }
           
        }
        else
        {
            nextBlock = null;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        blockColor.a = 1f;
        transform.GetChild(0).GetComponent<Image>().color = blockColor;

        if (UIUtility.GetWorldSpaceRect(paperBin).Contains(eventData.position, true))
        {
            Destroy(gameObject);
        }


        if (UIUtility.GetWorldSpaceRect(blocksPanel).Contains(eventData.position, true))
        {
            Destroy(gameObject);
        }

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
        if (collisionDetected && !checkedOnce ) {
            if (collision.GetComponent<DraggeableWindow>() != null || collision.GetComponent<SimpleDraggeable>() != null)
            {
                if(lastPos == Vector2.zero)
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
