using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Card : MonoBehaviour
{
    public enum CardState
    {
        InDeck,
        OnTable,
        BeforeCreate
    }

    public enum CardBonus
    {
        Left,
        Right,
        Center
    }

    public enum CardColor
    {
        Red,
        Green,
        Blue,
        Yellow,
        Black
    }

    [SerializeField] private Image _image;
    [SerializeField] private int _point;
    [SerializeField] private CardState _state;
    [SerializeField] private CardBonus _bonus;
    [SerializeField] private CardColor _color;
    
    public void SetState(CardState state) => _state = state;
    public void SetBonus(CardBonus bonus) => _bonus = bonus;
    public void SetColor(CardColor color) => _color = color; 
}
