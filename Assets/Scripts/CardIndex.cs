using UnityEngine;
using System.Collections.Generic;
using Unity.Android.Gradle;

namespace HarryGame
{
    [CreateAssetMenu(fileName = "New Card", menuName = "Card")]
    public class CardIndex : ScriptableObject
    {
        public string cardName;

        public string damage;

        public string block;

        public List<CardType> cardType;

        public Sprite cardSprite;

        public string cardDescription;
    }

    public enum CardType
    {
        Attack,
        Skill,
        Power,
    }




}
