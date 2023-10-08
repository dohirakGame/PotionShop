using UnityEngine;

public enum Req
{
    Red,
    Green,
    Blue,
    Yellow,
    Black
}

[System.Serializable]
public class Client
{


    [SerializeField] private Req _mainReq;
    [SerializeField] private Req _addReq;

    public Req GetMain() => _mainReq;
    public Req GetAdd() => _addReq;
}