using System.Collections.Generic;
using UnityEngine;

namespace Game_Logic.CardLogic
{
	public class RandomBonusOnCard
    {
        public List<Card> SetBonus(List<Card> cards)
        {
			for (int i = 0; i < cards.Count; i++)
			{
				SetBonusColor(cards[i], ThereIsBonus());
			}
            return cards;
        }


		private void SetBonusColor(Card card, bool thereIsBonus)
		{
			if (thereIsBonus)
			{
				CardBonusType cardBonusType = PutTypeBonus();
				card.SetBonus(cardBonusType);
				if (cardBonusType == CardBonusType.LeftAndRight)
				{
					card.SetBonusColor(SelectBonusColor());
					card.SetSecondBonusColor(SelectSecondBonusColor());
				}
				else
				{
					card.SetBonusColor(SelectBonusColor());
				}
			}
			else
			{
				card.SetBonus(CardBonusType.Empty);
			}
		}
		private bool ThereIsBonus()
		{
			int rand = Random.Range(1, 6);
			if (rand < 4) return true;
			return false;
		}

		private CardBonusType PutTypeBonus()
		{
			int rand = Random.Range(1, 101);
			if (rand <= 35)
			{
				return CardBonusType.Left;
			}
			if (rand > 35 && rand <= 70)
			{
				return CardBonusType.Right;
			}
			if (rand > 70 && rand <= 90)
			{
				return CardBonusType.LeftAndRight;
			}
			else
			{
				return CardBonusType.Center;
			}
		}
		
		private BonusColor SelectBonusColor()
		{
			int rand = Random.Range(1, 6);

			switch (rand)
			{
				case 1: return BonusColor.Red;
				case 2: return BonusColor.Green;
				case 3: return BonusColor.Blue;
				case 4: return BonusColor.Yellow;
				case 5: return BonusColor.Black;
				default: return BonusColor.Red;
			}
		}

		private SecondBonusColor SelectSecondBonusColor()
		{
			int rand = Random.Range(1, 6);

			switch (rand)
			{
				case 1: return SecondBonusColor.Red;
				case 2: return SecondBonusColor.Green;
				case 3: return SecondBonusColor.Blue;
				case 4: return SecondBonusColor.Yellow;
				case 5: return SecondBonusColor.Black;
				default: return SecondBonusColor.Red;
			}
		}
	}
}
