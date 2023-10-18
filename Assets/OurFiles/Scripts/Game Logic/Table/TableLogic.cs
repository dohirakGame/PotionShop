using Game_Logic.CardLogic;
using Game_Logic.General;
using TMPro;
using UnityEngine;

namespace Game_Logic.Table
{
	public class TableLogic : MonoBehaviour
    {
        [SerializeField] private ElementsBufer _elementsBufer;

        public void ProcessTableLogic(Transform card)
        {
            PutReceivedCard(card);
            // Переделать потом под немного другую логику именно CheckFullTable()
            if (CheckOnFullTable())
            {
                ClearTable();
            }
        }
        private void PutReceivedCard(Transform card)
        {
            if (GetComponent<TablePositions>().IsThereFreePosition())
            {
                Transform newTransform = GetComponent<TablePositions>().GetFreePosition();

                card.transform.parent = newTransform;
                card.transform.position = newTransform.position;

                newTransform.GetComponent<PositionData>().SetCardColor(card.GetComponent<CardInformation>().GetCardColor());
                newTransform.GetComponent<PositionData>().SetBonusType(card.GetComponent<CardInformation>().GetBonusType());
                newTransform.GetComponent<PositionData>().SetBonusColor(card.GetComponent<CardInformation>().GetBonusColor());

                GetComponent<TablePositions>().AddCardInList(card.gameObject);
            }

            // Потом переделать, чтобы взять число, а не через текст
            ModifyPoint(int.Parse(card.GetChild(1).transform.GetChild(0).GetComponent<TextMeshProUGUI>().text));
        }

        private bool CheckOnFullTable()
        {
            if (!GetComponent<TablePositions>().IsThereFreePosition())
            {
                if (_elementsBufer.GetPointsController().GetPoints() >= 0)
                {
                    _elementsBufer.GetScoresController().ScoresModify(_elementsBufer.GetPointsController().GetPoints());
                    _elementsBufer.GetScoresController().UpdateScoresText();
                    _elementsBufer.GetPointsController().ResetPoints();
                    _elementsBufer.GetPointsController().UpdatePointsText();
                }
                else
                {
                    _elementsBufer._textForTests.text = "ТЫ ПРОИГРАЛ, ЗАКРЫВАЙ ИГРУ";
                }
                return true;
            }
            return false;
        }

        private void ModifyPoint(int value)
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