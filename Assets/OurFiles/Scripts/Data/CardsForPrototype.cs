using Data.JSONStruct;
using Game_Logic.CardLogic;
using System.Collections.Generic;
using UnityEngine;


namespace Data
{
    public class CardsForPrototype : MonoBehaviour
    {
        public List<DayNCards> cards;

        //[day].[DeckColor].List<card>
        public List<Card> GetCardsDeck(int day, int colorNumber)
        {
            return cards[day].cardsProperties[colorNumber].cards;
        }
    }
}