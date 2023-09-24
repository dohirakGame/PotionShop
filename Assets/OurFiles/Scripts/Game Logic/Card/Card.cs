using UnityEngine;
using UnityEngine.UIElements;

[System.Serializable]
public class Card
{
    public enum CardState
    {
        InDeck,
        OnTable,
        BeforeCreate
    }

    /*public enum CardBonus
    {
        Left,
        Right,
        Center
    }

    public enum BonusColor
    {
        Red,
        Green,
        Blue,
        Yellow,
        Black
    }*/
/*
    public enum CardColor
    {
        Red,
        Green,
        Blue,
        Yellow,
        Black
    }*/

    [SerializeField] private Image _image;
    [SerializeField] private int _point;
    private CardState _state;
	//public CardColor _color;
	[SerializeField] private CardColor _color;
	[SerializeField] private CardBonus _bonus;
    [SerializeField] private BonusColor _bonusColor;
  
    public void SetState(CardState state) => _state = state;
    public void SetColor(CardColor color) => _color = color; 
    public void SetBonus(CardBonus bonus) => _bonus = bonus;
    public void SetBonusColor(BonusColor bonusColor) => _bonusColor = bonusColor;

    public CardColor GetColor() => _color;
    public CardBonus GetBonus() => _bonus;
    public BonusColor GetBonusColor() => _bonusColor;

    public int GetPoint() => _point;
}
