using Data;
using Game_Logic.CardLogic;
using System.Collections.Generic;
using UnityEngine;

namespace Game_Logic.Deck
{
	public class CreateDeck : MonoBehaviour
	{
		[SerializeField] private int _requaredCount;
		[SerializeField] private List<Card> _cards;
		[SerializeField] private List<Card> _cardsForPrototype;
		[SerializeField] private CardColor _color;

		public void Initialize()
		{
			CardsForPrototype cardsForPrototype = FindObjectOfType<CardsForPrototype>();
			int currentDay = FindObjectOfType<LoadCurrentDayJSON>().GetCurrentDay();
			
			switch (currentDay)
			{
				case 1:
					switch (_color)
					{
						case CardColor.Red:
							_cardsForPrototype = cardsForPrototype.GetCardsDeck(0, 0);
							break;
						case CardColor.Green:
							_cardsForPrototype = cardsForPrototype.GetCardsDeck(0, 1);
							break;
						case CardColor.Blue:
							_cardsForPrototype = cardsForPrototype.GetCardsDeck(0, 2);
							break;
						case CardColor.Yellow:
							_cardsForPrototype = cardsForPrototype.GetCardsDeck(0, 3);
							break;
						case CardColor.Black:
							break;
					}
					break;
				case 2:
					switch (_color)
					{
						case CardColor.Red:
							_cardsForPrototype = cardsForPrototype.GetCardsDeck(1, 0);
							break;
						case CardColor.Green:
							_cardsForPrototype = cardsForPrototype.GetCardsDeck(1, 1);
							break;
						case CardColor.Blue:
							_cardsForPrototype = cardsForPrototype.GetCardsDeck(1, 2);
							break;
						case CardColor.Yellow:
							_cardsForPrototype = cardsForPrototype.GetCardsDeck(1, 3);
							break;
						case CardColor.Black:
							break;
					}
					break;
				case 3:
					switch (_color)
					{
						case CardColor.Red:
							_cardsForPrototype = cardsForPrototype.GetCardsDeck(2, 0);
							break;
						case CardColor.Green:
							_cardsForPrototype = cardsForPrototype.GetCardsDeck(2, 1);
							break;
						case CardColor.Blue:
							_cardsForPrototype = cardsForPrototype.GetCardsDeck(2, 2);
							break;
						case CardColor.Yellow:
							_cardsForPrototype = cardsForPrototype.GetCardsDeck(2, 3);
							break;
						case CardColor.Black:
							break;
					}
					break;
				case 4:
					switch (_color)
					{
						case CardColor.Red:
							_cardsForPrototype = cardsForPrototype.GetCardsDeck(3, 0);
							break;
						case CardColor.Green:
							_cardsForPrototype = cardsForPrototype.GetCardsDeck(3, 1);
							break;
						case CardColor.Blue:
							_cardsForPrototype = cardsForPrototype.GetCardsDeck(3, 2);
							break;
						case CardColor.Yellow:
							_cardsForPrototype = cardsForPrototype.GetCardsDeck(3, 3);
							break;
						case CardColor.Black:
							break;
					}
					break;
				case 5:
					switch (_color)
					{
						case CardColor.Red:
							_cardsForPrototype = cardsForPrototype.GetCardsDeck(4, 0);
							break;
						case CardColor.Green:
							_cardsForPrototype = cardsForPrototype.GetCardsDeck(4, 1);
							break;
						case CardColor.Blue:
							_cardsForPrototype = cardsForPrototype.GetCardsDeck(4, 2);
							break;
						case CardColor.Yellow:
							_cardsForPrototype = cardsForPrototype.GetCardsDeck(4, 3);
							break;
						case CardColor.Black:
							break;
					}
					break;
			}
			
		}

		/*private void OnValidate()
		{
			switch (gameObject.name)
			{
				case "RedDeck":
					if (_cards.Count <= _requaredCount)
					{
						foreach (Card card in _cards)
						{
							card.SetColor(CardColor.Red);
						}
					}
					else
					{
						for (int i = 0; i < _requaredCount; i++)
						{
							_cards[i].SetColor(CardColor.Red);
							if (_cards[i].GetPoint() < 0)
								_cards[i].SetPointMinus();
						}
						for (int i = _requaredCount; i < _cards.Count; i++)
						{
							_cards[i].SetColor(CardColor.Black);
							if (_cards[i].GetPoint() > 0)
								_cards[i].SetPointMinus();
						}
					}
					break;
				case "GreenDeck":
					if (_cards.Count <= _requaredCount)
					{
						foreach (Card card in _cards)
						{
							card.SetColor(CardColor.Green);
						}
					}
					else
					{
						for (int i = 0; i < _requaredCount; i++)
						{
							_cards[i].SetColor(CardColor.Green);
							if (_cards[i].GetPoint() < 0)
								_cards[i].SetPointMinus();
						}
						for (int i = _requaredCount; i < _cards.Count; i++)
						{
							_cards[i].SetColor(CardColor.Black);
							if (_cards[i].GetPoint() > 0)
								_cards[i].SetPointMinus();
						}
					}
					break;
				case "BlueDeck":
					if (_cards.Count <= _requaredCount)
					{
						foreach (Card card in _cards)
						{
							card.SetColor(CardColor.Blue);
						}
					}
					else
					{
						for (int i = 0; i < _requaredCount; i++)
						{
							_cards[i].SetColor(CardColor.Blue);
							if (_cards[i].GetPoint() < 0)
								_cards[i].SetPointMinus();
						}
						for (int i = _requaredCount; i < _cards.Count; i++)
						{
							_cards[i].SetColor(CardColor.Black);
							if (_cards[i].GetPoint() > 0)
								_cards[i].SetPointMinus();
						}
					}
					break;
				case "YellowDeck":
					if (_cards.Count <= _requaredCount)
					{
						foreach (Card card in _cards)
						{
							card.SetColor(CardColor.Yellow);
						}
					}
					else
					{
						for (int i = 0; i < _requaredCount; i++)
						{
							_cards[i].SetColor(CardColor.Yellow);
							if (_cards[i].GetPoint() < 0)
								_cards[i].SetPointMinus();
						}
						for (int i = _requaredCount; i < _cards.Count; i++)
						{
							_cards[i].SetColor(CardColor.Black);
							if (_cards[i].GetPoint() > 0)
								_cards[i].SetPointMinus();
						}
					}
					break;
			}
		}*/

		public Card GetCard(int index)
		{
			return _cardsForPrototype[index];
		}

		public int CountCardsInList()
		{
			return _cardsForPrototype.Count;
		}
	}
}