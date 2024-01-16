using Game_Logic.CardLogic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game_Logic.Client;

namespace Game_Logic.Table
{
    public class TablePositions : MonoBehaviour
    {
        [SerializeField] private List<Transform> _positions;
        [SerializeField] private List<GameObject> _cards;
        [SerializeField] private GameObject _clientele;

        private float _width = 1080f;

        private int _indexFreePosition;
        private int _lastIndexOfInsertedCard;
        public List<Transform> GetPositions() => _positions;

        public void Initialize()
        {
            MoveCardPositions();
        }

        public void MoveCardPositions() => SetXPositionsDependingCount();

		public Transform GetAndBlockFreeTransform()
        {
            _positions[_indexFreePosition].GetComponent<PositionData>().SetFreeStatus(false);
            return _positions[_indexFreePosition];
        }
        public bool IsThereFreePosition()
        {
            for (int i = 0; i < _positions.Count; i++)
            {
                if (_positions[i].GetComponent<PositionData>().GetFreeStatus())
                {
                    _indexFreePosition = i;
                    return true;
                }
            }
            return false;
        }
        public int CurrentListCount()
        {
            return _cards.Count;
        }

        public void AddCardInList(GameObject card, float xPosition)
        {
			_lastIndexOfInsertedCard = SortListWithNewCard(xPosition);

			if (_cards.Count < 1)
            {
                _cards.Add(card);
            }
            else
            {
                //_lastIndexOfInsertedCard = SortListWithNewCard(xPosition);
                _cards.Insert(_lastIndexOfInsertedCard, card);
            }
        }
        public int SortListWithNewCard(float xPosition)
        {
            int index = 0;
            for (int i = 0; i < _indexFreePosition + 1; i++)
            {
                if (xPosition < _positions[i].GetComponent<PositionData>().GetXPosition())
                {
                    index = i;
                    break;
                }
                else if (i == _indexFreePosition)
                {
                    index = i;
                    break;
                }
            }
            return index;
        }
        public void SetNewParentTransform(GameObject card)
        {
            if (_cards.Count <= 1)
            {
                card.transform.parent = GetAndBlockFreeTransform();
                card.transform.position = GetAndBlockFreeTransform().position;
            }
            else
            {
                for (int i = _cards.Count - 1; i >= 0; i--)
                {
                    if (i == _cards.Count - 1)
                    {
                        _cards[i].transform.parent = GetAndBlockFreeTransform();
                        _cards[i].transform.position = GetAndBlockFreeTransform().position;
                    }
                    else
                    {
                        _cards[i].transform.parent = _positions[i];
                        _cards[i].transform.position = _positions[i].position;
                    }
                }
            }
        }
        public void UpdatePositionData()
        {
            for (int i = 0; i < _positions.Count; i++)
            {
                if (!_positions[i].GetComponent<PositionData>().GetFreeStatus())
                {
                    CardInformation card = _positions[i].transform.GetChild(0).GetComponent<CardInformation>();

                    _positions[i].GetComponent<PositionData>().SetCardColor(card.GetCardColor());
                    _positions[i].GetComponent<PositionData>().SetBonusType(card.GetBonusType());
                    _positions[i].GetComponent<PositionData>().SetBonusColor(card.GetBonusColor());
                }
            }
        }
        public void ClearCardsInList()
        {
            for (int i = 0; i < _cards.Count; i++)
            {
                Destroy(_cards[i]);
                _positions[i].GetComponent<PositionData>().SetFreeStatus(true);
            }
            StartCoroutine(DelayClear());
        }
        public void CheckForAccrual(GameObject card)
        {
            int indexLastCard = _lastIndexOfInsertedCard;

            //Передача очков с карты в Points (Работает корректно)
            card.GetComponent<CardInformation>().SetPoints(card.GetComponent<CardInformation>().GetPoints());
            card.GetComponent<UpdateVisualCardInformation>().UpdatePointsInformation();
            FindObjectOfType<TableLogic>().ModifyPoint(card.GetComponent<CardInformation>().GetPoints());

			// Проверка на соответствие бонусному цвету клиента (Работает корректно)
			card.GetComponent<BonusCardAccrual>().ChekingClientBonus(card, _clientele.GetComponent<CurrentClient>().GetAdded());

            if (_cards.Count < 2)
            {
                if (_positions[indexLastCard].GetComponent<PositionData>().GetBonusType() == CardBonusType.Center)
                {
					card.GetComponent<BonusCardAccrual>().CheckingAndAccrualYourself(_cards, indexLastCard);
				}
            }
            else
            {
                CheckBonusYourselft(card, indexLastCard);
                CheckBonusOnNeughbourCard(card, indexLastCard);
                CheckBonusOnCenterType(indexLastCard);             
            }

        }

        private void CheckBonusYourselft(GameObject card, int indexLastCard)
        {
			switch (_positions[indexLastCard].GetComponent<PositionData>().GetBonusType())
			{
				case CardBonusType.Left:
					if (indexLastCard != 0)
					{
						card.GetComponent<BonusCardAccrual>().CheckingAndAccrualYourself(card, _cards[indexLastCard - 1]);
					}
					break;
				case CardBonusType.Right:
					if (indexLastCard != _cards.Count - 1)
					{
						card.GetComponent<BonusCardAccrual>().CheckingAndAccrualYourself(card, _cards[indexLastCard + 1]);
					}
					break;
				case CardBonusType.Center:
					card.GetComponent<BonusCardAccrual>().CheckingAndAccrualYourself(_cards, indexLastCard);
					break;
				case CardBonusType.LeftAndRight:
					break;
				case CardBonusType.Empty:
					break;
			}
		}

        private void CheckBonusOnNeughbourCard(GameObject card, int indexLastCard)
        {
			if (indexLastCard == 0)
			{
                _cards[indexLastCard + 1].GetComponent<BonusCardAccrual>().CheckingBonusOnNeighbourCard(card, _cards[indexLastCard + 1], indexLastCard, indexLastCard + 1);
                _cards[indexLastCard + 1].GetComponent<UpdateVisualCardInformation>().UpdateCardInformation();
			}
			else if (indexLastCard == _cards.Count - 1)
			{
				_cards[indexLastCard - 1].GetComponent<BonusCardAccrual>().CheckingBonusOnNeighbourCard(card, _cards[indexLastCard - 1], indexLastCard, indexLastCard - 1);
			}
			else
			{
				_cards[indexLastCard + 1].GetComponent<BonusCardAccrual>().CheckingBonusOnNeighbourCard(card, _cards[indexLastCard + 1], indexLastCard, indexLastCard + 1);
				_cards[indexLastCard - 1].GetComponent<BonusCardAccrual>().CheckingBonusOnNeighbourCard(card, _cards[indexLastCard - 1], indexLastCard, indexLastCard - 1);
			}
		}

        private void CheckBonusOnCenterType(int indexLastCard)
        {
			for (int i = 0; i < _cards.Count; i++)
			{
				if (i != indexLastCard && _cards[i].GetComponent<CardInformation>().GetBonusType() == CardBonusType.Center)
				{
					_cards[i].GetComponent<BonusCardAccrual>().CheckingCenterBonusOnCard(_cards[indexLastCard], _cards[i]);
				}
			}
		}

        private IEnumerator DelayClear()
        {
            yield return new WaitForSeconds(0.3f);
            _cards.Clear();
        }

        private int CountUnFreePositions()
        {
            int count = 0;
            for (int i = 0; i < _positions.Count; i++)
            {
                if (!_positions[i].GetComponent<PositionData>().GetFreeStatus())
                {
                    count++;
                }
            }
            return count;
        }
        private void SetXPositionsDependingCount()
        {
            int count = CountUnFreePositions();
            switch (count)
            {
                case 0:
                    for (int i = count; i < _positions.Count; i++)
                    {
                        _positions[i].localPosition = new Vector2(0f, _positions[i].localPosition.y);
                        _positions[i].GetComponent<PositionData>().SetXPosition(0f + _width/2);
                    }
                    break;
				case 1:
					_positions[0].localPosition = new Vector2(0f, _positions[0].localPosition.y);
					_positions[0].GetComponent<PositionData>().SetXPosition(0f + _width / 2);
					for (int i = count; i < _positions.Count; i++)
                    {
						_positions[i].localPosition = new Vector2(0f, _positions[i].localPosition.y);
						_positions[i].GetComponent<PositionData>().SetXPosition(0f + _width / 2);
					}
					break;
                case 2:
					_positions[0].localPosition = new Vector2(-145f, _positions[0].localPosition.y);
                    _positions[1].localPosition = new Vector2(145f, _positions[1].localPosition.y);

					_positions[0].GetComponent<PositionData>().SetXPosition(-145f + _width / 2);
					_positions[1].GetComponent<PositionData>().SetXPosition(145f + _width / 2);
					for (int i = count; i < _positions.Count; i++)
                    {
						_positions[i].localPosition = new Vector2(0f, _positions[i].localPosition.y);
						_positions[i].GetComponent<PositionData>().SetXPosition(0f + _width / 2);
					}
					break;
                case 3:
					_positions[0].localPosition = new Vector2(-260f, _positions[0].localPosition.y);
                    _positions[1].localPosition = new Vector2(0f, _positions[1].localPosition.y);
                    _positions[2].localPosition = new Vector2(260f, _positions[2].localPosition.y);
                    _positions[3].localPosition = new Vector2(0f, _positions[3].localPosition.y);

					_positions[0].GetComponent<PositionData>().SetXPosition(-260f + _width / 2);
					_positions[1].GetComponent<PositionData>().SetXPosition(0f + _width / 2);
					_positions[2].GetComponent<PositionData>().SetXPosition(260f + _width / 2);
					_positions[3].GetComponent<PositionData>().SetXPosition(0f + _width / 2);
					break;
                case 4:
					_positions[0].localPosition = new Vector2(-375f, _positions[0].localPosition.y);
					_positions[1].localPosition = new Vector2(-125f, _positions[1].localPosition.y);
					_positions[2].localPosition = new Vector2(125f, _positions[2].localPosition.y);
					_positions[3].localPosition = new Vector2(375f, _positions[3].localPosition.y);

					_positions[0].GetComponent<PositionData>().SetXPosition(-375f + _width / 2);
					_positions[1].GetComponent<PositionData>().SetXPosition(-125f + _width / 2);
					_positions[2].GetComponent<PositionData>().SetXPosition(125f + _width / 2);
					_positions[3].GetComponent<PositionData>().SetXPosition(375f + _width / 2);
					break;
			}
        }
    }
}