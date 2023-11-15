using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game_Logic.CardLogic
{
	public class BonusCardAccrual : MonoBehaviour
	{
		// Соседние карты работают!
		public void CheckingAndAccrualYourself(List<GameObject> cards, int indexLastCard)
		{
			CardInformation mainInformation = cards[indexLastCard].GetComponent<CardInformation>();
			for (int i = 0; i < cards.Count; i++)
			{
				CardInformation checkedCardInformation = cards[i].GetComponent<CardInformation>();
				if (mainInformation.GetBonusColor().ToString() == checkedCardInformation.GetCardColor().ToString())
				{
					mainInformation.SetPoints(mainInformation.GetPoints() + 1);
				}
			}
			cards[indexLastCard].GetComponent<UpdateVisualCardInformation>().UpdatePointsInformation();
		}
		public void CheckingAndAccrualYourself(GameObject mainCard, GameObject neighbouringCard)
		{
			CardInformation mainInformation = mainCard.GetComponent<CardInformation>();
			CardInformation neighbourInformation = neighbouringCard.GetComponent<CardInformation>();

			if (mainInformation.GetBonusColor().ToString() == neighbourInformation.GetCardColor().ToString())
			{
				mainInformation.SetPoints(mainInformation.GetPoints() + 1);
			}

			mainCard.GetComponent<UpdateVisualCardInformation>().UpdatePointsInformation();

			//mainCard.GetComponent<UpdateVisualCardInformation>().UpdateCardInformation();
			/*if (bonusType == CardBonusType.Left)
			{
				CardInformation mainInformation = mainCard.GetComponent<CardInformation>();
				CardInformation neighbourInformation = neighbouringCard.GetComponent<CardInformation>();
				if (mainInformation.GetBonusColor().ToString() == neighbourInformation.GetCardColor().ToString())
				{
					mainInformation.SetPoints(mainInformation.GetPoints() + 1);
				}
			}
			else if (bonusType == CardBonusType.Right)
			{
				CardInformation mainInformation = mainCard.GetComponent<CardInformation>();
				CardInformation neighbourInformation = neighbouringCard.GetComponent<CardInformation>();
				if (mainInformation.GetBonusColor().ToString() == neighbourInformation.GetCardColor().ToString())
				{
					mainInformation.SetPoints(mainInformation.GetPoints() + 1);
				}
			}*/
		}

		public void CheckingBonusOnNeighbourCard(GameObject mainCard, GameObject neighbourCard)
		{
			CardInformation neighbourInformation = neighbourCard.GetComponent<CardInformation>();
			CardInformation mainInformation = mainCard.GetComponent<CardInformation>();

			if (neighbourInformation.GetBonusColor().ToString() == mainInformation.GetCardColor().ToString())
			{
				neighbourInformation.SetPoints(neighbourInformation.GetPoints() + 1);
			}

			neighbourInformation.GetComponent<UpdateVisualCardInformation>().UpdatePointsInformation();
		}

		public void CheckingCenterBonusOnCard(GameObject mainCard, GameObject verifiedCard)
		{
			CardInformation verifiedInformation = verifiedCard.GetComponent<CardInformation>();
			CardInformation mainInformation = mainCard.GetComponent<CardInformation>();

			if (verifiedInformation.GetBonusColor().ToString() ==  mainInformation.GetCardColor().ToString())
			{
				verifiedInformation.SetPoints(verifiedInformation.GetPoints() + 1);
			}
			
			verifiedInformation.GetComponent<UpdateVisualCardInformation>().UpdatePointsInformation();
		}
	}
}