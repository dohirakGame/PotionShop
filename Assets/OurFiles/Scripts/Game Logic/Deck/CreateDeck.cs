using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CreateDeck : MonoBehaviour
{
	[SerializeField] private List<Card> _cards;
	[SerializeField] private int _requaredCount;

	private void OnValidate()
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
					}
					for (int i = _requaredCount; i < _cards.Count; i++)
					{
						_cards[i].SetColor(CardColor.Black);
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
					}
					for (int i = _requaredCount; i < _cards.Count; i++)
					{
						_cards[i].SetColor(CardColor.Black);
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
					}
					for (int i = _requaredCount; i < _cards.Count; i++)
					{
						_cards[i].SetColor(CardColor.Black);
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
					}
					for (int i = _requaredCount; i < _cards.Count; i++)
					{
						_cards[i].SetColor(CardColor.Black);
					}
				}
				break;
		}
	}

	public Card GetCard(int index)
    {
        return _cards[index];
    }

    public int CountCardsInList()
    {
        return _cards.Count;
    }
}
