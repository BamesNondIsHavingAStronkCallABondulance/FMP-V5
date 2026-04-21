using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class PlayCards : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public LineRenderer lineRenderer;

    public GameObject card;
    public EventSystem eventSystem;

    private Vector2 originalPosition;
    private Vector2 originalScale;

    private Vector2 startMousePos;
    private Vector2 mousePos;

    public bool enemyIsSelected;
    public bool cardIsPlayed;

    public bool card1Selected, card2Selected, card3Selected;

    private float cardDelay = 1.5f;

    //-2.7, -2.2 for card 1

    public void OnBeginDrag(PointerEventData eventData)
    {

        originalPosition = transform.position;
        transform.localScale += new Vector3(0.2f, 0.2f, 0);

        startMousePos = Input.mousePosition;

        startMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //Vector2 worldPoint2d = new Vector2(worldPoint.x, worldPoint.y);
    }

    public void OnDrag(PointerEventData eventData)
    {

        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); //Input.mousePosition;

        print(startMousePos.x);

        /* if (mousePos.x >= -2.7f)
         {
             lineRenderer.SetPosition(0, new Vector3(-2.7f, -2.2f));
         }
        */

        // Try to get line to only start if above the card

        
        if (mousePos.y > 0 && (mousePos.x < 1 && mousePos.x > -1))
        {
            if (-3.7f < startMousePos.x && startMousePos.x < -1.7f)
            {
                lineRenderer.SetPosition(0, new Vector3(-2.7f, -2.2f));
                lineRenderer.SetPosition(1, new Vector3(0, 1));

                card1Selected = true;
            }

            if (-1f < startMousePos.x && startMousePos.x < 1f)
            {
                lineRenderer.SetPosition(0, new Vector3(0f, -2.2f));
                lineRenderer.SetPosition(1, new Vector3(0, 1));

                card2Selected = true;
            }

            if (1.7f < startMousePos.x && startMousePos.x < 3.7f)
            {
                lineRenderer.SetPosition(0, new Vector3(2.7f, -2.2f));
                lineRenderer.SetPosition(1, new Vector3(0, 1));

                card3Selected = true;
            }



            enemyIsSelected = true;
        }
        else
        {

            if (-3.7f < startMousePos.x && startMousePos.x < -1.7f)
            {
                lineRenderer.SetPosition(0, new Vector3(-2.7f, -2.2f));
                lineRenderer.SetPosition(1, new Vector3(mousePos.x, mousePos.y));
            }

            if (-1f < startMousePos.x && startMousePos.x < 1f)
            {
                lineRenderer.SetPosition(0, new Vector3(0, -2.2f));
                lineRenderer.SetPosition(1, new Vector3(mousePos.x, mousePos.y));
            }
            if (1.7f < startMousePos.x && startMousePos.x < 3.7f)
            {
                lineRenderer.SetPosition(0, new Vector3(2.7f, -2.2f));
                lineRenderer.SetPosition(1, new Vector3(mousePos.x, mousePos.y));
            }


            enemyIsSelected = false;
        }

    }

    public void OnEndDrag(PointerEventData eventData)
    {

        transform.position = new Vector2(originalPosition.x, originalPosition.y);
        transform.localScale = originalScale;

        lineRenderer.SetPosition(0, new Vector3(0, 0));
        lineRenderer.SetPosition(1, new Vector3(0, 0));
    }

    private void Start()
    {
        print(transform.position);
        originalScale = transform.localScale;
        card = GetComponent<GameObject>();
    }

    private void Update()
    {
        DelayNewCard();
    }

    void DelayNewCard()
    {
        if (enemyIsSelected)
        {
            cardIsPlayed = true;

            if (cardDelay <= 0)
            {
                cardDelay = 1.5f;
                cardIsPlayed = false;
                enemyIsSelected = false;
                eventSystem.enabled = true;
            }
            else
            {
                cardDelay -= Time.deltaTime;
                eventSystem.enabled = false;
            }

        }
    }
}
