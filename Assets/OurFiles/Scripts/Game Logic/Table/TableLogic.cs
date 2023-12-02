using Game_Logic.CardLogic;
using Game_Logic.General;
using TMPro;
using UnityEngine;
using Game_Logic.Client;
using System.Collections;

namespace Game_Logic.Table
{
	public class TableLogic : MonoBehaviour
    {
        [SerializeField] private ElementsBufer _elementsBufer;
        [SerializeField] private GameObject _clientele;

        public void ProcessTableLogic(Transform card, float xPosition)
        {
            PutReceivedCard(card, xPosition);

            // ���������� ����� ��� ������� ������ ������ ������ CheckFullTable()
            if (CheckOnFullTable())
            {
                StartCoroutine(ClearTableEnd());
            }
        }

        private IEnumerator ClearTableEnd()
        {
            yield return new WaitForSeconds(3f);
            ClearTable();
        } 
        private void PutReceivedCard(Transform card, float xPosition)
        {
            TablePositions tablePos = GetComponent<TablePositions>();

            if (tablePos.IsThereFreePosition())
            {
                // ++
                tablePos.AddCardInList(card.gameObject, xPosition);
				tablePos.SetNewParentTransform(card.gameObject);
				tablePos.MoveCardPositions();
                tablePos.UpdatePositionData();

                tablePos.CheckForAccrual(card.gameObject);

            }

            // ����� ����������, ����� ����� �����, � �� ����� �����
            //ModifyPoint(int.Parse(card.GetChild(2).transform.GetChild(0).GetComponent<TextMeshProUGUI>().text));
            //ModifyPoint(card.GetComponent<CardInformation>().GetPoints());
        }

        private bool CheckOnFullTable()
        {
            if (!GetComponent<TablePositions>().IsThereFreePosition())
            {
                CardColor MainReq = _clientele.GetComponent<CurrentClient>().GetMain();
                bool found = false;
                foreach(Transform position in GetComponent<TablePositions>().GetPositions())
                {
                    if(position.gameObject.GetComponent<PositionData>().GetColor() == MainReq)
                    {
                        found = true;
                    }
                }
                if(found)
                {
                    if (_elementsBufer.GetPointsController().GetPoints() > 0)
                    {
                        _clientele.GetComponent<CurrentClient>().NextClient();
                        _elementsBufer.GetScoresController().ScoresModify(_elementsBufer.GetPointsController().GetPoints());
                        _elementsBufer.GetScoresController().UpdateScoresText();
                        _elementsBufer.GetPointsController().ResetPoints();
                        _elementsBufer.GetPointsController().UpdatePointsText();
					}
                    else
                    {
                        _elementsBufer._textForTests.text = "�� ��������, �������� ����";
                    }
                }
                else
                {
                    _elementsBufer._textForTests.text = "�� ��������, �������� ����";
                }
                return true;
            }
            return false;
        }

        public void ModifyPoint(int value)
        {
            _elementsBufer.GetPointsController().ModifyPoints(value);
            _elementsBufer.GetPointsController().UpdatePointsText();
        }

        private void ClearTable()
        {
            GetComponent<TablePositions>().ClearCardsInList();
        }
    }
}