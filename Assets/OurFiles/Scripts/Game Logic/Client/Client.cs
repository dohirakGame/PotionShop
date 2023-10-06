using UnityEngine;

[System.Serializable]
public class Client
{
    public enum MainReq
    {
        Red,
        Green,
        Blue,
        Yellow,
        Black
    }

    public enum AddReq
    {
        Red,
        Green,
        Blue,
        Yellow,
        Black
    }

    [SerializeField] private MainReq _mainReq;
    [SerializeField] private AddReq _addReq;
}