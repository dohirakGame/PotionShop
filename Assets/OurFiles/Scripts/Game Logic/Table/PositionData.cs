using Game_Logic.CardLogic;
using UnityEngine;

namespace Game_Logic.Table
{
    public class PositionData : MonoBehaviour
    {
        [SerializeField] private bool _isFree;
        [SerializeField] private float _xPosition;
        [SerializeField] private CardColor _cardColor;
        [SerializeField] private CardBonusType _cardBonusType;
        [SerializeField] private BonusColor _cardBonusColor;

        public void Initialize()
        {
            SetFreeStatus(true);
        }
        public bool GetFreeStatus() => _isFree;
        public float GetXPosition() => _xPosition;
        public CardColor GetColor() => _cardColor;
        public CardBonusType GetBonusType() => _cardBonusType;
        public BonusColor GetBonusColor() => _cardBonusColor;

        public void SetFreeStatus(bool status) => _isFree = status;
        public void SetXPosition(float xPos) => _xPosition = xPos;
        public void SetCardColor(CardColor color) => _cardColor = color;
        public void SetBonusType(CardBonusType bonusType) => _cardBonusType = bonusType;
        public void SetBonusColor(BonusColor bonusColor) => _cardBonusColor = bonusColor;
    }
}