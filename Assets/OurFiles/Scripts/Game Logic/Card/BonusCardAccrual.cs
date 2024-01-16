using Game_Logic.Table;
using System.Collections.Generic;
using UnityEngine;

namespace Game_Logic.CardLogic
{
	public class BonusCardAccrual : MonoBehaviour
	{
		private TableLogic _tableLogic;

		private void Start()
		{
			_tableLogic = FindObjectOfType<TableLogic>();
		}

		public void CheckingAndAccrualYourself(List<GameObject> cards, int indexLastCard)
		{
			CardInformation mainInformation = cards[indexLastCard].GetComponent<CardInformation>();
			for (int i = 0; i < cards.Count; i++)
			{
				CardInformation checkedCardInformation = cards[i].GetComponent<CardInformation>();
				if (mainInformation.GetBonusColor().ToString() == checkedCardInformation.GetCardColor().ToString())
				{
					int oldPoints = mainInformation.GetPoints();
					mainInformation.SetPoints(mainInformation.GetPoints() + 1);
					int newPoints = mainInformation.GetPoints();
					_tableLogic.ModifyPoint(newPoints - oldPoints);
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
				int oldPoints = mainInformation.GetPoints();
				mainInformation.SetPoints(mainInformation.GetPoints() + 1);
				int newPoints = mainInformation.GetPoints();
				_tableLogic.ModifyPoint(newPoints - oldPoints);
			}
			mainCard.GetComponent<UpdateVisualCardInformation>().UpdatePointsInformation();
		}

		public void CheckingBonusOnNeighbourCard(GameObject mainCard, GameObject neighbourCard, int mainIndex, int neighbourIndex)
		{
			CardInformation neighbourInformation = neighbourCard.GetComponent<CardInformation>();
			CardInformation mainInformation = mainCard.GetComponent<CardInformation>();
			
			if (neighbourIndex > mainIndex && (neighbourInformation.GetBonusType() == CardBonusType.Left))
			{
				if (neighbourInformation.GetBonusColor().ToString() == mainInformation.GetCardColor().ToString())
				{
					int oldPoints = neighbourInformation.GetPoints();
					neighbourInformation.SetPoints(neighbourInformation.GetPoints() + 1);
					int newPoints = neighbourInformation.GetPoints();
					_tableLogic.ModifyPoint(newPoints - oldPoints);
				}
			}
			
			if (neighbourIndex < mainIndex && (neighbourInformation.GetBonusType() == CardBonusType.Right))
			{
				if (neighbourInformation.GetBonusColor().ToString() == mainInformation.GetCardColor().ToString())
				{
					int oldPoints = neighbourInformation.GetPoints();
					neighbourInformation.SetPoints(neighbourInformation.GetPoints() + 1);
					int newPoints = neighbourInformation.GetPoints();
					_tableLogic.ModifyPoint(newPoints - oldPoints);
				}
			}
			neighbourInformation.GetComponent<UpdateVisualCardInformation>().UpdatePointsInformation();
		}

		public void CheckingCenterBonusOnCard(GameObject mainCard, GameObject verifiedCard)
		{
			CardInformation verifiedInformation = verifiedCard.GetComponent<CardInformation>();
			CardInformation mainInformation = mainCard.GetComponent<CardInformation>();

			if (verifiedInformation.GetBonusColor().ToString() ==  mainInformation.GetCardColor().ToString())
			{
				int oldPoints = verifiedInformation.GetPoints();
				verifiedInformation.SetPoints(verifiedInformation.GetPoints() + 1);
				int newPoints = verifiedInformation.GetPoints();
				_tableLogic.ModifyPoint(newPoints - oldPoints);
			}
			verifiedInformation.GetComponent<UpdateVisualCardInformation>().UpdatePointsInformation();
		}

		public void ChekingClientBonus(GameObject card, CardColor Client)
		{
			CardInformation cardInformation = card.GetComponent<CardInformation>();

			if (cardInformation.GetCardColor().ToString() == Client.ToString())
			{
				int oldPoints = cardInformation.GetPoints();
				cardInformation.SetPoints(cardInformation.GetPoints()+1);
				int newPoints = cardInformation.GetPoints();
				_tableLogic.ModifyPoint(newPoints - oldPoints);
			}
			cardInformation.GetComponent<UpdateVisualCardInformation>().UpdatePointsInformation();
		}
	}
}