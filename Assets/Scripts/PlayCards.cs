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

    public GameObject[] cards;

    public EventSystem eventSystem;

    private Vector2 originalPosition;
    private Vector2 originalScale;

    private Vector2 startMousePos;
    private Vector2 mousePos;

    public bool enemyIsSelected;
    public bool cardIsPlayed;

    public bool card1Selected, card2Selected, card3Selected;

    private float cardDelay = 1.5f;



    //Cannon Unselect enemy when playing a card, try to fix

    //Need to put this script on card manager with access to all 3 cards to prevent multiple instances running


    public void OnBeginDrag(PointerEventData eventData)
    {
        originalPosition = transform.position;

        //transform.localScale += new Vector3(0.2f, 0.2f, 0);

        startMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //Vector2 worldPoint2d = new Vector2(worldPoint.x, worldPoint.y);

        print(startMousePos);

    }

    public void OnDrag(PointerEventData eventData)
    {

        Transform cardSelected=null;

        //reset scale to normal
        for (int i = 0; i < cards.Length; i++)
        {
            cards[i].transform.localScale = originalScale;
        }

        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); //Input.mousePosition;

        /* if (mousePos.x >= -2.7f)
         {
             lineRenderer.SetPosition(0, new Vector3(-2.7f, -2.2f));
         }
        */

        // Try to get line to only start if above the card

        
        if (mousePos.y > 0 && (mousePos.x < 1 && mousePos.x > -1)) //When mouse is near enemy
        {
            if (-3.7f < startMousePos.x && startMousePos.x < -1.7f) //What card is selected
            {
                lineRenderer.SetPosition(0, new Vector3(-2.7f, -2.2f));
                lineRenderer.SetPosition(1, new Vector3(0, 1));

                card1Selected = true;
                cardSelected = cards[0].transform;
            }

            if (-1f < startMousePos.x && startMousePos.x < 1f)
            {
                lineRenderer.SetPosition(0, new Vector3(0f, -2.2f));
                lineRenderer.SetPosition(1, new Vector3(0, 1));

                card2Selected = true;
                cardSelected = cards[1].transform;

            }

            if (1.7f < startMousePos.x && startMousePos.x < 3.7f)
            {
                lineRenderer.SetPosition(0, new Vector3(2.7f, -2.2f));
                lineRenderer.SetPosition(1, new Vector3(0, 1));

                card3Selected = true;
                cardSelected = cards[2].transform;

            }



            enemyIsSelected = true;
        }
        else
        {

            if (-3.7f < startMousePos.x && startMousePos.x < -1.7f) //when mouse is not near enemy
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

        //set scale of currently selected card
        if( cardSelected != null )
        {
            cardSelected.transform.localScale = Vector3.one * 2;
        }

    }

    public void OnEndDrag(PointerEventData eventData)
    {

        transform.position = new Vector2(originalPosition.x, originalPosition.y);
        transform.localScale = originalScale;

        lineRenderer.SetPosition(0, new Vector3(0, 0));
        lineRenderer.SetPosition(1, new Vector3(0, 0));

        enemyIsSelected = false;

        card1Selected = false;
        card2Selected = false;
        card3Selected = false;
    }

    private void Start()
    {
        originalScale = transform.localScale;

        cardIsPlayed = false;

        //cards = GameObject.FindGameObjectsWithTag("card");
    }

    private void Update()
    {
        DelayNewCard();

        print(cardIsPlayed);
    }

    void DelayNewCard()
    {
        if (enemyIsSelected)
        {
            if (cardDelay <= 0)
            {
                cardDelay = 1.5f;
                enemyIsSelected = false;
                eventSystem.enabled = true;
                cardIsPlayed = false;
            }
            else
            {
                cardDelay -= Time.deltaTime;
                eventSystem.enabled = false;
                cardIsPlayed = true;
            }

        }
    }
}
