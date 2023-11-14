using Game_Logic.CardLogic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game_Logic.Table
{
    public class TablePositions : MonoBehaviour
    {
        [SerializeField] private List<Transform> _positions;
        [SerializeField] private List<GameObject> _cards;

        private float _width = 1080f;

        private int _indexFreePosition;
        public List<Transform> GetPositions() => _positions;

        public void Initialize()
        {
            SetXPositionsDependingCount();
        }

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
            if (_cards.Count < 1)
            {
                _cards.Add(card);
            }
            else
            {
                _cards.Insert(SortListWithNewCard(xPosition), card);
            }

            SetNewParentTransform(card);
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
        private void SetNewParentTransform(GameObject card)
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