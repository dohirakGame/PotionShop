using System.Collections.Generic;
using Game_Logic.CardLogic;
using Game_Logic.General;
using TMPro;
using UnityEngine;
using Game_Logic.Client;
using Game_Logic.Combinations;
using System.Collections;

namespace Game_Logic.Table
{
	public class TableLogic : MonoBehaviour
    {
        [SerializeField] private ElementsBufer _elementsBufer;
        [SerializeField] private GameObject _clientele;

        // Комбинации заполняются в Startе
        public List<CardCombinations> _combinations;
        public void ProcessTableLogic(Transform card, float xPosition)
        {
            PutReceivedCard(card, xPosition);

            // Ïåðåäåëàòü ïîòîì ïîä íåìíîãî äðóãóþ ëîãèêó èìåííî CheckFullTable()
            if (CheckOnFullTable())
            {
                StartCoroutine(ClearTableEnd());
            }
        }

        private IEnumerator ClearTableEnd()
        {
            yield return new WaitForSeconds(1f);
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

            // Ïîòîì ïåðåäåëàòü, ÷òîáû âçÿòü ÷èñëî, à íå ÷åðåç òåêñò
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
                    // Тот метод который я создал
                    CheckCombinations();
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
                        _elementsBufer._textForTests.text = "ÒÛ ÏÐÎÈÃÐÀË, ÇÀÊÐÛÂÀÉ ÈÃÐÓ";
                    }
                }
                else
                {
                    _elementsBufer._textForTests.text = "ÒÛ ÏÐÎÈÃÐÀË, ÇÀÊÐÛÂÀÉ ÈÃÐÓ";
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

        private void CheckCombinations()
        {
            int rred = 0,ggreen = 0,bblue = 0,yyellow = 0,bblack = 0;
            foreach(Transform position in GetComponent<TablePositions>().GetPositions())
            {
                switch(position.gameObject.GetComponent<PositionData>().GetColor())
                {
                    case CardColor.Red:
                    rred++;
                    break;
                    case CardColor.Blue:
                    bblue++;
                    break;
                    case CardColor.Green:
                    ggreen++;
                    break;
                    case CardColor.Yellow:
                    yyellow++;
                    break;
                    case CardColor.Black:
                    bblack++;
                    break;
                }
            }
            CardCombinations tableCombination = new CardCombinations{red = rred, green = ggreen, blue = bblue, yellow = yyellow, black = bblack};
            foreach(CardCombinations combination in _combinations)
            {
                if(combination.red != 0 && tableCombination.red != combination.red)
                {
                    continue;
                }
                if(combination.blue != 0 && tableCombination.blue != combination.blue)
                {
                    continue;
                }
                if(combination.green != 0 && tableCombination.green != combination.green)
                {
                    continue;
                }
                if(combination.yellow != 0 && tableCombination.yellow != combination.yellow)
                {
                    continue;
                }
                if(combination.black != 0 && tableCombination.black != combination.black)
                {
                    continue;
                }
                ModifyPoint(combination.points);
            }
        }

        public void Start()
        {
            _combinations = new List<CardCombinations>{new CardCombinations{red = 2, points = 2},new CardCombinations{green = 2, points = 2}};
        }
    }
}