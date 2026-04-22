using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;
using HarryGame;
using Unity.VisualScripting;

public class HandManager : MonoBehaviour
{
    public GameObject cardPrefab;
    public CardIndex cardData1, cardData2, cardData3;
    private ListOfCards listOfCards;

    [Header("Card1")]

    public TMP_Text card1Name;
    public TMP_Text card1Type;
    public TMP_Text card1Description;
    public Image card1Image;

    [Header("Card2")]

    public TMP_Text card2Name;
    public TMP_Text card2Type;
    public TMP_Text card2Description;
    public Image card2Image;

    [Header("Card3")]

    public TMP_Text card3Name;
    public TMP_Text card3Type;
    public TMP_Text card3Description;
    public Image card3Image;


    private Color[] typeColours =
{
        Color.red, //attack
        Color.blue, //skill
        Color.yellow, //power
    };

    public List<GameObject> preparedCards = new List<GameObject>();

    //** card **
    // image
    // card name text 
    // card type text 
    // card description text



    void Start()
    {
        UpdateCard1();
        UpdateCard2();
        UpdateCard3();
        
    }

    public void AddCardToHand()
    {
        /*GameObject newCard = Instantiate(cardPrefab, handTransform.position, Quaternion.identity, handTransform);
        preparedCards.Add(newCard);
        UpdateHandVisuals();
        */
    }

    
    private void UpdateCard1()
    {
        card1Name.text = cardData1.cardName;
        card1Description.text = cardData1.cardDescription;
        card1Type.text = cardData1.cardType[0].ToString();
        card1Image.color = typeColours[(int)cardData1.cardType[0]];
    }

    private void UpdateCard2()
    {
        card2Name.text = cardData2.name;
        card2Description.text = cardData2.cardDescription;
        card2Type.text = cardData2.cardType[0].ToString();
        card2Image.color = typeColours[(int)cardData2.cardType[0]];
    }

    private void UpdateCard3()
    {
        card3Name.text = cardData3.name;
        card3Description.text = cardData3.cardDescription;
        card3Type.text = cardData3.cardType[0].ToString();
        card3Image.color = typeColours[(int)cardData3.cardType[0]];
    }


    #region DeckLogic

    //






    #endregion

}
